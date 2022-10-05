using BaoTangBn.API.Attributes;
using BaoTangBn.Common;
using BaoTangBn.Common.Extensions;
using BaoTangBn.Common.Models;
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using BaoTangBn.Service.ChucNangNhiemVuService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaoTangBn.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ChucNangNhiemVu_AdminController : ControllerBase
    {
        private IChucNangNhiemVuService _ChucNangNhiemVuService;
        public ChucNangNhiemVu_AdminController(IChucNangNhiemVuService ChucNangNhiemVuService)
        {
            _ChucNangNhiemVuService = ChucNangNhiemVuService;
        }

        [HttpPost("GetList")]
        

        [HttpPut]
        [Role(Common.Enums.Role.Boss)]
        [Route("Edit")]
        public IActionResult EditChucNangNhiemVu( [FromBody] ChucNangNhiemVuDto ChucNangNhiemVuDto)
        {
            ResponseBase response = new ResponseBase();
            try
            {
                var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                var temp = _ChucNangNhiemVuService.EditChucNangNhiemVu( token, ChucNangNhiemVuDto);
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
