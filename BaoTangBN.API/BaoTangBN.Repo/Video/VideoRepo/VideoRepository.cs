using AutoMapper;
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BaoTangBn.Common.Extensions;
using BaoTangBn.Common.Models;

namespace BaoTangBn.Repo.VideoRepo
{
    public class VideoRepository : IVideoRepository
    {
        private readonly BaoTangBNDataContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public VideoRepository(BaoTangBNDataContext context, IMapper mapper,IOptions<AppSettings> appSettings)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        public IEnumerable<Video> GetAll()
        {

            var temp = _context.Video;
   
            return temp;
        }

        public bool AddVideo(Video Video)
        {
            try
            {
                _context.Video.Add(Video);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool XoaVideo(Guid ID_bai_can_xoa, Guid ID_nguoi_xoa)
        {
            try
            {
                var temp = _context.Video.FirstOrDefault(x=> x.ID == ID_bai_can_xoa);
                if (temp != null)
                {
                    temp.DaXoa = true;
                    temp.IDNguoiXoa = ID_nguoi_xoa;
                    temp.NgayXoa = DateTime.UtcNow;
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool EditVideo(Guid IDBaiCanSua, Guid IDNguoiSua, VideoDto VideoDto)
        {
            try
            {
                var temp = _context.Video.FirstOrDefault(x => x.ID == IDBaiCanSua);
                if (temp != null)
                {
                    temp.IDNguoiSua = IDNguoiSua;
                    temp.NgaySua = DateTime.UtcNow;
                    temp.Ten = VideoDto.Ten;
                    temp.AnhMinhHoa = VideoDto.AnhMinhHoa;
                    temp.MaVideo = VideoDto.MaVideo;
                    temp.MoTa = VideoDto.MoTa;
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public string ShowDetails(Guid id)
        {
            try
            {

                var _Video = _context.Video.SingleOrDefault(x => x.ID == id);
                if(_Video.DaXoa == true)
                {
                    return " Tin đã bị xóa";
                }    
                return _Video.MaVideo;

            }
            catch (Exception ex)
            {
                return "Không có bài viết này";
            }
        }
    }
}
