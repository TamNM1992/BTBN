using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Repo.VideoRepo
{
    public interface IVideoRepository
    {
        public IEnumerable<Video> GetAll();
        public bool AddVideo(Video Video);
        public bool XoaVideo(Guid IDBaiCanXoa, Guid IDNguoiXoa);
        public bool EditVideo(Guid IDBaiCanSua, Guid IDNguoiSua, VideoDto VideoDto);
        public string ShowDetails(Guid id);
        
    }
}
