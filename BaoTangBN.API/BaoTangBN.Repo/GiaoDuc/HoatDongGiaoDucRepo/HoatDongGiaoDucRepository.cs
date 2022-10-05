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

namespace BaoTangBn.Repo.HoatDongGiaoDucRepo
{
    public class HoatDongGiaoDucRepository : IHoatDongGiaoDucRepository
    {
        private readonly BaoTangBNDataContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public HoatDongGiaoDucRepository(BaoTangBNDataContext context, IMapper mapper,IOptions<AppSettings> appSettings)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        public IEnumerable<HoatDongGiaoDuc> GetAll()
        {

            var temp = _context.HoatDongGiaoDuc;
   
            return temp;
        }
        public List<HoatDongGiaoDuc> GetRelated()
        {
            var temp = _context.HoatDongGiaoDuc.ToList();
            temp.RemoveAll(x => x.TrangThaiXuatBan == false);
            temp.RemoveAll(x => x.DaXoa == true);
            return temp;
        }

        public string UploadImg()
        {
            string x = "y";
            return x;
        }
        public bool AddHoatDongGiaoDuc(HoatDongGiaoDuc HoatDongGiaoDuc)
        {
            try
            {
                _context.HoatDongGiaoDuc.Add(HoatDongGiaoDuc);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool XoaHoatDongGiaoDuc(Guid IDBaiCanXoa, Guid IDNguoiXoa)
        {
            try
            {
                var temp = _context.HoatDongGiaoDuc.FirstOrDefault(x=> x.ID == IDBaiCanXoa);
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
        public bool EditHoatDongGiaoDuc(Guid IDBaiCanSua, Guid IDNguoiSua, HoatDongGiaoDucDto HoatDongGiaoDucDto)
        {
            try
            {
                var temp = _context.HoatDongGiaoDuc.FirstOrDefault(x => x.ID == IDBaiCanSua);
                if (temp != null)
                {
                    temp.IDNguoiSua = IDNguoiSua;
                    temp.NgaySua = DateTime.UtcNow;
                    temp.Ten = HoatDongGiaoDucDto.Ten;
                    temp.TrangThaiXuatBan = HoatDongGiaoDucDto.TrangThaiXuatBan;
                    temp.Nguon = HoatDongGiaoDucDto.Nguon;
                    temp.AnhMinhHoa = HoatDongGiaoDucDto.AnhMinhHoa;
                    temp.TieuDe = HoatDongGiaoDucDto.TieuDe;
                    temp.NoiDung = HoatDongGiaoDucDto.NoiDung;
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public HoatDongGiaoDuc_Detail ShowDetails(Guid id)
        {
            HoatDongGiaoDuc_Detail HoatDongGiaoDuc_Detail = new HoatDongGiaoDuc_Detail();

            var _HoatDongGiaoDuc = _context.HoatDongGiaoDuc.SingleOrDefault(x => x.ID == id);
            if (_HoatDongGiaoDuc != null)
            {
                if (_HoatDongGiaoDuc.DaXoa == true)
                {
                    return HoatDongGiaoDuc_Detail;
                }
                HoatDongGiaoDuc_Detail.NoiDung = _HoatDongGiaoDuc.NoiDung;
                HoatDongGiaoDuc_Detail.Nguon = _HoatDongGiaoDuc.Nguon;
                HoatDongGiaoDuc_Detail.NgayTao = _HoatDongGiaoDuc.NgayTao;
            }
            return HoatDongGiaoDuc_Detail;
        }
    }
}
