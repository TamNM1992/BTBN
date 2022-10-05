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

namespace BaoTangBn.Repo.BaoVatQuocGiaRepo
{
    public class BaoVatQuocGiaRepository : IBaoVatQuocGiaRepository
    {
        private readonly BaoTangBNDataContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public BaoVatQuocGiaRepository(BaoTangBNDataContext context, IMapper mapper,IOptions<AppSettings> appSettings)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        public IEnumerable<BaoVatQuocGia> GetAll()
        {

            var temp = _context.BaoVatQuocGia;
   
            return temp;
        }
        public List<BaoVatQuocGia> GetRelated()
        {
            var temp = _context.BaoVatQuocGia.ToList();
            temp.RemoveAll(x => x.TrangThaiXuatBan == false);
            temp.RemoveAll(x => x.DaXoa == true);
            return temp;
        }

        public string UploadImg()
        {
            string x = "y";
            return x;
        }
        public bool AddBaoVatQuocGia(BaoVatQuocGia BaoVatQuocGia)
        {
            try
            {
                _context.BaoVatQuocGia.Add(BaoVatQuocGia);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool XoaBaoVatQuocGia(Guid IDBaiCanXoa, Guid IDNguoiXoa)
        {
            try
            {
                var temp = _context.BaoVatQuocGia.FirstOrDefault(x=> x.ID == IDBaiCanXoa);
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
        public bool EditBaoVatQuocGia(Guid IDBaiCanSua, Guid IDNguoiSua, BaoVatQuocGiaDto BaoVatQuocGiaDto)
        {
            try
            {
                var temp = _context.BaoVatQuocGia.FirstOrDefault(x => x.ID == IDBaiCanSua);
                if (temp != null)
                {
                    temp.IDNguoiSua = IDNguoiSua;
                    temp.NgaySua = DateTime.UtcNow;
                    temp.Ten = BaoVatQuocGiaDto.Ten;
                    temp.TrangThaiXuatBan = BaoVatQuocGiaDto.TrangThaiXuatBan;
                    temp.Nguon = BaoVatQuocGiaDto.Nguon;
                    temp.AnhMinhHoa = BaoVatQuocGiaDto.AnhMinhHoa;
                    temp.TieuDe = BaoVatQuocGiaDto.TieuDe;
                    temp.NoiDung = BaoVatQuocGiaDto.NoiDung;
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public BaoVatQuocGia_Detail ShowDetails(Guid id)
        {
            BaoVatQuocGia_Detail BaoVatQuocGia_Detail = new BaoVatQuocGia_Detail();

            var _BaoVatQuocGia = _context.BaoVatQuocGia.SingleOrDefault(x => x.ID == id);
            if (_BaoVatQuocGia != null)
            {
                if (_BaoVatQuocGia.DaXoa == true)
                {
                    return BaoVatQuocGia_Detail;
                }
                BaoVatQuocGia_Detail.NoiDung = _BaoVatQuocGia.NoiDung;
                BaoVatQuocGia_Detail.Nguon = _BaoVatQuocGia.Nguon;
                BaoVatQuocGia_Detail.NgayTao = _BaoVatQuocGia.NgayTao;
            }
            return BaoVatQuocGia_Detail;
        }
    }
}
