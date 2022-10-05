using BaoTangBn.API.Attributes;
using BaoTangBn.Common;
using BaoTangBn.Common.Extensions;
using BaoTangBn.Common.Models;
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using BaoTangBn.Service.NoiQuyThamQuanService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaoTangBn.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NoiQuyThamQuan_AdminController : ControllerBase
    {
        private INoiQuyThamQuanService _NoiQuyThamQuanService;
        public NoiQuyThamQuan_AdminController(INoiQuyThamQuanService NoiQuyThamQuanService)
        {
            _NoiQuyThamQuanService = NoiQuyThamQuanService;
        }

        [HttpPost("GetList")]
        

        [HttpPut]
        [Role(Common.Enums.Role.Boss)]
        [Route("Edit")]
        public IActionResult EditNoiQuyThamQuan( [FromBody] NoiQuyThamQuanDto NoiQuyThamQuanDto)
        {
            ResponseBase response = new ResponseBase();
            try
            {
                var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                var temp = _NoiQuyThamQuanService.EditNoiQuyThamQuan( token, NoiQuyThamQuanDto);
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
