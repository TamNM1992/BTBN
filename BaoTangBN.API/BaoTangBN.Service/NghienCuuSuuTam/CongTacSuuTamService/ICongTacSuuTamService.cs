
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Service.CongTacSuuTamService
{
    public interface ICongTacSuuTamService
    {
        public IEnumerable<CongTacSuuTam_ShowOnViewer> GetList(bool admin);
        public bool AddCongTacSuuTam(CongTacSuuTamDto CongTacSuuTamDto, string token);
        public bool XoaCongTacSuuTam(Guid ID_BaiCanXoa, string token);
        public bool EditCongTacSuuTam(Guid IDBaiCanSua, string token, CongTacSuuTamDto CongTacSuuTamDto);
        public CongTacSuuTam_Detail ShowDetails(Guid id);
        public IEnumerable<CongTacSuuTam_Related> GetRelated(Guid IDBaiViet, int pre_count, int next_count);
        public IEnumerable<CongTacSuuTam_ShowOnUser> SearchByTenAndTieuDe(string keyWord);
    }
}
