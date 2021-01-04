using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TheWayShop_2._0.DB;
using TheWayShop_2._0.Interfaces;
using TheWayShop_2._0.Models;
using TheWayShop_2._0.ViewModels;

namespace TheWayShop_2._0.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext context;

        private readonly IWebHostEnvironment environment;

        public AdminController(AppDbContext context, IWebHostEnvironment environment)
        {
            this.context = context;
            this.environment = environment;

        }

        // GET: AdminController
        [Route("/Admin")]
        public async Task<IActionResult> Index()
        {
            var thingContext = context.Thing.Include(g => g.category);
            return View(await thingContext.ToListAsync());
        }
        [Route("/Admin/Categories")]
        public async Task<IActionResult> Categories()
        {
            var categoryContext = context.Category.Include(c => c.categoryItem);
            return View(await categoryContext.ToListAsync());
        }

        // GET: AdminController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Thing thing = await context.Thing
                .Include(g => g.category)
                .FirstOrDefaultAsync(m => m.id == id);
            if (thing == null)
            {
                return NotFound();
            }

            return View(thing);
        }
        public async Task<IActionResult> DetailsCategory(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Category category = await context.Category
                .Include(g => g.categoryItem)
                .FirstOrDefaultAsync(m => m.id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // GET: AdminController/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Category = new SelectList(context.Category, "id", "name");
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ThingViewModel tvm)
        {
            if (tvm.UploadedFile!=null)
            {
                string path = "/Files" + tvm.UploadedFile.FileName;
                using (FileStream file = new FileStream(environment.WebRootPath + path, FileMode.Create))
                {
                    await tvm.UploadedFile.CopyToAsync(file);
                }

                Thing thing = new Thing();
                thing.name = tvm.Thing.name;
                thing.description = tvm.Thing.description;
                thing.price = tvm.Thing.price;
                thing.color = tvm.Thing.color;
                thing.size = tvm.Thing.size;
                thing.categoryId = tvm.Thing.categoryId;
                thing.img = path;
                context.Thing.Add(thing);
                await context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        // GET: AdminController/Create
        [HttpGet]
        public IActionResult CreateCategory()
        {
            ViewBag.CategoryItems = new SelectList(context.CategoryItems, "id", "name");

            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategory(CategoryViewModel cVM)
        {
            if (ModelState.IsValid)
            {
                Category category = new Category();
                category.name = cVM.Category.name;
                category.description = cVM.Category.description;
                category.categoryItemId = cVM.Category.categoryItemId;
                context.Category.Add(category);
                await context.SaveChangesAsync();
            }
            return RedirectToAction("Categories");
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

        // GET: AdminController/Edit/5
        public ActionResult EditCategory(int id)
        {
            return View();
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCategory(int id, IFormCollection collection)
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

        // GET: AdminController/Delete/5
        public ActionResult DeleteCategory(int id)
        {
            return View();
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCategory(int id, IFormCollection collection)
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
