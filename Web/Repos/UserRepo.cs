using System;
using System.Collections.Generic;
using System.Linq;
using Web.Models;

namespace Web
{
    public class UserRepo : IUserRepo
    {
        private static readonly List<User> Users = new List<User>();

        public IEnumerable<User> GetAll()
        {
            return Users;
        }

        public User Get(int id)
        {
            return Users.SingleOrDefault(u => u.Id == id);
        }

        public User Get(string username)
        {
            return Users.SingleOrDefault(u => u.UserName == username);
        }

        public User Save(User user)
        {
            var existing = Users.SingleOrDefault(u => u.Id == user.Id);

            if (existing == default(User) && Users.Any(u => u.UserName == user.UserName))
                throw new Exception("User already exists.");

            if (existing == default(User))
            {
                if (user.Id == 0)
                    user.Id = Users.Count + 1;
                Users.Add(user);
                return user;
            }

            existing.UserName = user.UserName;
            existing.FirstName = user.FirstName;
            existing.LastName = user.LastName;
            return existing;
        }

        public void Delete(int id)
        {
            var user = Users.SingleOrDefault(u => u.Id == id);
            if (user != default(User))
                Users.Remove(user);
        }
    }
}