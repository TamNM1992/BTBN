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

namespace BaoTangBn.Repo.SuKienSapDienRaRepo
{
    public class SuKienSapDienRaRepository : ISuKienSapDienRaRepository
    {
        private readonly BaoTangBNDataContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public SuKienSapDienRaRepository(BaoTangBNDataContext context, IMapper mapper,IOptions<AppSettings> appSettings)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        public IEnumerable<SuKienSapDienRa> GetAll()
        {
            var temp = _context.SuKienSapDienRa;
   
            return temp;
        }
        public List<SuKienSapDienRa> GetRelated()
        {
            var temp = _context.SuKienSapDienRa.ToList();
            temp.RemoveAll(x => x.TrangThaiXuatBan == false);
            temp.RemoveAll(x => x.DaXoa == true);
            return temp;
        }

        public string UploadImg()
        {
            string x = "y";
            return x;
        }
        public bool AddSuKienSapDienRa(SuKienSapDienRa SuKienSapDienRa)
        {
            try
            {
                _context.SuKienSapDienRa.Add(SuKienSapDienRa);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool XoaSuKienSapDienRa(Guid IDBaiCanXoa, Guid IDNguoiXoa)
        {
            try
            {
                var temp = _context.SuKienSapDienRa.FirstOrDefault(x=> x.ID == IDBaiCanXoa);
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
        public bool EditSuKienSapDienRa(Guid IDBaiCanSua, Guid IDNguoiSua, SuKienSapDienRaDto SuKienSapDienRaDto)
        {
            try
            {
                var temp = _context.SuKienSapDienRa.FirstOrDefault(x => x.ID == IDBaiCanSua);
                if (temp != null)
                {
                    temp.IDNguoiSua = IDNguoiSua;
                    temp.NgaySua = DateTime.UtcNow;
                    temp.Ten = SuKienSapDienRaDto.Ten;
                    temp.TrangThaiXuatBan = SuKienSapDienRaDto.TrangThaiXuatBan;
                    temp.Nguon = SuKienSapDienRaDto.Nguon;
                    temp.AnhMinhHoa = SuKienSapDienRaDto.AnhMinhHoa;
                    temp.TieuDe = SuKienSapDienRaDto.TieuDe;
                    temp.NoiDung = SuKienSapDienRaDto.NoiDung;
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public SuKienSapDienRa_Detail ShowDetails(Guid id)
        {
            SuKienSapDienRa_Detail SuKienSapDienRa_Detail = new SuKienSapDienRa_Detail();

            var _SuKienSapDienRa = _context.SuKienSapDienRa.SingleOrDefault(x => x.ID == id);
            if (_SuKienSapDienRa != null)
            {
                if (_SuKienSapDienRa.DaXoa == true)
                {
                    return SuKienSapDienRa_Detail;
                }
                SuKienSapDienRa_Detail.NoiDung = _SuKienSapDienRa.NoiDung;
                SuKienSapDienRa_Detail.Nguon = _SuKienSapDienRa.Nguon;
                SuKienSapDienRa_Detail.NgayTao = _SuKienSapDienRa.NgayTao;
            }
            return SuKienSapDienRa_Detail;
        }
    }
}
