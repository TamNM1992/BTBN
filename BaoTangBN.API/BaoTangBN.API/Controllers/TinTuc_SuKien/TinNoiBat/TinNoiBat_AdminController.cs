using BaoTangBn.API.Attributes;
using BaoTangBn.Common;
using BaoTangBn.Common.Extensions;
using BaoTangBn.Common.Models;
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using BaoTangBn.Service.TinNoiBatService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaoTangBn.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TinNoiBat_AdminController : ControllerBase
    {
        private ITinNoiBatService _tinNoiBatService;
        private IHttpClientFactory _factory;
        private MyTypedClient _client;
        public TinNoiBat_AdminController(ITinNoiBatService tinNoiBatService, IHttpClientFactory factory, MyTypedClient client)
        {
            _tinNoiBatService = tinNoiBatService;
            _factory = factory;
            _client = client;
        }

        //[Role(Common.Enums.Role.Boss)]
        //[HttpPost("UploadImg")]
        //public IActionResult UploadImage(List<IFormFile> img)
        //{
        //    var temp = _client.PostImgAndGetData(img);
        //    return Ok();
        //}

        [Role(Common.Enums.Role.Boss)]
        [HttpPost("GetList")]
        public IActionResult GetListAndPaging(FilterBase filter)
        {
            ResponseBase response = new ResponseBase();
            try
            {
                var temp = _tinNoiBatService.GetList(true).ToList();
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
        [Role(Common.Enums.Role.Boss)]
        [Route("Add")]
        public IActionResult AddTinNoiBat([FromBody]TinNoiBatDto tinNoiBatDto) 
        {
            ResponseBase response = new ResponseBase();
            try
            {
                
                var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                var temp = _tinNoiBatService.AddTinNoiBat(tinNoiBatDto, token);
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
        [HttpDelete]
        [Role(Common.Enums.Role.Boss)]
        [Route("Delete")]
        public IActionResult DeleteTinNoiBat(Guid IdBaiCanXoa)
        {
            ResponseBase response = new ResponseBase();
            try
            {
                var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                var temp = _tinNoiBatService.XoaTinNoiBat(IdBaiCanXoa, token);
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

        [HttpGet]
        [Role(Common.Enums.Role.Boss)]
        [Route("Search")]
        public IActionResult SearchByTenAndTieuDe(string keyWord, FilterBase filter)
        {
            ResponseBase response = new ResponseBase();
            try
            {
                var temp = _tinNoiBatService.SearchByTenAndTieuDe(keyWord).ToList();
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

        [HttpPut]
        [Role(Common.Enums.Role.Boss)]
        [Route("Edit")]
        public IActionResult EditTinNoiBat(Guid IdBaiCanSua ,[FromBody] TinNoiBatDto tinNoiBatDto)
        {
            ResponseBase response = new ResponseBase();
            try
            {
                var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                var temp = _tinNoiBatService.EditTinNoiBat(IdBaiCanSua, token, tinNoiBatDto);
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

        [HttpGet]
        [Route("GetID")]
        public IActionResult GetID()
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            return Ok(General.GetIDInToken(token));
        }
    }
}
