using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Repo.GioiThieuChungRepo
{
    public interface IGioiThieuChungRepository
    {
        public bool EditGioiThieuChung( Guid IDNguoiSua, GioiThieuChungDto GioiThieuChungDto);
        public GioiThieuChung_Detail ShowDetails();
    }
}
