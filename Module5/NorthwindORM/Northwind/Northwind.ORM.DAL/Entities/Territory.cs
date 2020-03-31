using System;
using System.Collections.Generic;
using LinqToDB.Mapping;

namespace Northwind.EF.DAL.Entities
{
    [Table("Territories")]
    public class Territory
    {
        [Column, PrimaryKey, Identity]
        public string TerritoryId { get; set; }
        [Column]
        public string TerritoryDescription { get; set; }
        [Column]
        public int RegionId { get; set; }

        [Association(ThisKey = nameof(RegionId),
            OtherKey = nameof(Entities.Region.RegionId),
            CanBeNull = true)]
        public Region Region { get; set; }
        //public virtual ICollection<EmployeeTerritory> EmployeeTerritories { get; set; }
    }
}
