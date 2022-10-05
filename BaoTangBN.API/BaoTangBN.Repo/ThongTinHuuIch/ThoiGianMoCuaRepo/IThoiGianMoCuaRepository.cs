using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Repo.ThoiGianMoCuaRepo
{
    public interface IThoiGianMoCuaRepository
    {
        public bool EditThoiGianMoCua( Guid IDNguoiSua, ThoiGianMoCuaDto ThoiGianMoCuaDto);
        public ThoiGianMoCua_Detail ShowDetails();
    }
}
