using BaoTangBn.API.Configurations;
using BaoTangBn.API.MiddleWare;
using BaoTangBn.API.Providers;
using BaoTangBn.Common.Models;
using BaoTangBn.Data.Models;
using BaoTangBn.Repo.AlbumRepo;
using BaoTangBn.Repo.BaoVatQuocGiaRepo;
using BaoTangBn.Repo.CacBoSuuTapRepo;
using BaoTangBn.Repo.ChiDanRepo;
using BaoTangBn.Repo.ChucNangNhiemVuRepo;
using BaoTangBn.Repo.CoCauToChucRepo;
using BaoTangBn.Repo.CongTacSuuTamRepo;
using BaoTangBn.Repo.DeTaiKhoaHocAnPhamRepo;
using BaoTangBn.Repo.GioiThieuChungRepo;
using BaoTangBn.Repo.HoatDongGiaoDucRepo;
using BaoTangBn.Repo.HuongDanThamQuanRepo;
using BaoTangBn.Repo.KhaiQuatKhaoCoHocRepo;
using BaoTangBn.Repo.KienThucLichSuVanHoaRepo;
using BaoTangBn.Repo.NoiQuyThamQuanRepo;
using BaoTangBn.Repo.RoleRepo;
using BaoTangBn.Repo.RoleUserRepo;
using BaoTangBn.Repo.SuKienSapDienRaRepo;
using BaoTangBn.Repo.ThoiGianMoCuaRepo;
using BaoTangBn.Repo.TinNoiBatRepo;
using BaoTangBn.Repo.TrungBayChuyenDeRepo;
using BaoTangBn.Repo.TrungBayLuuDongRepo;
using BaoTangBn.Repo.TrungBaythuongXuyenRepo;
using BaoTangBn.Repo.UserRepo;
using BaoTangBn.Repo.VideoRepo;
using BaoTangBn.Service.AlbumService;
using BaoTangBn.Service.AuthorityServices;
using BaoTangBn.Service.AuthUserServices;
using BaoTangBn.Service.BaoVatQuocGiaService;
using BaoTangBn.Service.CacBoSuuTapService;
using BaoTangBn.Service.ChiDanService;
using BaoTangBn.Service.ChucNangNhiemVuService;
using BaoTangBn.Service.CoCauToChucService;
using BaoTangBn.Service.CongTacSuuTamService;
using BaoTangBn.Service.DeTaiKhoaHocAnPhamService;
using BaoTangBn.Service.GioiThieuChungService;
using BaoTangBn.Service.HoatDongGiaoDucService;
using BaoTangBn.Service.HuongDanThamQuanService;
using BaoTangBn.Service.KhaiQuatKhaoCoHocService;
using BaoTangBn.Service.KienThucLichSuVanHoaService;
using BaoTangBn.Service.NoiQuyThamQuanService;
using BaoTangBn.Service.SuKienSapDienRaService;
using BaoTangBn.Service.ThoiGianMoCuaService;
using BaoTangBn.Service.TinNoiBatService;
using BaoTangBn.Service.TrungBayChuyenDeService;
using BaoTangBn.Service.TrungBayLuuDongService;
using BaoTangBn.Service.TrungBayThuongXuyenService;
using BaoTangBn.Service.UserService;
using BaoTangBn.Service.VideoService;
using Microsoft.EntityFrameworkCore;

using Microsoft.OpenApi.Models;

namespace BaoTangBn.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();
            //services.AddHttpClient();
            //services.AddHttpClient("myclient", client =>
            //{
            //    client.BaseAddress = new Uri("https://localhost:1234");
            //});
            services.AddHttpClient<MyTypedClient>();

            services.AddCors();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BaoTangBn.API", Version = "v1" });
            });
            services.AddCommonServices();
            services.AddHttpContextAccessor();
            // //service
            services.AddScoped<ITinNoiBatService, TinNoiBatService>();
            services.AddScoped<ISuKienSapDienRaService, SuKienSapDienRaService>();
            services.AddScoped<ITrungBayThuongXuyenService, TrungBayThuongXuyenService>();
            services.AddScoped<ITrungBayLuuDongService, TrungBayLuuDongService>();
            services.AddScoped<ITrungBayChuyenDeService, TrungBayChuyenDeService>();
            services.AddScoped<ICongTacSuuTamService, CongTacSuuTamService>();
            services.AddScoped<IDeTaiKhoaHocAnPhamService, DeTaiKhoaHocAnPhamService>();
            services.AddScoped<IKienThucLichSuVanHoaService, KienThucLichSuVanHoaService>();
            services.AddScoped<IKhaiQuatKhaoCoHocService, KhaiQuatKhaoCoHocService>();
            services.AddScoped<IKhaiQuatKhaoCoHocService, KhaiQuatKhaoCoHocService>();
            services.AddScoped<ICacBoSuuTapService, CacBoSuuTapService>();
            services.AddScoped<IBaoVatQuocGiaService, BaoVatQuocGiaService>();
            services.AddScoped<IHuongDanThamQuanService, HuongDanThamQuanService>();
            services.AddScoped<IHoatDongGiaoDucService, HoatDongGiaoDucService>();
            services.AddScoped<IChiDanService, ChiDanService>();
            services.AddScoped<INoiQuyThamQuanService, NoiQuyThamQuanService>();
            services.AddScoped<IThoiGianMoCuaService, ThoiGianMoCuaService>(); 
            services.AddScoped<ICoCauToChucService, CoCauToChucService>(); 
            services.AddScoped<IChucNangNhiemVuService, ChucNangNhiemVuService>(); 
            services.AddScoped<IGioiThieuChungService, GioiThieuChungService>();
            services.AddScoped<IVideoService, VideoService>();
            services.AddScoped<IAlbumService, AlbumService>();


            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IRoleUserService, RoleUserService>();

            // //repo
            services.AddScoped<ITinNoiBatRepository, TinNoiBatRepository>();
            services.AddScoped<ISuKienSapDienRaRepository, SuKienSapDienRaRepository>();
            services.AddScoped<ITrungBayThuongXuyenRepository, TrungBayThuongXuyenRepository>();
            services.AddScoped<ITrungBayLuuDongRepository, TrungBayLuuDongRepository>();
            services.AddScoped<ITrungBayChuyenDeRepository, TrungBayChuyenDeRepository>();
            services.AddScoped<ICongTacSuuTamRepository, CongTacSuuTamRepository>();
            services.AddScoped<IDeTaiKhoaHocAnPhamRepository, DeTaiKhoaHocAnPhamRepository>();
            services.AddScoped<IKienThucLichSuVanHoaRepository, KienThucLichSuVanHoaRepository>();
            services.AddScoped<IKhaiQuatKhaoCoHocRepository, KhaiQuatKhaoCoHocRepository>();
            services.AddScoped<IKhaiQuatKhaoCoHocRepository, KhaiQuatKhaoCoHocRepository>();
            services.AddScoped<ICacBoSuuTapRepository, CacBoSuuTapRepository>();
            services.AddScoped<IBaoVatQuocGiaRepository, BaoVatQuocGiaRepository>();
            services.AddScoped<IHuongDanThamQuanRepository, HuongDanThamQuanRepository>();
            services.AddScoped<IHoatDongGiaoDucRepository, HoatDongGiaoDucRepository>();
            services.AddScoped<IChiDanRepository, ChiDanRepository>();
            services.AddScoped<INoiQuyThamQuanRepository, NoiQuyThamQuanRepository>(); 
            services.AddScoped<IThoiGianMoCuaRepository, ThoiGianMoCuaRepository>(); 
            services.AddScoped<ICoCauToChucRepository, CoCauToChucRepository>();
            services.AddScoped<IChucNangNhiemVuRepository, ChucNangNhiemVuRepository>();
            services.AddScoped<IGioiThieuChungRepository, GioiThieuChungRepository>();
            services.AddScoped<IVideoRepository, VideoRepository>();
            services.AddScoped<IAlbumRepository, AlbumRepository>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleUserRepository, RoleUserRepository>();

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));


            string connectionString = Configuration.GetConnectionString("BaoTangBNDataContext");
            services.AddDbContext<BaoTangBNDataContext>(options =>
           options.UseSqlServer(connectionString));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            StaticServiceProvider.Provider = app.ApplicationServices;
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BaoTangBn.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
