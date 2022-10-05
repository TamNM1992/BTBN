using BaoTangBn.Data.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Repo.RoleUserRepo
{
    public interface IRoleUserRepository
    {
        public bool SetAuthUser(RoleUser authUser);
    }
}
