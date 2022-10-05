using AutoMapper;
using BaoTangBn.Common.Enums;
using BaoTangBn.Data.Dtos;
using BaoTangBn.Repo.RoleRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Service.AuthorityServices
{
    public class RoleService : IRoleService
    {
        private IRoleRepository _roleRepository;
        private IMapper _mapper;

        public RoleService(IRoleRepository authority, IMapper mapper)
        {
            //  mình gọi thằng authority trong pipeline ra, gắn nó vào thằng _authorityRepository để dùng
            _roleRepository = authority;
            _mapper = mapper;
        }
        public bool AddAuthority(RoleDto authorityDto)
        {
            var temp = _roleRepository.AddAuthority(authorityDto);
            return temp;
        }
        public bool CheckUserRole(Role[] roles, Guid userId)
        {
            
            var roleByUsers = _roleRepository.GetAuthorityByUser(userId); 
            foreach(var roleByUser in roleByUsers)
            {
                Role role = (Role)Enum.Parse(typeof(Role), roleByUser.Code, true);

                if (roles.Contains(role))
                    return true;
            }
            return false;
        }
    }
}
