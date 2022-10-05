
using BaoTangBn.Data.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaoTangBn.Common.Enums;

namespace BaoTangBn.Service.AuthorityServices
{
    public interface IRoleService
    {
        public bool AddAuthority(RoleDto authorityDto);
        bool CheckUserRole(Role[] roles, Guid userId);
    }
}
