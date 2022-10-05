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

namespace BaoTangBn.Repo.KhaiQuatKhaoCoHocRepo
{
    public class KhaiQuatKhaoCoHocRepository : IKhaiQuatKhaoCoHocRepository
    {
        private readonly BaoTangBNDataContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public KhaiQuatKhaoCoHocRepository(BaoTangBNDataContext context, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        public IEnumerable<KhaiQuatKhaoCoHoc> GetAll()
        {

            var temp = _context.KhaiQuatKhaoCoHoc;

            return temp;
        }
        public List<KhaiQuatKhaoCoHoc> GetRelated()
        {
            var temp = _context.KhaiQuatKhaoCoHoc.ToList();
            temp.RemoveAll(x => x.TrangThaiXuatBan == false);
            temp.RemoveAll(x => x.DaXoa == true);
            return temp;
        }

        public string UploadImg()
        {
            string x = "y";
            return x;
        }
        public bool AddKhaiQuatKhaoCoHoc(KhaiQuatKhaoCoHoc KhaiQuatKhaoCoHoc)
        {
            try
            {
                _context.KhaiQuatKhaoCoHoc.Add(KhaiQuatKhaoCoHoc);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool XoaKhaiQuatKhaoCoHoc(Guid IDBaiCanXoa, Guid IDNguoiXoa)
        {
            try
            {
                var temp = _context.KhaiQuatKhaoCoHoc.FirstOrDefault(x => x.ID == IDBaiCanXoa);
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
        public bool EditKhaiQuatKhaoCoHoc(Guid IDBaiCanSua, Guid IDNguoiSua, KhaiQuatKhaoCoHocDto KhaiQuatKhaoCoHocDto)
        {
            try
            {
                var temp = _context.KhaiQuatKhaoCoHoc.FirstOrDefault(x => x.ID == IDBaiCanSua);
                if (temp != null)
                {
                    temp.IDNguoiSua = IDNguoiSua;
                    temp.NgaySua = DateTime.UtcNow;
                    temp.Ten = KhaiQuatKhaoCoHocDto.Ten;
                    temp.TrangThaiXuatBan = KhaiQuatKhaoCoHocDto.TrangThaiXuatBan;
                    temp.Nguon = KhaiQuatKhaoCoHocDto.Nguon;
                    temp.AnhMinhHoa = KhaiQuatKhaoCoHocDto.AnhMinhHoa;
                    temp.TieuDe = KhaiQuatKhaoCoHocDto.TieuDe;
                    temp.NoiDung = KhaiQuatKhaoCoHocDto.NoiDung;
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public KhaiQuatKhaoCoHoc_Detail ShowDetails(Guid id)
        {
            KhaiQuatKhaoCoHoc_Detail KhaiQuatKhaoCoHoc_Detail = new KhaiQuatKhaoCoHoc_Detail();

            var _KhaiQuatKhaoCoHoc = _context.KhaiQuatKhaoCoHoc.SingleOrDefault(x => x.ID == id);
            if (_KhaiQuatKhaoCoHoc != null)
            {
                if (_KhaiQuatKhaoCoHoc.DaXoa == true)
                {
                    return KhaiQuatKhaoCoHoc_Detail;
                }
                KhaiQuatKhaoCoHoc_Detail.NoiDung = _KhaiQuatKhaoCoHoc.NoiDung;
                KhaiQuatKhaoCoHoc_Detail.Nguon = _KhaiQuatKhaoCoHoc.Nguon;
                KhaiQuatKhaoCoHoc_Detail.NgayTao = _KhaiQuatKhaoCoHoc.NgayTao;
            }
            return KhaiQuatKhaoCoHoc_Detail;
        }
    }
}
