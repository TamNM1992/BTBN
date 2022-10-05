using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Repo.ChucNangNhiemVuRepo
{
    public interface IChucNangNhiemVuRepository
    {
        public bool EditChucNangNhiemVu( Guid IDNguoiSua, ChucNangNhiemVuDto ChucNangNhiemVuDto);
        public ChucNangNhiemVu_Detail ShowDetails();
    }
}
