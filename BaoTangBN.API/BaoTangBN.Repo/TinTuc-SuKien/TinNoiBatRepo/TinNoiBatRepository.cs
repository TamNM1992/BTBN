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

namespace BaoTangBn.Repo.TinNoiBatRepo
{
    public class TinNoiBatRepository : ITinNoiBatRepository
    {
        private readonly BaoTangBNDataContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public TinNoiBatRepository(BaoTangBNDataContext context, IMapper mapper,IOptions<AppSettings> appSettings)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        public IEnumerable<TinNoiBat> GetAll()
        {

            var temp = _context.TinNoiBat;
   
            return temp;
        }
        public List<TinNoiBat> GetRelated()
        {
            var temp = _context.TinNoiBat.ToList();
            temp.RemoveAll(x => x.TrangThaiXuatBan == false);
            temp.RemoveAll(x => x.DaXoa == true);
            return temp;
        }

        public string UploadImg()
        {
            string x = "y";
            return x;
        }
        public bool AddTinNoiBat(TinNoiBat tinNoiBat)
        {
            try
            {
                _context.TinNoiBat.Add(tinNoiBat);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool XoaTinNoiBat(Guid IDBaiCanXoa, Guid IDNguoiXoa)
        {
            try
            {
                var temp = _context.TinNoiBat.FirstOrDefault(x=> x.ID == IDBaiCanXoa);
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
        public bool EditTinNoiBat(Guid IDBaiCanSua, Guid IDNguoiSua, TinNoiBatDto tinNoiBatDto)
        {
            try
            {
                var temp = _context.TinNoiBat.FirstOrDefault(x => x.ID == IDBaiCanSua);
                if (temp != null)
                {
                    temp.IDNguoiSua = IDNguoiSua;
                    temp.NgaySua = DateTime.UtcNow;
                    temp.Ten = tinNoiBatDto.Ten;
                    temp.TrangThaiXuatBan = tinNoiBatDto.TrangThaiXuatBan;
                    temp.Nguon = tinNoiBatDto.Nguon;
                    temp.AnhMinhHoa = tinNoiBatDto.AnhMinhHoa;
                    temp.TieuDe = tinNoiBatDto.TieuDe;
                    temp.NoiDung = tinNoiBatDto.NoiDung;
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public TinNoiBat_Detail ShowDetails(Guid id)
        {
            TinNoiBat_Detail tinNoiBat_Detail = new TinNoiBat_Detail();

            var _tinNoiBat = _context.TinNoiBat.SingleOrDefault(x => x.ID == id);
            if (_tinNoiBat != null)
            {
                if (_tinNoiBat.DaXoa == true)
                {
                    return tinNoiBat_Detail;
                }
                tinNoiBat_Detail.NoiDung = _tinNoiBat.NoiDung;
                tinNoiBat_Detail.Nguon = _tinNoiBat.Nguon;
                tinNoiBat_Detail.NgayTao = _tinNoiBat.NgayTao;
            }
            return tinNoiBat_Detail;
        }
    }
}
