using AutoMapper;
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Repo.TrungBayChuyenDeRepo
{
    public class TrungBayChuyenDeRepository : ITrungBayChuyenDeRepository
    {
        private readonly BaoTangBNDataContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public TrungBayChuyenDeRepository(BaoTangBNDataContext context, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        public IEnumerable<TrungBayChuyenDe> GetAll()
        {

            var temp = _context.TrungBayChuyenDe;

            return temp;
        }
        public List<TrungBayChuyenDe> GetRelated()
        {
            var temp = _context.TrungBayChuyenDe.ToList();
            temp.RemoveAll(x => x.TrangThaiXuatBan == false);
            temp.RemoveAll(x => x.DaXoa == true);
            return temp;
        }

        public string UploadImg()
        {
            string x = "y";
            return x;
        }
        public bool AddTrungBayChuyenDe(TrungBayChuyenDe TrungBayChuyenDe)
        {
            try
            {
                _context.TrungBayChuyenDe.Add(TrungBayChuyenDe);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool XoaTrungBayChuyenDe(Guid IDBaiCanXoa, Guid IDNguoiXoa)
        {
            try
            {
                var temp = _context.TrungBayChuyenDe.FirstOrDefault(x => x.ID == IDBaiCanXoa);
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
        public bool EditTrungBayChuyenDe(Guid IDBaiCanSua, Guid IDNguoiSua, TrungBayChuyenDeDto TrungBayChuyenDeDto)
        {
            try
            {
                var temp = _context.TrungBayChuyenDe.FirstOrDefault(x => x.ID == IDBaiCanSua);
                if (temp != null)
                {
                    temp.IDNguoiSua = IDNguoiSua;
                    temp.NgaySua = DateTime.UtcNow;
                    temp.Ten = TrungBayChuyenDeDto.Ten;
                    temp.TrangThaiXuatBan = TrungBayChuyenDeDto.TrangThaiXuatBan;
                    temp.Nguon = TrungBayChuyenDeDto.Nguon;
                    temp.AnhMinhHoa = TrungBayChuyenDeDto.AnhMinhHoa;
                    temp.TieuDe = TrungBayChuyenDeDto.TieuDe;
                    temp.NoiDung = TrungBayChuyenDeDto.NoiDung;
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public TrungBayChuyenDe_Detail ShowDetails(Guid id)
        {
            TrungBayChuyenDe_Detail TrungBayChuyenDe_Detail = new TrungBayChuyenDe_Detail();

            var _TrungBayChuyenDe = _context.TrungBayChuyenDe.SingleOrDefault(x => x.ID == id);
            if (_TrungBayChuyenDe != null)
            {
                if (_TrungBayChuyenDe.DaXoa == true)
                {
                    return TrungBayChuyenDe_Detail;
                }
                TrungBayChuyenDe_Detail.NoiDung = _TrungBayChuyenDe.NoiDung;
                TrungBayChuyenDe_Detail.Nguon = _TrungBayChuyenDe.Nguon;
                TrungBayChuyenDe_Detail.NgayTao = _TrungBayChuyenDe.NgayTao;
            }
            return TrungBayChuyenDe_Detail;
        }
    }
}
