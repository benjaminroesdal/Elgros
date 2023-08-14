using ElgrosWeb.Shared.Enums;
using ElgrosWeb.Shared.Models;

namespace ElgrosWeb.Server.Facades.Interfaces
{
    public interface IProductFacade
    {
        Task<List<ProductModel>> GetCategoryProducts(Category productCategory);
        Task<List<ProductModel>> GetElectricalProducts(ElectricalCategory productCategory);
        Task<List<ProductModel>> GetVvsProducts(VvsCategory productCategory);
    }
}
    