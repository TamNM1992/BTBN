using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Repo.CacBoSuuTapRepo
{
    public interface ICacBoSuuTapRepository
    {
        public IEnumerable<CacBoSuuTap> GetAll();
        public bool AddCacBoSuuTap(CacBoSuuTap CacBoSuuTap);
        public bool XoaCacBoSuuTap(Guid IDBaiCanXoa, Guid IDNguoiXoa);
        public bool EditCacBoSuuTap(Guid IDBaiCanSua, Guid IDNguoiSua, CacBoSuuTapDto CacBoSuuTapDto);
        public CacBoSuuTap_Detail ShowDetails(Guid id);
        
        public List<CacBoSuuTap> GetRelated();
    }
}
