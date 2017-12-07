using System.Collections.Generic;
using Web.Models;

namespace Web
{
    public interface IUserRepo
    {
        IEnumerable<User> GetAll();
        User Get(int id);
        User Get(string username);
        User Save(User user);
        void Delete(int id);
    }
}