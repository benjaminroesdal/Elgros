﻿
namespace ElgrosWeb.Shared.Dao
{
    public class SubCategoryDao
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ProductDao> Products { get; set; }
    }
}
