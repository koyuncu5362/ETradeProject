﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Product:IEntity
    {
        public int? Id { get; set; }
        public int? CategoryId { get; set; }
        public string? Header  { get; set; }
        public string? Description { get; set; }
        public string? ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? UnitsInStock { get; set; }
        public string? UploadTime { get; set; }
        public bool ShowCase { get; set; }
        public int? ImageId { get; set; }
        public string? Sizes { get; set; }
    }
}
