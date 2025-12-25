using EMS.API.Controllers.Base;
using EMS.Application.DTOs.KtxManagement;
using EMS.Application.Services.KtxService;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.Repositories.KtxManagement.Dtos;
using EMS.Domain.Models;
using LanguageExt.Common;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers.KtxController
{
    [Route("api/don-ktx")]
    [ApiController]
    public class DonKtxController : BaseController<DonKtx>
    {
        private readonly IDonKtxService _service;

        public DonKtxController(IDonKtxService service) : base(service)
        {
            _service = service;
        }

        [HttpPost("tao-don")]
        public async Task<IActionResult> Create([FromBody] DonKtxCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.AddDonAsync(dto);

            return result.Match<IActionResult>(
                Succ: id => Ok(new { message = "Tạo đơn thành công", donId = id }),
                Fail: err => BadRequest(new { error = err.Message })
            );
        }

        [HttpGet("pagination")]
        public async Task<IActionResult> GetPaginated([FromQuery] PaginationRequest request,
            [FromQuery] string? trangThai = null,
            [FromQuery] string? loaiDon = null)
        {
            var result = await _service.GetPaginatedWithDetailsAsync(request, trangThai, loaiDon);

            return result.Match(
                succ => Ok(succ),
                err => StatusCode(500, new { message = "Lỗi lấy danh sách đơn", error = err.Message })
            );
        }

        [HttpPost("{donId}/duyet-vao-o")]
        public async Task<IActionResult> DuyetVaoO(Guid donId, Guid phongId, Guid giuongId, [FromQuery] string? ghiChuDuyet = null)
        {
            var result = await _service.DuyetDonVaoOAsync(donId, phongId, giuongId, ghiChuDuyet);

            return result.Match<IActionResult>(
                Succ: _ => Ok(new { message = "Duyệt đơn vào ở thành công" }),
                Fail: err => BadRequest(new { error = err.Message })
            );
        }

        [HttpPost("{donId}/duyet-chuyen-phong")]
        public async Task<IActionResult> DuyetChuyenPhong(Guid donId, Guid phongMoiId, Guid giuongMoiId, DateTime ngayBatDau,
            DateTime ngayHetHan, [FromQuery] string? ghiChuDuyet = null)
        {
            var result = await _service.DuyetDonChuyenPhongAsync(donId, phongMoiId, giuongMoiId, ngayBatDau, ngayHetHan, ghiChuDuyet);

            return result.Match<IActionResult>(
                Succ: _ => Ok(new { message = "Duyệt chuyển phòng thành công" }),
                Fail: err => BadRequest(new { error = err.Message })
            );
        }

        [HttpPost("{donId}/duyet-gia-han")]
        public async Task<IActionResult> DuyetGiaHan(Guid donId, DateTime ngayHetHanMoi, [FromQuery] string? ghiChuDuyet = null)
        {
            var result = await _service.DuyetDonGiaHanAsync(donId, ngayHetHanMoi, ghiChuDuyet);

            return result.Match<IActionResult>(
                Succ: _ => Ok(new { message = "Duyệt gia hạn thành công" }),
                Fail: err => BadRequest(new { error = err.Message })
            );
        }

        [HttpPost("{donId}/duyet-roi-ktx")]
        public async Task<IActionResult> DuyetRoiKtx(Guid donId, [FromQuery] string? ghiChuDuyet = null)
        {
            var result = await _service.DuyetDonRoiKtxAsync(donId, ghiChuDuyet);

            return result.Match<IActionResult>(
                Succ: _ => Ok(new { message = "Duyệt rời KTX thành công" }),
                Fail: err => BadRequest(new { error = err.Message })
            );
        }

        [HttpPost("{donId}/tu-choi")]
        public async Task<IActionResult> TuChoi(Guid donId, [FromBody] string lyDoTuChoi)
        {
            if (string.IsNullOrWhiteSpace(lyDoTuChoi))
                return BadRequest(new { error = "Lý do từ chối không được để trống" });

            var result = await _service.TuChoiDonAsync(donId, lyDoTuChoi);

            return result.Match<IActionResult>(
                Succ: _ => Ok(new { message = "Từ chối đơn thành công" }),
                Fail: err => BadRequest(new { error = err.Message })
            );
        }
    }
}