using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Repo.KhaiQuatKhaoCoHocRepo
{
    public interface IKhaiQuatKhaoCoHocRepository
    {
        public IEnumerable<KhaiQuatKhaoCoHoc> GetAll();
        public bool AddKhaiQuatKhaoCoHoc(KhaiQuatKhaoCoHoc KhaiQuatKhaoCoHoc);
        public bool XoaKhaiQuatKhaoCoHoc(Guid IDBaiCanXoa, Guid IDNguoiXoa);
        public bool EditKhaiQuatKhaoCoHoc(Guid IDBaiCanSua, Guid IDNguoiSua, KhaiQuatKhaoCoHocDto KhaiQuatKhaoCoHocDto);
        public KhaiQuatKhaoCoHoc_Detail ShowDetails(Guid id);

        public List<KhaiQuatKhaoCoHoc> GetRelated();
    }
}
