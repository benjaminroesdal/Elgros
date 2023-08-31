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

        /// <summary>
        /// Gets all products with category VVS
        /// </summary>
        /// <returns>products with VVS category</returns>
        [HttpGet]
        [Route("GetVvsProducts")]
        public async Task<List<ProductModel>> GetAllVvsProducts()
        {
            return await _productFacade.GetCategoryProducts(Shared.Enums.Category.VVS);
        }

        /// <summary>
        /// Gets all products with category Electrical
        /// </summary>
        /// <returns>products with electrical category</returns>
        [HttpGet]
        [Route("GetElectricalProducts")]
        public async Task<List<ProductModel>> GetAllElectricalProducts()
        {
            return await _productFacade.GetCategoryProducts(Shared.Enums.Category.Electrical);
        }

        /// <summary>
        /// Gets all products with provided subcategory
        /// </summary>
        /// <param name="model">Subcategory to find products on</param>
        /// <returns>Products with provided subcategory</returns>
        [HttpPost]
        [Route("GetProductsOnSubCategory")]
        public async Task<List<ProductModel>> GetProductsSubCategory([FromBody] SubCategoryModel model)
        {
            return await _productFacade.GetSubCategoryProducts(model);
        }

        /// <summary>
        /// Gets all subcategories based on a category
        /// </summary>
        /// <param name="category">Category to find subcategories on</param>
        /// <returns>All subcategories from category</returns>
        [HttpGet]
        [Route("GetAllSubcategorys")]
        public async Task<List<SubCategoryModel>> GetAllSubCategorys(Category category)
        {
            return await _productFacade.GetSubCategorys(category);
        }
    }
}