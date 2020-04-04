// Copyright © Microsoft Corporation.  All Rights Reserved.
// This code released under the terms of the 
// Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)
//
//Copyright (C) Microsoft Corporation.  All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using SampleSupport;
using Task.Data;

// Version Mad01

namespace SampleQueries
{
    [Title("LINQ Module")]
    [Prefix("Linq")]
    public class LinqSamples : SampleHarness
    {

        private DataSource dataSource = new DataSource();

        [Category("Restriction Operators")]
        [Title("Where - Task 1")]
        [Description("This sample uses the where clause to find all elements of an array with a value less than 5.")]
        public void Linq1()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var lowNums =
                from num in numbers
                where num < 5
                select num;

            Console.WriteLine("Numbers < 5:");
            foreach (var x in lowNums)
            {
                Console.WriteLine(x);
            }
        }

        [Category("Restriction Operators")]
        [Title("Where - Task 2")]
        [Description("This sample return return all presented in market products")]

        public void Linq2()
        {
            var products =
                from p in dataSource.Products
                where p.UnitsInStock > 0
                select p;

            foreach (var p in products)
            {
                ObjectDumper.Write(p);
            }
        }

        [Category("Homework")]
        [Title("Task 1")]
        [Description("Выдайте список всех клиентов, чей суммарный оборот (сумма всех заказов) " +
        "превосходит некоторую величину X. Продемонстрируйте выполнение запроса с различными Х" +
        "(подумайте, можно ли обойтись без копирования запроса несколько раз.)")]
        public void Linq3()
        {
            IEnumerable<Customer> Customers(int x) =>
                dataSource.Customers.Where(q => q.Orders.Length > x);

            foreach (var x in new[] { 15, 10 })
            {
                ObjectDumper.Write($"Результат при X={x}");
                ObjectDumper.Write(Customers(x));
            }
        }

        [Category("Homework")]
        [Title("Task 2")]
        [Description("Для каждого клиента составьте список поставщиков, находящихся в той же" +
        "стране и том же городе. Сделайте задания с использованием группировки и без")]
        public void Linq4()
        {
            var res1 = dataSource.Customers.GroupJoin(dataSource.Suppliers,
                c => c.City,
                s => s.City,
                (customer, suppliers) => new { customer, suppliers });
            ObjectDumper.Write($"Результат с использованием группировки:");
            ObjectDumper.Write(res1, 1);

            var res2 = dataSource.Customers
                .Select(customer => new
                {
                    customer,
                    Suppliers = dataSource.Suppliers.Where(z =>
                        customer.City == z.City)
                });
            ObjectDumper.Write($"Результат без использования группировки:");
            ObjectDumper.Write(res2, 1);
        }

        [Category("Homework")]
        [Title("Task 3")]
        [Description("Найдите всех клиентов, у которых были заказы, превосходящие по сумме величину X")]
        public void Linq5()
        {
            IEnumerable<Customer> Customers(int x) =>
                dataSource.Customers.Where(c => c.Orders?
                    .Any(o => o?.Total > x) ?? false);

            foreach (var x in new[] { 10000, 11000 })
            {
                ObjectDumper.Write($"Результат при X={x}");
                ObjectDumper.Write(Customers(x));
            }
        }

        [Category("Homework")]
        [Title("Task 4")]
        [Description("Выдайте список клиентов с указанием, начиная с какого месяца какого " +
        "года они стали клиентами (принять за таковые месяц и год самого первого заказа)")]
        public void Linq6()
        {
            var res = dataSource.Customers.Select(x =>
            {
                var date = x.Orders?.Min(q => q?.OrderDate);
                return new
                {
                    date?.Year,
                    date?.Month,
                    x.CustomerID,
                    x.CompanyName,
                    x.Address,
                    x.Country,
                    x.City,
                    x.PostalCode,
                    x.Region,
                    x.Fax,
                    x.Phone,
                    x.Orders,
                };
            });

            ObjectDumper.Write(res);
        }

        [Category("Homework")]
        [Title("Task 5")]
        [Description("Сделайте предыдущее задание, но выдайте список отсортированным по году, " +
        "месяцу, оборотам клиента (от максимального к минимальному) и имени клиента")]
        public void Linq7()
        {
            var res = dataSource.Customers.Select(x =>
            {
                var date = x.Orders?.Min(q => q?.OrderDate);
                return new
                {
                    date?.Year,
                    date?.Month,
                    x.CustomerID,
                    x.CompanyName,
                    x.Address,
                    x.Country,
                    x.City,
                    x.PostalCode,
                    x.Region,
                    x.Fax,
                    x.Phone,
                    x.Orders,
                };
            })
            .OrderBy(x => x.Year)
            .ThenBy(x => x.Month)
            .ThenBy(x => x.Orders.Length)
            .ThenBy(x => x.CompanyName);

            ObjectDumper.Write(res);
        }

        [Category("Homework")]
        [Title("Task 6")]
        [Description("Укажите всех клиентов, у которых указан нецифровой почтовый код или не" +
        "заполнен регион или в телефоне не указан код оператора (для простоты считаем, что " +
        "это равнозначно «нет круглых скобочек в начале»")]
        public void Linq8()
        {
            var res = dataSource.Customers
                .Where(x => string.IsNullOrWhiteSpace(x.PostalCode)
                            || (x.PostalCode.Any(c => !char.IsDigit(c))
                            || string.IsNullOrWhiteSpace(x.Region)
                            || x.Phone.StartsWith("(")));

            ObjectDumper.Write(res);
        }

        [Category("Homework")]
        [Title("Task 7")]
        [Description("Сгруппируйте все продукты по категориям, внутри – по наличию на складе," +
        "внутри последней группы отсортируйте по стоимости")]
        public void Linq9()
        {
            var res = dataSource.Products
                .GroupBy(x => x.Category, (categoryKey, products)
                     => new
                     {
                         Category = categoryKey,
                         Product = products.GroupBy(x => x.UnitsInStock > 0)
                             .Select(f => new
                             {
                                 InStock = f.Key,
                                 Product = f.OrderBy(x => x.UnitPrice)
                             })
                     });

            ObjectDumper.Write(res, 2);
        }

        [Category("Homework")]
        [Title("Task 8")]
        [Description("Сгруппируйте товары по группам «дешевые», «средняя цена», «дорогие»." +
        "Границы каждой группы задайте сами")]
        public void Linq10()
        {
            var res = dataSource.Products
                .Select(x => new
                {
                    x.ProductID,
                    x.ProductName,
                    x.Category,
                    x.UnitsInStock,
                    x.UnitPrice,
                    PriceCategory = x.UnitPrice switch
                    {
                        var u when u < 200 => "cheap",
                        var u when u < 20000 => "average price",
                        _ => "expensive"
                    }
                })
                .GroupBy(x => x.PriceCategory);

            ObjectDumper.Write(res, 1);
        }

        [Category("Homework")]
        [Title("Task 9")]
        [Description("Рассчитайте среднюю прибыльность каждого города (среднюю сумму заказа" +
        "по всем клиентам из данного города) и среднюю интенсивность (среднее количество " +
        "заказов, приходящееся на клиента из каждого города")]
        public void Linq11()
        {
            var res = dataSource.Customers.GroupBy(x => x.City,
                (x, y) => new
                {
                    x,
                    AverageOrderAmount = y.SelectMany(o => o.Orders)
                        .Average(c => c.Total),
                    AverageNumberOfOrdersPerCustomer = y.Select(t => t.Orders.Count())
                });
            ObjectDumper.Write(res, 1);
        }

        [Category("Homework")]
        [Title("Task 10")]
        [Description("Сделайте среднегодовую статистику активности клиентов по месяцам " +
        "(без учета года), статистику по годам, по годам и месяцам (т.е. когда один " +
        "месяц в разные годы имеет своё значение)")]
        public void Linq12()
        {
            Func<int, IEnumerable<Order>, object> statistics = (m, o) => new
            {
                m,
                NumberOfOrders = o.Count(),
                MaxTotal = o.Max(b => b.Total),
            };

            var res = dataSource.Customers.Select(x => new
            {
                x,
                StatisticsByMonth = x.Orders.GroupBy(c => c.OrderDate.Month, statistics),
                StatisticsByYear = x.Orders.GroupBy(v => v.OrderDate.Year, statistics),
                StatisticsByYearAndMonth = x.Orders.GroupBy(v => v.OrderDate.Year, (y, orders) => new
                {
                    y,
                    StatisticsForMonthOfTheYear = orders.GroupBy(a => a.OrderDate.Month, statistics)
                })
            });

            ObjectDumper.Write(res, 2);
        }
    }
}
