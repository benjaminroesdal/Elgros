using ElgrosWeb.Shared.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElgrosWeb.Shared.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public UserModel User { get; set; }
        public List<ProductModel> Products { get; set; }
        public double TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public PaymentModel PaymentDetails { get; set; }
        public bool HasAcceptedPolicies { get; set; }
        public bool  HomeDelivery { get; set; }
    }
}
