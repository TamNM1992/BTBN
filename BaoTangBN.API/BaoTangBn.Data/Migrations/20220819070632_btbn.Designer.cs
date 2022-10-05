﻿// <auto-generated />
using System;
using BaoTangBn.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BaoTangBn.Data.Migrations
{
    [DbContext(typeof(BaoTangBNDataContext))]
    [Migration("20220819070632_btbn")]
    partial class btbn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BaoTangBn.Data.Models.Album", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("DaXoa")
                        .HasColumnType("bit");

                    b.Property<Guid?>("IDNguoiSua")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDNguoiTao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IDNguoiXoa")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Mota")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<DateTime?>("NgaySua")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayXoa")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoiDungAlbum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<bool>("TrangThaiXuatBan")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("Album");
                });

            modelBuilder.Entity("BaoTangBn.Data.Models.Bao_vat_quoc_gia", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AnhMinhHoa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("DaXoa")
                        .HasColumnType("bit");

                    b.Property<Guid?>("IDNguoiSua")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDNguoiTao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IDNguoiXoa")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("NgaySua")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayXoa")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nguon")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("TieuDe")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<bool>("TrangThaiXuatBan")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("Bao_vat_quoc_gia");
                });

            modelBuilder.Entity("BaoTangBn.Data.Models.Cac_bo_suu_tap", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AnhMinhHoa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("DaXoa")
                        .HasColumnType("bit");

                    b.Property<Guid?>("IDNguoiSua")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDNguoiTao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IDNguoiXoa")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("NgaySua")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayXoa")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nguon")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("TieuDe")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<bool>("TrangThaiXuatBan")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("Cac_bo_suu_tap");
                });

            modelBuilder.Entity("BaoTangBn.Data.Models.Co_cau_to_chuc", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IDNguoiSua")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("NgaySua")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("TomTat")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.HasKey("ID");

                    b.ToTable("Co_cau_to_chuc");
                });

            modelBuilder.Entity("BaoTangBn.Data.Models.Cong_tac_suu_tam", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AnhMinhHoa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("DaXoa")
                        .HasColumnType("bit");

                    b.Property<Guid?>("IDNguoiSua")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDNguoiTao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IDNguoiXoa")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("NgaySua")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayXoa")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nguon")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("TieuDe")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<bool>("TrangThaiXuatBan")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("Cong_tac_suu_tam");
                });

            modelBuilder.Entity("BaoTangBn.Data.Models.Chi_dan", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IDNguoiSua")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("NgaySua")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("TomTat")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.HasKey("ID");

                    b.ToTable("Chi_dan");
                });

            modelBuilder.Entity("BaoTangBn.Data.Models.Chuc_nang_nhiem_vu", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IDNguoiSua")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("NgaySua")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("TomTat")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.HasKey("ID");

                    b.ToTable("Chuc_nang_nhiem_vu");
                });

            modelBuilder.Entity("BaoTangBn.Data.Models.De_tai_khoa_hoc_an_pham", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AnhMinhHoa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("DaXoa")
                        .HasColumnType("bit");

                    b.Property<Guid?>("IDNguoiSua")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDNguoiTao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IDNguoiXoa")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("NgaySua")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayXoa")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nguon")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("TieuDe")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<bool>("TrangThaiXuatBan")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("De_tai_khoa_hoc_an_pham");
                });

            modelBuilder.Entity("BaoTangBn.Data.Models.Gioi_thieu_chung", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IDNguoiSua")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("NgaySua")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("TomTat")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.HasKey("ID");

                    b.ToTable("Gioi_thieu_chung");
                });

            modelBuilder.Entity("BaoTangBn.Data.Models.Hien_vat_tieu_bieu", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AnhMinhHoa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("DaXoa")
                        .HasColumnType("bit");

                    b.Property<Guid?>("IDNguoiSua")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDNguoiTao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IDNguoiXoa")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("NgaySua")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayXoa")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nguon")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("TieuDe")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<bool>("TrangThaiXuatBan")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("Hien_vat_tieu_bieu");
                });

            modelBuilder.Entity("BaoTangBn.Data.Models.Hoat_dong_giao_duc", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AnhMinhHoa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("DaXoa")
                        .HasColumnType("bit");

                    b.Property<Guid?>("IDNguoiSua")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDNguoiTao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IDNguoiXoa")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("NgaySua")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayXoa")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nguon")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("TieuDe")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<bool>("TrangThaiXuatBan")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("Hoat_dong_giao_duc");
                });

            modelBuilder.Entity("BaoTangBn.Data.Models.Huong_dan_tham_quan", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AnhMinhHoa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("DaXoa")
                        .HasColumnType("bit");

                    b.Property<Guid?>("IDNguoiSua")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDNguoiTao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IDNguoiXoa")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("NgaySua")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayXoa")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nguon")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("TieuDe")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<bool>("TrangThaiXuatBan")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("Huong_dan_tham_quan");
                });

            modelBuilder.Entity("BaoTangBn.Data.Models.Kien_thuc_lich_su_van_hoa", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AnhMinhHoa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("DaXoa")
                        .HasColumnType("bit");

                    b.Property<Guid?>("IDNguoiSua")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDNguoiTao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IDNguoiXoa")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("NgaySua")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayXoa")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nguon")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("TieuDe")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<bool>("TrangThaiXuatBan")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("Kien_thuc_lich_su_van_hoa");
                });

            modelBuilder.Entity("BaoTangBn.Data.Models.Khai_quat_khao_co_hoc", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AnhMinhHoa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("DaXoa")
                        .HasColumnType("bit");

                    b.Property<Guid?>("IDNguoiSua")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDNguoiTao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IDNguoiXoa")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("NgaySua")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayXoa")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nguon")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("TieuDe")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<bool>("TrangThaiXuatBan")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("Khai_quat_khao_co_hoc");
                });

            modelBuilder.Entity("BaoTangBn.Data.Models.Noi_quy_tham_quan", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IDNguoiSua")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("NgaySua")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("TomTat")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.HasKey("ID");

                    b.ToTable("Noi_quy_tham_quan");
                });

            modelBuilder.Entity("BaoTangBn.Data.Models.Role", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("BaoTangBn.Data.Models.Su_kien_sap_dien_ra", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AnhMinhHoa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("DaXoa")
                        .HasColumnType("bit");

                    b.Property<Guid?>("IDNguoiSua")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDNguoiTao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IDNguoiXoa")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("NgaySua")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayXoa")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nguon")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("TieuDe")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<bool>("TrangThaiXuatBan")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("Su_kien_sap_dien_ra");
                });

            modelBuilder.Entity("BaoTangBn.Data.Models.Tin_noi_bat", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AnhMinhHoa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("DaXoa")
                        .HasColumnType("bit");

                    b.Property<Guid?>("IDNguoiSua")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDNguoiTao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IDNguoiXoa")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("NgaySua")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayXoa")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nguon")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("TieuDe")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<bool>("TrangThaiXuatBan")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("Tin_noi_bat");
                });

            modelBuilder.Entity("BaoTangBn.Data.Models.Thoi_gian_mo_cua", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IDNguoiSua")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("NgaySua")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("TomTat")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.HasKey("ID");

                    b.ToTable("Thoi_gian_mo_cua");
                });

            modelBuilder.Entity("BaoTangBn.Data.Models.Trung_bay_chuyen_de", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AnhMinhHoa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("DaXoa")
                        .HasColumnType("bit");

                    b.Property<Guid?>("IDNguoiSua")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDNguoiTao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IDNguoiXoa")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("NgaySua")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayXoa")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nguon")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("TieuDe")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<bool>("TrangThaiXuatBan")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("Trung_bay_chuyen_de");
                });

            modelBuilder.Entity("BaoTangBn.Data.Models.Trung_bay_luu_dong", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AnhMinhHoa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("DaXoa")
                        .HasColumnType("bit");

                    b.Property<Guid?>("IDNguoiSua")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDNguoiTao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IDNguoiXoa")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("NgaySua")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayXoa")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nguon")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("TieuDe")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<bool>("TrangThaiXuatBan")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("Trung_bay_luu_dong");
                });

            modelBuilder.Entity("BaoTangBn.Data.Models.Trung_bay_thuong_xuyen", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AnhMinhHoa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("DaXoa")
                        .HasColumnType("bit");

                    b.Property<Guid?>("IDNguoiSua")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDNguoiTao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IDNguoiXoa")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("NgaySua")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayXoa")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nguon")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("TieuDe")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<bool>("TrangThaiXuatBan")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("Trung_bay_thuong_xuyen");
                });

            modelBuilder.Entity("BaoTangBn.Data.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsActive")
                        .HasMaxLength(200)
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("BaoTangBn.Data.Models.Video", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AnhMinhHoa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("DaXoa")
                        .HasColumnType("bit");

                    b.Property<Guid?>("IDNguoiSua")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDNguoiTao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IDNguoiXoa")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MaVideo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<DateTime?>("Ngay_sua")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Ngay_tao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Ngay_xoa")
                        .HasColumnType("datetime2");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.HasKey("ID");

                    b.ToTable("Video");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.Property<Guid>("RolesID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RolesID", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("RoleUser");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.HasOne("BaoTangBn.Data.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BaoTangBn.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}