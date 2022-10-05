using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Repo.TrungBayLuuDongRepo
{
    public interface ITrungBayLuuDongRepository
    {
        public IEnumerable<TrungBayLuuDong> GetAll();
        public bool AddTrungBayLuuDong(TrungBayLuuDong TrungBayLuuDong);
        public bool XoaTrungBayLuuDong(Guid IDBaiCanXoa, Guid IDNguoiXoa);
        public bool EditTrungBayLuuDong(Guid IDBaiCanSua, Guid IDNguoiSua, TrungBayLuuDongDto TrungBayLuuDongDto);
        public TrungBayLuuDong_Detail ShowDetails(Guid id);

        public List<TrungBayLuuDong> GetRelated();
    }
}
