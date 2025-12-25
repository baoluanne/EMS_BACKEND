using EMS.Application.DTOs.Financial;
using EMS.Application.Services.Base;
using EMS.Domain.Entities.FinancialModuleManagement;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.Base;
using EMS.EFCore;
using LanguageExt.Common;
using Microsoft.EntityFrameworkCore;

namespace EMS.Application.Services.Financial
{
    public class MienGiamService : BaseService<MienGiamSinhVien>, IMienGiamService
    {
        private readonly AppDbContext _context;

        public MienGiamService(
            IUnitOfWork unitOfWork,
            IAuditRepository<MienGiamSinhVien> repository,
            AppDbContext context) : base(unitOfWork, repository)
        {
            _context = context;
        }

        protected override Task UpdateEntityProperties(MienGiamSinhVien existingEntity, MienGiamSinhVien newEntity)
        {
            existingEntity.LyDo = newEntity.LyDo;
            return Task.CompletedTask;
        }

        public async Task<Result<MienGiamPagedResult>> GetPagedCustomAsync(MienGiamFilterDto filter)
        {
            try
            {
                var query = _context.MienGiamSinhViens
                    .AsNoTracking()
                    .Where(x => !x.IsDeleted);
                if (filter.NamHocHocKyId.HasValue)
                    query = query.Where(x => x.NamHocHocKyId == filter.NamHocHocKyId);

                if (!string.IsNullOrEmpty(filter.TrangThai))
                    query = query.Where(x => x.TrangThai == filter.TrangThai);

                if (!string.IsNullOrEmpty(filter.Keyword))
                {
                    var k = filter.Keyword.ToLower().Trim();
                    query = query.Where(x =>
                        x.SinhVien.MaSinhVien.ToLower().Contains(k) ||
                        x.SinhVien.HoDem.ToLower().Contains(k) ||
                        x.SinhVien.Ten.ToLower().Contains(k));
                }
                var total = await query.CountAsync();
                var items = await query
                    .OrderByDescending(x => x.NgayTao)
                    .Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize)
                    .Select(x => new
                    {
                        x.Id,
                        x.SinhVienId,
                        MaSinhVien = x.SinhVien.MaSinhVien,
                        TenSinhVien = x.SinhVien.HoDem + " " + x.SinhVien.Ten,
                        x.ChinhSachMienGiamId,
                        TenChinhSach = x.ChinhSachMienGiam.TenChinhSach,
                        x.NamHocHocKyId,
                        TenHocKy = _context.NamHoc_HocKy
                                    .Where(nh => nh.Id == x.NamHocHocKyId)
                                    .Select(nh => nh.TenDot)
                                    .FirstOrDefault() ?? "",
                        x.SoTien,
                        x.TrangThai,
                        x.LyDo,
                        x.NgayTao
                    })
                    .ToListAsync();
                var resultData = items.Select(x => new MienGiamSinhVienDto
                {
                    Id = x.Id,
                    SinhVienId = x.SinhVienId,
                    MaSinhVien = x.MaSinhVien,
                    TenSinhVien = x.TenSinhVien,
                    ChinhSachMienGiamId = x.ChinhSachMienGiamId,
                    TenChinhSach = x.TenChinhSach,
                    NamHocHocKyId = x.NamHocHocKyId,
                    TenHocKy = x.TenHocKy,
                    SoTien = x.SoTien,
                    TrangThai = x.TrangThai,
                    LyDo = x.LyDo,
                    NgayTao = x.NgayTao
                }).ToList();

                return new Result<MienGiamPagedResult>(new MienGiamPagedResult
                {
                    Data = resultData,
                    TotalRecords = total,
                    PageNumber = filter.PageNumber,
                    PageSize = filter.PageSize
                });
            }
            catch (Exception ex)
            {
                return new Result<MienGiamPagedResult>(ex);
            }
        }

        public async Task<Result<Guid>> ApplyAsync(ApplyMienGiamDto dto)
        {
            try
            {
                var exists = await _context.MienGiamSinhViens
                    .AnyAsync(x => x.SinhVienId == dto.SinhVienId &&
                                   x.NamHocHocKyId == dto.NamHocHocKyId &&
                                   x.ChinhSachMienGiamId == dto.ChinhSachMienGiamId &&
                                   !x.IsDeleted);

                if (exists)
                    return new Result<Guid>(new Exception("Sinh viên đã được áp dụng chính sách này trong học kỳ này"));

                var entity = new MienGiamSinhVien
                {
                    Id = Guid.NewGuid(),
                    SinhVienId = dto.SinhVienId,
                    ChinhSachMienGiamId = dto.ChinhSachMienGiamId,
                    NamHocHocKyId = dto.NamHocHocKyId,
                    TrangThai = "ChoDuyet",
                    LyDo = dto.LyDo,
                    SoTien = 0,
                    NgayTao = DateTime.UtcNow
                };

                _context.MienGiamSinhViens.Add(entity);
                await _context.SaveChangesAsync();

                return new Result<Guid>(entity.Id);
            }
            catch (Exception ex)
            {
                return new Result<Guid>(ex);
            }
        }

        public async Task<Result<bool>> ApproveAsync(ApprovalMienGiamDto dto)
        {
            var strategy = _context.Database.CreateExecutionStrategy();
            return await strategy.ExecuteAsync(async () =>
            {
                using var transaction = await _context.Database.BeginTransactionAsync();
                try
                {
                    var mienGiam = await _context.MienGiamSinhViens
                        .Include(x => x.ChinhSachMienGiam)
                        .FirstOrDefaultAsync(x => x.Id == dto.Id);

                    if (mienGiam == null) return new Result<bool>(new Exception("Không tìm thấy đơn miễn giảm"));
                    if (mienGiam.TrangThai == "DaDuyet") return new Result<bool>(new Exception("Đơn đã được duyệt trước đó"));

                    if (!dto.IsApproved)
                    {
                        mienGiam.TrangThai = "TuChoi";
                        mienGiam.LyDo = dto.LyDoTuChoi;
                        await _context.SaveChangesAsync();
                        await transaction.CommitAsync();
                        return new Result<bool>(true);
                    }
                    var congNo = await _context.CongNoSinhViens
                        .Include(x => x.ChiTiets)
                        .FirstOrDefaultAsync(x => x.SinhVienId == mienGiam.SinhVienId &&
                                                  x.NamHocHocKyId == mienGiam.NamHocHocKyId &&
                                                  !x.IsDeleted);

                    if (congNo == null)
                        return new Result<bool>(new Exception("Sinh viên chưa có công nợ học kỳ này, vui lòng tạo công nợ trước"));

                    decimal soTienGiam = 0;
                    var policy = mienGiam.ChinhSachMienGiam;

                    if (policy.LoaiChinhSach == "SoTien")
                    {
                        soTienGiam = policy.GiaTri;
                    }
                    else if (policy.LoaiChinhSach == "PhanTram")
                    {
                        var tongHocPhi = congNo.ChiTiets.Sum(c => c.SoTien);
                        soTienGiam = (tongHocPhi * policy.GiaTri) / 100;
                    }

                    mienGiam.SoTien = soTienGiam;
                    mienGiam.TrangThai = "DaDuyet";
                    mienGiam.NgayCapNhat = DateTime.UtcNow;

                    congNo.TongMienGiam += soTienGiam;
                    congNo.NgayCapNhat = DateTime.UtcNow;

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    return new Result<bool>(true);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return new Result<bool>(ex);
                }
            });
        }
    }
}