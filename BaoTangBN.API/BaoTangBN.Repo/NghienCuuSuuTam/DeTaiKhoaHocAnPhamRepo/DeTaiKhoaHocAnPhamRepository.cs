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

namespace BaoTangBn.Repo.DeTaiKhoaHocAnPhamRepo
{
    public class DeTaiKhoaHocAnPhamRepository : IDeTaiKhoaHocAnPhamRepository
    {
        private readonly BaoTangBNDataContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public DeTaiKhoaHocAnPhamRepository(BaoTangBNDataContext context, IMapper mapper,IOptions<AppSettings> appSettings)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        public IEnumerable<DeTaiKhoaHocAnPham> GetAll()
        {

            var temp = _context.DeTaiKhoaHocAnPham;
   
            return temp;
        }
        public List<DeTaiKhoaHocAnPham> GetRelated()
        {
            var temp = _context.DeTaiKhoaHocAnPham.ToList();
            temp.RemoveAll(x => x.TrangThaiXuatBan == false);
            temp.RemoveAll(x => x.DaXoa == true);
            return temp;
        }

        public string UploadImg()
        {
            string x = "y";
            return x;
        }
        public bool AddDeTaiKhoaHocAnPham(DeTaiKhoaHocAnPham DeTaiKhoaHocAnPham)
        {
            try
            {
                _context.DeTaiKhoaHocAnPham.Add(DeTaiKhoaHocAnPham);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool XoaDeTaiKhoaHocAnPham(Guid IDBaiCanXoa, Guid IDNguoiXoa)
        {
            try
            {
                var temp = _context.DeTaiKhoaHocAnPham.FirstOrDefault(x=> x.ID == IDBaiCanXoa);
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
        public bool EditDeTaiKhoaHocAnPham(Guid IDBaiCanSua, Guid IDNguoiSua, DeTaiKhoaHocAnPhamDto DeTaiKhoaHocAnPhamDto)
        {
            try
            {
                var temp = _context.DeTaiKhoaHocAnPham.FirstOrDefault(x => x.ID == IDBaiCanSua);
                if (temp != null)
                {
                    temp.IDNguoiSua = IDNguoiSua;
                    temp.NgaySua = DateTime.UtcNow;
                    temp.Ten = DeTaiKhoaHocAnPhamDto.Ten;
                    temp.TrangThaiXuatBan = DeTaiKhoaHocAnPhamDto.TrangThaiXuatBan;
                    temp.Nguon = DeTaiKhoaHocAnPhamDto.Nguon;
                    temp.AnhMinhHoa = DeTaiKhoaHocAnPhamDto.AnhMinhHoa;
                    temp.TieuDe = DeTaiKhoaHocAnPhamDto.TieuDe;
                    temp.NoiDung = DeTaiKhoaHocAnPhamDto.NoiDung;
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public DeTaiKhoaHocAnPham_Detail ShowDetails(Guid id)
        {
            DeTaiKhoaHocAnPham_Detail DeTaiKhoaHocAnPham_Detail = new DeTaiKhoaHocAnPham_Detail();

            var _DeTaiKhoaHocAnPham = _context.DeTaiKhoaHocAnPham.SingleOrDefault(x => x.ID == id);
            if (_DeTaiKhoaHocAnPham != null)
            {
                if (_DeTaiKhoaHocAnPham.DaXoa == true)
                {
                    return DeTaiKhoaHocAnPham_Detail;
                }
                DeTaiKhoaHocAnPham_Detail.NoiDung = _DeTaiKhoaHocAnPham.NoiDung;
                DeTaiKhoaHocAnPham_Detail.Nguon = _DeTaiKhoaHocAnPham.Nguon;
                DeTaiKhoaHocAnPham_Detail.NgayTao = _DeTaiKhoaHocAnPham.NgayTao;
            }
            return DeTaiKhoaHocAnPham_Detail;
        }
    }
}
