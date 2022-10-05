
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Service.KhaiQuatKhaoCoHocService
{
    public interface IKhaiQuatKhaoCoHocService
    {
        public IEnumerable<KhaiQuatKhaoCoHoc_ShowOnViewer> GetList(bool admin);
        public bool AddKhaiQuatKhaoCoHoc(KhaiQuatKhaoCoHocDto KhaiQuatKhaoCoHocDto, string token);
        public bool XoaKhaiQuatKhaoCoHoc(Guid ID_BaiCanXoa, string token);
        public bool EditKhaiQuatKhaoCoHoc(Guid IDBaiCanSua, string token, KhaiQuatKhaoCoHocDto KhaiQuatKhaoCoHocDto);
        public KhaiQuatKhaoCoHoc_Detail ShowDetails(Guid id);
        public IEnumerable<KhaiQuatKhaoCoHoc_Related> GetRelated(Guid IDBaiViet, int pre_count, int next_count);
        public IEnumerable<KhaiQuatKhaoCoHoc_ShowOnUser> SearchByTenAndTieuDe(string keyWord);
    }
}
