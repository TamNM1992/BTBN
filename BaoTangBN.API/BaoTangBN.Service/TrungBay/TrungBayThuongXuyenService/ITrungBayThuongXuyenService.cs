using BaoTangBn.Data.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Service.TrungBayThuongXuyenService
{
    public interface ITrungBayThuongXuyenService
    {
        public IEnumerable<TrungBayThuongXuyen_ShowOnViewer> GetList(bool admin);
        public bool AddTrungBayThuongXuyen(TrungBayThuongXuyenDto TrungBayThuongXuyenDto, string token);
        public bool XoaTrungBayThuongXuyen(Guid ID_BaiCanXoa, string token);
        public bool EditTrungBayThuongXuyen(Guid IDBaiCanSua, string token, TrungBayThuongXuyenDto TrungBayThuongXuyenDto);
        public TrungBayThuongXuyen_Detail ShowDetails(Guid id);
        public IEnumerable<TrungBayThuongXuyen_Related> GetRelated(Guid IDBaiViet, int pre_count, int next_count);
        public IEnumerable<TrungBayThuongXuyen_ShowOnUser> SearchByTenAndTieuDe(string keyWord);
    }
}
