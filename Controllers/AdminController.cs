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
            if (tvm.UploadedFile != null)
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
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Thing thing = await context.Thing.FirstOrDefaultAsync(p => p.id == id);
            if (thing == null)
            {
                return NotFound();
            }
            ViewData["categoryId"] = new SelectList(context.Category, "id", "name", thing.categoryId);
            return View(thing);
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, [Bind("id,name,description,img,color,size,price,categoryId")]Thing thing)
        {
            if (id != thing.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Thing.Update(thing);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThingExists(thing.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["categoryId"] = new SelectList(context.Category, "id", "name", thing.categoryId);
            return View(thing);
        }

        // GET: AdminController/Edit/5
        [HttpGet]
        public async Task<IActionResult> EditCategory(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category category = await context.Category.FirstOrDefaultAsync(p => p.id == id);
            if (category == null)
            {
                return NotFound();
            }
            ViewData["categoryitemId"] = new SelectList(context.CategoryItems, "id", "name", category.categoryItemId);
            return View(category);
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditCategory(int id, [Bind("id,name,description,categoryItemId")] Category category)
        {
            if (id != category.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Category.Update(category);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Categories));
            }
            ViewData["categoryItemId"] = new SelectList(context.CategoryItems, "id", "name", category.categoryItemId);
            return View(category);
        }

        // GET: AdminController/Delete/5
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
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

        // POST: AdminController/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {

            Thing thing = new Thing { id = id.Value };
            context.Entry(thing).State = EntityState.Deleted;
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: AdminController/Delete/5
        [HttpGet]
        [ActionName("DeleteCategory")]
        public async Task<IActionResult> ConfirmDeleteCategory(int? id)
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

        // POST: AdminController/Delete/5
        [HttpPost]
        [ActionName("DeleteCategory")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCategory(int? id)
        {
            Category category = new Category { id = id.Value };
            context.Entry(category).State = EntityState.Deleted;
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Categories));
        }
        private bool ThingExists(int id)
        {
            return context.Thing.Any(e => e.id == id);
        }

        private bool CategoryExists(int id)
        {
            return context.Category.Any(e => e.id == id);
        }
    }
}

