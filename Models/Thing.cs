using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheWayShop_2._0.Models
{
    public class Thing
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string img { get; set; }
        public ushort price { get; set; }
        public int categoryId { get; set; }

        public virtual Category category { get; set; }
    }
}
