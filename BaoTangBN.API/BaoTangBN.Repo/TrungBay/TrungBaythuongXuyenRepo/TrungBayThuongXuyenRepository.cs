
using AutoMapper;
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Repo.TrungBaythuongXuyenRepo
{
    public class TrungBayThuongXuyenRepository : ITrungBayThuongXuyenRepository
    {
        private readonly BaoTangBNDataContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public TrungBayThuongXuyenRepository(BaoTangBNDataContext context, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        public IEnumerable<TrungBayThuongXuyen> GetAll()
        {

            var temp = _context.TrungBayThuongXuyen;

            return temp;
        }
        public List<TrungBayThuongXuyen> GetRelated()
        {
            var temp = _context.TrungBayThuongXuyen.ToList();
            temp.RemoveAll(x => x.TrangThaiXuatBan == false);
            temp.RemoveAll(x => x.DaXoa == true);
            return temp;
        }

        public string UploadImg()
        {
            string x = "y";
            return x;
        }
        public bool AddTrungBayThuongXuyen(TrungBayThuongXuyen TrungBayThuongXuyen)
        {
            try
            {
                _context.TrungBayThuongXuyen.Add(TrungBayThuongXuyen);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool XoaTrungBayThuongXuyen(Guid IDBaiCanXoa, Guid IDNguoiXoa)
        {
            try
            {
                var temp = _context.TrungBayThuongXuyen.FirstOrDefault(x => x.ID == IDBaiCanXoa);
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
        public bool EditTrungBayThuongXuyen(Guid IDBaiCanSua, Guid IDNguoiSua, TrungBayThuongXuyenDto TrungBayThuongXuyenDto)
        {
            try
            {
                var temp = _context.TrungBayThuongXuyen.FirstOrDefault(x => x.ID == IDBaiCanSua);
                if (temp != null)
                {
                    temp.IDNguoiSua = IDNguoiSua;
                    temp.NgaySua = DateTime.UtcNow;
                    temp.Ten = TrungBayThuongXuyenDto.Ten;
                    temp.TrangThaiXuatBan = TrungBayThuongXuyenDto.TrangThaiXuatBan;
                    temp.Nguon = TrungBayThuongXuyenDto.Nguon;
                    temp.AnhMinhHoa = TrungBayThuongXuyenDto.AnhMinhHoa;
                    temp.TieuDe = TrungBayThuongXuyenDto.TieuDe;
                    temp.NoiDung = TrungBayThuongXuyenDto.NoiDung;
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public TrungBayThuongXuyen_Detail ShowDetails(Guid id)
        {
            TrungBayThuongXuyen_Detail TrungBayThuongXuyen_Detail = new TrungBayThuongXuyen_Detail();

            var _TrungBayThuongXuyen = _context.TrungBayThuongXuyen.SingleOrDefault(x => x.ID == id);
            if (_TrungBayThuongXuyen != null)
            {
                if (_TrungBayThuongXuyen.DaXoa == true)
                {
                    return TrungBayThuongXuyen_Detail;
                }
                TrungBayThuongXuyen_Detail.NoiDung = _TrungBayThuongXuyen.NoiDung;
                TrungBayThuongXuyen_Detail.Nguon = _TrungBayThuongXuyen.Nguon;
                TrungBayThuongXuyen_Detail.NgayTao = _TrungBayThuongXuyen.NgayTao;
            }
            return TrungBayThuongXuyen_Detail;
        }
    }
}
