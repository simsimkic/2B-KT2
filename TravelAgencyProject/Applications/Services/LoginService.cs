using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Applications.DTOs;
using TravelAgencyProject.Applications.Util;
using TravelAgencyProject.Domain.Model;
using TravelAgencyProject.Applications.Services;
using TravelAgencyProject.Repository;

namespace TravelAgencyProject.Applications.Services
{
    public class LoginService
    {
        UserRepository userRepository = new UserRepository();


        public UserType Login(UserDTO userDTO)
        {
            var userByUsername = userRepository.GetByUsername(userDTO.Username);
            var userByPassword = userRepository.GetByPassword(userDTO.Password);

            if (userByUsername.Equals(userByPassword))
            {
                UserSession.User = userByUsername;
            }
            else
            {
                throw new Exception("User doesn't exist!");
            }

            return userByUsername.Type;
        }
    }
}
