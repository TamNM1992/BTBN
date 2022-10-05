using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaoTangBn.Data.Migrations
{
    public partial class btbn2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Trung_bay_thuong_xuyen",
                table: "Trung_bay_thuong_xuyen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trung_bay_luu_dong",
                table: "Trung_bay_luu_dong");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trung_bay_chuyen_de",
                table: "Trung_bay_chuyen_de");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Thoi_gian_mo_cua",
                table: "Thoi_gian_mo_cua");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tin_noi_bat",
                table: "Tin_noi_bat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Su_kien_sap_dien_ra",
                table: "Su_kien_sap_dien_ra");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Noi_quy_tham_quan",
                table: "Noi_quy_tham_quan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Khai_quat_khao_co_hoc",
                table: "Khai_quat_khao_co_hoc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kien_thuc_lich_su_van_hoa",
                table: "Kien_thuc_lich_su_van_hoa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Huong_dan_tham_quan",
                table: "Huong_dan_tham_quan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hoat_dong_giao_duc",
                table: "Hoat_dong_giao_duc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hien_vat_tieu_bieu",
                table: "Hien_vat_tieu_bieu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gioi_thieu_chung",
                table: "Gioi_thieu_chung");

            migrationBuilder.DropPrimaryKey(
                name: "PK_De_tai_khoa_hoc_an_pham",
                table: "De_tai_khoa_hoc_an_pham");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chuc_nang_nhiem_vu",
                table: "Chuc_nang_nhiem_vu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chi_dan",
                table: "Chi_dan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cong_tac_suu_tam",
                table: "Cong_tac_suu_tam");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Co_cau_to_chuc",
                table: "Co_cau_to_chuc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cac_bo_suu_tap",
                table: "Cac_bo_suu_tap");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bao_vat_quoc_gia",
                table: "Bao_vat_quoc_gia");

            migrationBuilder.RenameTable(
                name: "Trung_bay_thuong_xuyen",
                newName: "TrungBayThuongXuyen");

            migrationBuilder.RenameTable(
                name: "Trung_bay_luu_dong",
                newName: "TrungBayLuuDong");

            migrationBuilder.RenameTable(
                name: "Trung_bay_chuyen_de",
                newName: "TrungBayChuyenDe");

            migrationBuilder.RenameTable(
                name: "Thoi_gian_mo_cua",
                newName: "ThoiGianMoCua");

            migrationBuilder.RenameTable(
                name: "Tin_noi_bat",
                newName: "TinNoiBat");

            migrationBuilder.RenameTable(
                name: "Su_kien_sap_dien_ra",
                newName: "SuKienSapDienRa");

            migrationBuilder.RenameTable(
                name: "Noi_quy_tham_quan",
                newName: "NoiQuyThamQuan");

            migrationBuilder.RenameTable(
                name: "Khai_quat_khao_co_hoc",
                newName: "KhaiQuatKhaoCoHoc");

            migrationBuilder.RenameTable(
                name: "Kien_thuc_lich_su_van_hoa",
                newName: "KienThucLichSuVanHoa");

            migrationBuilder.RenameTable(
                name: "Huong_dan_tham_quan",
                newName: "HuongDanThamQuan");

            migrationBuilder.RenameTable(
                name: "Hoat_dong_giao_duc",
                newName: "HoatDongGiaoDuc");

            migrationBuilder.RenameTable(
                name: "Hien_vat_tieu_bieu",
                newName: "HienVatTieuBieu");

            migrationBuilder.RenameTable(
                name: "Gioi_thieu_chung",
                newName: "GioiThieuChung");

            migrationBuilder.RenameTable(
                name: "De_tai_khoa_hoc_an_pham",
                newName: "DeTaiHhoaHocAnPham");

            migrationBuilder.RenameTable(
                name: "Chuc_nang_nhiem_vu",
                newName: "ChucNangNhiemVu");

            migrationBuilder.RenameTable(
                name: "Chi_dan",
                newName: "ChiDan");

            migrationBuilder.RenameTable(
                name: "Cong_tac_suu_tam",
                newName: "CongTacSuuTam");

            migrationBuilder.RenameTable(
                name: "Co_cau_to_chuc",
                newName: "CoCauToChuc");

            migrationBuilder.RenameTable(
                name: "Cac_bo_suu_tap",
                newName: "CacBoSuuTap");

            migrationBuilder.RenameTable(
                name: "Bao_vat_quoc_gia",
                newName: "BaoVatQuocGia");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrungBayThuongXuyen",
                table: "TrungBayThuongXuyen",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrungBayLuuDong",
                table: "TrungBayLuuDong",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrungBayChuyenDe",
                table: "TrungBayChuyenDe",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ThoiGianMoCua",
                table: "ThoiGianMoCua",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TinNoiBat",
                table: "TinNoiBat",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SuKienSapDienRa",
                table: "SuKienSapDienRa",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NoiQuyThamQuan",
                table: "NoiQuyThamQuan",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KhaiQuatKhaoCoHoc",
                table: "KhaiQuatKhaoCoHoc",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KienThucLichSuVanHoa",
                table: "KienThucLichSuVanHoa",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HuongDanThamQuan",
                table: "HuongDanThamQuan",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HoatDongGiaoDuc",
                table: "HoatDongGiaoDuc",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HienVatTieuBieu",
                table: "HienVatTieuBieu",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GioiThieuChung",
                table: "GioiThieuChung",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeTaiHhoaHocAnPham",
                table: "DeTaiHhoaHocAnPham",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChucNangNhiemVu",
                table: "ChucNangNhiemVu",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiDan",
                table: "ChiDan",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CongTacSuuTam",
                table: "CongTacSuuTam",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoCauToChuc",
                table: "CoCauToChuc",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CacBoSuuTap",
                table: "CacBoSuuTap",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaoVatQuocGia",
                table: "BaoVatQuocGia",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TrungBayThuongXuyen",
                table: "TrungBayThuongXuyen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrungBayLuuDong",
                table: "TrungBayLuuDong");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrungBayChuyenDe",
                table: "TrungBayChuyenDe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ThoiGianMoCua",
                table: "ThoiGianMoCua");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TinNoiBat",
                table: "TinNoiBat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SuKienSapDienRa",
                table: "SuKienSapDienRa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NoiQuyThamQuan",
                table: "NoiQuyThamQuan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KhaiQuatKhaoCoHoc",
                table: "KhaiQuatKhaoCoHoc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KienThucLichSuVanHoa",
                table: "KienThucLichSuVanHoa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HuongDanThamQuan",
                table: "HuongDanThamQuan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HoatDongGiaoDuc",
                table: "HoatDongGiaoDuc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HienVatTieuBieu",
                table: "HienVatTieuBieu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GioiThieuChung",
                table: "GioiThieuChung");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeTaiHhoaHocAnPham",
                table: "DeTaiHhoaHocAnPham");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChucNangNhiemVu",
                table: "ChucNangNhiemVu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiDan",
                table: "ChiDan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CongTacSuuTam",
                table: "CongTacSuuTam");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoCauToChuc",
                table: "CoCauToChuc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CacBoSuuTap",
                table: "CacBoSuuTap");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaoVatQuocGia",
                table: "BaoVatQuocGia");

            migrationBuilder.RenameTable(
                name: "TrungBayThuongXuyen",
                newName: "Trung_bay_thuong_xuyen");

            migrationBuilder.RenameTable(
                name: "TrungBayLuuDong",
                newName: "Trung_bay_luu_dong");

            migrationBuilder.RenameTable(
                name: "TrungBayChuyenDe",
                newName: "Trung_bay_chuyen_de");

            migrationBuilder.RenameTable(
                name: "ThoiGianMoCua",
                newName: "Thoi_gian_mo_cua");

            migrationBuilder.RenameTable(
                name: "TinNoiBat",
                newName: "Tin_noi_bat");

            migrationBuilder.RenameTable(
                name: "SuKienSapDienRa",
                newName: "Su_kien_sap_dien_ra");

            migrationBuilder.RenameTable(
                name: "NoiQuyThamQuan",
                newName: "Noi_quy_tham_quan");

            migrationBuilder.RenameTable(
                name: "KhaiQuatKhaoCoHoc",
                newName: "Khai_quat_khao_co_hoc");

            migrationBuilder.RenameTable(
                name: "KienThucLichSuVanHoa",
                newName: "Kien_thuc_lich_su_van_hoa");

            migrationBuilder.RenameTable(
                name: "HuongDanThamQuan",
                newName: "Huong_dan_tham_quan");

            migrationBuilder.RenameTable(
                name: "HoatDongGiaoDuc",
                newName: "Hoat_dong_giao_duc");

            migrationBuilder.RenameTable(
                name: "HienVatTieuBieu",
                newName: "Hien_vat_tieu_bieu");

            migrationBuilder.RenameTable(
                name: "GioiThieuChung",
                newName: "Gioi_thieu_chung");

            migrationBuilder.RenameTable(
                name: "DeTaiHhoaHocAnPham",
                newName: "De_tai_khoa_hoc_an_pham");

            migrationBuilder.RenameTable(
                name: "ChucNangNhiemVu",
                newName: "Chuc_nang_nhiem_vu");

            migrationBuilder.RenameTable(
                name: "ChiDan",
                newName: "Chi_dan");

            migrationBuilder.RenameTable(
                name: "CongTacSuuTam",
                newName: "Cong_tac_suu_tam");

            migrationBuilder.RenameTable(
                name: "CoCauToChuc",
                newName: "Co_cau_to_chuc");

            migrationBuilder.RenameTable(
                name: "CacBoSuuTap",
                newName: "Cac_bo_suu_tap");

            migrationBuilder.RenameTable(
                name: "BaoVatQuocGia",
                newName: "Bao_vat_quoc_gia");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trung_bay_thuong_xuyen",
                table: "Trung_bay_thuong_xuyen",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trung_bay_luu_dong",
                table: "Trung_bay_luu_dong",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trung_bay_chuyen_de",
                table: "Trung_bay_chuyen_de",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Thoi_gian_mo_cua",
                table: "Thoi_gian_mo_cua",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tin_noi_bat",
                table: "Tin_noi_bat",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Su_kien_sap_dien_ra",
                table: "Su_kien_sap_dien_ra",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Noi_quy_tham_quan",
                table: "Noi_quy_tham_quan",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Khai_quat_khao_co_hoc",
                table: "Khai_quat_khao_co_hoc",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kien_thuc_lich_su_van_hoa",
                table: "Kien_thuc_lich_su_van_hoa",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Huong_dan_tham_quan",
                table: "Huong_dan_tham_quan",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hoat_dong_giao_duc",
                table: "Hoat_dong_giao_duc",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hien_vat_tieu_bieu",
                table: "Hien_vat_tieu_bieu",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gioi_thieu_chung",
                table: "Gioi_thieu_chung",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_De_tai_khoa_hoc_an_pham",
                table: "De_tai_khoa_hoc_an_pham",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chuc_nang_nhiem_vu",
                table: "Chuc_nang_nhiem_vu",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chi_dan",
                table: "Chi_dan",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cong_tac_suu_tam",
                table: "Cong_tac_suu_tam",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Co_cau_to_chuc",
                table: "Co_cau_to_chuc",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cac_bo_suu_tap",
                table: "Cac_bo_suu_tap",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bao_vat_quoc_gia",
                table: "Bao_vat_quoc_gia",
                column: "ID");
        }
    }
}
