using ElgrosWeb.Shared.Enums;
using ElgrosWeb.Shared.Models;

namespace ElgrosWeb.Server.Repositories.Interfaces
{
    public interface IProductRepository
    {
        /// <summary>
        /// Fetches products from DB based on provided category enum
        /// </summary>
        /// <param name="productCategory">Category enum to find products on</param>
        /// <returns>Products with provided category</returns>
        Task<List<ProductModel>> GetCategoryProducts(Category productCategory);
        /// <summary>
        /// Fetches products from DB based on provided sub category ID
        /// </summary>
        /// <param name="subCategoryId">sub category id to find products on</param>
        /// <returns>List products with provided subcategory</returns>
        Task<List<ProductModel>> GetSubCategoryProducts(int subCategoryId);
        /// <summary>
        /// Fetches all current subcategories in database from a provided main category
        /// </summary>
        /// <param name="category">Main category to find subcategories from</param>
        /// <returns>List of sub categories</returns>
        Task<List<SubCategoryModel>> GetSubCategorys(Category category);
    }
}
