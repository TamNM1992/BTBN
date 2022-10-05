
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Service.ChucNangNhiemVuService
{
    public interface IChucNangNhiemVuService
    {
        public bool EditChucNangNhiemVu(string token, ChucNangNhiemVuDto ChucNangNhiemVuDto);
        public ChucNangNhiemVu_Detail ShowDetails();
    }
}
