using BaoTangBn.Data.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Service.TrungBayLuuDongService
{
    public interface ITrungBayLuuDongService
    {
        public IEnumerable<TrungBayLuuDong_ShowOnViewer> GetList(bool admin);
        public bool AddTrungBayLuuDong(TrungBayLuuDongDto TrungBayLuuDongDto, string token);
        public bool XoaTrungBayLuuDong(Guid ID_BaiCanXoa, string token);
        public bool EditTrungBayLuuDong(Guid IDBaiCanSua, string token, TrungBayLuuDongDto TrungBayLuuDongDto);
        public TrungBayLuuDong_Detail ShowDetails(Guid id);
        public IEnumerable<TrungBayLuuDong_Related> GetRelated(Guid IDBaiViet, int pre_count, int next_count);
        public IEnumerable<TrungBayLuuDong_ShowOnUser> SearchByTenAndTieuDe(string keyWord);
    }
}
