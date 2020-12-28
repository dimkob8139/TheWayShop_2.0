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
            if (!context.Category.Any())
            {
                context.Category.AddRange(Categories.Select(c => c.Value));
            }

            if (!context.Thing.Any())
            {
                context.AddRange(
                    new Thing
                    {
                        id = 1,
                        name = "shirt",
                        description = "a very great shirt",
                        img = "~/images/shirt-img.jpg",
                        price = 250,
                        categoryId=1,
                        category = Categories["Shirts"]

                    },
                    new Thing
                    {
                        name = "shoes",
                        description = "a very great men shoes",
                        img = "~/images/shoes-img.jpg",
                        price = 890,
                        categoryId=2,
                        category = Categories["Shoes"]
                    }


                    );
            }
            context.SaveChanges();
            //if(!context.User.Any())
            //{
            //    context.AddRange(
            //        new User
            //        {
            //            id = 1,
            //            login="admin",
            //            password="admin",
            //            email="dimkob8139@gmail.com"
            //        }

            //        ) ;
            //}
            //context.SaveChanges();

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
                       new Category{name="Shirts",description="Very nice shirts"},
                       new Category{name="Shoes",description="Very nice shoes"}
                    };
                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                        category.Add(el.name, el);
                }
                return category;
            }
        }
    }

}
