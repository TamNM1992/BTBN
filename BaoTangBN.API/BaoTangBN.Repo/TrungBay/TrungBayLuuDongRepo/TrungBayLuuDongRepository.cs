using AutoMapper;
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Repo.TrungBayLuuDongRepo
{
    public class TrungBayLuuDongRepository : ITrungBayLuuDongRepository
    {
        private readonly BaoTangBNDataContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public TrungBayLuuDongRepository(BaoTangBNDataContext context, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        public IEnumerable<TrungBayLuuDong> GetAll()
        {

            var temp = _context.TrungBayLuuDong;

            return temp;
        }
        public List<TrungBayLuuDong> GetRelated()
        {
            var temp = _context.TrungBayLuuDong.ToList();
            temp.RemoveAll(x => x.TrangThaiXuatBan == false);
            temp.RemoveAll(x => x.DaXoa == true);
            return temp;
        }

        public string UploadImg()
        {
            string x = "y";
            return x;
        }
        public bool AddTrungBayLuuDong(TrungBayLuuDong TrungBayLuuDong)
        {
            try
            {
                _context.TrungBayLuuDong.Add(TrungBayLuuDong);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool XoaTrungBayLuuDong(Guid IDBaiCanXoa, Guid IDNguoiXoa)
        {
            try
            {
                var temp = _context.TrungBayLuuDong.FirstOrDefault(x => x.ID == IDBaiCanXoa);
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
        public bool EditTrungBayLuuDong(Guid IDBaiCanSua, Guid IDNguoiSua, TrungBayLuuDongDto TrungBayLuuDongDto)
        {
            try
            {
                var temp = _context.TrungBayLuuDong.FirstOrDefault(x => x.ID == IDBaiCanSua);
                if (temp != null)
                {
                    temp.IDNguoiSua = IDNguoiSua;
                    temp.NgaySua = DateTime.UtcNow;
                    temp.Ten = TrungBayLuuDongDto.Ten;
                    temp.TrangThaiXuatBan = TrungBayLuuDongDto.TrangThaiXuatBan;
                    temp.Nguon = TrungBayLuuDongDto.Nguon;
                    temp.AnhMinhHoa = TrungBayLuuDongDto.AnhMinhHoa;
                    temp.TieuDe = TrungBayLuuDongDto.TieuDe;
                    temp.NoiDung = TrungBayLuuDongDto.NoiDung;
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public TrungBayLuuDong_Detail ShowDetails(Guid id)
        {
            TrungBayLuuDong_Detail TrungBayLuuDong_Detail = new TrungBayLuuDong_Detail();

            var _TrungBayLuuDong = _context.TrungBayLuuDong.SingleOrDefault(x => x.ID == id);
            if (_TrungBayLuuDong != null)
            {
                if (_TrungBayLuuDong.DaXoa == true)
                {
                    return TrungBayLuuDong_Detail;
                }
                TrungBayLuuDong_Detail.NoiDung = _TrungBayLuuDong.NoiDung;
                TrungBayLuuDong_Detail.Nguon = _TrungBayLuuDong.Nguon;
                TrungBayLuuDong_Detail.NgayTao = _TrungBayLuuDong.NgayTao;
            }
            return TrungBayLuuDong_Detail;
        }
    }
}
