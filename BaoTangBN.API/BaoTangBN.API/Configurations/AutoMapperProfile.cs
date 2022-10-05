using AutoMapper;
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;

namespace BaoTangBn.API.Configurations
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Tin Nổi bật
            CreateMap<TinNoiBat, TinNoiBatDto>().ReverseMap();
            CreateMap<TinNoiBatDto, TinNoiBat>().ReverseMap();
            CreateMap<TinNoiBat, TinNoiBat_ShowOnViewer>().ReverseMap();
            CreateMap<TinNoiBat_ShowOnViewer, TinNoiBat>().ReverseMap(); 
            CreateMap<TinNoiBat_Related, TinNoiBat>().ReverseMap();
            CreateMap<TinNoiBat, TinNoiBat_Related>().ReverseMap();
            CreateMap<TinNoiBat, TinNoiBat_ShowOnUser>().ReverseMap();
            CreateMap<TinNoiBat_ShowOnUser, TinNoiBat>().ReverseMap();
            //---------------------------------
            //Sự kiện sắp diễn ra
            CreateMap<SuKienSapDienRa, SuKienSapDienRaDto>().ReverseMap();
            CreateMap<SuKienSapDienRaDto, SuKienSapDienRa>().ReverseMap();
            CreateMap<SuKienSapDienRa, SuKienSapDienRa_ShowOnViewer>().ReverseMap();
            CreateMap<SuKienSapDienRa_ShowOnViewer, SuKienSapDienRa>().ReverseMap();
            CreateMap<SuKienSapDienRa_Related, SuKienSapDienRa>().ReverseMap();
            CreateMap<SuKienSapDienRa, SuKienSapDienRa_Related>().ReverseMap();
            CreateMap<SuKienSapDienRa, SuKienSapDienRa_ShowOnUser>().ReverseMap();
            CreateMap<SuKienSapDienRa_ShowOnUser, SuKienSapDienRa>().ReverseMap();
            //---------------------------------
            // Trưng bày thường xuyên
            CreateMap<TrungBayThuongXuyen, TrungBayThuongXuyenDto>().ReverseMap();
            CreateMap<TrungBayThuongXuyenDto, TrungBayThuongXuyen>().ReverseMap();
            CreateMap<TrungBayThuongXuyen, TrungBayThuongXuyen_ShowOnViewer>().ReverseMap();
            CreateMap<TrungBayThuongXuyen_ShowOnViewer, TrungBayThuongXuyen>().ReverseMap();
            CreateMap<TrungBayThuongXuyen_Related, TrungBayThuongXuyen>().ReverseMap();
            CreateMap<TrungBayThuongXuyen, TrungBayThuongXuyen_Related>().ReverseMap();
            CreateMap<TrungBayThuongXuyen, TrungBayThuongXuyen_ShowOnUser>().ReverseMap();
            CreateMap<TrungBayThuongXuyen_ShowOnUser, TrungBayThuongXuyen>().ReverseMap();
            // Trưng bày lưu động
            CreateMap<TrungBayLuuDong, TrungBayLuuDongDto>().ReverseMap();
            CreateMap<TrungBayLuuDongDto, TrungBayLuuDong>().ReverseMap();
            CreateMap<TrungBayLuuDong, TrungBayLuuDong_ShowOnViewer>().ReverseMap();
            CreateMap<TrungBayLuuDong_ShowOnViewer, TrungBayLuuDong>().ReverseMap();
            CreateMap<TrungBayLuuDong_Related, TrungBayLuuDong>().ReverseMap();
            CreateMap<TrungBayLuuDong, TrungBayLuuDong_Related>().ReverseMap();
            CreateMap<TrungBayLuuDong, TrungBayLuuDong_ShowOnUser>().ReverseMap();
            CreateMap<TrungBayLuuDong_ShowOnUser, TrungBayLuuDong>().ReverseMap();
            // Trưng bày chuyên đề
            CreateMap<TrungBayChuyenDe, TrungBayChuyenDeDto>().ReverseMap();
            CreateMap<TrungBayChuyenDeDto, TrungBayChuyenDe>().ReverseMap();
            CreateMap<TrungBayChuyenDe, TrungBayChuyenDe_ShowOnViewer>().ReverseMap();
            CreateMap<TrungBayChuyenDe_ShowOnViewer, TrungBayChuyenDe>().ReverseMap();
            CreateMap<TrungBayChuyenDe_Related, TrungBayChuyenDe>().ReverseMap();
            CreateMap<TrungBayChuyenDe, TrungBayChuyenDe_Related>().ReverseMap();
            CreateMap<TrungBayChuyenDe, TrungBayChuyenDe_ShowOnUser>().ReverseMap();
            CreateMap<TrungBayChuyenDe_ShowOnUser, TrungBayChuyenDe>().ReverseMap();
            //---------------------------------
            // Công tác sưu tầm
            CreateMap<CongTacSuuTam, CongTacSuuTamDto>().ReverseMap();
            CreateMap<CongTacSuuTamDto, CongTacSuuTam>().ReverseMap();
            CreateMap<CongTacSuuTam, CongTacSuuTam_ShowOnViewer>().ReverseMap();
            CreateMap<CongTacSuuTam_ShowOnViewer, CongTacSuuTam>().ReverseMap();
            CreateMap<CongTacSuuTam_Related, CongTacSuuTam>().ReverseMap();
            CreateMap<CongTacSuuTam, CongTacSuuTam_Related>().ReverseMap();
            CreateMap<CongTacSuuTam, CongTacSuuTam_ShowOnUser>().ReverseMap();
            CreateMap<CongTacSuuTam_ShowOnUser, CongTacSuuTam>().ReverseMap();
            //---------------------------------
            // Đề tài khoa học ấn phẩm
            CreateMap<DeTaiKhoaHocAnPham, DeTaiKhoaHocAnPhamDto>().ReverseMap();
            CreateMap<DeTaiKhoaHocAnPhamDto, DeTaiKhoaHocAnPham>().ReverseMap();
            CreateMap<DeTaiKhoaHocAnPham, DeTaiKhoaHocAnPham_ShowOnViewer>().ReverseMap();
            CreateMap<DeTaiKhoaHocAnPham_ShowOnViewer, DeTaiKhoaHocAnPham>().ReverseMap();
            CreateMap<DeTaiKhoaHocAnPham_Related, DeTaiKhoaHocAnPham>().ReverseMap();
            CreateMap<DeTaiKhoaHocAnPham, DeTaiKhoaHocAnPham_Related>().ReverseMap();
            CreateMap<DeTaiKhoaHocAnPham, DeTaiKhoaHocAnPham_ShowOnUser>().ReverseMap();
            CreateMap<DeTaiKhoaHocAnPham_ShowOnUser, DeTaiKhoaHocAnPham>().ReverseMap();
            //---------------------------------
            // Kiến thức lịch sử văn hóa
            CreateMap<KienThucLichSuVanHoa, KienThucLichSuVanHoaDto>().ReverseMap();
            CreateMap<KienThucLichSuVanHoaDto, KienThucLichSuVanHoa>().ReverseMap();
            CreateMap<KienThucLichSuVanHoa, KienThucLichSuVanHoa_ShowOnViewer>().ReverseMap();
            CreateMap<KienThucLichSuVanHoa_ShowOnViewer, KienThucLichSuVanHoa>().ReverseMap();
            CreateMap<KienThucLichSuVanHoa_Related, KienThucLichSuVanHoa>().ReverseMap();
            CreateMap<KienThucLichSuVanHoa, KienThucLichSuVanHoa_Related>().ReverseMap();
            CreateMap<KienThucLichSuVanHoa, KienThucLichSuVanHoa_ShowOnUser>().ReverseMap();
            CreateMap<KienThucLichSuVanHoa_ShowOnUser, KienThucLichSuVanHoa>().ReverseMap();
            //---------------------------------
            // Khai quật khảo cổ học
            CreateMap<KhaiQuatKhaoCoHoc, KhaiQuatKhaoCoHocDto>().ReverseMap();
            CreateMap<KhaiQuatKhaoCoHocDto, KhaiQuatKhaoCoHoc>().ReverseMap();
            CreateMap<KhaiQuatKhaoCoHoc, KhaiQuatKhaoCoHoc_ShowOnViewer>().ReverseMap();
            CreateMap<KhaiQuatKhaoCoHoc_ShowOnViewer, KhaiQuatKhaoCoHoc>().ReverseMap();
            CreateMap<KhaiQuatKhaoCoHoc_Related, KhaiQuatKhaoCoHoc>().ReverseMap();
            CreateMap<KhaiQuatKhaoCoHoc, KhaiQuatKhaoCoHoc_Related>().ReverseMap();
            CreateMap<KhaiQuatKhaoCoHoc, KhaiQuatKhaoCoHoc_ShowOnUser>().ReverseMap();
            CreateMap<KhaiQuatKhaoCoHoc_ShowOnUser, KhaiQuatKhaoCoHoc>().ReverseMap();
            //---------------------------------
            // Hiện Vật Tiêu Biểu
            CreateMap<HienVatTieuBieu, HienVatTieuBieuDto>().ReverseMap();
            CreateMap<HienVatTieuBieuDto, HienVatTieuBieu>().ReverseMap();
            CreateMap<HienVatTieuBieu, HienVatTieuBieu_ShowOnViewer>().ReverseMap();
            CreateMap<HienVatTieuBieu_ShowOnViewer, HienVatTieuBieu>().ReverseMap();
            CreateMap<HienVatTieuBieu_Related, HienVatTieuBieu>().ReverseMap();
            CreateMap<HienVatTieuBieu, HienVatTieuBieu_Related>().ReverseMap();
            CreateMap<HienVatTieuBieu, HienVatTieuBieu_ShowOnUser>().ReverseMap();
            CreateMap<HienVatTieuBieu_ShowOnUser, HienVatTieuBieu>().ReverseMap();
            //---------------------------------
            // Bảo vật quốc gia
            CreateMap<BaoVatQuocGia, BaoVatQuocGiaDto>().ReverseMap();
            CreateMap<BaoVatQuocGiaDto, BaoVatQuocGia>().ReverseMap();
            CreateMap<BaoVatQuocGia, BaoVatQuocGia_ShowOnViewer>().ReverseMap();
            CreateMap<BaoVatQuocGia_ShowOnViewer, BaoVatQuocGia>().ReverseMap();
            CreateMap<BaoVatQuocGia_Related, BaoVatQuocGia>().ReverseMap();
            CreateMap<BaoVatQuocGia, BaoVatQuocGia_Related>().ReverseMap();
            CreateMap<BaoVatQuocGia, BaoVatQuocGia_ShowOnUser>().ReverseMap();
            CreateMap<BaoVatQuocGia_ShowOnUser, BaoVatQuocGia>().ReverseMap();
            //---------------------------------
            // Các bộ sưu tập
            CreateMap<CacBoSuuTap, CacBoSuuTapDto>().ReverseMap();
            CreateMap<CacBoSuuTapDto, CacBoSuuTap>().ReverseMap();
            CreateMap<CacBoSuuTap, CacBoSuuTap_ShowOnViewer>().ReverseMap();
            CreateMap<CacBoSuuTap_ShowOnViewer, CacBoSuuTap>().ReverseMap();
            CreateMap<CacBoSuuTap_Related, CacBoSuuTap>().ReverseMap();
            CreateMap<CacBoSuuTap, CacBoSuuTap_Related>().ReverseMap();
            CreateMap<CacBoSuuTap, CacBoSuuTap_ShowOnUser>().ReverseMap();
            CreateMap<CacBoSuuTap_ShowOnUser, CacBoSuuTap>().ReverseMap();
            //---------------------------------
            // Hoạt động giáo dục
            CreateMap<HoatDongGiaoDuc, HoatDongGiaoDucDto>().ReverseMap();
            CreateMap<HoatDongGiaoDucDto, HoatDongGiaoDuc>().ReverseMap();
            CreateMap<HoatDongGiaoDuc, HoatDongGiaoDuc_ShowOnViewer>().ReverseMap();
            CreateMap<HoatDongGiaoDuc_ShowOnViewer, HoatDongGiaoDuc>().ReverseMap();
            CreateMap<HoatDongGiaoDuc_Related, HoatDongGiaoDuc>().ReverseMap();
            CreateMap<HoatDongGiaoDuc, HoatDongGiaoDuc_Related>().ReverseMap();
            CreateMap<HoatDongGiaoDuc, HoatDongGiaoDuc_ShowOnUser>().ReverseMap();
            CreateMap<HoatDongGiaoDuc_ShowOnUser, HoatDongGiaoDuc>().ReverseMap();
            //---------------------------------
            // HƯớng dẫn tham quan
            CreateMap<HuongDanThamQuan, HuongDanThamQuanDto>().ReverseMap();
            CreateMap<HuongDanThamQuanDto, HuongDanThamQuan>().ReverseMap();
            CreateMap<HuongDanThamQuan, HuongDanThamQuan_ShowOnViewer>().ReverseMap();
            CreateMap<HuongDanThamQuan_ShowOnViewer, HuongDanThamQuan>().ReverseMap();
            CreateMap<HuongDanThamQuan_Related, HuongDanThamQuan>().ReverseMap();
            CreateMap<HuongDanThamQuan, HuongDanThamQuan_Related>().ReverseMap();
            CreateMap<HuongDanThamQuan, HuongDanThamQuan_ShowOnUser>().ReverseMap();
            CreateMap<HuongDanThamQuan_ShowOnUser, HuongDanThamQuan>().ReverseMap();
            // Video
            CreateMap<Video, VideoDto>().ReverseMap();
            CreateMap<VideoDto, Video>().ReverseMap();
            CreateMap<Video, Video_ShowOnViewer>().ReverseMap();
            CreateMap<Video_ShowOnViewer, Video>().ReverseMap();
            CreateMap<Video_Related, Video>().ReverseMap();
            CreateMap<Video, Video_Related>().ReverseMap();
            CreateMap<Video, Video_ShowOnUser>().ReverseMap();
            CreateMap<Video_ShowOnUser, Video>().ReverseMap();
            // Album
            CreateMap<Album, AlbumDto>().ReverseMap();
            CreateMap<AlbumDto, Album>().ReverseMap();
            CreateMap<Album, Album_ShowOnViewer>().ReverseMap();
            CreateMap<Album_ShowOnViewer, Album>().ReverseMap();
            CreateMap<Album_Related, Album>().ReverseMap();
            CreateMap<Album, Album_Related>().ReverseMap();
            CreateMap<Album, Album_ShowOnUser>().ReverseMap();
            CreateMap<Album_ShowOnUser, Album>().ReverseMap();
            //---------------------------------
            // Chi dẫn
            CreateMap<ChiDan, ChiDanDto>().ReverseMap();
            CreateMap<ChiDanDto, ChiDan>().ReverseMap();
            //---------------------------------
            // Nội quy tham quan
            CreateMap<NoiQuyThamQuan, NoiQuyThamQuanDto>().ReverseMap();
            CreateMap<NoiQuyThamQuanDto, NoiQuyThamQuan>().ReverseMap(); 
            //---------------------------------
            // Thời gian mở cửa
            CreateMap<ThoiGianMoCua, ThoiGianMoCuaDto>().ReverseMap();
            CreateMap<ThoiGianMoCuaDto, ThoiGianMoCua>().ReverseMap(); 
            //---------------------------------
            // Cơ cấu tổ chức
            CreateMap<CoCauToChuc, CoCauToChucDto>().ReverseMap();
            CreateMap<CoCauToChucDto, CoCauToChuc>().ReverseMap(); 
            //---------------------------------
            // Chức năng nhiệm vụ
            CreateMap<ChucNangNhiemVu, ChucNangNhiemVuDto>().ReverseMap();
            CreateMap<ChucNangNhiemVuDto, ChucNangNhiemVu>().ReverseMap();
            //---------------------------------
            // Giới thiệu chung
            CreateMap<GioiThieuChung, GioiThieuChungDto>().ReverseMap();
            CreateMap<GioiThieuChungDto, GioiThieuChung>().ReverseMap(); 
            //---------------------------------
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<RoleDto, Role>().ReverseMap();


        }
    }
}
