
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Service.BaoVatQuocGiaService
{
    public interface IBaoVatQuocGiaService
    {
        public IEnumerable<BaoVatQuocGia_ShowOnViewer> GetList(bool admin);
        public bool AddBaoVatQuocGia(BaoVatQuocGiaDto BaoVatQuocGiaDto, string token);
        public bool XoaBaoVatQuocGia(Guid ID_BaiCanXoa, string token);
        public bool EditBaoVatQuocGia(Guid IDBaiCanSua, string token, BaoVatQuocGiaDto BaoVatQuocGiaDto);
        public BaoVatQuocGia_Detail ShowDetails(Guid id);
        public IEnumerable<BaoVatQuocGia_Related> GetRelated(Guid IDBaiViet, int pre_count, int next_count);
        public IEnumerable<BaoVatQuocGia_ShowOnUser> SearchByTenAndTieuDe(string keyWord);
    }
}
