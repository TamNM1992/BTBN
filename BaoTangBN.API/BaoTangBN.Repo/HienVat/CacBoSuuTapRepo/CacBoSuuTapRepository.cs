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

namespace BaoTangBn.Repo.CacBoSuuTapRepo
{
    public class CacBoSuuTapRepository : ICacBoSuuTapRepository
    {
        private readonly BaoTangBNDataContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public CacBoSuuTapRepository(BaoTangBNDataContext context, IMapper mapper,IOptions<AppSettings> appSettings)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        public IEnumerable<CacBoSuuTap> GetAll()
        {

            var temp = _context.CacBoSuuTap;
   
            return temp;
        }
        public List<CacBoSuuTap> GetRelated()
        {
            var temp = _context.CacBoSuuTap.ToList();
            temp.RemoveAll(x => x.TrangThaiXuatBan == false);
            temp.RemoveAll(x => x.DaXoa == true);
            return temp;
        }

        public string UploadImg()
        {
            string x = "y";
            return x;
        }
        public bool AddCacBoSuuTap(CacBoSuuTap CacBoSuuTap)
        {
            try
            {
                _context.CacBoSuuTap.Add(CacBoSuuTap);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool XoaCacBoSuuTap(Guid IDBaiCanXoa, Guid IDNguoiXoa)
        {
            try
            {
                var temp = _context.CacBoSuuTap.FirstOrDefault(x=> x.ID == IDBaiCanXoa);
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
        public bool EditCacBoSuuTap(Guid IDBaiCanSua, Guid IDNguoiSua, CacBoSuuTapDto CacBoSuuTapDto)
        {
            try
            {
                var temp = _context.CacBoSuuTap.FirstOrDefault(x => x.ID == IDBaiCanSua);
                if (temp != null)
                {
                    temp.IDNguoiSua = IDNguoiSua;
                    temp.NgaySua = DateTime.UtcNow;
                    temp.Ten = CacBoSuuTapDto.Ten;
                    temp.TrangThaiXuatBan = CacBoSuuTapDto.TrangThaiXuatBan;
                    temp.Nguon = CacBoSuuTapDto.Nguon;
                    temp.AnhMinhHoa = CacBoSuuTapDto.AnhMinhHoa;
                    temp.TieuDe = CacBoSuuTapDto.TieuDe;
                    temp.NoiDung = CacBoSuuTapDto.NoiDung;
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public CacBoSuuTap_Detail ShowDetails(Guid id)
        {
            CacBoSuuTap_Detail CacBoSuuTap_Detail = new CacBoSuuTap_Detail();

            var _CacBoSuuTap = _context.CacBoSuuTap.SingleOrDefault(x => x.ID == id);
            if (_CacBoSuuTap != null)
            {
                if (_CacBoSuuTap.DaXoa == true)
                {
                    return CacBoSuuTap_Detail;
                }
                CacBoSuuTap_Detail.NoiDung = _CacBoSuuTap.NoiDung;
                CacBoSuuTap_Detail.Nguon = _CacBoSuuTap.Nguon;
                CacBoSuuTap_Detail.NgayTao = _CacBoSuuTap.NgayTao;
            }
            return CacBoSuuTap_Detail;
        }
    }
}
