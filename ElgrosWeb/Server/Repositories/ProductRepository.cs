using ElgrosWeb.Server.Data.Db;
using ElgrosWeb.Server.Repositories.Interfaces;
using ElgrosWeb.Shared.Enums;
using ElgrosWeb.Shared.Models;
using ElgrosWeb.Shared.Tools;
using ElgrosWeb.Shared.Dao;
using Microsoft.EntityFrameworkCore;

namespace ElgrosWeb.Server.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ElgrosContext _context;

        public ProductRepository(ElgrosContext ctx)
        {
            _context = ctx;
        }

        public async Task<List<ProductModel>> GetCategoryProducts(Category productCategory)
        {
            List<ProductDao> products;
            using (var context = _context)
            {
                products = await context.Product.Include(e => e.SubCategoryList).Where(e => e.Category.Equals(productCategory)).ToListAsync();
            }
            return products.CreateModelList();
        }

        public async Task<List<ProductModel>> GetSubCategoryProducts(int subCategoryId)
        {
            List<ProductDao> products;
            using (var context = _context)
            {
                products = await context.Product.Include(e => e.SubCategoryList).Where(e => e.SubCategoryList.Any(e => e.Id == subCategoryId)).ToListAsync();
            }
            return products.CreateModelList();
        }

        public async Task<List<SubCategoryModel>> GetSubCategorys(Category category)
        {
            List<SubCategoryDao> subCategorys;
            using (var context = _context)
            {
                subCategorys = await context.SubCategory.Where(e => e.Category == category).ToListAsync();
            }
            return subCategorys.CreateModelList();
        }

    }
}
