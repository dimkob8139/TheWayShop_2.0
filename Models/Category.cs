﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheWayShop_2._0.Models
{
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int categoryItemId { get; set; }

        public virtual CategoryItem categoryItem { get; set; }
    }
}
