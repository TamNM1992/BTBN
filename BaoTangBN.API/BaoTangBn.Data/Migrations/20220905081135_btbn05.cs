using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaoTangBn.Data.Migrations
{
    public partial class btbn05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChiDan",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TomTat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IDNguoiSua = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiDan", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NoiQuyThamQuan",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TomTat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IDNguoiSua = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoiQuyThamQuan", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ThoiGianMoCua",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TomTat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IDNguoiSua = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThoiGianMoCua", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiDan");

            migrationBuilder.DropTable(
                name: "NoiQuyThamQuan");

            migrationBuilder.DropTable(
                name: "ThoiGianMoCua");
        }
    }
}
