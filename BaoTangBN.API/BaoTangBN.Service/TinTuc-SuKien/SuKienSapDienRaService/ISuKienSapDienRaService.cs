
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Service.SuKienSapDienRaService
{
    public interface ISuKienSapDienRaService
    {
        public IEnumerable<SuKienSapDienRa_ShowOnViewer> GetList(bool admin);
        public bool AddSuKienSapDienRa(SuKienSapDienRaDto SuKienSapDienRaDto, string token);
        public bool XoaSuKienSapDienRa(Guid ID_BaiCanXoa, string token);
        public bool EditSuKienSapDienRa(Guid IDBaiCanSua, string token, SuKienSapDienRaDto SuKienSapDienRaDto);
        public SuKienSapDienRa_Detail ShowDetails(Guid id);
        public IEnumerable<SuKienSapDienRa_Related> GetRelated(Guid IDBaiViet, int pre_count, int next_count);
        public IEnumerable<SuKienSapDienRa_ShowOnUser> SearchByTenAndTieuDe(string keyWord);
    }
}
