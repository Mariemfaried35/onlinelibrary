﻿using System;
using System.Collections.Generic;

namespace OlineLibrary.Data
{
    public partial class Book
    {
        public string Isbn { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string? Category { get; set; }
        public string? RackNumber { get; set; }
        public int Price { get; set; }
        public int? StockNumber { get; set; }
    }
}
