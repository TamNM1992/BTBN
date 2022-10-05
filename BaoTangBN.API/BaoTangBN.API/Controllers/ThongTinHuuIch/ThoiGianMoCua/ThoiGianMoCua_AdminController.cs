using BaoTangBn.API.Attributes;
using BaoTangBn.Common;
using BaoTangBn.Common.Extensions;
using BaoTangBn.Common.Models;
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using BaoTangBn.Service.ThoiGianMoCuaService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaoTangBn.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ThoiGianMoCua_AdminController : ControllerBase
    {
        private IThoiGianMoCuaService _ThoiGianMoCuaService;
        public ThoiGianMoCua_AdminController(IThoiGianMoCuaService ThoiGianMoCuaService)
        {
            _ThoiGianMoCuaService = ThoiGianMoCuaService;
        }

        [HttpPost("GetList")]
        

        [HttpPut]
        [Role(Common.Enums.Role.Boss)]
        [Route("Edit")]
        public IActionResult EditThoiGianMoCua( [FromBody] ThoiGianMoCuaDto ThoiGianMoCuaDto)
        {
            ResponseBase response = new ResponseBase();
            try
            {
                var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                var temp = _ThoiGianMoCuaService.EditThoiGianMoCua( token, ThoiGianMoCuaDto);
                if (temp == false)
                {
                    response.Code = ErrorCodeMessage.OperationFail.Key;
                    response.Message = ErrorCodeMessage.OperationFail.Value;
                }
            }
            catch
            {
                response.Code = ErrorCodeMessage.InternalExeption.Key;
                response.Message = ErrorCodeMessage.InternalExeption.Value;
            }
            return Ok(response);
        }

    }
}
