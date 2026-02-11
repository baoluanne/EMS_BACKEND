using System;
using System.Threading.Tasks;
using EMS.API.Controllers.Base;
using EMS.Application.Services.EquipService;
using EMS.Application.Services.EquipService.Dtos;
using EMS.Domain.Entities.EquipmentManagement;
using EMS.Domain.Enums.EquipmentManagement;
using EMS.Domain.Models; // Namespace chứa MobileScanResult vừa tạo
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers.Mobile
{
    [Route("api/mobile")]
    [ApiController]
    public class MobileController : ControllerBase
    {
        private readonly IThietBiService _thietBiService;

        public MobileController(IThietBiService thietBiService)
        {
            _thietBiService = thietBiService;
        }

        [HttpGet("scan/{id}")]
        public async Task<IActionResult> ScanDevice(Guid id)
        {
            // 1. Tìm thiết bị theo ID (QR Code chứa Guid ID)
            var result = await _thietBiService.GetByIdAsync(id);

            return result.Match<IActionResult>(
                succ =>
                {
                    if (succ == null)
                        return NotFound(new { message = "Không tìm thấy thiết bị trong hệ thống" });

                    // 2. Map dữ liệu sang DTO gọn nhẹ cho Mobile
                    var response = new MobileScanResult
                    {
                        Id = succ.Id,
                        MaThietBi = succ.MaThietBi,
                        TenThietBi = succ.TenThietBi,
                        Model = succ.Model,
                        SerialNumber = succ.SerialNumber,
                        HinhAnhUrl = succ.HinhAnhUrl,

                        // Lấy trạng thái (Mặc định là Mới nhập nếu null)
                        TrangThaiCode = (int)(succ.TrangThai ?? TrangThaiThietBiEnum.MoiNhap),
                        TrangThaiText = GetTrangThaiText(succ.TrangThai),

                        // Xác định vị trí sơ bộ
                        ViTri = GetViTriText(succ),

                        // 3. LOGIC QUAN TRỌNG: Quyết định được làm gì?

                        // Chỉ cho mượn nếu: Mới nhập (0)
                        AllowMuon = succ.TrangThai == TrangThaiThietBiEnum.MoiNhap,

                        // Chỉ cho trả nếu: Đang mượn (3)
                        AllowTra = succ.TrangThai == TrangThaiThietBiEnum.DangMuon,

                        // Chỉ cho thanh lý nếu: Hỏng (4)
                        AllowThanhLy = succ.TrangThai == TrangThaiThietBiEnum.Hong
                    };

                    return Ok(response);
                },
                err => StatusCode(500, new { message = err.Message })
            );
        }

        // Hàm phụ trợ: Chuyển Enum sang tiếng Việt hiển thị
        private string GetTrangThaiText(TrangThaiThietBiEnum? status)
        {
            return status switch
            {
                TrangThaiThietBiEnum.MoiNhap => "Mới nhập (Sẵn sàng)",
                TrangThaiThietBiEnum.DangSuDung => "Đang sử dụng tại trường",
                TrangThaiThietBiEnum.DangBaoTri => "Đang bảo trì",
                TrangThaiThietBiEnum.DangMuon => "Đang cho mượn",
                TrangThaiThietBiEnum.Hong => "Bị hỏng",
                TrangThaiThietBiEnum.ChoThanhLy => "Chờ thanh lý",
                TrangThaiThietBiEnum.DaThanhLy => "Đã thanh lý",
                TrangThaiThietBiEnum.Mat => "Đã mất",
                _ => "Không xác định"
            };
        }

        // Hàm phụ trợ: Xác định vị trí
        private string GetViTriText(TSTBThietBi tb)
        {
            if (tb.PhongHocId.HasValue) return "Tại Phòng Học";
            if (tb.PhongKtxId.HasValue) return "Tại KTX";
            return "Trong Kho";
        }
    }
}