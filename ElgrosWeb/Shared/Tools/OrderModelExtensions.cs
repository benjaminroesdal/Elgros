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

        public static OrderDao CreateDao(this OrderModel orderModel)
        {
            return new OrderDao()
            {
                Id = orderModel.Id,
                User = orderModel.User.CreateDao(),
                Products = orderModel.Products.CreateDaoList(),
                TotalAmount = orderModel.TotalAmount,
                PaymentDetails = orderModel.PaymentDetails.CreateDao()
            };
        }
    }
}
