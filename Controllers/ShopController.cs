using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheWayShop_2._0.DB;
using TheWayShop_2._0.Interfaces;
using TheWayShop_2._0.Models;
using TheWayShop_2._0.ViewModels;

namespace TheWayShop_2._0.Controllers
{
    public class ShopController : Controller
    {
        //private readonly IAllThings<Thing> allThings;
        //private readonly IAllCategories<Category> allCategories;
        //private readonly IAllCategoryItems<CategoryItem> allCategoryItems;

        //public ShopController(IAllThings<Thing> allThings, IAllCategories<Category> allCategories, IAllCategoryItems<CategoryItem> allCategoryItems)
        //{
        //    this.allThings = allThings;
        //    this.allCategories = allCategories;
        //    this.allCategoryItems = allCategoryItems;
        //}
        private readonly AppDbContext context;
        public ShopController(AppDbContext context)
        {
            this.context = context;
        }
        public IActionResult List(string category, string categoryItem)
        {
            string _category = category;
            string _categoryItem = categoryItem;
            IEnumerable<Thing> things = null;
            string currCategory = "";
            string currCategoryItem = "";
            if ((string.IsNullOrEmpty(category)) && (string.IsNullOrEmpty(categoryItem)))
            {
                things = context.Thing.OrderBy(t => t.id);

            }

            var thingObj = new ThingListViewModel
            {
                allThings = things,
                currCategory = currCategory,
                currCategoryItem=currCategoryItem
            };
            ViewBag.Title = "Page of things";
            return View(thingObj);
        }

        public IActionResult ShirtList(string category, string categoryItem)
        {
            string _category = category;
            string _categoryItem = categoryItem;
            IEnumerable<Thing> things = null;
            string currCategory = "";
            string currCategoryItem = "";
            if ((string.IsNullOrEmpty(category)) && (string.IsNullOrEmpty(categoryItem)))
            {
                things = context.Thing.Where(t => t.category.name.Equals("Top")).Where(c => c.category.categoryItemId == 1);

            }

            var thingObj = new ThingListViewModel
            {
                allThings = things,
                currCategory = currCategory
            };
            ViewBag.Title = "Page of shirts";
            return View(thingObj);
        }
    }
}
