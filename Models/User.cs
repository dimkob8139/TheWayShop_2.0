using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheWayShop_2._0.Models
{
    public class User
    {
        public int id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int? roleId { get; set; }
        public Role role { get; set; }
    }
}
