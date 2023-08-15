using ElgrosWeb.Server.Facades.Interfaces;
using ElgrosWeb.Server.Repositories.Interfaces;
using ElgrosWeb.Shared.Enums;
using ElgrosWeb.Shared.Models;

namespace ElgrosWeb.Server.Facades
{
    public class ProductFacade : IProductFacade
    {
        private readonly IProductRepository _repository;
        public ProductFacade(IProductRepository repository)
        {
            _repository = repository;
        }
        public Task<List<ProductModel>> GetCategoryProducts(Category productCategory) 
            => _repository.GetCategoryProducts(productCategory);

        public Task<List<ProductModel>> GetSubCategoryProducts(SubCategoryModel productCategory) 
            => _repository.GetSubCategoryProducts(productCategory.Id);
    }
}
