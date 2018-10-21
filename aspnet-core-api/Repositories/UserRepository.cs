using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Helpers;
using WebApi.Models;

namespace WebApi.Repositories
{
    public interface IUserRepository
    {
        User Get(string username);
        User Get(string username, string password);
        int GetMaxId();
        void AddNew(User user);
        IEnumerable<User> GetAll();
    }
    public class UserRepository : IUserRepository
    {
        private List<User> _users;
        public UserRepository()
        {
            // users hardcoded for simplicity, store in a db with hashed passwords in production applications
            _users = LocalDBSingleton.users;
        }

        public void AddNew(User user)
        {
            _users.Add(user);
        }

        public int GetMaxId()
        {
            return _users.OrderByDescending(x => x.Id).FirstOrDefault()?.Id ?? 0; // get max id of existing users, if no user exists return 0
        }

        public User Get(string username, string password)
        {
            return _users.SingleOrDefault(x => x.Username == username && x.Password == password);
        }

        public User Get(string username)
        {
            return _users.SingleOrDefault(x => x.Username == username);
        }

        public IEnumerable<User> GetAll()
        {
            return _users.Select(x =>
            {
                return x;
            });
        }
    }
}
