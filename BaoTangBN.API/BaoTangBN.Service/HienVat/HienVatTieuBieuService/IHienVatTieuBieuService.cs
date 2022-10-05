
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Service.HienVatTieuBieuService
{
    public interface IHienVatTieuBieuService
    {
        public IEnumerable<HienVatTieuBieu_ShowOnViewer> GetList(bool admin);
        public bool AddHienVatTieuBieu(HienVatTieuBieuDto HienVatTieuBieuDto, string token);
        public bool XoaHienVatTieuBieu(Guid ID_BaiCanXoa, string token);
        public bool EditHienVatTieuBieu(Guid IDBaiCanSua, string token, HienVatTieuBieuDto HienVatTieuBieuDto);
        public HienVatTieuBieu_Detail ShowDetails(Guid id);
        public IEnumerable<HienVatTieuBieu_Related> GetRelated(Guid IDBaiViet, int pre_count, int next_count);
        public IEnumerable<HienVatTieuBieu_ShowOnUser> SearchByTenAndTieuDe(string keyWord);
    }
}
