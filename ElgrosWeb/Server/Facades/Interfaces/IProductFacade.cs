using ElgrosWeb.Shared.Enums;
using ElgrosWeb.Shared.Models;

namespace ElgrosWeb.Server.Facades.Interfaces
{
    public interface IProductFacade
    {
        Task<List<ProductModel>> GetCategoryProducts(Category productCategory);
        Task<List<ProductModel>> GetSubCategoryProducts(SubCategoryModel productCategory);
    }
}
    