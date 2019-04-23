using System.Collections.Generic;
using System.Threading.Tasks;
using DMD.Test.Models;
using DMD.Test.Models.Models;

namespace DMD.Test.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> Get();
        Task<IEnumerable<Product>> Get(string type);
        Task<Product> Add(Product model);
        Task<Product> Update(Product model);
        Task<IEnumerable<Category>> GetTypes();
    }
}