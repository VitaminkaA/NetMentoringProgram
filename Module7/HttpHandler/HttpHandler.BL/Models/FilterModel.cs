﻿using System;

namespace HttpHandler.BL.Models
{
    public class FilterModel
    {
        public string CustomerId { get; set; }
        public (DateTimeOffset?, DateTimeOffset?) DateRange { get; set; }
        public int? Skip { get; set; }
        public int? Take { get; set; }
    }
}
