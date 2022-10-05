using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaoTangBn.Data.Migrations
{
    public partial class btbn4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeTaiHhoaHocAnPham");

            migrationBuilder.CreateTable(
                name: "DeTaiKhoaHocAnPham",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TieuDe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nguon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_DeTaiKhoaHocAnPham", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeTaiKhoaHocAnPham");

            migrationBuilder.CreateTable(
                name: "DeTaiHhoaHocAnPham",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnhMinhHoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true),
                    IDNguoiSua = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IDNguoiTao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDNguoiXoa = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Nguon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TieuDe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThaiXuatBan = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeTaiHhoaHocAnPham", x => x.ID);
                });
        }
    }
}
