using System.Linq.Expressions;
using EMS.Application.Services.Base;
using EMS.Application.Services.SinhVienMienMonHocServices.Dtos;
using EMS.Domain.Entities.StudentManagement;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;
using EMS.Domain.Interfaces.Repositories.StudentManagement;
using EMS.Domain.Models;
using EMS.Domain.Models.Import;
using FluentValidation;
using LanguageExt.Common;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace EMS.Application.Services.SinhVienMienMonHocServices
{
    public class SinhVienMienMonHocService : BaseService<SinhVienMienMonHoc>, ISinhVienMienMonHocService
    {
        private readonly IValidator<SinhVienMienMonHocImportDto> _validator;

        public SinhVienMienMonHocService(IUnitOfWork unitOfWork,
            ISinhVienMienMonHocRepository repository,
            IValidator<SinhVienMienMonHocImportDto> validator)
            : base(unitOfWork, repository)
        {
            _validator = validator;
        }

        protected override Task UpdateEntityProperties(SinhVienMienMonHoc existingEntity, SinhVienMienMonHoc newEntity)
        {
            existingEntity.IdSinhVien = newEntity.IdSinhVien;
            existingEntity.IdMonHocBacDaoTao = newEntity.IdMonHocBacDaoTao;
            existingEntity.IdQuyetDinh = newEntity.IdQuyetDinh;

            return Task.CompletedTask;
        }

        public virtual async Task<Result<PaginationResponse<SinhVienMienMonHoc>>> GetSinhVienMienMonHocPaginatedAsync(
            PaginationRequest request,
            SinhVienMienMonHocFilter filter)
        {
            try
            {
                // UTC Conversion
                DateTime? startNgayTaoUtc = filter.StartNgayTao.HasValue
                    ? filter.StartNgayTao.Value.ToUniversalTime()
                    : null;

                DateTime? endNgayTaoUtc = filter.EndNgayTao.HasValue
                    ? filter.EndNgayTao.Value.AddDays(1).ToUniversalTime()
                    : null;

                Expression<Func<SinhVienMienMonHoc, bool>> filterExpression = svmmh => true;

                if (filter.IdQuyetDinh != null)
                {
                    filterExpression = filterExpression.And(svmmh => svmmh.IdQuyetDinh == filter.IdQuyetDinh);
                }

                if (filter.IdCoSo != null)
                    filterExpression = filterExpression.And(svmmh => svmmh.SinhVien != null && svmmh.SinhVien.IdCoSo == filter.IdCoSo);

                if (filter.IdKhoaHoc != null)
                    filterExpression = filterExpression.And(svmmh => svmmh.SinhVien != null && svmmh.SinhVien.IdKhoaHoc == filter.IdKhoaHoc);

                if (filter.IdBacDaoTao != null)
                    filterExpression = filterExpression.And(svmmh => svmmh.SinhVien != null && svmmh.SinhVien.IdBacDaoTao == filter.IdBacDaoTao);

                if (filter.IdLoaiDaoTao != null)
                    filterExpression = filterExpression.And(svmmh => svmmh.SinhVien != null && svmmh.SinhVien.IdLoaiDaoTao == filter.IdLoaiDaoTao);

                if (filter.IdNganh != null)
                    filterExpression = filterExpression.And(svmmh => svmmh.SinhVien != null && svmmh.SinhVien.IdNganh == filter.IdNganh);

                if (filter.IdChuyenNganh != null)
                    filterExpression = filterExpression.And(svmmh => svmmh.SinhVien != null && svmmh.SinhVien.IdChuyenNganh == filter.IdChuyenNganh);

                if (filter.IdLopHoc != null)
                    filterExpression = filterExpression.And(svmmh => svmmh.SinhVien != null && svmmh.SinhVien.IdLopHoc == filter.IdLopHoc);

                if (!string.IsNullOrEmpty(filter.MaSinhVien))
                    filterExpression = filterExpression.And(svmmh => svmmh.SinhVien != null && svmmh.SinhVien.MaSinhVien.ToLower().Contains(filter.MaSinhVien.ToLower()));

                if (!string.IsNullOrEmpty(filter.HoDem))
                    filterExpression = filterExpression.And(svmmh => svmmh.SinhVien != null && svmmh.SinhVien.HoDem.ToLower().Contains(filter.HoDem.ToLower()));

                if (!string.IsNullOrEmpty(filter.Ten))
                    filterExpression = filterExpression.And(svmmh => svmmh.SinhVien != null && svmmh.SinhVien.Ten.ToLower().Contains(filter.Ten.ToLower()));

                if (startNgayTaoUtc.HasValue)
                    filterExpression = filterExpression.And(svmmh => svmmh.NgayTao >= startNgayTaoUtc.Value);

                if (endNgayTaoUtc.HasValue)
                    filterExpression = filterExpression.And(svmmh => svmmh.NgayTao < endNgayTaoUtc.Value);


                IQueryable<SinhVienMienMonHoc> includeFunc(IQueryable<SinhVienMienMonHoc> q)
                {
                    return q.AsNoTracking()
                            .Include(sv => sv.SinhVien).ThenInclude(l => l!.LopHoc)
                            .Include(q => q.MonHocBacDaoTao).ThenInclude(l => l!.MonHoc)
                            .Include(q => q.QuyetDinh);
                }

                var result = await Repository.PaginateAsync(request, include: includeFunc, filter: filterExpression);

                return new Result<PaginationResponse<SinhVienMienMonHoc>>(result);
            }
            catch (Exception ex)
            {
                return new Result<PaginationResponse<SinhVienMienMonHoc>>(ex);
            }
        }

        public virtual async Task<BaseResponse<string>> BulkCreateAsync(BulkCreateRequestDto requestDto)
        {
            try
            {
                var sinhVienRepo = UnitOfWork.GetRepository<ISinhVienRepository>();
                var sinhVien = await sinhVienRepo.GetByIdAsync(requestDto.IdSinhVien);
                if (sinhVien == null)
                {
                    return BaseResponse<string>.Error("Sinh viên không tồn tại");
                }
                if (requestDto.IdMonHocBacDaoTaos.Count == 0)
                {
                    return BaseResponse<string>.Error("Danh sách môn học miễn không được để trống");
                }

                var entities = new List<SinhVienMienMonHoc>();
                foreach (var idMonHocBacDaoTao in requestDto.IdMonHocBacDaoTaos.Distinct())
                {
                    var entity = new SinhVienMienMonHoc
                    {
                        IdSinhVien = requestDto.IdSinhVien,
                        IdMonHocBacDaoTao = idMonHocBacDaoTao,
                        IdQuyetDinh = requestDto.IdQuyetDinh,
                    };
                    entities.Add(entity);
                }
                Repository.AddRange(entities);
                await UnitOfWork.CommitAsync();

                return BaseResponse<string>.Success("Thêm mới thành công");
            }
            catch (Exception ex)
            {
                return BaseResponse<string>.Error(ex.Message);
            }
        }

        public async Task<ImportResultResponse<SinhVienMienMonHocImportDto>> ImportMienMonHocAsync(byte[] fileBytes)
        {

            var svRepo = UnitOfWork.GetRepository<ISinhVienRepository>();
            var ctkRepo = UnitOfWork.GetRepository<IChuongTrinhKhungTinChiRepository>();
            var chiTietCtkRepo = UnitOfWork.GetRepository<IChiTietKhungHocKy_TinChiRepository>();
            var mhRepo = UnitOfWork.GetRepository<IMonHocRepository>();
            var mienHocRepo = UnitOfWork.GetRepository<ISinhVienMienMonHocRepository>();
            var quyetDinhRepo = UnitOfWork.GetRepository<IQuyetDinhRepository>();

            // 1.1. SinhVien và các FK
            var svLookup = (await svRepo.ListAsync())
               .ToDictionary(sv => sv.MaSinhVien.Trim().ToLower(), sv => new
               {
                   sv.Id,
                   sv.IdCoSo,
                   sv.IdKhoaHoc,
                   sv.IdLoaiDaoTao,
                   sv.IdNganh,
                   sv.IdBacDaoTao,
                   sv.IdChuyenNganh,
                   sv.HoDem,
                   sv.Ten,
               });

            // 1.2. MonHoc cơ bản
            var mhLookup = (await mhRepo.ListAsync())
                .ToDictionary(mh => mh.MaMonHoc.Trim().ToLower(), mh => new
                {
                    mh.Id,
                    mh.TenMonHoc,
                });

            // 1.3. Chương trình khung
            var allChuongTrinhKhung = (await ctkRepo.ListAsync())
                .Select(ctk => new
                {
                    ctk.Id,
                    ctk.IdCoSoDaoTao,
                    ctk.IdKhoaHoc,
                    ctk.IdLoaiDaoTao,
                    ctk.IdNganhHoc,
                    ctk.IdBacDaoTao,
                    ctk.IdChuyenNganh
                })
                .ToList();

            // 1.4. Chi tiết CTK (Bao gồm MonHocBacDaoTao và MonHoc)
            var allChiTietKhung = (await chiTietCtkRepo.ListAsync(
                    filter: x => !x.IsDeleted,
                    include: q => q.Include(c => c.MonHocBacDaoTao).ThenInclude(mhbdt => mhbdt.MonHoc)))
                .Select(ct => new
                {
                    ct.IdChuongTrinhKhung,
                    ct.IdMonHocBacDaoTao,
                    IdMonHoc = ct.MonHocBacDaoTao?.MonHoc?.Id,
                })
                .ToList();

            // 1.5. Các bản miễn hiện có
            var existingMienHoc = (await mienHocRepo.ListAsync())
                .Select(m => new { m.IdSinhVien, m.IdMonHocBacDaoTao })
                .ToHashSet();

            var quyetDinhs = await quyetDinhRepo.ListAsync();

            var result = await base.ImportAsync(
                fileBytes,

                mapFunc: dto =>
                {
                    // Val 1: SinhVien
                    if (!svLookup.TryGetValue(dto.MaSinhVien.Trim().ToLower(), out var sv))
                        throw new Exception($"Mã sinh viên '{dto.MaSinhVien}' không tồn tại.");

                    dto.HoDem = sv.HoDem;
                    dto.Ten = sv.Ten;

                    // Val 2: MonHoc
                    if (!mhLookup.TryGetValue(dto.MaMonHoc.Trim().ToLower(), out var monHoc))
                        throw new Exception($"Mã môn học '{dto.MaMonHoc}' không tồn tại.");

                    dto.TenMonHoc = monHoc.TenMonHoc;

                    // Val 3: Tìm Chương trình khung (CTK) của SinhVien
                    var ctk = allChuongTrinhKhung.FirstOrDefault(c =>
                        c.IdCoSoDaoTao == sv.IdCoSo &&
                        c.IdKhoaHoc == sv.IdKhoaHoc &&
                        c.IdNganhHoc == sv.IdNganh &&
                        c.IdBacDaoTao == sv.IdBacDaoTao &&
                        c.IdChuyenNganh == sv.IdChuyenNganh);

                    if (ctk == null)
                        throw new Exception($"Không tìm thấy Chương trình khung cho sinh viên '{dto.MaSinhVien}'.");

                    // Val 4: Tìm IdMonHocBacDaoTao (NGHIỆP VỤ CỐT LÕI)
                    var targetChiTiet = allChiTietKhung.FirstOrDefault(ct =>
                        ct.IdChuongTrinhKhung == ctk.Id &&
                        ct.IdMonHoc == monHoc.Id);

                    if (targetChiTiet == null)
                        throw new Exception($"Môn học '{dto.MaMonHoc}' không tồn tại trong chương trình khung của sinh viên.");

                    if (existingMienHoc.Contains(new { IdSinhVien = sv.Id, targetChiTiet.IdMonHocBacDaoTao }))
                        throw new Exception("Sinh viên đã được miễn môn này.");

                    var quyetDinh = dto.SoQuyetDinh != null ? quyetDinhs
                        .FirstOrDefault(qd => qd.SoQuyetDinh.Trim().Equals(dto.SoQuyetDinh.Trim(), StringComparison.OrdinalIgnoreCase) ||
                                            qd.TenQuyetDinh.Trim().Equals(dto.SoQuyetDinh.Trim(), StringComparison.OrdinalIgnoreCase)) : null;
                    var entity = new SinhVienMienMonHoc
                    {
                        IdSinhVien = sv.Id,
                        IdMonHocBacDaoTao = targetChiTiet.IdMonHocBacDaoTao,
                        IdQuyetDinh = quyetDinh?.Id,
                    };

                    return Task.FromResult(entity);
                },

                _validator
            );

            return result;
        }
    }
}