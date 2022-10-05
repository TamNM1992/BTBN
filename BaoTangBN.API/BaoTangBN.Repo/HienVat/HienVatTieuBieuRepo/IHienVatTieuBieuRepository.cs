using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Repo.HienVatTieuBieuRepo
{
    public interface IHienVatTieuBieuRepository
    {
        public IEnumerable<HienVatTieuBieu> GetAll();
        public bool AddHienVatTieuBieu(HienVatTieuBieu HienVatTieuBieu);
        public bool XoaHienVatTieuBieu(Guid IDBaiCanXoa, Guid IDNguoiXoa);
        public bool EditHienVatTieuBieu(Guid IDBaiCanSua, Guid IDNguoiSua, HienVatTieuBieuDto HienVatTieuBieuDto);
        public HienVatTieuBieu_Detail ShowDetails(Guid id);
        
        public List<HienVatTieuBieu> GetRelated();
    }
}
