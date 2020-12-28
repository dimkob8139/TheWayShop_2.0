using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheWayShop_2._0.DB;
using TheWayShop_2._0.Interfaces;
using TheWayShop_2._0.Models;

namespace TheWayShop_2._0.Repositories
{
    public class CategoryRepository : IAllCategories<Category>
    {
        private readonly AppDbContext context;
        private readonly DbSet<Category> categories;

        public CategoryRepository(AppDbContext context, DbSet<Category> categories)
        {
            this.context = context;
            this.categories = this.context.Category;
        }


        public IEnumerable<Category> Categories => context.Category;

        public void Create(Category entity)
        {
            context.Category.Add(entity);
        }

        public void Delete(int id)
        {
            var category = context.Category.Find(id);
            Delete(category);
        }

        public void Delete(Category entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                context.Category.Attach(entity);
            }
            context.Entry(entity).State = EntityState.Deleted;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Category getObjectCategory(int categoryId)
        {
            return context.Category.FirstOrDefault(p => p.id == categoryId);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Category entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
