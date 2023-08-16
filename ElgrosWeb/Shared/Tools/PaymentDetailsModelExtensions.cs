using ElgrosWeb.Shared.Dao;
using ElgrosWeb.Shared.Models;

namespace ElgrosWeb.Shared.Tools
{
    public static class PaymentDetailsModelExtensions
    {
        public static PaymentModel CreateModel(this PaymentDao dao)
        {
            return new PaymentModel()
            {
                Id = dao.Id,
                Provider = dao.Provider,
                Status = dao.Status,
            };
        }

        public static PaymentDao CreateDao(this PaymentModel dao)
        {
            return new PaymentDao()
            {
                Id = dao.Id,
                Provider = dao.Provider,
                Status = dao.Status,
            };
        }
    }
}
