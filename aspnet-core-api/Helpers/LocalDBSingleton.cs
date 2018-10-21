using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Helpers
{
    // keep the data in a singleton class for project simplicity
    public class LocalDBSingleton
    {
        private static readonly LocalDBSingleton instance = new LocalDBSingleton();
        // explicit static constructor to tell C# compiler not to mark type as beforefieldinit  
        static LocalDBSingleton() { }
        private LocalDBSingleton()
        {
            // add admin login by default
            users = new List<User>(){
                new User { Id = 1, FirstName = "Admin", LastName = "Admin", Username = "admin", Password = Encrypt.EncryptPassword("admin") }
            };
        }
        public static LocalDBSingleton Instance
        {
            get
            {
                return instance;
            }
        }
        public static List<User> users;
    }
}
