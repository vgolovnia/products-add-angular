using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMD.Test.Models;
using DMD.Test.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace DMD.Test.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly MainContext _dataContext;

        public ProductRepository(MainContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<Product>> Get()
        {
            return await _dataContext.Products
                .Include(r => r.Category).ToListAsync();
        }

        public async Task<IEnumerable<Product>> Get(string type)
        {
            return await _dataContext.Products
                .Include(r => r.Category)
                .Where(row => row.Category.Name.ToLower() == type.ToLower()).ToListAsync();
        }

        public async Task<Product> Add(Product model)
        {
            try
            {
                var productDb = new Product
                {
                    CategoryId = model.Category.Id,
                    Name = model.Name
                };

                await _dataContext.Products.AddAsync(productDb);
                await _dataContext.SaveChangesAsync();
                return model;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Product> Update(Product model)
        {
            var product = await _dataContext.Products.Where(row => row.Id == model.Id).FirstOrDefaultAsync();
            product.Name = model.Name;
            product.CategoryId = model.CategoryId;
            await _dataContext.SaveChangesAsync();
            return product;
        }

        public async Task<IEnumerable<Category>> GetTypes()
        {
            return await Task.Run(() => _dataContext.Categories);
        }
    }
}
