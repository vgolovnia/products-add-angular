using System.Collections.Generic;
using System.Linq;
using DMD.Test.Models;
using DMD.Test.Models.Models;

namespace DMD.Test.Server.UnitTests
{
    public class FakeContext
    {
        public FakeContext()
        {
            Categories = (new List<Category>
                {
                    new Category() { Id = 1, Name = "Savings" },
                    new Category() { Id = 2, Name = "P2P" },
                    new Category() { Id = 3, Name = "Funds" }
                }).AsQueryable();

            var assetTypes = Categories.ToList();
            Products = (new List<Product>
                {
                    new Product() { Id = 1, Name = "Name of investment 1", Category = assetTypes[0] },
                    new Product() { Id = 1, Name = "Name of investment 2", Category = assetTypes[1] },
                    new Product() { Id = 1, Name = "Name of investment 3", Category = assetTypes[2] },
                    new Product() { Id = 1, Name = "Name of investment 4", Category = assetTypes[0] },
                    new Product() { Id = 1, Name = "Name of investment 5", Category = assetTypes[1] },
                    new Product() { Id = 1, Name = "Name of investment 6", Category = assetTypes[2] },
                    new Product() { Id = 1, Name = "Name of investment 7", Category = assetTypes[0] },
                    new Product() { Id = 1, Name = "Name of investment 8", Category = assetTypes[1] },
                    new Product() { Id = 1, Name = "Name of investment 9", Category = assetTypes[2] },
                    new Product() { Id = 1, Name = "Name of investment 10", Category = assetTypes[0] }
                }).AsQueryable();
        }

        public IQueryable<Category> Categories { get; }

        public IQueryable<Product> Products { get; }
    }
}
