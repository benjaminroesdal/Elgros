using ElgrosWeb.Shared.Enums;
using ElgrosWeb.Shared.Models;

namespace ElgrosWeb.Server.Facades.Interfaces
{
    public interface IProductFacade
    {
        /// <summary>
        /// Gets products based on category enum
        /// </summary>
        /// <param name="productCategory">Category enum to query on</param>
        /// <returns>List of products with requested category</returns>
        Task<List<ProductModel>> GetCategoryProducts(Category productCategory);
        /// <summary>
        /// Get products based on the subcategory model provided
        /// </summary>
        /// <param name="productCategory">Subcategory model to base the query on</param>
        /// <returns>List of products found based on subcategory model</returns>
        Task<List<ProductModel>> GetSubCategoryProducts(SubCategoryModel productCategory);
        /// <summary>
        /// Gets all sub categories from a specific category
        /// </summary>
        /// <param name="category">main category to find sub categories on.</param>
        /// <returns>All sub categories based on category.</returns>
        Task<List<SubCategoryModel>> GetSubCategorys(Category category);
    }
}
    