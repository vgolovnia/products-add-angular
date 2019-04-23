using System.Collections.Generic;
using DMD.Test.Models;
using DMD.Test.Models.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace DMD.Test.Services.DbInit
{
    public class DataContextInitializer
    {
        public void InitializeForContext(MainContext context)
        {
            List<Category> categories = new List<Category>();
            if (!context.Categories.Any())
            {
                categories = new List<Category> {

                    new Category
                    {
                        Name = "Category1"
                    },
                    new Category
                    {
                        Name = "Category2"
                    },
                    new Category
                    {
                        Name = "Category3"
                    },
                    new Category
                    {
                        Name = "Category4"
                    }
                };

                context.Categories.AddRange(categories);
            }

            if (!context.Products.Any())
            {
                var products = new List<Product> {

                    new Product
                    {
                        Name = "Product 1",
                        Category = categories[0]
                    },
                    new Product
                    {
                        Name = "Product 2",
                        Category = categories[1]
                    },
                    new Product
                    {
                        Name = "Product 3",
                        Category = categories[2]
                    },
                    new Product
                    {
                        Name = "Product 4",
                        Category = categories[3]
                    }
                };

                context.Products.AddRange(products);
            }

            context.SaveChanges();
        }
    }
}
