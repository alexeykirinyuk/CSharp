using MvcEntityTask.Models;
using System;
using System.Linq;
using System.Text;

namespace MvcEntityTask.Managers
{
    public class UserManager
    {
        private static UserManager _manager;
        private static object lockObject = new object();

        public static UserManager Instance
        {
            get
            {
                if(_manager == null)
                {
                    lock(lockObject)
                    {
                        if(_manager == null)
                        {
                            _manager = new UserManager();
                        }
                    }
                }
                return _manager;
            }
        }

        public bool HasName(string name)
        {
            using (var dbContext = new UserContext())
            {
                return 0 != dbContext.Users.Where(user => user.Name == name).Count();
            }
        }

        public bool HasKey(string userKey)
        {
            using (var dbContext = new UserContext())
            {
                return 0 != dbContext.Users.Where(user => user.Key == userKey).Count();
            }
        }

        public string AddUser(string name, string password)
        {
            using (var dbContext = new UserContext())
            {
                var user = new User { Name = name, Password = password, Key = GenerateRandomKey() };
                dbContext.Users.Add(user);
                dbContext.SaveChanges();

                return user.Key;
            }
        }

        public string GetKey(string name, string password)
        {
            using (var dbContext = new UserContext())
            {
                var foundUser = dbContext.Users.Where(user => user.Name == name && user.Password == password).FirstOrDefault();
                
                if(foundUser == null)
                {
                    return string.Empty;
                }

                return foundUser.Key;
            }
        }

        private string GenerateRandomKey()
        {
            return new Guid().ToString();
        }
    }
}