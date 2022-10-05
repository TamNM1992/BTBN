using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Repo.CoCauToChucRepo
{
    public interface ICoCauToChucRepository
    {
        public bool EditCoCauToChuc( Guid IDNguoiSua, CoCauToChucDto CoCauToChucDto);
        public CoCauToChuc_Detail ShowDetails();
    }
}
