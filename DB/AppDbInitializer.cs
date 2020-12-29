using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheWayShop_2._0.Models;


namespace TheWayShop_2._0.DB
{
    public class AppDbInitializer
    {
        public static void Initial(AppDbContext context)
        {
            if (!context.CategoryItems.Any())
            {
                context.CategoryItems.AddRange(CategoryItems.Select(c => c.Value));
            }

            if (!context.Category.Any())
            {
                context.Category.AddRange(Categories.Select(c => c.Value));
            }

            if (!context.Thing.Any())
            {
                context.AddRange(
                    new Thing
                    {

                        name = "shirt",
                        description = "a very great shirt",
                        img = "~/images/shirt-img.jpg",
                        color = "brown",
                        size = "L",
                        price = 250,
                        categoryId = 1,
                        category = Categories["Top"]

                    },
                    new Thing
                    {
                        name = "shoes",
                        description = "a very great men shoes",
                        img = "~/images/shoes-img.jpg",
                        color = "black",
                        size ="S",
                        price = 890,
                        categoryId = 2,
                        category = Categories["Bottom"]
                    }


                    );
            }
            context.SaveChanges();


        }
        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]
                    {
                       new Category{name="Top",description="Cloth for top",categoryItemId=1,categoryItem=CategoryItems["Shirts"]},
                       new Category{name="Bottom",description="Cloth for bottom",categoryItemId=2,categoryItem=CategoryItems["Shoes"]}
                    };
                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                        category.Add(el.name, el);
                }
                return category;
            }
        }
        private static Dictionary<string, CategoryItem> categoryItem;
        public static Dictionary<string, CategoryItem> CategoryItems
        {
            get
            {
                if (categoryItem == null)
                {
                    var list = new CategoryItem[]
                    {
                       new CategoryItem{name="Shirts",description="Very nice shirts"},
                       new CategoryItem{name="Shoes",description="Very nice shoes"}
                    };
                    categoryItem = new Dictionary<string, CategoryItem>();
                    foreach (CategoryItem el in list)
                        categoryItem.Add(el.name, el);
                }
                return categoryItem;
            }
        }
    }

}
