using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheWayShop_2._0.Models;

namespace TheWayShop_2._0.ViewModels
{
    public class ThingListViewModel
    {
        public IEnumerable<Thing> allThings { get; set; }

        public string currCategory { get; set; }

        public string currCategoryItem  { get; set; }
    }
}
