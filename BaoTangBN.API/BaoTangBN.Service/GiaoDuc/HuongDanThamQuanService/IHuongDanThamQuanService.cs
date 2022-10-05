
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Service.HuongDanThamQuanService
{
    public interface IHuongDanThamQuanService
    {
        public IEnumerable<HuongDanThamQuan_ShowOnViewer> GetList(bool admin);
        public bool AddHuongDanThamQuan(HuongDanThamQuanDto HuongDanThamQuanDto, string token);
        public bool XoaHuongDanThamQuan(Guid ID_BaiCanXoa, string token);
        public bool EditHuongDanThamQuan(Guid IDBaiCanSua, string token, HuongDanThamQuanDto HuongDanThamQuanDto);
        public HuongDanThamQuan_Detail ShowDetails(Guid id);
        public IEnumerable<HuongDanThamQuan_Related> GetRelated(Guid IDBaiViet, int pre_count, int next_count);
        public IEnumerable<HuongDanThamQuan_ShowOnUser> SearchByTenAndTieuDe(string keyWord);
    }
}
