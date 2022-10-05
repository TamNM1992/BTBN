using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Data.Models
{
    public class BaoTangBNDataContext : DbContext
    {
        public BaoTangBNDataContext(DbContextOptions options)
             : base(options)
        {
                
        }
        public DbSet<Album> Album { get; set; }
        public DbSet<HoatDongGiaoDuc> HoatDongGiaoDuc { get; set; }
        public DbSet<HuongDanThamQuan> HuongDanThamQuan { get; set; }
        public DbSet<CoCauToChuc> CoCauToChuc { get; set; }
        public DbSet<ChucNangNhiemVu> ChucNangNhiemVu { get; set; }
        public DbSet<GioiThieuChung> GioiThieuChung { get; set; }
        public DbSet<BaoVatQuocGia> BaoVatQuocGia { get; set; }
        public DbSet<CacBoSuuTap> CacBoSuuTap { get; set; }
        public DbSet<HienVatTieuBieu> HienVatTieuBieu { get; set; }
        public DbSet<CongTacSuuTam> CongTacSuuTam { get; set; }
        public DbSet<DeTaiKhoaHocAnPham> DeTaiKhoaHocAnPham { get; set; }
        public DbSet<KienThucLichSuVanHoa> KienThucLichSuVanHoa { get; set; }
        public DbSet<KhaiQuatKhaoCoHoc> KhaiQuatKhaoCoHoc { get; set; }
        public DbSet<SuKienSapDienRa> SuKienSapDienRa { get; set; }
        public DbSet<TinNoiBat> TinNoiBat { get; set; }
        public DbSet<ChiDan> ChiDan { get; set; }
        public DbSet<NoiQuyThamQuan> NoiQuyThamQuan { get; set; }
        public DbSet<ThoiGianMoCua> ThoiGianMoCua { get; set; }
        public DbSet<TrungBayChuyenDe> TrungBayChuyenDe { get; set; }
        public DbSet<TrungBayLuuDong> TrungBayLuuDong { get; set; }
        public DbSet<TrungBayThuongXuyen> TrungBayThuongXuyen { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Video> Video { get; set; }


    }
}
