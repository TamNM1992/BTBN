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

namespace BaoTangBn.Repo.CongTacSuuTamRepo
{
    public class CongTacSuuTamRepository : ICongTacSuuTamRepository
    {
        private readonly BaoTangBNDataContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public CongTacSuuTamRepository(BaoTangBNDataContext context, IMapper mapper,IOptions<AppSettings> appSettings)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        public IEnumerable<CongTacSuuTam> GetAll()
        {

            var temp = _context.CongTacSuuTam;
   
            return temp;
        }
        public List<CongTacSuuTam> GetRelated()
        {
            var temp = _context.CongTacSuuTam.ToList();
            temp.RemoveAll(x => x.TrangThaiXuatBan == false);
            temp.RemoveAll(x => x.DaXoa == true);
            return temp;
        }

        public string UploadImg()
        {
            string x = "y";
            return x;
        }
        public bool AddCongTacSuuTam(CongTacSuuTam CongTacSuuTam)
        {
            try
            {
                _context.CongTacSuuTam.Add(CongTacSuuTam);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool XoaCongTacSuuTam(Guid IDBaiCanXoa, Guid IDNguoiXoa)
        {
            try
            {
                var temp = _context.CongTacSuuTam.FirstOrDefault(x=> x.ID == IDBaiCanXoa);
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
        public bool EditCongTacSuuTam(Guid IDBaiCanSua, Guid IDNguoiSua, CongTacSuuTamDto CongTacSuuTamDto)
        {
            try
            {
                var temp = _context.CongTacSuuTam.FirstOrDefault(x => x.ID == IDBaiCanSua);
                if (temp != null)
                {
                    temp.IDNguoiSua = IDNguoiSua;
                    temp.NgaySua = DateTime.UtcNow;
                    temp.Ten = CongTacSuuTamDto.Ten;
                    temp.TrangThaiXuatBan = CongTacSuuTamDto.TrangThaiXuatBan;
                    temp.Nguon = CongTacSuuTamDto.Nguon;
                    temp.AnhMinhHoa = CongTacSuuTamDto.AnhMinhHoa;
                    temp.TieuDe = CongTacSuuTamDto.TieuDe;
                    temp.NoiDung = CongTacSuuTamDto.NoiDung;
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public CongTacSuuTam_Detail ShowDetails(Guid id)
        {
            CongTacSuuTam_Detail CongTacSuuTam_Detail = new CongTacSuuTam_Detail();

            var _CongTacSuuTam = _context.CongTacSuuTam.SingleOrDefault(x => x.ID == id);
            if (_CongTacSuuTam != null)
            {
                if (_CongTacSuuTam.DaXoa == true)
                {
                    return CongTacSuuTam_Detail;
                }
                CongTacSuuTam_Detail.NoiDung = _CongTacSuuTam.NoiDung;
                CongTacSuuTam_Detail.Nguon = _CongTacSuuTam.Nguon;
                CongTacSuuTam_Detail.NgayTao = _CongTacSuuTam.NgayTao;
            }
            return CongTacSuuTam_Detail;
        }
    }
}
