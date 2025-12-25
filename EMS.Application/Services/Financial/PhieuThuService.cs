using EMS.Application.DTOs.Financial;
using EMS.Application.Services.Base;
using EMS.Domain.Entities.FinancialModuleManagement;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;
using EMS.Domain.Interfaces.Repositories.Base;
using EMS.EFCore;
using LanguageExt.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.Application.Services.Financial
{
    public class PhieuThuService : BaseService<PhieuThuSinhVien>, IPhieuThuService
    {
        private readonly AppDbContext _context;

        public PhieuThuService(IUnitOfWork unitOfWork, IPhieuThuSinhVienRepository repository,
            AppDbContext context)
            : base(unitOfWork, repository)
        {
            _context = context;
        }

        protected override Task UpdateEntityProperties(PhieuThuSinhVien existing, PhieuThuSinhVien newEntity)
        {
            existing.GhiChu = newEntity.GhiChu;
            return Task.CompletedTask;
        }

        public async Task<Result<Guid>> CreatePaymentAsync(CreatePhieuThuDto dto)
        {
            var strategy = _context.Database.CreateExecutionStrategy();
            return await strategy.ExecuteAsync(async () =>
            {
                using var transaction = await _context.Database.BeginTransactionAsync();
                try
                {
                    if (dto.CongNoId.HasValue)
                    {
                        var congNo = await _context.CongNoSinhViens.FindAsync(dto.CongNoId.Value);
                        if (congNo != null)
                        {
                            congNo.DaThu += dto.SoTien;
                            congNo.NgayCapNhat = DateTime.UtcNow;
                        }
                    }

                    var phieuThu = new PhieuThuSinhVien
                    {
                        Id = Guid.NewGuid(),
                        SoPhieu = $"PT-{DateTime.Now:yyMMdd}-{Guid.NewGuid().ToString("N")[..4].ToUpper()}",
                        SinhVienId = dto.SinhVienId,
                        CongNoId = dto.CongNoId,
                        SoTien = dto.SoTien,
                        HinhThucThanhToan = dto.HinhThucThanhToan,
                        GhiChu = dto.GhiChu,
                        NgayThu = DateTime.UtcNow,
                        NgayTao = DateTime.UtcNow
                    };
                    _context.PhieuThuSinhViens.Add(phieuThu);

                    if (dto.ChiTiets != null && dto.ChiTiets.Any())
                    {
                        var chiTietNotes = new List<string>();

                        foreach (var ct in dto.ChiTiets)
                        {
                            if (ct.IdCongNoChiTiet.HasValue)
                            {
                                var noChiTiet = await _context.CongNoChiTiets.FindAsync(ct.IdCongNoChiTiet.Value);
                                if (noChiTiet != null)
                                {
                                    var loaiThu = await _context.LoaiKhoanThu.FindAsync(noChiTiet.LoaiKhoanThuId);
                                    if (loaiThu != null)
                                    {
                                        chiTietNotes.Add($"{loaiThu.TenLoaiKhoanThu}: {ct.SoTien:N0}");
                                    }
                                }
                            }
                            else
                            {
                                var loaiThu = await _context.LoaiKhoanThu.FindAsync(ct.LoaiKhoanThuId);
                                if (loaiThu != null)
                                {
                                    chiTietNotes.Add($"{loaiThu.TenLoaiKhoanThu}: {ct.SoTien:N0}");
                                }
                            }
                        }

                        if (chiTietNotes.Any())
                        {
                            var chiTietString = string.Join(", ", chiTietNotes);
                            phieuThu.GhiChu = string.IsNullOrEmpty(phieuThu.GhiChu)
                                ? $"Chi tiết: {chiTietString}"
                                : $"{phieuThu.GhiChu} ({chiTietString})";
                        }
                    }

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    return new Result<Guid>(phieuThu.Id);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return new Result<Guid>(ex);
                }
            });
        }

        [HttpGet("danh-sach-custom")]
        public async Task<PhieuThuCustomPaging> GetDanhSachPhieuThuCustomAsync(int page, int pageSize, string keyword)
        {
            try
            {
                var query = _context.PhieuThuSinhViens.AsQueryable()
                 .Where(x => !x.IsDeleted);

                if (!string.IsNullOrEmpty(keyword))
                {
                    var k = keyword.Trim().ToLower();
                    query = query.Where(x =>
                        x.SinhVien.MaSinhVien.ToLower().Contains(k) ||
                        x.SinhVien.HoDem.ToLower().Contains(k) ||
                        x.SinhVien.Ten.ToLower().Contains(k));
                }

                var total = await query.CountAsync();

                var items = await query
                    .OrderByDescending(x => x.NgayTao)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .Select(x => new PhieuThuCustomRespone
                    {
                        Id = x.Id,
                        SinhVienId = x.SinhVienId,
                        MaSinhVien = x.SinhVien.MaSinhVien,
                        HoTen = x.SinhVien.HoDem + " " + x.SinhVien.Ten,
                        SoTienThu = (double)x.SoTien,
                        NgayThu = x.NgayThu,
                        GhiChu = x.GhiChu,
                        SoPhieu = x.SoPhieu,
                        HinhThucThanhToan = x.HinhThucThanhToan,
                    })
                    .ToListAsync();

                return new PhieuThuCustomPaging
                {
                    Data = items,
                    Total = total
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error");
            }
        }
        public class PhieuThuCustomRespone
        {
            public Guid Id { get; set; }
            public Guid SinhVienId { get; set; }
            public string MaSinhVien { get; set; }
            public string HoTen { get; set; }
            public double SoTienThu { get; set; }
            public DateTime NgayThu { get; set; }
            public string GhiChu { get; set; }
            public string SoPhieu { get; set; }
            public string HinhThucThanhToan { get; set; }
        }
        public class PhieuThuCustomPaging
        {
            public List<PhieuThuCustomRespone> Data { get; set; }
            public int Total { get; set; }
        }
    }
}