﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HttpHandler.DAL.Context
{
    public sealed class NorthwindEFContext : DbContext
    {
        public NorthwindEFContext(DbContextOptions<NorthwindEFContext> options)
            : base(options) { }

        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerCustomerDemo> CustomerCustomerDemos { get; set; }
        public DbSet<CustomerDemographics> CustomersDemographics { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeTerritory> EmployeeTerritories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrdersDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Territory> Territories { get; set; }
    }
}