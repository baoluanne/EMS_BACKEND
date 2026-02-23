using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Application.Services.EquipService;
using EMS.Application.Services.EquipService.Dtos;
using EMS.Domain.Entities.EquipmentManagement;
using EMS.Domain.Enums.EquipmentManagement;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;
using EMS.Domain.Interfaces.Repositories.EquipManagement;
using EMS.Domain.Interfaces.Repositories.StudentManagement;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers.Mobile
{
    [Route("api/mobile")]
    [ApiController]
    public class MobileController : ControllerBase
    {
        private readonly IThietBiService _thietBiService;
        private readonly IPhieuMuonTraService _phieuMuonTraService;
        private readonly IUnitOfWork _unitOfWork;

        public MobileController(
            IThietBiService thietBiService,
            IPhieuMuonTraService phieuMuonTraService,
            IUnitOfWork unitOfWork)
        {
            _thietBiService = thietBiService;
            _phieuMuonTraService = phieuMuonTraService;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("create-from-mobile")]
        public async Task<IActionResult> CreateFromMobile([FromBody] MobileBorrowRequest request)
        {
            try
            {
                if (request == null || string.IsNullOrWhiteSpace(request.MaDoiTuong))
                    return BadRequest(new { message = "Dữ liệu không hợp lệ" });

                Guid? sinhVienId = null;
                Guid? giangVienId = null;
                LoaiDoiTuongMuonEnum loaiDoiTuong;
                if (request.MaDoiTuong.StartsWith("SV", StringComparison.OrdinalIgnoreCase) ||
                    request.MaDoiTuong.StartsWith("HS", StringComparison.OrdinalIgnoreCase))
                {
                    var repo = _unitOfWork.GetRepository<ISinhVienRepository>();
                    var sv = await repo.GetFirstAsync(x => x.MaSinhVien.ToLower() == request.MaDoiTuong.ToLower());

                    if (sv == null) return NotFound(new { message = $"Không tìm thấy Sinh viên: {request.MaDoiTuong}" });

                    sinhVienId = sv.Id;
                    loaiDoiTuong = LoaiDoiTuongMuonEnum.SinhVien;
                }
                else
                {
                    var repo = _unitOfWork.GetRepository<IGiangVienRepository>();
                    var gv = await repo.GetFirstAsync(x => x.MaGiangVien.ToLower() == request.MaDoiTuong.ToLower());

                    if (gv == null) return NotFound(new { message = $"Không tìm thấy Giảng viên: {request.MaDoiTuong}" });

                    giangVienId = gv.Id;
                    loaiDoiTuong = LoaiDoiTuongMuonEnum.GiangVien;
                }

                var tbRes = await _thietBiService.GetByIdAsync(request.ThietBiId);
                var thietBi = tbRes.Match(s => s, e => null);

                if (thietBi == null || thietBi.TrangThai != TrangThaiThietBiEnum.MoiNhap)
                    return BadRequest(new { message = "Thiết bị không tồn tại hoặc không sẵn sàng để mượn" });

                var now = DateTime.UtcNow;
                var entity = new TSTBPhieuMuonTra
                {
                    Id = Guid.NewGuid(),
                    LoaiDoiTuong = loaiDoiTuong,
                    SinhVienId = sinhVienId,
                    GiangVienId = giangVienId,
                    NgayMuon = request.NgayMuon,
                    TrangThai = TrangThaiPhieuMuonEnum.DangMuon,
                    GhiChu = $"Mobile Scan: {request.MaDoiTuong}",
                    NgayTao = now,
                    NgayCapNhat = now,
                    ChiTietPhieuMuons = new List<TSTBChiTietPhieuMuon>
                    {
                        new TSTBChiTietPhieuMuon
                        {
                            Id = Guid.NewGuid(),
                            ThietBiId = request.ThietBiId,
                            TinhTrangKhiMuon = "Bình thường",
                            NgayTao = now,
                            NgayCapNhat = now
                        }
                    }
                };

                Console.WriteLine($"[CONTROLLER DEBUG] Send to Service - SV_ID: {entity.SinhVienId}");

                var result = await _phieuMuonTraService.CreateAsync(entity);

                return result.Match<IActionResult>(
                    succ => Ok(new { success = true, maPhieu = succ.MaPhieu }),
                    err => StatusCode(500, new { message = err.Message })
                );
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return StatusCode(500, new { message = "Lỗi Backend: " + msg });
            }
        }
    }
}