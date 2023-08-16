using ElgrosWeb.Shared.Enums;
using ElgrosWeb.Shared.Models;

namespace ElgrosWeb.Server.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<List<ProductModel>> GetCategoryProducts(Category productCategory);
        Task<List<ProductModel>> GetSubCategoryProducts(int subCategoryId);
        Task<List<SubCategoryModel>> GetSubCategorys(Category category);
    }
}
