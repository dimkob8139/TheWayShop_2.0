using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheWayShop_2._0.Models;

namespace TheWayShop_2._0.Interfaces
{
    public interface IAllCategoryItems<TEntity> : IDisposable where TEntity : class
    {
        IEnumerable<CategoryItem> CategoryItems { get; }
        CategoryItem getObjectCategoryItem(int categoryItemId);

        void Delete(int id);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        void Create(TEntity entity);
        void Save();
    }
}
