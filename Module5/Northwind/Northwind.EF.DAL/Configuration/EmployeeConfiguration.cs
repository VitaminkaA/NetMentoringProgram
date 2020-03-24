using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind.EF.DAL.Entities;

namespace Northwind.EF.DAL.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");
            builder.HasKey(e => e.EmployeeId);
            builder.HasIndex(e => e.LastName)
                .HasName("LastName");
            builder.HasIndex(e => e.PostalCode)
                .HasName("PostalCode");
            builder.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            builder.Property(e => e.Address).HasMaxLength(60);
            builder.Property(e => e.BirthDate).HasColumnType("datetime");
            builder.Property(e => e.City).HasMaxLength(15);
            builder.Property(e => e.Country).HasMaxLength(15);
            builder.Property(e => e.Extension).HasMaxLength(4);
            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(10);
            builder.Property(e => e.HireDate).HasColumnType("datetime");
            builder.Property(e => e.HomePhone).HasMaxLength(24);
            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(e => e.Notes).HasColumnType("ntext");
            builder.Property(e => e.PostalCode).HasMaxLength(10);
            builder.Property(e => e.Region).HasMaxLength(15);
            builder.Property(e => e.Title).HasMaxLength(30);
            builder.Property(e => e.TitleOfCourtesy).HasMaxLength(25);
            builder.HasOne(d => d.ReportsToNavigation)
                .WithMany(p => p.InverseReportsToNavigation)
                .HasForeignKey(d => d.ReportsTo)
                .HasConstraintName("FK_Employees_Employees");

            builder.HasData(EmployeesData);
        }

        private static Employee[] EmployeesData
            => new[]
            {
                new Employee
                {
                    EmployeeId = 1,
                    LastName = "Davolio",
                    FirstName = "Nancy",
                    Title = "Sales Representative",
                    TitleOfCourtesy = "Ms.",
                    Address = "507 - 20th Ave. E.Apt. 2A",
                    City = "Seattle",
                    Region = "WA",
                    PostalCode = "98122",
                    Country = "USA",
                    HomePhone = "(206) 555-9857",
                    Extension = "5467",
                    Notes = "Education includes a BA in psychology from Colorado State University in 1970.  She also completed The Art of the Cold Call.  Nancy is a member of Toastmasters International.",
                    ReportsTo = 2,
                },
                new Employee
                {
                    EmployeeId = 2,
                    LastName = "Fuller",
                    FirstName = "Andrew",
                    Title = "Vice President, Sales",
                    TitleOfCourtesy = "Dr.",
                    Address = "908 W. Capital Way",
                    City = "Tacoma",
                    Region = "WA",
                    PostalCode = "98401",
                    Country = "USA",
                    HomePhone = "(206) 555-9482",
                    Extension = "3457",
                    Notes = "Andrew received his BTS commercial in 1974 and a Ph.D. in international marketing from the University of Dallas in 1981.  He is fluent in French and Italian and reads German.  He joined the company as a sales representative, was promoted to sales manager in January 1992 and to vice president of sales in March 1993.  Andrew is a member of the Sales Management Roundtable, the Seattle Chamber of Commerce, and the Pacific Rim Importers Association.",
                },
                new Employee
                {
                    EmployeeId = 3,
                    LastName = "Leverling",
                    FirstName = "Janet",
                    Title = "Sales Representative",
                    TitleOfCourtesy = "Ms.",
                    Address = "722 Moss Bay Blvd.",
                    City = "Kirkland",
                    Region = "WA",
                    PostalCode = "98033",
                    Country = "USA",
                    HomePhone = "(206) 555-3412",
                    Extension = "3355",
                    Notes = "Janet has a BS degree in chemistry from Boston College (1984).  She has also completed a certificate program in food retailing management.  Janet was hired as a sales associate in 1991 and promoted to sales representative in February 1992.",
                    ReportsTo = 2,
                }
            };
    }
}
