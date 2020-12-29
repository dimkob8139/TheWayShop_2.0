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
    public class CategoryItemRepository : IAllCategoryItems<CategoryItem>
    {
        private readonly AppDbContext context;
        private readonly DbSet<CategoryItem> categoryItems;

        public CategoryItemRepository(AppDbContext context,DbSet<CategoryItemRepository> categoryItems)
        {
            this.context = context;
            this.categoryItems = this.context.CategoryItems;
        }

        public IEnumerable<CategoryItem> CategoryItems => context.CategoryItems;

        public void Create(CategoryItem entity)
        {
            context.CategoryItems.Add(entity);
        }

        public void Delete(int id)
        {
            var categoryItem = context.CategoryItems.Find(id);
            Delete(categoryItem);
        }

        public void Delete(CategoryItem entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                context.CategoryItems.Attach(entity);
            }
            context.Entry(entity).State = EntityState.Deleted;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public CategoryItem getObjectCategoryItem(int categoryItemId)
        {
            return context.CategoryItems.FirstOrDefault(p => p.id == categoryItemId);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(CategoryItem entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
