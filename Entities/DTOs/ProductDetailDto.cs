﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ProductDetailDto:IDto
    {
        public int? ProductId { get; set; }
        public string? CategoryName { get; set; }
        public string? ProductName { get; set; }
        public int UnitsInStock { get; set; }
        public string? UploadTime { get; set; }
        public decimal UnitPrice { get; set; }
        public string? Header { get; set; }
        public string? Description { get; set; }
        public string? ImageContentType { get; set; }
        public byte[]? ImageData { get; set; }
        public string? Sizes { get; set; }
    }
}
