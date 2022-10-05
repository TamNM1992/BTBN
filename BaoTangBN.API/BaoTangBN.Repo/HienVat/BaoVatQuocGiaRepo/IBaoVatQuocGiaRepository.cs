using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Repo.BaoVatQuocGiaRepo
{
    public interface IBaoVatQuocGiaRepository
    {
        public IEnumerable<BaoVatQuocGia> GetAll();
        public bool AddBaoVatQuocGia(BaoVatQuocGia BaoVatQuocGia);
        public bool XoaBaoVatQuocGia(Guid IDBaiCanXoa, Guid IDNguoiXoa);
        public bool EditBaoVatQuocGia(Guid IDBaiCanSua, Guid IDNguoiSua, BaoVatQuocGiaDto BaoVatQuocGiaDto);
        public BaoVatQuocGia_Detail ShowDetails(Guid id);
        
        public List<BaoVatQuocGia> GetRelated();
    }
}
