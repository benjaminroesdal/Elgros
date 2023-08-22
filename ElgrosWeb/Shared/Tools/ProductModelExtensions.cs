using ElgrosWeb.Shared.Dao;
using ElgrosWeb.Shared.Models;

namespace ElgrosWeb.Shared.Tools
{
    public static class ProductModelExtensions
    {
        public static ProductModel CreateModel(this ProductDao dao)
        {
            return new ProductModel()
            {
                Id = dao.Id,
                Name = dao.Name,
                Description = dao.Description,
                Brand = dao.Brand,
                Category = dao.Category,
                Price = dao.Price,
                Image = dao.Image,
                StockQuantity = dao.Quantity,
                SubCategoryList = dao.SubCategoryList.CreateModelList()
            };
        }

        public static ProductDao CreateDao(this ProductModel model)
        {
            return new ProductDao()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Brand = model.Brand,
                Category = model.Category,
                Price = model.Price,
                Image = model.Image,
                Quantity = model.StockQuantity,
                SubCategoryList = new List<SubCategoryDao>()
            };
        }

        public static List<ProductModel> CreateModelList(this List<ProductDao> dao)
        {
            var modelList = new List<ProductModel>();
            dao.ForEach(e => modelList.Add(e.CreateModel()));
            return modelList;
        }

        public static List<ProductDao> CreateDaoList(this List<ProductModel> modelList)
        {
            var daoList = new List<ProductDao>();
            modelList.ForEach(e => daoList.Add(e.CreateDao()));
            return daoList;
        }
    }
}
