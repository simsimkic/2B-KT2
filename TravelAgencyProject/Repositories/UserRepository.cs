
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.Data.Sqlite;
using System.Linq;
using System.Windows.Input;
using TravelAgencyProject.Domain.Model;
using TravelAgencyProject.Resources.DBAcces;

namespace TravelAgencyProject.Repository
{
    public class UserRepository
    {
        private List<User> users;
        private readonly IDataHandler<User> userDataHandler;

        public UserRepository()
        {
            userDataHandler = new UserDataHandler();
            users = userDataHandler.GetAll().ToList();
        }
        public List<User> GetAll()
        {
            return users;
        }

        public User GetById(int id)
        {
            return users.FirstOrDefault(user => user.Id == id);
        }

        public User GetByUsername(string Username)
        {
            return users.FirstOrDefault(users => users.EqualsUsername(Username));
        }

        public User GetByPassword(string Password)
        {
            return users.FirstOrDefault(users => users.EqualsPassword(Password));
        }

        public void Update(User user)
        {
            userDataHandler.Update(user); 
        }

        public List<Owner> GetOwners()
        {
            List<Owner> owners = new List<Owner>();
            foreach (User user in users)
            {
                if (user.Type == UserType.Owner)
                    owners.Add((Owner)user);
            }
            return owners;
        }

        
    }
}
