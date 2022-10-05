using AutoMapper;
using BaoTangBn.Common.Extensions;
using BaoTangBn.Common.Models;

using BaoTangBn.Service.AlbumService;
using Microsoft.AspNetCore.Mvc;

namespace BaoTangBn.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Album_ViewerController : ControllerBase
    {
        private IAlbumService _AlbumService;
        private readonly IMapper _mapper;
        public Album_ViewerController(IAlbumService AlbumService, IMapper mapper)
        {
            _AlbumService = AlbumService;
            _mapper = mapper;
        }


        [HttpPost("GetList")]
        public IActionResult GetListAndPaging(FilterBase filter)
        {
            ResponseBase response = new ResponseBase();
            try
            {
                var temp = _AlbumService.GetList(false).ToList();
                response.Count = temp.Count;
                if (temp != null)
                {
                    if (filter.SortField == null)
                    {
                        temp.SortByField("asc", "NgayTao");
                    }
                    else
                    {
                        temp.SortByField(filter.SortBy, filter.SortField);
                    }

                    response.Data = temp.ConvertToPaging(filter.PageSize, filter.PageIndex).Items;

                }
                else
                {
                    response.Code = ErrorCodeMessage.ListNull.Key;
                    response.Message = ErrorCodeMessage.ListNull.Value;
                }

            }
            catch
            {
                response.Code = ErrorCodeMessage.InternalExeption.Key;
                response.Message = ErrorCodeMessage.InternalExeption.Value;
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("ShowDetails")]
        public IActionResult ShowDetails(Guid ID)
        {
            ResponseBase response = new ResponseBase();
            try
            {
                var temp = _AlbumService.ShowDetails(ID);
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
