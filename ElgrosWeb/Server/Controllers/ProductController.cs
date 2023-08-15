using ElgrosWeb.Server.Facades.Interfaces;
using ElgrosWeb.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElgrosWeb.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductFacade _productFacade;

        public ProductController(ILogger<ProductController> logger, IProductFacade productFacade)
        {
            _logger = logger;
            _productFacade = productFacade;
        }

        [HttpGet]
        [Route("GetVvsProducts")]
        public async Task<List<ProductModel>> GetAllVvsProducts()
        {
            return await _productFacade.GetCategoryProducts(Shared.Enums.Category.VVS);
        }

        [HttpGet]
        [Route("GetElectricalProducts")]
        public async Task<List<ProductModel>> GetAllElectricalProducts()
        {
            return await _productFacade.GetCategoryProducts(Shared.Enums.Category.Electrical);
        }

        [HttpGet]
        [Route("GetProductsOnSubCategory")]
        public async Task<List<ProductModel>> GetProductsSubCategory([FromBody] SubCategoryModel model)
        {
            return await _productFacade.GetSubCategoryProducts(model);
        }
    }
}