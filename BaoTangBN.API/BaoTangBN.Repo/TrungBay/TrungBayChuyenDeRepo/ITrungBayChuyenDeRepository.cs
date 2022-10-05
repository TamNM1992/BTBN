using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Repo.TrungBayChuyenDeRepo
{
    public interface ITrungBayChuyenDeRepository
    {
        public IEnumerable<TrungBayChuyenDe> GetAll();
        public bool AddTrungBayChuyenDe(TrungBayChuyenDe TrungBayChuyenDe);
        public bool XoaTrungBayChuyenDe(Guid IDBaiCanXoa, Guid IDNguoiXoa);
        public bool EditTrungBayChuyenDe(Guid IDBaiCanSua, Guid IDNguoiSua, TrungBayChuyenDeDto TrungBayChuyenDeDto);
        public TrungBayChuyenDe_Detail ShowDetails(Guid id);

        public List<TrungBayChuyenDe> GetRelated();
    }
}
