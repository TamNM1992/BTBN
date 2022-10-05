
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Service.CacBoSuuTapService
{
    public interface ICacBoSuuTapService
    {
        public IEnumerable<CacBoSuuTap_ShowOnViewer> GetList(bool admin);
        public bool AddCacBoSuuTap(CacBoSuuTapDto CacBoSuuTapDto, string token);
        public bool XoaCacBoSuuTap(Guid ID_BaiCanXoa, string token);
        public bool EditCacBoSuuTap(Guid IDBaiCanSua, string token, CacBoSuuTapDto CacBoSuuTapDto);
        public CacBoSuuTap_Detail ShowDetails(Guid id);
        public IEnumerable<CacBoSuuTap_Related> GetRelated(Guid IDBaiViet, int pre_count, int next_count);
        public IEnumerable<CacBoSuuTap_ShowOnUser> SearchByTenAndTieuDe(string keyWord);
    }
}
