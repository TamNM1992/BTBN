using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaoTangBn.Data.Migrations
{
    public partial class btbn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Album",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar", nullable: false),
                    Mota = table.Column<string>(type: "nvarchar", nullable: false),
                    NoiDungAlbum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThaiXuatBan = table.Column<bool>(type: "bit", nullable: false),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IDNguoiTao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDNguoiSua = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IDNguoiXoa = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Bao_vat_quoc_gia",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar", nullable: false),
                    TieuDe = table.Column<string>(type: "nvarchar", nullable: false),
                    Nguon = table.Column<string>(type: "nvarchar", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar", nullable: false),
                    AnhMinhHoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThaiXuatBan = table.Column<bool>(type: "bit", nullable: false),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IDNguoiTao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDNguoiSua = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IDNguoiXoa = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bao_vat_quoc_gia", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Cac_bo_suu_tap",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar", nullable: false),
                    TieuDe = table.Column<string>(type: "nvarchar", nullable: false),
                    Nguon = table.Column<string>(type: "nvarchar", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar", nullable: false),
                    AnhMinhHoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThaiXuatBan = table.Column<bool>(type: "bit", nullable: false),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IDNguoiTao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDNguoiSua = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IDNguoiXoa = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cac_bo_suu_tap", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Co_cau_to_chuc",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar", nullable: false),
                    TomTat = table.Column<string>(type: "nvarchar", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar", nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IDNguoiSua = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Co_cau_to_chuc", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Cong_tac_suu_tam",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar", nullable: false),
                    TieuDe = table.Column<string>(type: "nvarchar", nullable: false),
                    Nguon = table.Column<string>(type: "nvarchar", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar", nullable: false),
                    AnhMinhHoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThaiXuatBan = table.Column<bool>(type: "bit", nullable: false),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IDNguoiTao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDNguoiSua = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IDNguoiXoa = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cong_tac_suu_tam", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Chi_dan",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar", nullable: false),
                    TomTat = table.Column<string>(type: "nvarchar", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar", nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IDNguoiSua = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chi_dan", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Chuc_nang_nhiem_vu",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar", nullable: false),
                    TomTat = table.Column<string>(type: "nvarchar", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar", nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IDNguoiSua = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chuc_nang_nhiem_vu", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "De_tai_khoa_hoc_an_pham",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar", nullable: false),
                    TieuDe = table.Column<string>(type: "nvarchar", nullable: false),
                    Nguon = table.Column<string>(type: "nvarchar", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar", nullable: false),
                    AnhMinhHoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThaiXuatBan = table.Column<bool>(type: "bit", nullable: false),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IDNguoiTao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDNguoiSua = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IDNguoiXoa = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_De_tai_khoa_hoc_an_pham", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Gioi_thieu_chung",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar", nullable: false),
                    TomTat = table.Column<string>(type: "nvarchar", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar", nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IDNguoiSua = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gioi_thieu_chung", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Hien_vat_tieu_bieu",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar", nullable: false),
                    TieuDe = table.Column<string>(type: "nvarchar", nullable: false),
                    Nguon = table.Column<string>(type: "nvarchar", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar", nullable: false),
                    AnhMinhHoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThaiXuatBan = table.Column<bool>(type: "bit", nullable: false),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IDNguoiTao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDNguoiSua = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IDNguoiXoa = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hien_vat_tieu_bieu", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Hoat_dong_giao_duc",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar", nullable: false),
                    TieuDe = table.Column<string>(type: "nvarchar", nullable: false),
                    Nguon = table.Column<string>(type: "nvarchar", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar", nullable: false),
                    AnhMinhHoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThaiXuatBan = table.Column<bool>(type: "bit", nullable: false),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IDNguoiTao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDNguoiSua = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IDNguoiXoa = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hoat_dong_giao_duc", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Huong_dan_tham_quan",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar", nullable: false),
                    TieuDe = table.Column<string>(type: "nvarchar", nullable: false),
                    Nguon = table.Column<string>(type: "nvarchar", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar", nullable: false),
                    AnhMinhHoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThaiXuatBan = table.Column<bool>(type: "bit", nullable: false),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IDNguoiTao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDNguoiSua = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IDNguoiXoa = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Huong_dan_tham_quan", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Kien_thuc_lich_su_van_hoa",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar", nullable: false),
                    TieuDe = table.Column<string>(type: "nvarchar", nullable: false),
                    Nguon = table.Column<string>(type: "nvarchar", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar", nullable: false),
                    AnhMinhHoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThaiXuatBan = table.Column<bool>(type: "bit", nullable: false),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IDNguoiTao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDNguoiSua = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IDNguoiXoa = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kien_thuc_lich_su_van_hoa", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Khai_quat_khao_co_hoc",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar", nullable: false),
                    TieuDe = table.Column<string>(type: "nvarchar", nullable: false),
                    Nguon = table.Column<string>(type: "nvarchar", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar", nullable: false),
                    AnhMinhHoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThaiXuatBan = table.Column<bool>(type: "bit", nullable: false),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IDNguoiTao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDNguoiSua = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IDNguoiXoa = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khai_quat_khao_co_hoc", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Noi_quy_tham_quan",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar", nullable: false),
                    TomTat = table.Column<string>(type: "nvarchar", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar", nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IDNguoiSua = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Noi_quy_tham_quan", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Su_kien_sap_dien_ra",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar", nullable: false),
                    TieuDe = table.Column<string>(type: "nvarchar", nullable: false),
                    Nguon = table.Column<string>(type: "nvarchar", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar", nullable: false),
                    AnhMinhHoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThaiXuatBan = table.Column<bool>(type: "bit", nullable: false),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IDNguoiTao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDNguoiSua = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IDNguoiXoa = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Su_kien_sap_dien_ra", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tin_noi_bat",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar", nullable: false),
                    TieuDe = table.Column<string>(type: "nvarchar", nullable: false),
                    Nguon = table.Column<string>(type: "nvarchar", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar", nullable: false),
                    AnhMinhHoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThaiXuatBan = table.Column<bool>(type: "bit", nullable: false),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IDNguoiTao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDNguoiSua = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IDNguoiXoa = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tin_noi_bat", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Thoi_gian_mo_cua",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar", nullable: false),
                    TomTat = table.Column<string>(type: "nvarchar", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar", nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IDNguoiSua = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thoi_gian_mo_cua", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Trung_bay_chuyen_de",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar", nullable: false),
                    TieuDe = table.Column<string>(type: "nvarchar", nullable: false),
                    Nguon = table.Column<string>(type: "nvarchar", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar", nullable: false),
                    AnhMinhHoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThaiXuatBan = table.Column<bool>(type: "bit", nullable: false),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IDNguoiTao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDNguoiSua = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IDNguoiXoa = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trung_bay_chuyen_de", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Trung_bay_luu_dong",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar", nullable: false),
                    TieuDe = table.Column<string>(type: "nvarchar", nullable: false),
                    Nguon = table.Column<string>(type: "nvarchar", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar", nullable: false),
                    AnhMinhHoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThaiXuatBan = table.Column<bool>(type: "bit", nullable: false),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IDNguoiTao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDNguoiSua = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IDNguoiXoa = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trung_bay_luu_dong", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Trung_bay_thuong_xuyen",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar", nullable: false),
                    TieuDe = table.Column<string>(type: "nvarchar", nullable: false),
                    Nguon = table.Column<string>(type: "nvarchar", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar", nullable: false),
                    AnhMinhHoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThaiXuatBan = table.Column<bool>(type: "bit", nullable: false),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IDNguoiTao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDNguoiSua = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IDNguoiXoa = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trung_bay_thuong_xuyen", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Video",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar", nullable: false),
                    MaVideo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar", nullable: false),
                    AnhMinhHoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true),
                    Ngay_tao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ngay_sua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ngay_xoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IDNguoiTao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDNguoiSua = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IDNguoiXoa = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RoleUser",
                columns: table => new
                {
                    RolesID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUser", x => new { x.RolesID, x.UsersId });
                    table.ForeignKey(
                        name: "FK_RoleUser_Role_RolesID",
                        column: x => x.RolesID,
                        principalTable: "Role",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleUser_User_UsersId",
                        column: x => x.UsersId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleUser_UsersId",
                table: "RoleUser",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Album");

            migrationBuilder.DropTable(
                name: "Bao_vat_quoc_gia");

            migrationBuilder.DropTable(
                name: "Cac_bo_suu_tap");

            migrationBuilder.DropTable(
                name: "Co_cau_to_chuc");

            migrationBuilder.DropTable(
                name: "Cong_tac_suu_tam");

            migrationBuilder.DropTable(
                name: "Chi_dan");

            migrationBuilder.DropTable(
                name: "Chuc_nang_nhiem_vu");

            migrationBuilder.DropTable(
                name: "De_tai_khoa_hoc_an_pham");

            migrationBuilder.DropTable(
                name: "Gioi_thieu_chung");

            migrationBuilder.DropTable(
                name: "Hien_vat_tieu_bieu");

            migrationBuilder.DropTable(
                name: "Hoat_dong_giao_duc");

            migrationBuilder.DropTable(
                name: "Huong_dan_tham_quan");

            migrationBuilder.DropTable(
                name: "Kien_thuc_lich_su_van_hoa");

            migrationBuilder.DropTable(
                name: "Khai_quat_khao_co_hoc");

            migrationBuilder.DropTable(
                name: "Noi_quy_tham_quan");

            migrationBuilder.DropTable(
                name: "RoleUser");

            migrationBuilder.DropTable(
                name: "Su_kien_sap_dien_ra");

            migrationBuilder.DropTable(
                name: "Tin_noi_bat");

            migrationBuilder.DropTable(
                name: "Thoi_gian_mo_cua");

            migrationBuilder.DropTable(
                name: "Trung_bay_chuyen_de");

            migrationBuilder.DropTable(
                name: "Trung_bay_luu_dong");

            migrationBuilder.DropTable(
                name: "Trung_bay_thuong_xuyen");

            migrationBuilder.DropTable(
                name: "Video");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
