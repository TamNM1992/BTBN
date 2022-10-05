
using BaoTangBn.Common.Enums;
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Repo.UserRepo
{
    public interface IUserRepository
    {
        public AuthenticateResponse Authenticate(AuthenticateRequest model);
        public IEnumerable<User> GetAll();
        public User GetById(Guid id);
        public User GetByUserName(string username);
        public bool AddUser(UserDto user);
        public ActiveResponse GetPasswordHash(string userName);
        public ActiveResponse GetPasswordSalt(string userName);

    }
}
