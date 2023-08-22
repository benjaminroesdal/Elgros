using ElgrosWeb.Server.Facades.Interfaces;
using ElgrosWeb.Shared.Enums;
using ElgrosWeb.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElgrosWeb.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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

        [HttpPost]
        [Route("GetProductsOnSubCategory")]
        public async Task<List<ProductModel>> GetProductsSubCategory([FromBody] SubCategoryModel model)
        {
            return await _productFacade.GetSubCategoryProducts(model);
        }

        [HttpGet]
        [Route("GetAllSubcategorys")]
        public async Task<List<SubCategoryModel>> GetAllSubCategorys(Category category)
        {
            return await _productFacade.GetSubCategorys(category);
        }
    }
}