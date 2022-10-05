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

namespace BaoTangBn.Repo.HuongDanThamQuanRepo
{
    public class HuongDanThamQuanRepository : IHuongDanThamQuanRepository
    {
        private readonly BaoTangBNDataContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public HuongDanThamQuanRepository(BaoTangBNDataContext context, IMapper mapper,IOptions<AppSettings> appSettings)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        public IEnumerable<HuongDanThamQuan> GetAll()
        {

            var temp = _context.HuongDanThamQuan;
   
            return temp;
        }
        public List<HuongDanThamQuan> GetRelated()
        {
            var temp = _context.HuongDanThamQuan.ToList();
            temp.RemoveAll(x => x.TrangThaiXuatBan == false);
            temp.RemoveAll(x => x.DaXoa == true);
            return temp;
        }

        public string UploadImg()
        {
            string x = "y";
            return x;
        }
        public bool AddHuongDanThamQuan(HuongDanThamQuan HuongDanThamQuan)
        {
            try
            {
                _context.HuongDanThamQuan.Add(HuongDanThamQuan);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool XoaHuongDanThamQuan(Guid IDBaiCanXoa, Guid IDNguoiXoa)
        {
            try
            {
                var temp = _context.HuongDanThamQuan.FirstOrDefault(x=> x.ID == IDBaiCanXoa);
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
        public bool EditHuongDanThamQuan(Guid IDBaiCanSua, Guid IDNguoiSua, HuongDanThamQuanDto HuongDanThamQuanDto)
        {
            try
            {
                var temp = _context.HuongDanThamQuan.FirstOrDefault(x => x.ID == IDBaiCanSua);
                if (temp != null)
                {
                    temp.IDNguoiSua = IDNguoiSua;
                    temp.NgaySua = DateTime.UtcNow;
                    temp.Ten = HuongDanThamQuanDto.Ten;
                    temp.TrangThaiXuatBan = HuongDanThamQuanDto.TrangThaiXuatBan;
                    temp.Nguon = HuongDanThamQuanDto.Nguon;
                    temp.AnhMinhHoa = HuongDanThamQuanDto.AnhMinhHoa;
                    temp.TieuDe = HuongDanThamQuanDto.TieuDe;
                    temp.NoiDung = HuongDanThamQuanDto.NoiDung;
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public HuongDanThamQuan_Detail ShowDetails(Guid id)
        {
            HuongDanThamQuan_Detail HuongDanThamQuan_Detail = new HuongDanThamQuan_Detail();

            var _HuongDanThamQuan = _context.HuongDanThamQuan.SingleOrDefault(x => x.ID == id);
            if (_HuongDanThamQuan != null)
            {
                if (_HuongDanThamQuan.DaXoa == true)
                {
                    return HuongDanThamQuan_Detail;
                }
                HuongDanThamQuan_Detail.NoiDung = _HuongDanThamQuan.NoiDung;
                HuongDanThamQuan_Detail.Nguon = _HuongDanThamQuan.Nguon;
                HuongDanThamQuan_Detail.NgayTao = _HuongDanThamQuan.NgayTao;
            }
            return HuongDanThamQuan_Detail;
        }
    }
}
