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

namespace BaoTangBn.Repo.KienThucLichSuVanHoaRepo
{
    public class KienThucLichSuVanHoaRepository : IKienThucLichSuVanHoaRepository
    {
        private readonly BaoTangBNDataContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public KienThucLichSuVanHoaRepository(BaoTangBNDataContext context, IMapper mapper,IOptions<AppSettings> appSettings)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        public IEnumerable<KienThucLichSuVanHoa> GetAll()
        {

            var temp = _context.KienThucLichSuVanHoa;
   
            return temp;
        }
        public List<KienThucLichSuVanHoa> GetRelated()
        {
            var temp = _context.KienThucLichSuVanHoa.ToList();
            temp.RemoveAll(x => x.TrangThaiXuatBan == false);
            temp.RemoveAll(x => x.DaXoa == true);
            return temp;
        }

        public string UploadImg()
        {
            string x = "y";
            return x;
        }
        public bool AddKienThucLichSuVanHoa(KienThucLichSuVanHoa KienThucLichSuVanHoa)
        {
            try
            {
                _context.KienThucLichSuVanHoa.Add(KienThucLichSuVanHoa);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool XoaKienThucLichSuVanHoa(Guid IDBaiCanXoa, Guid IDNguoiXoa)
        {
            try
            {
                var temp = _context.KienThucLichSuVanHoa.FirstOrDefault(x=> x.ID == IDBaiCanXoa);
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
        public bool EditKienThucLichSuVanHoa(Guid IDBaiCanSua, Guid IDNguoiSua, KienThucLichSuVanHoaDto KienThucLichSuVanHoaDto)
        {
            try
            {
                var temp = _context.KienThucLichSuVanHoa.FirstOrDefault(x => x.ID == IDBaiCanSua);
                if (temp != null)
                {
                    temp.IDNguoiSua = IDNguoiSua;
                    temp.NgaySua = DateTime.UtcNow;
                    temp.Ten = KienThucLichSuVanHoaDto.Ten;
                    temp.TrangThaiXuatBan = KienThucLichSuVanHoaDto.TrangThaiXuatBan;
                    temp.Nguon = KienThucLichSuVanHoaDto.Nguon;
                    temp.AnhMinhHoa = KienThucLichSuVanHoaDto.AnhMinhHoa;
                    temp.TieuDe = KienThucLichSuVanHoaDto.TieuDe;
                    temp.NoiDung = KienThucLichSuVanHoaDto.NoiDung;
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public KienThucLichSuVanHoa_Detail ShowDetails(Guid id)
        {
            KienThucLichSuVanHoa_Detail KienThucLichSuVanHoa_Detail = new KienThucLichSuVanHoa_Detail();

            var _KienThucLichSuVanHoa = _context.KienThucLichSuVanHoa.SingleOrDefault(x => x.ID == id);
            if (_KienThucLichSuVanHoa != null)
            {
                if (_KienThucLichSuVanHoa.DaXoa == true)
                {
                    return KienThucLichSuVanHoa_Detail;
                }
                KienThucLichSuVanHoa_Detail.NoiDung = _KienThucLichSuVanHoa.NoiDung;
                KienThucLichSuVanHoa_Detail.Nguon = _KienThucLichSuVanHoa.Nguon;
                KienThucLichSuVanHoa_Detail.NgayTao = _KienThucLichSuVanHoa.NgayTao;
            }
            return KienThucLichSuVanHoa_Detail;
        }
    }
}
