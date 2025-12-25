using EMS.Application.Services;
using EMS.Application.Services.AuthServices;
using EMS.Application.Services.BangDiemChiTietServices;
using EMS.Application.Services.ChungChiServices;
using EMS.Application.Services.ChuyenNganhServices;
using EMS.Application.Services.CoSoDaoTaoServices;
using EMS.Application.Services.CurrentUserServices;
using EMS.Application.Services.DanhMucHocBongServices;
using EMS.Application.Services.DanhMucPhongBanServices;
using EMS.Application.Services.DanhSachKhoaSuDungServices;
using EMS.Application.Services.Financial;
using EMS.Application.Services.KhenThuongServices;
using EMS.Application.Services.KhoaHocServices;
using EMS.Application.Services.KhoaServices;
using EMS.Application.Services.KhoiKienThucServices;
using EMS.Application.Services.KhoiNganhServices;
using EMS.Application.Services.KieuLamTronServices;
using EMS.Application.Services.KieuMonHocServices;
using EMS.Application.Services.KtxService;
using EMS.Application.Services.LoaiChungChiServices;
using EMS.Application.Services.LoaiMonHocServices;
using EMS.Application.Services.LoaiPhongServices;
using EMS.Application.Services.LoaiTietServices;
using EMS.Application.Services.LopNienCheServices;
using EMS.Application.Services.LyDoXinPhongServices;
using EMS.Application.Services.MinioServices;
using EMS.Application.Services.MonHocServices;
using EMS.Application.Services.NamHocServices;
using EMS.Application.Services.NganhHocServices;
using EMS.Application.Services.NguoiDungServices;
using EMS.Application.Services.QuyChe_NienChe_Services;
using EMS.Application.Services.QuyChe_TinChi_Services;
using EMS.Application.Services.QuyCheHocVuServices;
using EMS.Application.Services.QuyUocCotDiem_NC_Services;
using EMS.Application.Services.QuyUocCotDiem_TC_Services;
using EMS.Application.Services.ThoiGianDaoTao_Services;
using EMS.Application.Services.ThongTinChung_QuyCheTC_Services;
using EMS.Application.Services.TieuChuanXetDanhHieuServices;
using EMS.Application.Services.TieuChuanXetHocBongServices;
using EMS.Application.Services.TinhChatMonHocServices;
using EMS.Application.Services.ToBoMonServices;
using EMS.Application.Services.TrangThaiLopHPServices;
using EMS.Application.Services.TrangThaiXetQuyUocServices;
using EMS.Application.Services.XetLLHB_QuyCheTC_Services;
using EMS.Domain.Entities;
using EMS.Domain.Entities.FinancialModuleManagement;
using EMS.Domain.Interfaces.Repositories.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace EMS.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.ScanRegister();
        services.AddScoped<IMinioService, MinioService>();
        services.AddTransient<IPasswordHasher<NguoiDung>, PasswordHasher<NguoiDung>>();

        return services;
    }

    internal static IServiceCollection ScanRegister(this IServiceCollection services)
    {
        services.Scan(scan => scan
            .FromAssemblies(typeof(DependencyInjection).Assembly)
            .AddClasses(
                filter => filter.Where(x => x.Name.EndsWith("Service")),
                publicOnly: false)
            .UsingRegistrationStrategy(RegistrationStrategy.Throw)
            .AsMatchingInterface()
            .WithScopedLifetime());

        return services;
    }

    internal static IServiceCollection ManualRegister(this IServiceCollection services)
    {
        services.AddScoped<IKhoaService, KhoaService>();
        services.AddScoped<IKhoaHocService, KhoaHocService>();
        services.AddScoped<IKhoiKienThucService, KhoiKienThucService>();
        services.AddScoped<IKhoiNganhService, KhoiNganhService>();
        services.AddScoped<IToBoMonService, ToBoMonService>();
        services.AddScoped<INamHocService, NamHocService>();
        services.AddScoped<ICoSoDaoTaoService, CoSoDaoTaoService>();
        services.AddScoped<IDanhMucPhongBanService, DanhMucPhongBanService>();
        services.AddScoped<INganhHocService, NganhHocService>();
        services.AddScoped<ITinhChatMonHocService, TinhChatMonHocService>();
        services.AddScoped<ILoaiTietService, LoaiTietService>();
        services.AddScoped<ILoaiMonHocService, LoaiMonHocService>();
        services.AddScoped<ILyDoXinPhongService, LyDoXinPhongService>();
        services.AddScoped<IDanhSachKhoaSuDungService, DanhSachKhoaSuDungService>();
        services.AddScoped<ILopNienCheService, LopNienCheService>();
        services.AddScoped<IKieuLamTronService, KieuLamTronService>();
        services.AddScoped<ILoaiChungChiService, LoaiChungChiService>();
        services.AddScoped<ITrangThaiXetQuyUocService, TrangThaiXetQuyUocService>();
        services.AddScoped<IXetLLHB_QuyCheTC_Service, XetLLHB_QuyCheTC_Service>();
        services.AddScoped<ITrangThaiLopHPService, TrangThaiLopHPService>();
        services.AddScoped<ITieuChuanXetHocBongService, TieuChuanXetHocBongService>();
        services.AddScoped<ITieuChuanXetDanhHieuService, TieuChuanXetDanhHieuService>();
        services.AddScoped<IThongTinChung_QuyCheTC_Service, ThongTinChung_QuyCheTC_Service>();
        services.AddScoped<IQuyUocCotDiem_NC_Service, QuyUocCotDiem_NC_Service>();
        services.AddScoped<IQuyUocCotDiem_TC_Service, QuyUocCotDiem_TC_Service>();
        services.AddScoped<IThoiGianDaoTaoService, ThoiGianDaoTaoService>();
        services.AddScoped<IQuyChe_TinChi_Service, QuyChe_TinChi_Service>();
        services.AddScoped<IQuyCheHocVuService, QuyCheHocVuService>();
        services.AddScoped<IQuyChe_NienChe_Service, QuyChe_NienChe_Service>();
        services.AddScoped<IChungChiService, ChungChiService>();
        services.AddScoped<IChuyenNganhService, ChuyenNganhService>();
        services.AddScoped<IDanhMucHocBongService, DanhMucHocBongService>();
        services.AddScoped<IKhenThuongService, KhenThuongService>();
        services.AddScoped<IKieuMonHocService, KieuMonHocService>();
        services.AddScoped<ILoaiPhongService, LoaiPhongService>();
        services.AddScoped<IMonHocService, MonHocService>();
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        services.AddScoped<INguoiDungService, NguoiDungService>();
        services.AddScoped<IAuthService, AuthService>();
        // Financial Module
        services.AddScoped<CongNoSinhVien, CongNoSinhVien>();
        services.AddScoped<PhieuThuSinhVien, PhieuThuSinhVien>();
        services.AddScoped<IBangDiemChiTietService, BangDiemChiTietService>();


        //KTX
        services.AddScoped<IToaNhaKtxService, ToaNhaKtxService>();
        services.AddScoped<IPhongKtxService, PhongKtxService>();
        services.AddScoped<IGiuongKtxService, GiuongKtxService>();
        services.AddScoped<IDonKtxService, DonKtxService>();
        services.AddScoped<IChiSoDienNuocService, ChiSoDienNuocService>();
        services.AddScoped<IViPhamNoiQuyKTXService, ViPhamNoiQuyKTXService>();
        services.AddScoped<ICuTruKtxService, CuTruKtxService>();
        return services;
    }
}
