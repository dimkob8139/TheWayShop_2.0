using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheWayShop_2._0.DB;
using TheWayShop_2._0.Interfaces;
using TheWayShop_2._0.Models;

namespace TheWayShop_2._0.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext context;
        //private readonly IAllThings<Thing> things;
        //private readonly IAllCategories<Category> categories;
        //private readonly IAllCategoryItems<CategoryItem> categoryItems;
        private readonly IWebHostEnvironment environment;

        public AdminController(AppDbContext context,/*AllCategories<Category> categories, IAllCategoryItems<CategoryItem>categoryItems, IAllThings<Thing> things,*/ IWebHostEnvironment environment)
        {
            this.context = context;
            //this.things = things;
            this.environment = environment;
            //this.categories = categories;
           // this.categoryItems = categoryItems;
        }

        // GET: AdminController
        [Route("/Admin")]
        public async Task<IActionResult> Index()
        {
            var thingContext=context.Thing.Include(g => g.category);
            return View(await thingContext.ToListAsync());
        }
        [Route("/Admin/Categories")]
        public async Task<IActionResult> Categories()
        {
            var categoryContext = context.Category.Include(c => c.categoryItem);
            return View(await categoryContext.ToListAsync());
        }

        // GET: AdminController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
