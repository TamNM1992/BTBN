
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Service.UserService
{
    public interface IUserService
    {
            AuthenticateResponse Authenticate(AuthenticateRequest model);
            IEnumerable<User> GetAll();
            User GetById(Guid id);
        public User GetByUserName(string username);
            public bool AddUser(UserDto user);
            public AuthenticateResponse ValidateAccount(string userName, string password);
    }
}
