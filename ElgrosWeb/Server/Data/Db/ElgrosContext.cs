using Microsoft.EntityFrameworkCore;
using ElgrosWeb.Shared.Dao;

namespace ElgrosWeb.Server.Data.Db
{
    public class ElgrosContext : DbContext
    {
        public DbSet<OrderDao> Order { get; set; }
        public DbSet<PaymentDao> Payment { get; set; }
        public DbSet<ProductDao> Product { get; set; }
        public DbSet<UserDao> User { get; set; }
        public DbSet<SubCategoryDao> SubCategory { get; set; }

        public ElgrosContext(DbContextOptions<ElgrosContext> ctx) : base(ctx)
        {
            
        }
    }
}
