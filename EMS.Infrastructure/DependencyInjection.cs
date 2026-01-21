using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.EmailServices;
using EMS.Domain.Interfaces.Repositories;
using EMS.Domain.Interfaces.Repositories.Base;
using EMS.Domain.Interfaces.Repositories.EquipManagement;
using EMS.Domain.Interfaces.Repositories.KtxManagement;
using EMS.Domain.Interfaces.Storages;
using EMS.Domain.Models;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.EmailServices;
using EMS.Infrastructure.Persistence.Repositories.KtxManagement;
using EMS.Infrastructure.Repositories;
using EMS.Infrastructure.Repositories.Base;
using EMS.Infrastructure.Repositories.EquipmentManagement;
using EMS.Infrastructure.Repositories.KtxManagement;
using EMS.Infrastructure.StorageServices;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace EMS.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.ScanRegister();
        services.AddScoped(typeof(IAuditRepository<>), typeof(AuditRepository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<DbFactory>();

        services.AddHangfire(config =>
            config.UsePostgreSqlStorage(options =>
                options.UseNpgsqlConnection(configuration.GetConnectionString("DefaultConnection"))
            )
        );
        services.AddHangfireServer();

        services.Configure<MailSettings>(configuration.GetSection("MailSettings"));
        services.AddTransient<IEmailService, EmailService>();

        services.AddScoped<IStorageService, MinioStorageService>();
        return services;
    }

    internal static IServiceCollection ScanRegister(this IServiceCollection services)
    {
        services.Scan(scan => scan
            .FromAssemblies(typeof(DependencyInjection).Assembly)
            .AddClasses(
                filter => filter.Where(x => x.Name.EndsWith("Repository")),
                publicOnly: false)
            .UsingRegistrationStrategy(RegistrationStrategy.Throw)
            .AsMatchingInterface()
            .WithScopedLifetime());

        return services;
    }

    internal static IServiceCollection ManualRegister(this IServiceCollection services)
    {
        services.AddScoped<IKhoaRepository, KhoaRepository>();
        services.AddScoped<IKhoaHocRepository, KhoaHocRepository>();
        services.AddScoped<IKhoiKienThucRepository, KhoiKienThucRepository>();
        services.AddScoped<IKhoiNganhRepository, KhoiNganhRepository>();
        services.AddScoped<IToBoMonRepository, ToBoMonRepository>();
        services.AddScoped<INamHocRepository, NamHocRepository>();
        services.AddScoped<ICoSoDaoTaoRepository, CoSoDaoTaoRepository>();
        services.AddScoped<IDanhMucPhongBanRepository, DanhMucPhongBanRepository>();
        services.AddScoped<INganhHocRepository, NganhHocRepository>();
        services.AddScoped<ITinhChatMonHocRepository, TinhChatMonHocRepository>();
        services.AddScoped<ILoaiTietRepository, LoaiTietRepository>();
        services.AddScoped<ILoaiMonHocRepository, LoaiMonHocRepository>();
        services.AddScoped<ILyDoXinPhongRepository, LyDoXinPhongRepository>();
        services.AddScoped<IDanhSachKhoaSuDungRepository, DanhSachKhoaSuDungRepository>();
        services.AddScoped<ILopNienCheRepository, LopNienCheRepository>();
        services.AddScoped<IKieuLamTronRepository, KieuLamTronRepository>();
        services.AddScoped<ILoaiChungChiRepository, LoaiChungChiRepository>();
        services.AddScoped<ITrangThaiXetQuyUocRepository, TrangThaiXetQuyUocRepository>();
        services.AddScoped<IXetLLHB_QuyCheTC_Repository, XetLLHB_QuyCheTC_Repository>();
        services.AddScoped<ITrangThaiLopHPRepository, TrangThaiLopHPRepository>();
        services.AddScoped<ITieuChuanXetHocBongRepository, TieuChuanXetHocBongRepository>();
        services.AddScoped<ITieuChuanXetDanhHieuRepository, TieuChuanXetDanhHieuRepository>();
        services.AddScoped<IThongTinChung_QuyCheTC_Repository, ThongTinChung_QuyCheTC_Repository>();
        services.AddScoped<IQuyUocCotDiem_NC_Repository, QuyUocCotDiem_NC_Repository>();
        services.AddScoped<IQuyUocCotDiem_TC_Repository, QuyUocCotDiem_TC_Repository>();
        services.AddScoped<IThoiGianDaoTaoRepository, ThoiGianDaoTaoRepository>();
        services.AddScoped<IQuyChe_TinChi_Repository, QuyChe_TinChi_Repository>();
        services.AddScoped<IQuyCheHocVuRepository, QuyCheHocVuRepository>();
        services.AddScoped<IQuyChe_NienChe_Repository, QuyChe_NienChe_Repository>();
        services.AddScoped<IChungChiRepository, ChungChiRepository>();
        services.AddScoped<IChuyenNganhRepository, ChuyenNganhRepository>();
        services.AddScoped<IDanhMucHocBongRepository, DanhMucHocBongRepository>();
        services.AddScoped<IKhenThuongRepository, KhenThuongRepository>();
        services.AddScoped<IKieuMonHocRepository, KieuMonHocRepository>();
        services.AddScoped<ILoaiPhongRepository, LoaiPhongRepository>();
        services.AddScoped<IMonHocRepository, MonHocRepository>();
        services.AddScoped<INguoiDungRepository, NguoiDungRepository>();
        services.AddScoped<IChuongTrinhKhungTinChiRepository, ChuongTrinhKhungTinChiRepository>();
        services.AddScoped<IChiTietKhungHocKy_TinChiRepository, ChiTietKhungHocKy_TinChiRepository>();

        services.AddScoped<IBangDiemChiTietRepository, BangDiemChiTietRepository>();
        services.AddScoped<IChuyenDoiHocPhanRepository, ChuyenDoiHocPhanRepository>();

        //KTX
        services.AddScoped<IGiuongKtxRepository, GiuongKtxRepository>();
        services.AddScoped<IPhongKtxRepository, PhongKtxRepository>();
        services.AddScoped<IChiSoDienNuocRepository, ChiSoDienNuocRepository>();
        services.AddScoped<IViPhamNoiQuyKTXRepository, ViPhamNoiQuyKTXRepository>();
        services.AddScoped<IToaNhaKtxRepository, ToaNhaKtxRepository>();
        services.AddScoped<ITangRepository, TangRepository>();
        services.AddScoped<IDonKtxRepository, DonKtxRepository>();
        services.AddScoped<IDonChiTietKtxRepository, DonChiTietKtxRepository>();
        services.AddScoped<IDonChuyenPhongRepository, DonChuyenPhongRepository>();
        services.AddScoped<IDonDangKyMoiRepository, DonDangKyMoiRepository>();
        services.AddScoped<IDonGiaHanRepository, DonGiaHanRepository>();
        services.AddScoped<IDonRoiKtxRepository, DonRoiKtxRepository>();
        services.AddScoped<ICuTruKtxRepository, CuTruKtxRepository>();
        services.AddScoped<IYeuCauSuaChuaRepository, YeuCauSuaChuaRepository>();
        services.AddScoped<IKtxCuTruLichSuRepository, KtxCuTruLichSuRepository>();
        
        services.AddScoped<IChiTietKiemKeRepository, ChiTietKiemKeRepository>();
        services.AddScoped<IChiTietPhieuMuonRepository, ChiTietPhieuMuonRepository>();
        services.AddScoped<IChiTietThanhLyRepository, ChiTietThanhLyRepository>();
        services.AddScoped<IDotKiemKeRepository, DotKiemKeRepository>();
        services.AddScoped<ILoaiThietBiRepository, LoaiThietBiRepository>();
        services.AddScoped<INhaCungCapRepository, NhaCungCapRepository>();
        services.AddScoped<IPhieuBaoTriRepository, PhieuBaoTriRepository>();
        services.AddScoped<IPhieuMuonTraRepository, PhieuMuonTraRepository>();
        services.AddScoped<IPhieuThanhLyRepository, PhieuThanhLyRepository>();
        services.AddScoped<IThietBiRepository, ThietBiRepository>();
        
        
        return services;
    }
}
