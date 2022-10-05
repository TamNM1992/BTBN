using AutoMapper;
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using Microsoft.Extensions.Options;

using System;
using System.Collections.Generic;
using System.Linq;

namespace BaoTangBn.Repo.RoleRepo
{
    public class RoleRepository : IRoleRepository
    {
        private readonly BaoTangBNDataContext _authorityContext;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public RoleRepository(BaoTangBNDataContext context, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _authorityContext = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        public bool AddAuthority(RoleDto authority)
        {
            var temp = _authorityContext.Role.FirstOrDefault(x=> x.Code == authority.Code);
            if (temp == null)
            {
                var authEntity = _mapper.Map<RoleDto, Role>(authority);
                _authorityContext.Add(authEntity);
                _authorityContext.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<Role> GetAuthorityByUser(Guid user)
        {
            var authorities = _authorityContext.User.Where(x => x.Id == user).SelectMany(x => x.Roles);
            return authorities;
        }

    }
}
