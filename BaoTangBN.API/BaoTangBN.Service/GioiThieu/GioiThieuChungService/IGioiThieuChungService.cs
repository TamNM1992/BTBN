
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Service.GioiThieuChungService
{
    public interface IGioiThieuChungService
    {
        public bool EditGioiThieuChung(string token, GioiThieuChungDto GioiThieuChungDto);
        public GioiThieuChung_Detail ShowDetails();
    }
}
