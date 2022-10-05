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

namespace BaoTangBn.Repo.AlbumRepo
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly BaoTangBNDataContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public AlbumRepository(BaoTangBNDataContext context, IMapper mapper,IOptions<AppSettings> appSettings)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        public IEnumerable<Album> GetAll()
        {

            var temp = _context.Album;
   
            return temp;
        }

        public bool AddAlbum(Album Album)
        {
            try
            {
                _context.Album.Add(Album);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool XoaAlbum(Guid IDBaiCanXoa, Guid IDNguoiXoa)
        {
            try
            {
                var temp = _context.Album.FirstOrDefault(x=> x.ID == IDBaiCanXoa);
                if (temp != null)
                {
                    temp.DaXoa = true;
                    temp.IDNguoiXoa = IDNguoiXoa;
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
        public bool EditAlbum(Guid IDBaiCanSua, Guid IDNguoiSua, AlbumDto AlbumDto)
        {
            try
            {
                var temp = _context.Album.FirstOrDefault(x => x.ID == IDBaiCanSua);
                if (temp != null)
                {
                    temp.IDNguoiSua = IDNguoiSua;
                    temp.NgaySua = DateTime.UtcNow;
                    temp.Ten = AlbumDto.Ten;
                    temp.TrangThaiXuatBan = AlbumDto.TrangThaiXuatBan;
                    temp.Mota = AlbumDto.Mota;
                    temp.NoiDungAlbum = AlbumDto.NoiDungAlbum;
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

                var _Album = _context.Album.SingleOrDefault(x => x.ID == id);
                if(_Album.DaXoa == true)
                {
                    return " Tin đã bị xóa";
                }    
                return _Album.NoiDungAlbum;

            }
            catch (Exception ex)
            {
                return "Không có bài viết này";
            }
        }
    }
}
