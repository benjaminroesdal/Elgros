using ElgrosWeb.Shared.Dao;
using ElgrosWeb.Shared.Models;

namespace ElgrosWeb.Shared.Tools
{
    public static class UserModelExtensions
    {
        public static UserModel CreateModel(this UserDao dao)
        {
            return new UserModel()
            {
                Id = dao.Id,
                FirstName = dao.FirstName,
                LastName = dao.LastName,
                Address = dao.Address,
                PhoneNumber = dao.PhoneNumber,
                PostalCode = dao.PostalCode,
                City = dao.City,
                Email = dao.Email,
            };
        }

        public static UserDao CreateDao(this UserModel model)
        {
            return new UserDao()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                PhoneNumber = model.PhoneNumber,
                PostalCode= model.PostalCode,
                City = model.City,
                Email = model.Email,
            };
        }
    }
}
