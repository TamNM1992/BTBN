
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Service.DeTaiKhoaHocAnPhamService
{
    public interface IDeTaiKhoaHocAnPhamService
    {
        public IEnumerable<DeTaiKhoaHocAnPham_ShowOnViewer> GetList(bool admin);
        public bool AddDeTaiKhoaHocAnPham(DeTaiKhoaHocAnPhamDto DeTaiKhoaHocAnPhamDto, string token);
        public bool XoaDeTaiKhoaHocAnPham(Guid ID_BaiCanXoa, string token);
        public bool EditDeTaiKhoaHocAnPham(Guid IDBaiCanSua, string token, DeTaiKhoaHocAnPhamDto DeTaiKhoaHocAnPhamDto);
        public DeTaiKhoaHocAnPham_Detail ShowDetails(Guid id);
        public IEnumerable<DeTaiKhoaHocAnPham_Related> GetRelated(Guid IDBaiViet, int pre_count, int next_count);
        public IEnumerable<DeTaiKhoaHocAnPham_ShowOnUser> SearchByTenAndTieuDe(string keyWord);
    }
}
