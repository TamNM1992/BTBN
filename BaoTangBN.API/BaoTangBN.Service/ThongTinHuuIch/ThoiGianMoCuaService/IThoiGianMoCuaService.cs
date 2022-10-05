
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Service.ThoiGianMoCuaService
{
    public interface IThoiGianMoCuaService
    {
        public bool EditThoiGianMoCua(string token, ThoiGianMoCuaDto ThoiGianMoCuaDto);
        public ThoiGianMoCua_Detail ShowDetails();
    }
}
