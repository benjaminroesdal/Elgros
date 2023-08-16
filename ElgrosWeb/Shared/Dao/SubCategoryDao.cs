
using ElgrosWeb.Shared.Enums;

namespace ElgrosWeb.Shared.Dao
{
    public class SubCategoryDao
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public List<ProductDao> Products { get; set; }
    }
}
