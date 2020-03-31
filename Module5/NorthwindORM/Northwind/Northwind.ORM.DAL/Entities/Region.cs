using System;
using System.Collections.Generic;
using LinqToDB.Mapping;

namespace Northwind.EF.DAL.Entities
{
    [Table("Region")]
    public class Region
    {
        [Column, Identity, PrimaryKey]
        public int RegionId { get; set; }

        [Column]
        public string RegionDescription { get; set; }


        [Association(
            ThisKey = nameof(RegionId),
            OtherKey = nameof(Territory.RegionId))]
        public ICollection<Territory> Territories { get; set; }
    }
}
    