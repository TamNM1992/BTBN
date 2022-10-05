using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using BaoTangBn.Repo.UserRepo;

using System;
using System.Collections.Generic;



namespace BaoTangBn.Service.UserService
{

    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public bool AddUser(UserDto user)
        {
            var temp = _userRepository.AddUser(user);
            return temp;
        }

        public AuthenticateResponse ValidateAccount(string userName, string password)
        {
            try
            {
                User user = new User();
                user.UserName = userName;
                string salt = _userRepository.GetPasswordSalt(userName).value;
                string hashPass = BCrypt.Net.BCrypt.HashPassword(password,salt);
                string pass = _userRepository.GetPasswordHash(userName).value;
                if(pass == hashPass)
                {
                    AuthenticateResponse response1 = new AuthenticateResponse(user, null,"Authen pass");
                    return response1;

                }
                AuthenticateResponse response2 = new AuthenticateResponse(user, null,"Authen fail");
                return response2;
            }
            catch (Exception ex)
            {
                User user = new User();
                user.UserName = userName;
                AuthenticateResponse response = new AuthenticateResponse(user, null, $"exception {_userRepository.GetPasswordSalt(userName).status} {_userRepository.GetPasswordHash(userName).status}");
                return response;
            }
        }
        
        public AuthenticateResponse Authenticate(AuthenticateRequest user)
        {
            var response = ValidateAccount(user.UserName, user.Password);
            if (response.Status == "Authen pass")
            {
                var temp = _userRepository.Authenticate(user);

                return temp;
            }

            return response;
        }

        public IEnumerable<User> GetAll()
        {
            var temp = _userRepository.GetAll();
            return temp;
        }

        public User GetById(Guid id)
        {
            var temp = _userRepository.GetById(id);
            return temp;
        }

        public User GetByUserName(string username)
        {
            var temp = _userRepository.GetByUserName(username);
            return temp;
        }


    }
}