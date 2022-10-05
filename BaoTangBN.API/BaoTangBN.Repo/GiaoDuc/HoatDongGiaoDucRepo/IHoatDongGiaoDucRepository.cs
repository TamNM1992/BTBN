using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Repo.HoatDongGiaoDucRepo
{
    public interface IHoatDongGiaoDucRepository
    {
        public IEnumerable<HoatDongGiaoDuc> GetAll();
        public bool AddHoatDongGiaoDuc(HoatDongGiaoDuc HoatDongGiaoDuc);
        public bool XoaHoatDongGiaoDuc(Guid IDBaiCanXoa, Guid IDNguoiXoa);
        public bool EditHoatDongGiaoDuc(Guid IDBaiCanSua, Guid IDNguoiSua, HoatDongGiaoDucDto HoatDongGiaoDucDto);
        public HoatDongGiaoDuc_Detail ShowDetails(Guid id);
        
        public List<HoatDongGiaoDuc> GetRelated();
    }
}
