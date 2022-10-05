using AutoMapper;
using BaoTangBn.Common.Extensions;
using BaoTangBn.Common.Models;
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using BaoTangBn.Service.NoiQuyThamQuanService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaoTangBn.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoiQuyThamQuan_ViewerController : ControllerBase
    {
        private INoiQuyThamQuanService _NoiQuyThamQuanService;
        private readonly IMapper _mapper;
        public NoiQuyThamQuan_ViewerController(INoiQuyThamQuanService NoiQuyThamQuanService, IMapper mapper)
        {
            _NoiQuyThamQuanService = NoiQuyThamQuanService;
            _mapper = mapper;
        }


        
        [HttpPost]
        [Route("ShowDetails")]
        public IActionResult ShowDetails()
        {
            ResponseBase response = new ResponseBase();
            try
            {
                var temp = _NoiQuyThamQuanService.ShowDetails();
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
