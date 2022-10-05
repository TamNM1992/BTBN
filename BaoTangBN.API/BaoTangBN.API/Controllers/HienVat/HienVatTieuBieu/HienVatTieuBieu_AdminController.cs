using BaoTangBn.API.Attributes;
using BaoTangBn.Common;
using BaoTangBn.Common.Extensions;
using BaoTangBn.Common.Models;
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using BaoTangBn.Service.HienVatTieuBieuService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaoTangBn.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HienVatTieuBieu_AdminController : ControllerBase
    {
        private IHienVatTieuBieuService _HienVatTieuBieuService;
        public HienVatTieuBieu_AdminController(IHienVatTieuBieuService HienVatTieuBieuService)
        {
            _HienVatTieuBieuService = HienVatTieuBieuService;
        }

        [HttpPost("GetList")]
        public IActionResult GetListAndPaging(FilterBase filter)
        {
            ResponseBase response = new ResponseBase();
            try
            {
                var temp = _HienVatTieuBieuService.GetList(true).ToList();
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
        public IActionResult AddHienVatTieuBieu([FromBody] HienVatTieuBieuDto HienVatTieuBieuDto)
        {
            ResponseBase response = new ResponseBase();
            try
            {
                var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                var temp = _HienVatTieuBieuService.AddHienVatTieuBieu(HienVatTieuBieuDto, token);
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
        public IActionResult DeleteHienVatTieuBieu(Guid IdBaiCanXoa)
        {
            ResponseBase response = new ResponseBase();
            try
            {
                var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                var temp = _HienVatTieuBieuService.XoaHienVatTieuBieu(IdBaiCanXoa, token);
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
                var temp = _HienVatTieuBieuService.SearchByTenAndTieuDe(keyWord).ToList();
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
        public IActionResult EditHienVatTieuBieu(Guid IdBaiCanSua, [FromBody] HienVatTieuBieuDto HienVatTieuBieuDto)
        {
            ResponseBase response = new ResponseBase();
            try
            {
                var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                var temp = _HienVatTieuBieuService.EditHienVatTieuBieu(IdBaiCanSua, token, HienVatTieuBieuDto);
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
