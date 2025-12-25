using System.Linq.Expressions;
using EMS.Application.Services.Base;
using EMS.Application.Services.ChuyenLopServices.Dtos;
using EMS.Domain.Entities;
using EMS.Domain.Entities.ClassManagement;
using EMS.Domain.Enums;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;
using EMS.Domain.Interfaces.Repositories.ClassManagement;
using EMS.Domain.Interfaces.Repositories.StudentManagement;
using EMS.Domain.Models;
using LanguageExt.Common;
using Microsoft.EntityFrameworkCore;

namespace EMS.Application.Services.ChuyenLopServices
{
    public class ChuyenLopService : BaseService<ChuyenLop>, IChuyenLopService
    {
        private readonly IBangDiemChiTietRepository _bangDiemRepository;
        private readonly IChiTietKhungHocKy_TinChiRepository _ctkRepository;
        private readonly ILopHocRepository _lopHocRepository;
        private readonly IChuongTrinhKhungTinChiRepository _chuongTrinhKhungRepository;
        private readonly ILopHocPhanRepository _lopHocPhanRepository;
        private readonly ISinhVienRepository _sinhVienRepository;
        private readonly IChuyenDoiHocPhanRepository _chuyenDoiHocPhanRepository;
        private readonly IMonHocRepository _monHocRepository;

        public ChuyenLopService(IUnitOfWork unitOfWork,
            IChuyenLopRepository repository)
            : base(unitOfWork, repository)
        {
            _bangDiemRepository = unitOfWork.GetRepository<IBangDiemChiTietRepository>();
            _ctkRepository = unitOfWork.GetRepository<IChiTietKhungHocKy_TinChiRepository>();
            _lopHocRepository = unitOfWork.GetRepository<ILopHocRepository>();
            _chuongTrinhKhungRepository = unitOfWork.GetRepository<IChuongTrinhKhungTinChiRepository>();
            _lopHocPhanRepository = unitOfWork.GetRepository<ILopHocPhanRepository>();
            _sinhVienRepository = unitOfWork.GetRepository<ISinhVienRepository>();
            _chuyenDoiHocPhanRepository = unitOfWork.GetRepository<IChuyenDoiHocPhanRepository>();
            _monHocRepository = unitOfWork.GetRepository<IMonHocRepository>();
        }

        protected override Task UpdateEntityProperties(ChuyenLop existingEntity, ChuyenLop newEntity)
        {
            // Map all properties from newEntity to existingEntity
            existingEntity.IdSinhVien = newEntity.IdSinhVien;
            existingEntity.IdLopCu = newEntity.IdLopCu;
            existingEntity.IdLopMoi = newEntity.IdLopMoi;
            existingEntity.SoQuyetDinh = newEntity.SoQuyetDinh;
            existingEntity.NgayRaQuyetDinh = newEntity.NgayRaQuyetDinh;
            existingEntity.NgayChuyenLop = newEntity.NgayChuyenLop;
            existingEntity.GhiChu = newEntity.GhiChu;
            existingEntity.PhanLoaiChuyenLop = newEntity.PhanLoaiChuyenLop;
            existingEntity.TrichYeu = newEntity.TrichYeu;
            existingEntity.IdQuyetDinh = newEntity.IdQuyetDinh;

            return Task.CompletedTask;
        }

        // Implement custom methods if needed
        // public async Task<ImportResultResponse<ChuyenLopImportDto>> ImportAsync(byte[] fileBytes)
        // {
        //     // Implementation for Excel import functionality
        // }

        // public async Task<List<ChuyenLop>> GetByStudentIdAsync(Guid studentId)
        // {
        //     return await Repository.GetByStudentIdAsync(studentId);
        // }

        // public async Task<List<ChuyenLop>> GetByClassIdAsync(Guid classId)
        // {
        //     return await Repository.GetByClassIdAsync(classId);
        // }

        public async Task<List<ChuyenLop>> TransferStudents(TransferStudentsRequestDto request)
        {
            var sinhvienRepository = UnitOfWork.GetRepository<ISinhVienRepository>();
            var students = await sinhvienRepository.GetListAsync(f => request.IdDanhSachSinhVien.Contains(f.Id));
            var transfers = new List<ChuyenLop>();
            foreach (var student in students)
            {
                student.IdLopHoc = request.IdLopMoi;
                sinhvienRepository.Update(student);
                transfers.Add(new ChuyenLop
                {
                    IdLopCu = request.IdLopCu,
                    IdLopMoi = request.IdLopMoi,
                    IdSinhVien = student.Id,
                    PhanLoaiChuyenLop = request.PhanLoaiChuyenLop,
                    NgayChuyenLop = DateTime.UtcNow
                });
            }
            Repository.AddRange(transfers);
            await UnitOfWork.CommitAsync();
            return transfers;
        }

        public async Task<Result<PaginationResponse<HocPhanCuDto>>> GetDanhSachHocPhanCuAsync(Guid idSinhVien)
        {
            try
            {
                // Filter: Lấy điểm của SV này, và chỉ lấy điểm cao nhất
                Expression<Func<BangDiemChiTiet, bool>> filter = x => x.IdSinhVien == idSinhVien && x.IsDiemCaoNhat;

                // Include:
                // 1. SinhVien: Để lấy IdBacDaoTao (quan trọng để xác định tín chỉ)
                // 2. MonHoc -> MonHocBacDaoTaos: Để lấy danh sách tín chỉ
                // 3. LopHocPhan: Để lấy mã lớp HP
                // 4. ChuyenDoiHocPhan: Để kiểm tra trạng thái chuyển đổi
                Func<IQueryable<BangDiemChiTiet>, IQueryable<BangDiemChiTiet>> include = q => q
                    .Include(x => x.SinhVien)
                    .Include(x => x.MonHoc)
                        .ThenInclude(m => m.MonHocBacDaoTaos)
                    .Include(x => x.LopHocPhan)
                    .Include(x => x.ChuyenDoiHocPhan);

                var result = await _bangDiemRepository.ListAsync(
                    filter: filter,
                    include: include
                );

                var dtos = result.Select(bd =>
                {
                    // Logic lấy Số tín chỉ chuẩn:
                    // Tìm trong danh sách MonHocBacDaoTao của môn đó, cái nào có IdBacDaoTao trùng với SV
                    var monHocBacDaoTao = bd.MonHoc?.MonHocBacDaoTaos?
                        .FirstOrDefault(mh => mh.IdBacDaoTao == bd.SinhVien.IdBacDaoTao);

                    // Nếu không tìm thấy theo bậc đào tạo của SV (trường hợp hy hữu), fallback về cái đầu tiên
                    var soTinChi = monHocBacDaoTao?.SoTinChi
                                   ?? bd.MonHoc?.MonHocBacDaoTaos?.FirstOrDefault()?.SoTinChi
                                   ?? 0;

                    return new HocPhanCuDto
                    {
                        Id = bd.Id,
                        IdBangDiem = bd.Id,
                        MaHocPhan = bd.MonHoc?.MaMonHoc ?? "",
                        TenHocPhan = bd.MonHoc?.TenMonHoc ?? "",
                        MaLopHP = bd.LopHocPhan?.MaLopHocPhan ?? "",

                        SoTinChi = soTinChi,

                        Diem = bd.DiemTongKet,
                        IsDat = bd.DiemTongKet >= 4.0m,
                        DaDuocChuyenDoi = bd.IdChuyenDoiHocPhan.HasValue, // Nếu có ID -> Đã chuyển (hoặc được tạo từ chuyển đổi)

                        // Logic kiểm tra nút Hủy: Chỉ hiện nút hủy nếu có LHP (tức là đang học/vừa đăng ký)
                        // Nếu điểm này là điểm Chuyển đổi (không có LHP) thì không Hủy ở đây được.
                        IdLopHocPhan = bd.IdLopHocPhan
                    };
                }).ToList();

                return new Result<PaginationResponse<HocPhanCuDto>>(new PaginationResponse<HocPhanCuDto> { Result = dtos });
            }
            catch (Exception ex)
            {
                return new Result<PaginationResponse<HocPhanCuDto>>(ex);
            }
        }

        public async Task<Result<PaginationResponse<HocPhanMoiDto>>> GetDanhSachHocPhanMoiAsync(Guid idSinhVien, Guid idLopMoi)
        {
            try
            {
                // B1: Xác định Lớp Mới và các ID Khóa ngoại ĐÍCH
                var lopMoi = await _lopHocRepository.GetByIdAsync(idLopMoi);
                if (lopMoi == null)
                    return new Result<PaginationResponse<HocPhanMoiDto>>(new Exception("Lớp mới không tồn tại"));

                var idNganhHocDich = lopMoi.IdNganhHoc;
                var idKhoaHocDich = lopMoi.IdKhoaHoc;
                var idBacDaoTaoDich = lopMoi.IdBacDaoTao;

                // Tìm CTK đích
                var ctk = await _chuongTrinhKhungRepository.GetFirstAsync(x =>
                    x.IdNganhHoc == idNganhHocDich &&
                    x.IdKhoaHoc == idKhoaHocDich &&
                    x.IdBacDaoTao == idBacDaoTaoDich);

                // Nếu không có CTK đích, không có môn học nào để đăng ký
                if (ctk == null)
                    return new Result<PaginationResponse<HocPhanMoiDto>>(new PaginationResponse<HocPhanMoiDto> { Result = new List<HocPhanMoiDto>() });


                // B2: Lấy TẤT CẢ các Lớp Học Phần (LHP) đang mở
                // Giả định LHP có liên kết tới MonHoc để lấy thông tin.
                Func<IQueryable<LopHocPhan>, IQueryable<LopHocPhan>> includeLhp = q => q
                    .Include(x => x.MonHoc)
                    .Include(x => x.LopDuKiens).ThenInclude(ldk => ldk.LopDuKien);

                var listLopHocPhanDangMo = await _lopHocPhanRepository.ListAsync(
                    filter: x => x.TrangThai == TrangThaiLopHocPhanEnum.MoLop,
                    include: includeLhp);

                // ***************************************************************
                // B3: Lọc LHP đang mở theo Chương trình Khung (CTK) ĐÍCH
                // 
                // Logic: LHP đang mở chỉ hợp lệ nếu IdMonHoc của nó nằm trong 
                // danh sách ChiTietKhungHocKy_TinChi của CTK đích.
                // ***************************************************************

                // 3.1. Lấy danh sách IdMonHoc thuộc CTK đích (CTK của lớp mới)
                var listChiTietCtk = await _ctkRepository.ListAsync(
                    filter: x => x.IdChuongTrinhKhung == ctk.Id,
                    include: q => q.Include(x => x.MonHocBacDaoTao));

                var listIdMonHocThuocCtkDich = listChiTietCtk
                    .Where(x => x.MonHocBacDaoTao != null)
                    .Select(x => x.MonHocBacDaoTao.IdMonHoc)
                    .ToList();

                // 3.2. Lọc LHP đang mở chỉ giữ lại những LHP thuộc CTK đích
                var listLopHocPhanHopLe = listLopHocPhanDangMo
                    .Where(lhp => listIdMonHocThuocCtkDich.Contains(lhp.IdMonHoc))
                    .ToList();

                // Map danh sách LHP HỢP LỆ sang DTO
                var dtos = listLopHocPhanHopLe.Select(lopHP =>
                {
                    var monHoc = lopHP.MonHoc;

                    // Tìm chi tiết CTK để lấy SoTinChi, HocKy, IsBatBuoc
                    var chiTietCtk = listChiTietCtk.FirstOrDefault(
                        ctkItem => ctkItem.MonHocBacDaoTao?.IdMonHoc == monHoc.Id);

                    var soTinChi = chiTietCtk?.MonHocBacDaoTao?.SoTinChi ?? 0;

                    // Tính Mức Nộp
                    decimal donGia = 0m;
                    decimal mucNop = donGia * soTinChi;

                    // Lấy danh sách tên lớp dự kiến
                    var lopDuKienTen = lopHP.LopDuKiens?.Select(x => x.LopDuKien?.TenLop).Where(t => t != null).ToList();

                    return new HocPhanMoiDto
                    {
                        // Thông tin LHP
                        Id = lopHP.Id, // Thay thế Id ChiTietKhung bằng Id LopHocPhan (vì đây là đơn vị đăng ký)

                        // Thông tin Môn học
                        IdMonHoc = monHoc?.Id ?? Guid.Empty,
                        MaHocPhan = monHoc?.MaMonHoc ?? "",
                        TenHocPhan = monHoc?.TenMonHoc ?? "",

                        // Thông tin CTK
                        SoTinChi = soTinChi,
                        HocKy = chiTietCtk?.HocKy ?? 0,
                        IsBatBuoc = chiTietCtk?.IsBatBuoc ?? false,

                        // Thông tin LHP và Học phí
                        MaLopHP = lopHP.MaLopHocPhan ?? "",
                        LopDuKien = lopDuKienTen != null && lopDuKienTen.Any() ? string.Join(", ", lopDuKienTen) : "N/A",
                        MucNop = mucNop
                    };
                }).OrderBy(x => x.HocKy).ThenBy(x => x.MaHocPhan).ToList();

                return new Result<PaginationResponse<HocPhanMoiDto>>(new PaginationResponse<HocPhanMoiDto> { Result = dtos });
            }
            catch (Exception ex)
            {
                return new Result<PaginationResponse<HocPhanMoiDto>>(ex);
            }
        }


        public async Task<BaseResponse<string>> ChuyenLopTuDoAsync(ChuyenLopTuDoRequestDto request)
        {
            try
            {
                // =========================================================
                // BƯỚC 1: KIỂM TRA VÀ CẬP NHẬT TRẠNG THÁI CƠ SỞ
                // =========================================================
                var sinhVien = await _sinhVienRepository.GetByIdAsync(request.IdSinhVien);
                if (sinhVien == null) return BaseResponse<string>.Error("Sinh viên không tồn tại");
                if (sinhVien.TrangThai != TrangThaiSinhVienEnum.DangHoc)
                {
                    return BaseResponse<string>.Error("Chỉ được phép chuyển lớp tự do cho sinh viên đang học");
                }

                var lopMoi = await _lopHocRepository.GetByIdAsync(request.IdLopHocMoi);
                if (lopMoi == null) return BaseResponse<string>.Error("Lớp học mới không tồn tại");

                // Lưu ID lớp cũ trước khi cập nhật
                var idLopHocCu = sinhVien.IdLopHoc;

                // Cập nhật lớp và ngành học/chuyên ngành mới cho sinh viên
                sinhVien.IdLopHoc = request.IdLopHocMoi;
                sinhVien.IdNganh = lopMoi.IdNganhHoc;
                sinhVien.IdChuyenNganh = lopMoi.IdChuyenNganh;
                _sinhVienRepository.Update(sinhVien);

                // =========================================================
                // BƯỚC 2: TẠO RECORD LỊCH SỬ CHUYỂN LỚP
                // =========================================================
                var chuyenLop = new ChuyenLop
                {
                    Id = Guid.NewGuid(),
                    IdLopCu = idLopHocCu,
                    IdLopMoi = lopMoi.Id,
                    IdSinhVien = sinhVien.Id,
                    PhanLoaiChuyenLop = request.PhanLoaiChuyenLop,
                    NgayChuyenLop = DateTime.UtcNow,
                    TrangThaiXuLy = TrangThaiChuyenLopEnum.HoanThanh,
                };
                Repository.Add(chuyenLop); // Giả định Repository là repository cho ChuyenLop


                // =========================================================
                // BƯỚC 3: XỬ LÝ CHUYỂN ĐỔI HỌC PHẦN (MIỄN/CHUYỂN MÔN)
                // =========================================================

                if (request.IdHocPhanCu != null && request.IdHocPhanCu.Any())
                {
                    // Lấy CTK đích
                    var ctkMoi = await _chuongTrinhKhungRepository.GetFirstAsync(x =>
                        x.IdNganhHoc == lopMoi.IdNganhHoc &&
                        x.IdKhoaHoc == lopMoi.IdKhoaHoc &&
                        x.IdBacDaoTao == lopMoi.IdBacDaoTao);

                    if (ctkMoi == null)
                    {
                        // Nếu không tìm thấy CTK mới, Rollback và thông báo
                        return BaseResponse<string>.Error("Không tìm thấy Chương trình Khung cho lớp mới");
                    }

                    // Lấy tất cả môn học trong CTK mới để tra cứu (Tối ưu performance)
                    // Giả định MonHoc có liên kết IdChuongTrinhKhung
                    var listMonHocMoi = ctkMoi.ChiTietKhungHocKy_TinChis?.Select(x => x.MonHocBacDaoTao?.MonHoc);
                    if (listMonHocMoi != null && listMonHocMoi.Any())
                    {
                        foreach (var idMonHocCu in request.IdHocPhanCu)
                        {
                            var diemCu = await _bangDiemRepository.GetFirstAsync(
                                x => x.IdSinhVien == request.IdSinhVien && x.IdMonHoc == idMonHocCu && x.IsDiemCaoNhat);

                            var monHocCu = await _monHocRepository.GetByIdAsync(idMonHocCu);
                            if (diemCu == null || monHocCu == null) continue;

                            // 3.1. TÌM ID MÔN HỌC MỚI TƯƠNG ĐƯƠNG TRONG CTK ĐÍCH
                            // Tìm môn học MỚI trong list CTK đích có cùng Mã học phần (MaMonHoc)
                            var monHocMoi = listMonHocMoi.FirstOrDefault(x =>
                                x.MaMonHoc == monHocCu.MaMonHoc);

                            if (monHocMoi == null) continue; // Không tìm thấy môn tương đương để miễn

                            var idMonHocMoi = monHocMoi.Id;

                            // 3.2. KIỂM TRA TRÙNG LẶP (Đã được miễn/chuyển đổi chưa?)
                            var isMienTruDaTonTai = await _bangDiemRepository.GetFirstAsync(
                                 x => x.IdSinhVien == request.IdSinhVien &&
                                      x.IdMonHoc == idMonHocMoi &&
                                      x.IdChuyenDoiHocPhan != null);

                            if (isMienTruDaTonTai != null) continue; // Đã miễn rồi, bỏ qua

                            // 3.3. TẠO BẢN GHI ĐIỂM VÀ LỊCH SỬ CHUYỂN ĐỔI
                            var idBangDiemMoi = Guid.NewGuid();
                            var chuyenDoiId = Guid.NewGuid();

                            // 1. Tạo BangDiemChiTiet (Điểm mới cho MÔN MỚI)
                            var diemMoi = new BangDiemChiTiet
                            {
                                Id = idBangDiemMoi,
                                IdSinhVien = request.IdSinhVien,
                                IdMonHoc = idMonHocMoi, // Gán cho ID MÔN HỌC MỚI
                                DiemTongKet = diemCu.DiemTongKet,
                                LanHoc = 1,
                                IsDiemCaoNhat = true,
                                IdChuyenDoiHocPhan = chuyenDoiId, // Liên kết với lịch sử chuyển đổi
                                GhiChu = $"Chuyển điểm từ môn cũ {monHocCu.MaMonHoc} do chuyển lớp."
                            };

                            // 2. Tạo ChuyenDoiHocPhan (Lịch sử chi tiết)
                            var chuyenDoi = new ChuyenDoiHocPhan
                            {
                                Id = chuyenDoiId,
                                IdChuyenLop = chuyenLop.Id,
                                IdMonHocCu = idMonHocCu,
                                IdMonHocMoi = idMonHocMoi,
                                DiemCu = diemCu.DiemTongKet,
                                TinChiCu = (int)monHocCu.SoTinChi,
                                IdBangDiemCu = diemCu.Id,
                                TinChiMoi = (int)monHocMoi.SoTinChi,
                                IdBangDiemMoi = diemMoi.Id,
                                PhanLoai = request.PhanLoaiChuyenLop,
                                DiemChuyenDoiDuocApDung = diemCu.DiemTongKet,
                                IsDaThucThi = true,
                            };

                            _bangDiemRepository.Add(diemMoi);
                            _chuyenDoiHocPhanRepository.Add(chuyenDoi);
                        }
                    }
                }

                await UnitOfWork.CommitAsync();

                return BaseResponse<string>.Success("Chuyển lớp thành công");
            }
            catch (Exception ex)
            {
                return BaseResponse<string>.Error(ex.Message);
            }
        }
    }
}
