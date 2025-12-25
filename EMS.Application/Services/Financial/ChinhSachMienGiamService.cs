using EMS.Application.DTOs.Financial;
using EMS.Application.Services.Base;
using EMS.Domain.Entities.FinancialModuleManagement;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;
using EMS.EFCore;
using LanguageExt.Common;
using Microsoft.EntityFrameworkCore;

namespace EMS.Application.Services.Financial
{
    public class ChinhSachMienGiamService : BaseService<ChinhSachMienGiam>, IChinhSachMienGiamService
    {
        private readonly AppDbContext _context;

        public ChinhSachMienGiamService(
            IUnitOfWork unitOfWork,
            IChinhSachMienGiamRepository repository,
            AppDbContext context)
            : base(unitOfWork, repository)
        {
            _context = context;
        }
        protected override Task UpdateEntityProperties(ChinhSachMienGiam existing, ChinhSachMienGiam newEntity)
        {
            existing.TenChinhSach = newEntity.TenChinhSach;
            existing.LoaiChinhSach = newEntity.LoaiChinhSach;
            existing.GiaTri = newEntity.GiaTri;
            existing.ApDungCho = newEntity.ApDungCho;
            existing.DoiTuongId = newEntity.DoiTuongId;
            existing.NamHocHocKyId = newEntity.NamHocHocKyId;
            existing.NgayBatDau = newEntity.NgayBatDau;
            existing.NgayKetThuc = newEntity.NgayKetThuc;
            existing.GhiChu = newEntity.GhiChu;
            return Task.CompletedTask;
        }

        public async Task<Result<PagedChinhSachMienGiamResult>> GetPagedAsync(int page, int pageSize, string? keyword)
        {
            try
            {
                var query = _context.ChinhSachMienGiams
                    .Include(c => c.NamHocHocKy)
                    .AsNoTracking()
                    .Where(c => !c.IsDeleted);

                if (!string.IsNullOrEmpty(keyword))
                {
                    var k = keyword.ToLower().Trim();
                    query = query.Where(c => c.TenChinhSach.ToLower().Contains(k) ||
                                             c.LoaiChinhSach.ToLower().Contains(k));
                }

                var total = await query.CountAsync();
                var items = await query
                    .OrderByDescending(c => c.NgayTao)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                var dtos = items.Select(entity => new ChinhSachMienGiamDto
                {
                    Id = entity.Id,
                    TenChinhSach = entity.TenChinhSach,
                    LoaiChinhSach = entity.LoaiChinhSach,
                    GiaTri = entity.GiaTri,
                    ApDungCho = entity.ApDungCho,
                    DoiTuongId = entity.DoiTuongId,
                    NamHocHocKyId = entity.NamHocHocKyId,
                    TenDot = entity.NamHocHocKy?.TenDot,
                    NgayBatDau = entity.NgayBatDau,
                    NgayKetThuc = entity.NgayKetThuc,
                    TrangThai = entity.TrangThai,
                    GhiChu = entity.GhiChu,
                    NgayTao = entity.NgayTao,
                }).ToList();

                return new Result<PagedChinhSachMienGiamResult>(new PagedChinhSachMienGiamResult
                {
                    Data = dtos,
                    Total = total
                });
            }
            catch (Exception ex)
            {
                return new Result<PagedChinhSachMienGiamResult>(ex);
            }
        }
        public async Task<Result<ChinhSachMienGiamDto>> GetDetailAsync(Guid id)
        {
            try
            {
                var entity = await _context.ChinhSachMienGiams
                    .Include(c => c.NamHocHocKy)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);

                if (entity == null)
                    return new Result<ChinhSachMienGiamDto>(new Exception("Không tìm thấy chính sách"));

                var dto = new ChinhSachMienGiamDto
                {
                    Id = entity.Id,
                    TenChinhSach = entity.TenChinhSach,
                    LoaiChinhSach = entity.LoaiChinhSach,
                    GiaTri = entity.GiaTri,
                    ApDungCho = entity.ApDungCho,
                    DoiTuongId = entity.DoiTuongId,
                    NamHocHocKyId = entity.NamHocHocKyId,
                    TenDot = entity.NamHocHocKy?.TenDot,
                    NgayBatDau = entity.NgayBatDau,
                    NgayKetThuc = entity.NgayKetThuc,
                    TrangThai = entity.TrangThai,
                    GhiChu = entity.GhiChu,
                    NgayTao = entity.NgayTao,
                };

                return new Result<ChinhSachMienGiamDto>(dto);
            }
            catch (Exception ex)
            {
                return new Result<ChinhSachMienGiamDto>(ex);
            }
        }
        public async Task<Result<ChinhSachMienGiamDto>> CreateAsync(CreateChinhSachMienGiamDto dto)
        {
            var strategy = _context.Database.CreateExecutionStrategy();
            return await strategy.ExecuteAsync(async () =>
            {
                using var transaction = await _context.Database.BeginTransactionAsync();
                try
                {
                    if (await _context.ChinhSachMienGiams.AnyAsync(c => c.TenChinhSach == dto.TenChinhSach && !c.IsDeleted))
                        return new Result<ChinhSachMienGiamDto>(new Exception("Tên chính sách đã tồn tại"));
                    var entity = new ChinhSachMienGiam
                    {
                        Id = Guid.NewGuid(),
                        TenChinhSach = dto.TenChinhSach,
                        LoaiChinhSach = dto.LoaiChinhSach,
                        GiaTri = dto.GiaTri,
                        ApDungCho = dto.ApDungCho,
                        DoiTuongId = dto.DoiTuongId,
                        NamHocHocKyId = dto.NamHocHocKyId,
                        NgayBatDau = dto.NgayBatDau,
                        NgayKetThuc = dto.NgayKetThuc,
                        TrangThai = "HoatDong",
                        GhiChu = dto.GhiChu,
                        NgayTao = DateTime.UtcNow
                    };
                    _context.ChinhSachMienGiams.Add(entity);

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    return await GetDetailAsync(entity.Id);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return new Result<ChinhSachMienGiamDto>(ex);
                }
            });
        }
        public async Task<Result<ChinhSachMienGiamDto>> UpdateAsync(Guid id, UpdateChinhSachMienGiamDto dto)
        {
            var strategy = _context.Database.CreateExecutionStrategy();
            return await strategy.ExecuteAsync(async () =>
            {
                using var transaction = await _context.Database.BeginTransactionAsync();
                try
                {
                    var entity = await _context.ChinhSachMienGiams.FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);
                    if (entity == null) return new Result<ChinhSachMienGiamDto>(new Exception("Không tìm thấy chính sách"));

                    if (await _context.ChinhSachMienGiams.AnyAsync(c => c.TenChinhSach == dto.TenChinhSach && c.Id != id && !c.IsDeleted))
                        return new Result<ChinhSachMienGiamDto>(new Exception("Tên chính sách đã tồn tại"));

                    entity.TenChinhSach = dto.TenChinhSach;
                    entity.LoaiChinhSach = dto.LoaiChinhSach;
                    entity.GiaTri = dto.GiaTri;
                    entity.ApDungCho = dto.ApDungCho;
                    entity.NamHocHocKyId = dto.NamHocHocKyId;
                    entity.NgayBatDau = dto.NgayBatDau;
                    entity.NgayKetThuc = dto.NgayKetThuc;
                    entity.GhiChu = dto.GhiChu;
                    entity.NgayCapNhat = DateTime.UtcNow;

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    return await GetDetailAsync(id);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return new Result<ChinhSachMienGiamDto>(ex);
                }
            });
        }
        public override async Task<Result<bool>> DeleteAsync(Guid id)
        {
            try
            {
                bool isInUse = await _context.MienGiamSinhViens.AnyAsync(m => m.ChinhSachMienGiamId == id && !m.IsDeleted);
                if (isInUse) return new Result<bool>(new Exception("Chính sách đang được sử dụng, không thể xóa"));
                return await base.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                return new Result<bool>(ex);
            }
        }
    }
}