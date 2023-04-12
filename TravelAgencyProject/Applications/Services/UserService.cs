using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Domain.Model;
using TravelAgencyProject.Repository;

namespace TravelAgencyProject.Applications.Services
{
    public class UserService
    {
        private UserRepository userRepository;

        public UserService()
        {
            userRepository = new UserRepository();
        }
        public User GetById(int id)
        {
            return userRepository.GetById(id);
        }

        public void Update(User user)
        {
            userRepository.Update(user);
        }

        public List<Owner> GetOwners()
        {
            return userRepository.GetOwners();
        }

    }
}
