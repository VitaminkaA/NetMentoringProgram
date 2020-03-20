using System;
using System.Collections.Generic;
using Northwind.DAL.Entities;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using Northwind.DAL.Exceptions;
using Northwind.DAL.Mapping;
using Northwind.DAL.Extensions;

namespace Northwind.DAL
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DbProviderFactory _providerFactory;
        private readonly string _connectionString;
        private static readonly IMapper _mapper = new Mapper();

        public OrderRepository(string provider, string connectionString)
        {
            DbProviderFactories.RegisterFactory("System.Data.SqlClient", SqlClientFactory.Instance);

            _providerFactory = DbProviderFactories.GetFactory(provider
                               ?? throw new ArgumentNullException());
            _connectionString = connectionString
                                ?? throw new ArgumentNullException();
        }

        public void AddOrder(Order order)
        {
            if (order == null)
                throw new ArgumentNullException();

            var columnsDict = GetOrdersDictionary(order);
            var commandText = "INSERT INTO [dbo].[Orders] " +
                              $"VALUES(@{string.Join(",@", columnsDict.Keys)})";

            ExecuteNonQuery(commandText, columnsDict);
        }

        public void SetInWorkStatus(int id)
        {
            var ord = GetOrderById(id);

            if (ord.Status != OrderStatus.New)
                throw new RepositoryException("Only in the order with the NewStatus can the status be changed to InWork.");

            ord.OrderDate = DateTime.Now;
            Update(ord);
        }

        public void SetCompletedStatus(int id)
        {
            var ord = GetOrderById(id);

            if (ord.Status != OrderStatus.InWork)
                throw new RepositoryException("Status can't be changed to CompletedStatus.");

            ord.ShippedDate = DateTime.Now;
            Update(ord);
        }

        public IEnumerable<CustOrderHist> CustOrderHist(string customerId)
        {
            var commandText = $"EXEC [dbo].[CustOrderHist] @CustomerID = '{customerId}';";
            return ExecuteReader(commandText, ReadOrders<CustOrderHist>);
        }

        public IEnumerable<CustOrdersDetail> CustOrderDetail(int orderId)
        {
            var commandText = $"EXEC [dbo].CustOrdersDetail @OrderId = '{orderId}';";
            return ExecuteReader(commandText, ReadOrders<CustOrdersDetail>);
        }

        public void UpdateOrder(Order order)
        {
            if (order == null)
                throw new ArgumentNullException();

            var ord = GetOrderById(order.OrderId);

            if (ord.Status != OrderStatus.New)
                throw new RepositoryException(RepositoryExceptionType.NoRightsToExecuteRequest,
                    "Only orders with New status can be changed");

            if (order.OrderDate != ord.OrderDate || order.ShippedDate != ord.ShippedDate)
                throw new RepositoryException(RepositoryExceptionType.NoRightsToExecuteRequest,
                    "Orders with statuses InWork and Completed cannot be changed");

            Update(order);
        }

        public void DeleteOrder(int id)
        {
            var ord = GetOrderById(id);

            if (ord.Status == OrderStatus.Completed)
                throw new RepositoryException(RepositoryExceptionType.NoRightsToExecuteRequest,
                    "Orders with Completed status cannot be deleted");

            var commandText = $"DELETE FROM dbo.Orders WHERE orderID={id}";
            ExecuteNonQuery(commandText);
        }


        public IEnumerable<Order> GetOrders()
        {
            const string command = "select * from dbo.Orders";
            return ExecuteReader(command, ReadOrders<Order>);
        }

        public Order GetOrderById(int id)
        {
            var command = $"select * from dbo.Orders where OrderId={id};"
                          + $"select * from [dbo].[Order Details] as o left join[dbo].[Products] as p on o.ProductID=p.ProductID where o.OrderId={id}";
            return ExecuteReader(command, ReadOrderWithDetails);
        }

        private void ExecuteNonQuery(string commandText, IDictionary<string, object> parameters = null)
        {
            using var connection = _providerFactory.CreateConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();
            using var command = connection.CreateCommand();

            if (parameters != null)
                command.Parameters.AddRange(parameters.Select(x
                    => command.CreateParameter(x.Key, x.Value)).ToArray());

            command.CommandText = commandText;
            command.ExecuteNonQuery();
        }

        private T ExecuteReader<T>(string commandText, Func<IDataReader, T> readingMethod)
        {
            using var connection = _providerFactory.CreateConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = commandText;
            using var reader = command.ExecuteReader();

            return reader.HasRows ? readingMethod(reader)
                : throw new RepositoryException(RepositoryExceptionType.NotFound);
        }

        private static IEnumerable<T> ReadOrders<T>(IDataReader reader)
        where T : new()
        {
            var items = new List<T>();
            while (reader.Read())
                items.Add(_mapper.Map<T>(reader));
            return items;
        }

        private static Order ReadOrderWithDetails(IDataReader reader)
        {
            reader.Read();
            var order = _mapper.Map<Order>(reader);
            reader.NextResult();

            while (reader.Read())
            {
                var det = _mapper.Map<OrderDetails>(reader);
                det.Product = _mapper.Map<Product>(reader);
                order.OrderDetails.Add(det);
            }
            return order;
        }

        private void Update(Order order)
        {
            var columnsDict = GetOrdersDictionary(order);
            var commandText = "UPDATE dbo.Orders " +
                              $"SET {string.Join(',', columnsDict.Keys.Select(key => key + "=@" + key))} " +
                              $"WHERE OrderID = {order.OrderId}";

            ExecuteNonQuery(commandText, columnsDict);
        }

        private static IDictionary<string, object> GetOrdersDictionary(Order order)
        {
            if (order == null)
                throw new ArgumentNullException();

            return new Dictionary<string, object>()
            {
                {nameof(order.CustomerID), order.CustomerID},
                {nameof(order.EmployeeID), order.EmployeeID},
                {nameof(order.OrderDate), order.OrderDate.HasValue
                    ? $"{order.OrderDate.Value:yyyy - MM - dd HH: mm:ss}"
                    : null},
                {nameof(order.RequiredDate), order.RequiredDate.HasValue
                    ? $"{order.RequiredDate.Value:yyyy - MM - dd HH: mm:ss}"
                    : null},
                {nameof(order.ShippedDate), order.ShippedDate.HasValue
                    ? $"{order.ShippedDate.Value:yyyy - MM - dd HH: mm:ss}"
                    : null},
                {nameof(order.ShipVia), order.ShipVia},
                {nameof(order.Freight), order.Freight},
                {nameof(order.ShipName), order.ShipName},
                {nameof(order.ShipAddress), order.ShipAddress},
                {nameof(order.ShipCity), order.ShipCity},
                {nameof(order.ShipRegion), order.ShipRegion},
                {nameof(order.ShipPostalCode), order.ShipPostalCode},
                {nameof(order.ShipCountry), order.ShipCountry}
            };
        }

    }
}
