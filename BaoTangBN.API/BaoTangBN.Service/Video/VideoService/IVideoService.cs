
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Service.VideoService
{
    public interface IVideoService
    {
        public IEnumerable<Video_ShowOnViewer> GetList(bool admin);
        public bool AddVideo(VideoDto VideoDto, string token);
        public bool XoaVideo(Guid ID_BaiCanXoa, string token);
        public bool EditVideo(Guid IDBaiCanSua, string token, VideoDto VideoDto);
        public string ShowDetails(Guid id);
    }
}
