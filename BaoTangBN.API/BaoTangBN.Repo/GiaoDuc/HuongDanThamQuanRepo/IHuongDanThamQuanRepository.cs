using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Repo.HuongDanThamQuanRepo
{
    public interface IHuongDanThamQuanRepository
    {
        public IEnumerable<HuongDanThamQuan> GetAll();
        public bool AddHuongDanThamQuan(HuongDanThamQuan HuongDanThamQuan);
        public bool XoaHuongDanThamQuan(Guid IDBaiCanXoa, Guid IDNguoiXoa);
        public bool EditHuongDanThamQuan(Guid IDBaiCanSua, Guid IDNguoiSua, HuongDanThamQuanDto HuongDanThamQuanDto);
        public HuongDanThamQuan_Detail ShowDetails(Guid id);
        
        public List<HuongDanThamQuan> GetRelated();
    }
}
