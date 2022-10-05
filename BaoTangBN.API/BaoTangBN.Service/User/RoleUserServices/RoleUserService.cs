using AutoMapper;
using BaoTangBn.Data.Dtos;
using BaoTangBn.Repo.RoleUserRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Service.AuthUserServices
{
    public class RoleUserService : IRoleUserService
    {
        private IRoleUserRepository _repo;

        public RoleUserService(IRoleUserRepository authority)
        {
            _repo = authority;
        }
        public bool SetAuthUser(RoleUser authUser)
        {
            var temp = _repo.SetAuthUser(authUser);
            return temp;
        }
    }
}
