using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Repo.ChiDanRepo
{
    public interface IChiDanRepository
    {
        public bool EditChiDan( Guid IDNguoiSua, ChiDanDto ChiDanDto);
        public ChiDan_Detail ShowDetails();
    }
}
