using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheWayShop_2._0.Models
{
    public class Role
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<User> Users { get; set; }
        public Role()
        {
            Users = new List<User>();
        }
    }
}
