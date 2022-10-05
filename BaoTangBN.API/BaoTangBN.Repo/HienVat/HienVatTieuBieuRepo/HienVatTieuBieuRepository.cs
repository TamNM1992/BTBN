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

namespace BaoTangBn.Repo.HienVatTieuBieuRepo
{
    public class HienVatTieuBieuRepository : IHienVatTieuBieuRepository
    {
        private readonly BaoTangBNDataContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public HienVatTieuBieuRepository(BaoTangBNDataContext context, IMapper mapper,IOptions<AppSettings> appSettings)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        public IEnumerable<HienVatTieuBieu> GetAll()
        {

            var temp = _context.HienVatTieuBieu;
   
            return temp;
        }
        public List<HienVatTieuBieu> GetRelated()
        {
            var temp = _context.HienVatTieuBieu.ToList();
            temp.RemoveAll(x => x.TrangThaiXuatBan == false);
            temp.RemoveAll(x => x.DaXoa == true);
            return temp;
        }

        public string UploadImg()
        {
            string x = "y";
            return x;
        }
        public bool AddHienVatTieuBieu(HienVatTieuBieu HienVatTieuBieu)
        {
            try
            {
                _context.HienVatTieuBieu.Add(HienVatTieuBieu);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool XoaHienVatTieuBieu(Guid IDBaiCanXoa, Guid IDNguoiXoa)
        {
            try
            {
                var temp = _context.HienVatTieuBieu.FirstOrDefault(x=> x.ID == IDBaiCanXoa);
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
        public bool EditHienVatTieuBieu(Guid IDBaiCanSua, Guid IDNguoiSua, HienVatTieuBieuDto HienVatTieuBieuDto)
        {
            try
            {
                var temp = _context.HienVatTieuBieu.FirstOrDefault(x => x.ID == IDBaiCanSua);
                if (temp != null)
                {
                    temp.IDNguoiSua = IDNguoiSua;
                    temp.NgaySua = DateTime.UtcNow;
                    temp.Ten = HienVatTieuBieuDto.Ten;
                    temp.TrangThaiXuatBan = HienVatTieuBieuDto.TrangThaiXuatBan;
                    temp.Nguon = HienVatTieuBieuDto.Nguon;
                    temp.AnhMinhHoa = HienVatTieuBieuDto.AnhMinhHoa;
                    temp.TieuDe = HienVatTieuBieuDto.TieuDe;
                    temp.NoiDung = HienVatTieuBieuDto.NoiDung;
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public HienVatTieuBieu_Detail ShowDetails(Guid id)
        {
            HienVatTieuBieu_Detail HienVatTieuBieu_Detail = new HienVatTieuBieu_Detail();

            var _HienVatTieuBieu = _context.HienVatTieuBieu.SingleOrDefault(x => x.ID == id);
            if (_HienVatTieuBieu != null)
            {
                if (_HienVatTieuBieu.DaXoa == true)
                {
                    return HienVatTieuBieu_Detail;
                }
                HienVatTieuBieu_Detail.NoiDung = _HienVatTieuBieu.NoiDung;
                HienVatTieuBieu_Detail.Nguon = _HienVatTieuBieu.Nguon;
                HienVatTieuBieu_Detail.NgayTao = _HienVatTieuBieu.NgayTao;
            }
            return HienVatTieuBieu_Detail;
        }
    }
}
