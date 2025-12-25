using EMS.Application.DTOs.Financial;
using EMS.Application.Services.Base;
using EMS.Domain.Entities.FinancialModuleManagement;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;
using EMS.Domain.Interfaces.Repositories.Base;
using EMS.Domain.Models;
using EMS.EFCore;
using LanguageExt.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.Application.Services.Financial
{
    public class CongNoService : BaseService<CongNoSinhVien>, ICongNoService
    {
        private readonly AppDbContext _context;

        public CongNoService(
            IUnitOfWork unitOfWork,
            ICongNoSinhVienRepository repository,
            AppDbContext context) : base(unitOfWork, repository)
        {
            _context = context;
        }

        [HttpGet("danh-sach-custom")]
        public async Task<CongNoCustomPaging> GetDanhSachCongNoCustomAsync(int page, int pageSize, string keyword)
        {
            try
            {
                var query = _context.CongNoSinhViens.AsQueryable()
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
                    .Select(x => new CongNoCustomResponse
                    {
                        Id = x.Id,
                        SinhVienId = x.SinhVienId,
                        NamHocHocKyId = x.NamHocHocKyId,
                        MaSinhVien = x.SinhVien.MaSinhVien,
                        HoTen = x.SinhVien.HoDem + " " + x.SinhVien.Ten,
                        TenHocKy = x.NamHocHocKy.NamHoc + " - " + x.NamHocHocKy.TenDot,
                        DaThu = (double)x.DaThu,
                        TongMienGiam = (double)x.TongMienGiam,
                        ConNo = (double)(x.ChiTiets.Sum(ct => ct.SoTien) - x.DaThu - x.TongMienGiam),
                        HanNop = x.HanNop,
                        GhiChu = x.GhiChu
                    })
                    .ToListAsync();

                return new CongNoCustomPaging
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
        protected override Task UpdateEntityProperties(CongNoSinhVien existingEntity, CongNoSinhVien newEntity)
        {
            existingEntity.GhiChu = newEntity.GhiChu;
            existingEntity.HanNop = newEntity.HanNop;
            return Task.CompletedTask;
        }

        public async Task<Result<Guid>> AddKhoanThuAsync(AddKhoanThuDto dto)
        {
            try
            {
                // 1. Tìm công nợ đang hoạt động (chưa xóa)
                var congNo = await _context.CongNoSinhViens
                    .Include(x => x.ChiTiets)
                    .FirstOrDefaultAsync(x =>
                        x.SinhVienId == dto.SinhVienId &&
                        x.NamHocHocKyId == dto.NamHocHocKyId &&
                        !x.IsDeleted);

                if (congNo == null)
                {
                    // Tìm và XÓA VẬT LÝ công nợ cũ đã bị soft delete (nếu có)
                    var deletedCongNo = await _context.CongNoSinhViens
                        .Include(x => x.ChiTiets) // Xóa luôn chi tiết
                        .FirstOrDefaultAsync(x =>
                            x.SinhVienId == dto.SinhVienId &&
                            x.NamHocHocKyId == dto.NamHocHocKyId &&
                            x.IsDeleted);

                    if (deletedCongNo != null)
                    {
                        _context.CongNoChiTiets.RemoveRange(deletedCongNo.ChiTiets); // Xóa chi tiết
                        _context.CongNoSinhViens.Remove(deletedCongNo);              // Xóa công nợ
                    }

                    // Tạo mới hoàn toàn
                    congNo = new CongNoSinhVien
                    {
                        Id = Guid.NewGuid(),
                        SinhVienId = dto.SinhVienId,
                        NamHocHocKyId = dto.NamHocHocKyId,
                        HanNop = dto.HanNop?.ToUniversalTime() ?? DateTime.UtcNow.AddMonths(1),
                        NgayTao = DateTime.UtcNow,
                        IsDeleted = false
                    };
                    _context.CongNoSinhViens.Add(congNo);
                }
                else
                {
                    // Đã có công nợ đang hoạt động → chỉ cập nhật hạn nộp nếu có
                    congNo.NgayCapNhat = DateTime.UtcNow;
                    if (dto.HanNop.HasValue)
                        congNo.HanNop = dto.HanNop.Value.ToUniversalTime();
                }

                // 3. Thêm các chi tiết khoản thu (luôn được thêm mới)
                foreach (var item in dto.ChiTiets)
                {
                    var chiTiet = new CongNoChiTiet
                    {
                        Id = Guid.NewGuid(),
                        CongNoId = congNo.Id,
                        LoaiKhoanThuId = item.LoaiKhoanThuId,
                        SoTien = item.SoTien,
                        GhiChu = item.GhiChu,
                        NgayTao = DateTime.UtcNow,
                        IsDeleted = false
                    };
                    _context.CongNoChiTiets.Add(chiTiet);
                }

                await _context.SaveChangesAsync();
                return new Result<Guid>(congNo.Id);
            }
            catch (Exception ex)
            {
                // Log lỗi để dễ debug
                // _logger.LogError(ex, "Lỗi khi thêm khoản thu");
                return new Result<Guid>(ex);
            }
        }

        public async Task<Result<CongNoDetailDto>> GetDetailByStudentAsync(Guid sinhVienId, Guid namHocHocKyId)
        {
            try
            {
                var entity = await _context.CongNoSinhViens
                    .Include(x => x.SinhVien)
                    .Include(x => x.NamHocHocKy)
                    .Include(x => x.ChiTiets)
                    .Include(x => x.MienGiams)
                    .FirstOrDefaultAsync(x => x.SinhVienId == sinhVienId && x.NamHocHocKyId == namHocHocKyId && !x.IsDeleted);

                if (entity == null)
                {
                    return new Result<CongNoDetailDto>(new FileNotFoundException("Không tìm thấy công nợ"));
                }

                var result = new CongNoDetailDto
                {
                    Id = entity.Id,
                    SinhVienId = entity.SinhVienId,
                    TenSinhVien = $"{entity.SinhVien?.HoDem ?? ""} {entity.SinhVien?.Ten ?? ""}".Trim(),
                    MaSinhVien = entity.SinhVien?.MaSinhVien ?? "",
                    TenHocKy = entity.NamHocHocKy?.TenDot ?? $"{entity.NamHocHocKy?.NamHoc ?? ""} ".Trim(),
                    TongPhaiThu = entity.ChiTiets.Sum(c => c.SoTien),
                    TongMienGiam = entity.MienGiams.Where(m => m.TrangThai == "DaDuyet").Sum(m => m.SoTien),
                    DaThu = entity.DaThu,
                    ConNo = entity.ChiTiets.Sum(c => c.SoTien) - entity.MienGiams.Where(m => m.TrangThai == "DaDuyet").Sum(m => m.SoTien) - entity.DaThu,
                    HanNop = entity.HanNop,
                    GhiChu = entity.GhiChu ?? "",
                    ChiTiets = entity.ChiTiets.Select(c => new DTOs.Financial.CongNoChiTietViewDto
                    {
                        LoaiKhoanThuId = c.LoaiKhoanThuId,
                        SoTien = c.SoTien,
                        GhiChu = c.GhiChu
                    }).ToList()
                };

                return new Result<CongNoDetailDto>(result);
            }
            catch (Exception ex)
            {
                return new Result<CongNoDetailDto>(ex);
            }
        }

    }
    public class CongNoCustomResponse
    {
        public Guid Id { get; set; }
        public Guid SinhVienId { get; set; }
        public Guid NamHocHocKyId { get; set; }
        public string MaSinhVien { get; set; }
        public string HoTen { get; set; }
        public string TenHocKy { get; set; }
        public double DaThu { get; set; }
        public double TongMienGiam { get; set; }
        public double ConNo { get; set; }
        public DateTime? HanNop { get; set; }
        public string GhiChu { get; set; }
    }

    public class CongNoCustomPaging
    {
        public List<CongNoCustomResponse> Data { get; set; }
        public int Total { get; set; }
    }
}