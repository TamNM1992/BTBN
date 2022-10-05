using AutoMapper;
using BaoTangBn.Common.Extensions;
using BaoTangBn.Common.Models;
using BaoTangBn.Service.TrungBayChuyenDeService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaoTangBn.API.Controllers.TrungBay
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrungBayChuyenDe_ViewerController : ControllerBase
    {
        private ITrungBayChuyenDeService _TrungBayChuyenDeService;
        private readonly IMapper _mapper;
        public TrungBayChuyenDe_ViewerController(ITrungBayChuyenDeService TrungBayChuyenDeService, IMapper mapper)
        {
            _TrungBayChuyenDeService = TrungBayChuyenDeService;
            _mapper = mapper;
        }


        [HttpPost("GetList")]
        public IActionResult GetListAndPaging(FilterBase filter)
        {
            ResponseBase response = new ResponseBase();
            try
            {
                var temp = _TrungBayChuyenDeService.GetList(false).ToList();
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

        [HttpPost("ListRelated")]
        public IActionResult GetRelated(Guid IDBaiViet, int pre_count, int next_count)
        {
            ResponseBase response = new ResponseBase();
            try
            {
                var temp = _TrungBayChuyenDeService.GetRelated(IDBaiViet, pre_count, next_count).ToList();
                temp.RemoveAll(x => x == null);

                if (temp != null)
                {

                    response.Data = temp;

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
                var temp = _TrungBayChuyenDeService.ShowDetails(ID);
                if (temp != null && temp.NoiDung != null)
                {

                    response.Data = temp;
                }
                else
                if (temp.NoiDung == null)
                {
                    response.Code = ErrorCodeMessage.NoObject.Key;
                    response.Message = ErrorCodeMessage.NoObject.Value;
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
