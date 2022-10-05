using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaoTangBn.Data.Migrations
{
    public partial class btbn07 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ngay_xoa",
                table: "Video",
                newName: "NgayXoa");

            migrationBuilder.RenameColumn(
                name: "Ngay_tao",
                table: "Video",
                newName: "NgayTao");

            migrationBuilder.RenameColumn(
                name: "Ngay_sua",
                table: "Video",
                newName: "NgaySua");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NgayXoa",
                table: "Video",
                newName: "Ngay_xoa");

            migrationBuilder.RenameColumn(
                name: "NgayTao",
                table: "Video",
                newName: "Ngay_tao");

            migrationBuilder.RenameColumn(
                name: "NgaySua",
                table: "Video",
                newName: "Ngay_sua");
        }
    }
}
