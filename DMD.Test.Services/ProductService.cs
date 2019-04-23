using System.Collections.Generic;
using System.Threading.Tasks;
using DMD.Test.Models;
using DMD.Test.Models.Models;
using DMD.Test.Repositories;

namespace DMD.Test.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Product>> Get()
        {
            return await _repository.Get();
        }

        public async Task<IEnumerable<Product>> Get(string type)
        {
            return await _repository.Get(type);
        }

        public async Task<Product> Add(Product model)
        {
            return await _repository.Add(model);
        }

        public async Task<Product> Update(Product model)
        {
            return await _repository.Update(model);
        }

        public async Task<IEnumerable<Category>> GetTypes()
        {
            return await _repository.GetTypes();
        }

    }
}
