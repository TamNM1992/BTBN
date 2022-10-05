using BaoTangBn.API.Attributes;
using BaoTangBn.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaoTangBn.API.Common_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadImgController : ControllerBase
    {
        private IHttpClientFactory _factory;
        private MyTypedClient _client;
        public UploadImgController( IHttpClientFactory factory, MyTypedClient client)
        {
            _factory = factory;
            _client = client;
        }

        //[Role(Common.Enums.Role.Boss)]
        [HttpPost("UploadImg")]
        public IActionResult UploadImage(List<IFormFile> img, Guid IDBaiViet)
        {
            var temp = _client.PostImgAndGetData(img,IDBaiViet);
            return Ok(temp);
        }
    }
}
