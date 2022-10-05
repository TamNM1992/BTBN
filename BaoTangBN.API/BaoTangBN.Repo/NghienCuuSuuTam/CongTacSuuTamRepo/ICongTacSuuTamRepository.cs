using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Repo.CongTacSuuTamRepo
{
    public interface ICongTacSuuTamRepository
    {
        public IEnumerable<CongTacSuuTam> GetAll();
        public bool AddCongTacSuuTam(CongTacSuuTam CongTacSuuTam);
        public bool XoaCongTacSuuTam(Guid IDBaiCanXoa, Guid IDNguoiXoa);
        public bool EditCongTacSuuTam(Guid IDBaiCanSua, Guid IDNguoiSua, CongTacSuuTamDto CongTacSuuTamDto);
        public CongTacSuuTam_Detail ShowDetails(Guid id);
        
        public List<CongTacSuuTam> GetRelated();
    }
}
