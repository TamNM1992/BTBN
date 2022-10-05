using AutoMapper;
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Repo.RoleUserRepo
{
    public class RoleUserRepository : IRoleUserRepository
    {
        private readonly BaoTangBNDataContext _authUserContext;
        private readonly IMapper _mapper;
        public RoleUserRepository(BaoTangBNDataContext context, IMapper mapper)
        {
            _authUserContext = context;
            _mapper = mapper;
        }

        public bool SetAuthUser(RoleUser authUser)
        {
            var utemp = _authUserContext.User.FirstOrDefault(x=> x.UserName == authUser.UserName);
            var atemp = _authUserContext.Role.FirstOrDefault(x=> x.Code == authUser.RoleCode);
            //var userEntity = _mapper.Map<UserDto, User>(user);
            //var authEntity = _mapper.Map<AuthorityDto, Authority>(authority);

            utemp.Roles.Add(atemp);
            atemp.Users.Add(utemp);

            _authUserContext.SaveChanges();
            return true;
        }
    }
}
