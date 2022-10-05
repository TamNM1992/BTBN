using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace uploadFilesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[Action]")]
    public class UploadFileController : ControllerBase
    {
        IWebHostEnvironment _webHost;
        public UploadFileController(IWebHostEnvironment webHost)
        {
            _webHost = webHost;
        }

        public class ResponseData
        {
            public string status { get; set; }
            public string message { get; set; }
            public string data { get; set; }
        }
        public class FileUploadInfo
        {
            public string filename { get; set; }
            public long filesize { get; set; }
            public string prettyFileSize
            {
                get
                {
                    return BytesToReadableValue(this.filesize);
                }
            }

            public string BytesToReadableValue(long number)
            {
                var suffixes = new List<string> { " B", " KB", " MB", " GB", " TB", " PB" };

                for (int i = 0; i < suffixes.Count; i++)
                {
                    long temp = number / (int)Math.Pow(1024, i + 1);

                    if (temp == 0)
                    {
                        return (number / (int)Math.Pow(1024, i)) + suffixes[i];
                    }
                }

                return number.ToString();
            }
        }

        [HttpPost]
        public async Task<IActionResult> UploadFileAsync(List<IFormFile> file, Guid IDBaiViet)
        {
            const bool AllowLimitSize = true;
            const bool AllowLimitFileType = true;

            var limitFileSize = 2097152; // allow upload file less 2MB = 2097152
            var listFileError = new List<FileUploadInfo>();
            var responseData = new ResponseData();
            string result = "";

            if(file.Count <= 0)
            {
                responseData.status = "ERROR";
                responseData.message = $"Please, select file to upload.";                
                result = JsonConvert.SerializeObject(responseData);
                return Ok(result);
            }

            var listFileTypeAllow = "jpg|png|gif|xls|xlsx";
            // check file type upload allow
            if (AllowLimitFileType)
            {
                foreach (var formFile in file)
                {
                    var file_ext = Path.GetExtension(formFile.FileName).Replace(".", "");
                    var isAllow = listFileTypeAllow.Split('|').Any(x => x.ToLower() == file_ext.ToLower());
                    if (!isAllow)
                    {
                        listFileError.Add(new FileUploadInfo()
                        {
                            filename = formFile.FileName,
                            filesize = formFile.Length
                        });
                    }

                }
            }
           

            if (listFileError.Count > 0)
            {
                responseData.status = "ERROR";
                responseData.data = JsonConvert.SerializeObject(listFileError);
                responseData.message = $"File type upload only Allow Type: ({listFileTypeAllow}) \r\n {responseData.data}";
                result = JsonConvert.SerializeObject(responseData);
                return Ok(result);
            }


            // check list file less limit size
            if (AllowLimitSize)
            {
                foreach (var formFile in file)
                {
                    if (formFile.Length > limitFileSize)
                    {
                        listFileError.Add(new FileUploadInfo()
                        {
                            filename = formFile.FileName,
                            filesize = formFile.Length
                        });
                    }
                }
            }
           

            var listLinkUploaded = new List<string>();

            if (listFileError.Count > 0)
            {
                responseData.status = "ERROR";
                responseData.data = JsonConvert.SerializeObject(listFileError);
                responseData.message = $"File upload must less 2MB ({ responseData.data})";
                result = JsonConvert.SerializeObject(responseData);
                return Ok(result);
            }

            string baseUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            foreach (var formFile in file)
            {

                if (formFile.Length > 0)
                {

                    var time = DateTime.UtcNow;
                    var timestring = $"{time}";

                    string[] charsToRemove = new string[] { "@", ",", ".", ";", "'", "/", ":", " " };
                    foreach (var c in charsToRemove)
                    {
                        timestring = timestring.Replace(c, string.Empty);
                    }
                    var templateUrl = Path.GetExtension(formFile.FileName).Replace(".", $"{IDBaiViet}{timestring}.");

                    //var templateUrl = formFile.FileName ;
                    string filePath = Path.Combine($"{_webHost.WebRootPath}/uploads/", templateUrl);
                    string fileName = Path.GetFileName(filePath);

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                    listLinkUploaded.Add($"{baseUrl}/uploads/{templateUrl}");
                }
            }

            responseData.status = "SUCCESS";
            responseData.data = JsonConvert.SerializeObject(listLinkUploaded);
            responseData.message = $"uploaded {file.Count} files successful.";
            result = JsonConvert.SerializeObject(responseData);

            return Ok(result);
        }
    }


}
