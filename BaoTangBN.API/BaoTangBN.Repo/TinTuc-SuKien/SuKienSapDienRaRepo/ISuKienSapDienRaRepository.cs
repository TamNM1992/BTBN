using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Repo.SuKienSapDienRaRepo
{
    public interface ISuKienSapDienRaRepository
    {
        public IEnumerable<SuKienSapDienRa> GetAll();
        public bool AddSuKienSapDienRa(SuKienSapDienRa SuKienSapDienRa);
        public bool XoaSuKienSapDienRa(Guid IDBaiCanXoa, Guid IDNguoiXoa);
        public bool EditSuKienSapDienRa(Guid IDBaiCanSua, Guid IDNguoiSua, SuKienSapDienRaDto SuKienSapDienRaDto);
        public SuKienSapDienRa_Detail ShowDetails(Guid id);
        
        public List<SuKienSapDienRa> GetRelated();
    }
}
