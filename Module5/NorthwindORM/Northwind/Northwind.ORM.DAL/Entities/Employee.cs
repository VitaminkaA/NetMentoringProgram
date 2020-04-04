using System;
using System.Collections.Generic;
using LinqToDB.Mapping;

namespace Northwind.EF.DAL.Entities
{
    [Table("Employees")]
    public class Employee
    {
        [Column, PrimaryKey, Identity]
        public int EmployeeId { get; set; }
        [Column]
        public string LastName { get; set; }
        [Column]
        public string FirstName { get; set; }
        [Column]
        public string Title { get; set; }
        [Column]
        public string TitleOfCourtesy { get; set; }
        [Column]
        public DateTime? BirthDate { get; set; }
        [Column]
        public DateTime? HireDate { get; set; }
        [Column]
        public string Address { get; set; }
        [Column]
        public string City { get; set; }
        [Column]
        public string Region { get; set; }
        [Column]
        public string PostalCode { get; set; }
        [Column]
        public string Country { get; set; }
        [Column]
        public string HomePhone { get; set; }
        [Column]
        public string Extension { get; set; }
        [Column]
        public string Notes { get; set; }
        [Column]
        public int? ReportsTo { get; set; }


        [Association(
            ThisKey = nameof(EmployeeId),
            OtherKey = nameof(EmployeeTerritory.EmployeeId))]
        public IEnumerable<EmployeeTerritory> EmployeeTerritories { get; set; }

        [Association(
            ThisKey = nameof(EmployeeId),
            OtherKey = nameof(Order.EmployeeId))]
        public IEnumerable<Order> Orders { get; set; }
    }
}
