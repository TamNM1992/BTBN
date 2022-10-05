
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Service.TinNoiBatService
{
    public interface ITinNoiBatService
    {
        public IEnumerable<TinNoiBat_ShowOnViewer> GetList(bool admin);
        public bool AddTinNoiBat(TinNoiBatDto tinNoiBatDto, string token);
        public bool XoaTinNoiBat(Guid ID_BaiCanXoa, string token);
        public bool EditTinNoiBat(Guid IDBaiCanSua, string token, TinNoiBatDto tinNoiBatDto);
        public TinNoiBat_Detail ShowDetails(Guid id);
        public IEnumerable<TinNoiBat_Related> GetRelated(Guid IDBaiViet, int pre_count, int next_count);
        public IEnumerable<TinNoiBat_ShowOnUser> SearchByTenAndTieuDe(string keyWord);
    }
}
