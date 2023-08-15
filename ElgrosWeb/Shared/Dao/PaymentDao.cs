using ElgrosWeb.Shared.Enums;

namespace ElgrosWeb.Shared.Dao
{
    public class PaymentDao
    {
        public int Id { get; set; }
        public string Provider { get; set; }
        public PaymentStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
