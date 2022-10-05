
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Service.HoatDongGiaoDucService
{
    public interface IHoatDongGiaoDucService
    {
        public IEnumerable<HoatDongGiaoDuc_ShowOnViewer> GetList(bool admin);
        public bool AddHoatDongGiaoDuc(HoatDongGiaoDucDto HoatDongGiaoDucDto, string token);
        public bool XoaHoatDongGiaoDuc(Guid ID_BaiCanXoa, string token);
        public bool EditHoatDongGiaoDuc(Guid IDBaiCanSua, string token, HoatDongGiaoDucDto HoatDongGiaoDucDto);
        public HoatDongGiaoDuc_Detail ShowDetails(Guid id);
        public IEnumerable<HoatDongGiaoDuc_Related> GetRelated(Guid IDBaiViet, int pre_count, int next_count);
        public IEnumerable<HoatDongGiaoDuc_ShowOnUser> SearchByTenAndTieuDe(string keyWord);
    }
}
