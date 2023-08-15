namespace ElgrosWeb.Shared.Dao
{
    public class OrderDao
    {
        public int Id { get; set; }
        public UserDao User { get; set; }
        public List<ProductDao> Products { get; set; }
        public double TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set;}
        public PaymentDao PaymentDetails { get; set; }
    }
}
