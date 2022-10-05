using BaoTangBn.Data.Dtos;
using BaoTangBn.Service.AuthorityServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BaoTangBn.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private IRoleService _Service;

        public RoleController(IRoleService authorityService)
        {
            _Service = authorityService;
        }
        [HttpPost]
        [Route("add")]

        public string AddAuthority(RoleDto authorityDto)
        {
            var temp = _Service.AddAuthority(authorityDto);
            var json = JsonConvert.SerializeObject(temp);
            return json;
        }
    }
}
