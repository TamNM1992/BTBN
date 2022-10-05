using BaoTangBn.Data.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Service.AuthUserServices
{
    public interface IRoleUserService
    {
        public bool SetAuthUser(RoleUser authUser);
    }
}
