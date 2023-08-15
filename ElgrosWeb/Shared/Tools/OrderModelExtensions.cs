using ElgrosWeb.Shared.Dao;
using ElgrosWeb.Shared.Models;

namespace ElgrosWeb.Shared.Tools
{
    public static class OrderModelExtensions
    {
        public static OrderModel CreateModel(this OrderDao orderDao)
        {
            return new OrderModel()
            {
                Id = orderDao.Id,
                User = orderDao.User.CreateModel(),
                Products = orderDao.Products.CreateModelList(),
                TotalAmount = orderDao.TotalAmount,
                PaymentDetails = orderDao.PaymentDetails.CreateModel()
            };
        }
    }
}
