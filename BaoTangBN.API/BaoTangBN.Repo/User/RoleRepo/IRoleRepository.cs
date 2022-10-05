
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using System;
using System.Collections.Generic;

namespace BaoTangBn.Repo.RoleRepo
{
    public interface IRoleRepository
    {
        public bool AddAuthority(RoleDto authority);
        IEnumerable<Role> GetAuthorityByUser(Guid user);
    }
}
