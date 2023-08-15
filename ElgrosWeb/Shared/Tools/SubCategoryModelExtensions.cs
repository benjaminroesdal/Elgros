
using ElgrosWeb.Shared.Dao;
using ElgrosWeb.Shared.Models;

namespace ElgrosWeb.Shared.Tools
{
    public static class SubCategoryModelExtensions
    {
        public static SubCategoryModel CreateModel(this SubCategoryDao dao)
        {
            return new SubCategoryModel()
            {
                Id = dao.Id,
                Name = dao.Name,
                Description = dao.Description,
            };
        }

        public static List<SubCategoryModel> CreateModelList(this List<SubCategoryDao> daoList)
        {
            var modelList = new List<SubCategoryModel>();
            daoList.ForEach(e => modelList.Add(e.CreateModel()));
            return modelList;
        }
    }
}
