using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Repo.DeTaiKhoaHocAnPhamRepo
{
    public interface IDeTaiKhoaHocAnPhamRepository
    {
        public IEnumerable<DeTaiKhoaHocAnPham> GetAll();
        public bool AddDeTaiKhoaHocAnPham(DeTaiKhoaHocAnPham DeTaiKhoaHocAnPham);
        public bool XoaDeTaiKhoaHocAnPham(Guid IDBaiCanXoa, Guid IDNguoiXoa);
        public bool EditDeTaiKhoaHocAnPham(Guid IDBaiCanSua, Guid IDNguoiSua, DeTaiKhoaHocAnPhamDto DeTaiKhoaHocAnPhamDto);
        public DeTaiKhoaHocAnPham_Detail ShowDetails(Guid id);
        
        public List<DeTaiKhoaHocAnPham> GetRelated();
    }
}
