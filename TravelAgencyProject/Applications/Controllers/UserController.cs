using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Applications.Services;
using TravelAgencyProject.Domain.Model;

namespace TravelAgencyProject.Applications.Controller
{
    public class UserController
    {
        private UserService userService;

        public UserController()
        {
            userService = new UserService();
        }

        public User GetById(int id)
        {
            return userService.GetById(id);
        }

        public void Update(User user)
        {
            userService.Update(user);
        }

        public List<Owner> GetOwners()
        {
            return userService.GetOwners();
        }


    }
}
