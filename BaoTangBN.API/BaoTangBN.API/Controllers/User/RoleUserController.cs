using BaoTangBn.API.Attributes;
using BaoTangBn.Data.Dtos;
using BaoTangBn.Service.AuthUserServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace BaoTangBn.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleUserController : ControllerBase
    {
        private IRoleUserService _Service;


        public RoleUserController(IRoleUserService userService)
        {
            _Service = userService;
        }
        [HttpPost]
        //[Role( Common.Enums.Role.Xem_Them_Sua_Xoa)]
        [Route("SetAuth")]
        public bool SetAuthUser(RoleUser authUser)
        {
            var temp = _Service.SetAuthUser(authUser);
            return temp;
        }
    }
}
