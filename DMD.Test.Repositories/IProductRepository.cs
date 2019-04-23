using System.Collections.Generic;
using System.Threading.Tasks;
using DMD.Test.Models;
using DMD.Test.Models.Models;

namespace DMD.Test.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> Get();
        Task<IEnumerable<Product>> Get(string type);
        Task<IEnumerable<Category>> GetTypes();
        Task<Product> Add(Product model);
        Task<Product> Update(Product model);
    }
}