using System;
using System.Collections.Generic;
using Northwind.DAL.Entities;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Northwind.DAL.Mapping;

namespace Northwind.DAL
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DbProviderFactory _providerFactory;
        private readonly string _connectionString;
        private static readonly Mapper _mapper = new Mapper();

        public OrderRepository(string provider, string connectionString)
        {
            DbProviderFactories.RegisterFactory("System.Data.SqlClient", SqlClientFactory.Instance);

            _providerFactory = DbProviderFactories.GetFactory(provider
                               ?? throw new ArgumentNullException());
            _connectionString = connectionString
                                ?? throw new ArgumentNullException();
        }

        public IEnumerable<Order> GetOrders()
        {
            const string command = "select * from dbo.Orders";
            return GetRows(command, ReadOrders);
        }

        public Order GetOrderById(int id)
        {
            var command = $"select * from dbo.Orders where OrderId={id};"
                          + $"select * from [dbo].[Order Details] as o left join[dbo].[Products] as p on o.ProductID=p.ProductID where o.OrderId={id}";
            return GetRows(command, ReadOrderWithDetails);
        }

        private T GetRows<T>(string commandText, Func<IDataReader, T> readingMethod)
        {
            using var connection = _providerFactory.CreateConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = commandText;
            using var reader = command.ExecuteReader();

            return readingMethod(reader);
        }

        private static IEnumerable<Order> ReadOrders(IDataReader reader)
        {
            var orders = new List<Order>();
            while (reader.Read())
                orders.Add(_mapper.Map<Order>(reader));
            return orders;
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

    }
}
