using AutoMapper;
using BaoTangBn.Common.Extensions;
using BaoTangBn.Common.Models;
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using BaoTangBn.Service.CoCauToChucService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaoTangBn.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoCauToChuc_ViewerController : ControllerBase
    {
        private ICoCauToChucService _CoCauToChucService;
        private readonly IMapper _mapper;
        public CoCauToChuc_ViewerController(ICoCauToChucService CoCauToChucService, IMapper mapper)
        {
            _CoCauToChucService = CoCauToChucService;
            _mapper = mapper;
        }


        
        [HttpPost]
        [Route("ShowDetails")]
        public IActionResult ShowDetails()
        {
            ResponseBase response = new ResponseBase();
            try
            {
                var temp = _CoCauToChucService.ShowDetails();
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
