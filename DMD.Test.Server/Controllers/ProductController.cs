using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DMD.Test.Models;
using DMD.Test.Models.Models;
using DMD.Test.Services;

namespace DMD.Test.Server.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("[action]/{type}")]
        public async Task<IEnumerable<Product>> Get(string type)
        {
            if (string.IsNullOrWhiteSpace(type) || type.ToLower() == "all")
            {
                var res = await _productService.Get();
                return res;
            }

            return await _productService.Get(type);
        }

        [HttpPost("[action]")]
        public async Task<Product> Add([FromBody] Product model)
        {
            return await _productService.Add(model);
        }

        [HttpPut("[action]")]
        public async Task<Product> Update([FromBody] Product model)
        {
            return await _productService.Update(model);
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<Category>> GetTypes()
        {
            return await _productService.GetTypes();
        }
    }
}
