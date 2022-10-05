using BaoTangBn.Data.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Service.TrungBayChuyenDeService
{
    public interface ITrungBayChuyenDeService
    {
        public IEnumerable<TrungBayChuyenDe_ShowOnViewer> GetList(bool admin);
        public bool AddTrungBayChuyenDe(TrungBayChuyenDeDto TrungBayChuyenDeDto, string token);
        public bool XoaTrungBayChuyenDe(Guid ID_BaiCanXoa, string token);
        public bool EditTrungBayChuyenDe(Guid IDBaiCanSua, string token, TrungBayChuyenDeDto TrungBayChuyenDeDto);
        public TrungBayChuyenDe_Detail ShowDetails(Guid id);
        public IEnumerable<TrungBayChuyenDe_Related> GetRelated(Guid IDBaiViet, int pre_count, int next_count);
        public IEnumerable<TrungBayChuyenDe_ShowOnUser> SearchByTenAndTieuDe(string keyWord);
    }
}
