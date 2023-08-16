using ElgrosWeb.Shared.Enums;

namespace ElgrosWeb.Shared.Dao
{
    public class ProductDao
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public Category Category { get; set; }
        public double Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public List<OrderDao> OrderList { get; set; }
        public List<SubCategoryDao>? SubCategoryList { get; set; }
    }
}
