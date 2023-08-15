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
            };
        }
    }
}
