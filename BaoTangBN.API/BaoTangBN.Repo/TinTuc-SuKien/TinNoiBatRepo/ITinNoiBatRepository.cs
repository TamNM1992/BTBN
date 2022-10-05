using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Repo.TinNoiBatRepo
{
    public interface ITinNoiBatRepository
    {
        public IEnumerable<TinNoiBat> GetAll();
        public bool AddTinNoiBat(TinNoiBat tinNoiBat);
        public bool XoaTinNoiBat(Guid IDBaiCanXoa, Guid IDNguoiXoa);
        public bool EditTinNoiBat(Guid IDBaiCanSua, Guid IDNguoiSua, TinNoiBatDto tinNoiBatDto);
        public TinNoiBat_Detail ShowDetails(Guid id);
        
        public List<TinNoiBat> GetRelated();
    }
}
