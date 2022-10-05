using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Common
{
    internal class Sample
    {
        //mẫu check số trang
        //public IActionResult GetAll(FilterBase filter)
        //{
        //    ResponseBase response = new ResponseBase();
        //    try
        //    {
        //        DateTime date = new DateTime(2022, 8, 22, 1, 1, 1);
        //        var users = new List<TinNoiBat>
        //        {
        //            new TinNoiBat { AnhMinhHoa = "okok1" ,NgayXoa = date.AddSeconds(1)},
        //            new TinNoiBat { AnhMinhHoa = "okok2" ,NgayXoa = date.AddSeconds(3)},
        //            new TinNoiBat { AnhMinhHoa = "okok4" ,NgayXoa = date.AddSeconds(2)},
        //            new TinNoiBat { AnhMinhHoa = "okok3" ,NgayXoa = date.AddSeconds(4)}
        //        };//_service.GetAll();
        //        users = users.FilerByField(filter.FilterField, filter.FilterText);
        //        users = users.SortByField(filter.SortBy, filter.SortField);
        //        response.Data = users.ConvertToPaging(filter.PageSize, filter.PageIndex);
        //    }
        //    catch
        //    {
        //        response.Code = ErrorCodeMessage.InternalExeption.Key;
        //        response.Message = ErrorCodeMessage.InternalExeption.Value;
        //    }
        //    return Ok(response);
        //}
    }
}
