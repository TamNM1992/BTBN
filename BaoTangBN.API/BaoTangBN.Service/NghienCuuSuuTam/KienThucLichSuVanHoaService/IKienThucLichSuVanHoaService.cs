
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Service.KienThucLichSuVanHoaService
{
    public interface IKienThucLichSuVanHoaService
    {
        public IEnumerable<KienThucLichSuVanHoa_ShowOnViewer> GetList(bool admin);
        public bool AddKienThucLichSuVanHoa(KienThucLichSuVanHoaDto KienThucLichSuVanHoaDto, string token);
        public bool XoaKienThucLichSuVanHoa(Guid ID_BaiCanXoa, string token);
        public bool EditKienThucLichSuVanHoa(Guid IDBaiCanSua, string token, KienThucLichSuVanHoaDto KienThucLichSuVanHoaDto);
        public KienThucLichSuVanHoa_Detail ShowDetails(Guid id);
        public IEnumerable<KienThucLichSuVanHoa_Related> GetRelated(Guid IDBaiViet, int pre_count, int next_count);
        public IEnumerable<KienThucLichSuVanHoa_ShowOnUser> SearchByTenAndTieuDe(string keyWord);
    }
}
