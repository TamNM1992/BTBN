using AutoMapper;
using BaoTangBn.Common.Extensions;
using BaoTangBn.Common.Models;
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using BaoTangBn.Service.ThoiGianMoCuaService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaoTangBn.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThoiGianMoCua_ViewerController : ControllerBase
    {
        private IThoiGianMoCuaService _ThoiGianMoCuaService;
        private readonly IMapper _mapper;
        public ThoiGianMoCua_ViewerController(IThoiGianMoCuaService ThoiGianMoCuaService, IMapper mapper)
        {
            _ThoiGianMoCuaService = ThoiGianMoCuaService;
            _mapper = mapper;
        }


        
        [HttpPost]
        [Route("ShowDetails")]
        public IActionResult ShowDetails()
        {
            ResponseBase response = new ResponseBase();
            try
            {
                var temp = _ThoiGianMoCuaService.ShowDetails();
                if (temp != null)
                {
                    response.Data = temp;
                }
                else
                {
                    response.Code = ErrorCodeMessage.ObjectNull.Key;
                    response.Message = ErrorCodeMessage.ObjectNull.Value;
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
