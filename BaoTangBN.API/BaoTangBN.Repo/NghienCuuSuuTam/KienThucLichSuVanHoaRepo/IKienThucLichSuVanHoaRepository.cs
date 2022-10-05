using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Repo.KienThucLichSuVanHoaRepo
{
    public interface IKienThucLichSuVanHoaRepository
    {
        public IEnumerable<KienThucLichSuVanHoa> GetAll();
        public bool AddKienThucLichSuVanHoa(KienThucLichSuVanHoa KienThucLichSuVanHoa);
        public bool XoaKienThucLichSuVanHoa(Guid IDBaiCanXoa, Guid IDNguoiXoa);
        public bool EditKienThucLichSuVanHoa(Guid IDBaiCanSua, Guid IDNguoiSua, KienThucLichSuVanHoaDto KienThucLichSuVanHoaDto);
        public KienThucLichSuVanHoa_Detail ShowDetails(Guid id);
        
        public List<KienThucLichSuVanHoa> GetRelated();
    }
}
