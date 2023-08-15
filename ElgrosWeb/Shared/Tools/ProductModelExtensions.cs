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
            };
        }

        public static List<ProductModel> CreateModelList(this List<ProductDao> dao)
        {
            var modelList = new List<ProductModel>();
            dao.ForEach(e => modelList.Add(e.CreateModel()));
            return modelList;
        }
    }
}
