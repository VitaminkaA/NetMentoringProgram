using System;
using System.Collections.Generic;
using LinqToDB.Mapping;

namespace Northwind.EF.DAL.Entities
{
    [Table("EmployeeTerritories")]
    public class EmployeeTerritory
    {
        [Column, PrimaryKey(1)]
        public int EmployeeId { get; set; }
        [Column, PrimaryKey(2)]
        public string TerritoryId { get; set; }

        [Association(ThisKey = nameof(EmployeeId),
            OtherKey = nameof(Entities.Employee.EmployeeId))]
        public Employee Employee { get; set; }

        [Association(ThisKey = nameof(TerritoryId),
            OtherKey = nameof(Entities.Territory.TerritoryId))]
        public Territory Territory { get; set; }
    }
}
