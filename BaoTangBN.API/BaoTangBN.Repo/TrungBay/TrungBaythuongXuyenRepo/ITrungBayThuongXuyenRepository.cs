using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;

namespace BaoTangBn.Repo.TrungBaythuongXuyenRepo
{
    public interface ITrungBayThuongXuyenRepository
    {
        public IEnumerable<TrungBayThuongXuyen> GetAll();
        public List<TrungBayThuongXuyen> GetRelated();
        public bool AddTrungBayThuongXuyen(TrungBayThuongXuyen TrungBayThuongXuyen);
        public bool XoaTrungBayThuongXuyen(Guid IDBaiCanXoa, Guid IDNguoiXoa);
        public bool EditTrungBayThuongXuyen(Guid IDBaiCanSua, Guid IDNguoiSua, TrungBayThuongXuyenDto TrungBayThuongXuyenDto);
        public TrungBayThuongXuyen_Detail ShowDetails(Guid id);

    }
}
