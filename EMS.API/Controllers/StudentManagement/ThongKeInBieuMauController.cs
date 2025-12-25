using EMS.API.Controllers.Base;
using EMS.Application.Services.ThongKeInBieuMauServices;
using EMS.Domain.Entities.StudentManagement;
using EMS.Domain.Enums;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers.StudentManagement
{
    public class ThongKeInBieuMauController : BaseController<ThongKeInBieuMau>
    {
        private readonly IThongKeInBieuMauService _service;

        public ThongKeInBieuMauController(IThongKeInBieuMauService service) : base(service)
        {
            _service = service;
        }

        // Override GetAll to include related entities
        public override async Task<IActionResult> GetAll()
        {
            var result = await Service.GetAllAsync(q => q
                .Include(x => x.BieuMau)
                .Include(x => x.NguoiIn)
                .Include(x => x.SinhVien)
            );
            return result.ToResult();
        }

        [HttpGet("pagination")]
        public virtual async Task<IActionResult> GetPagination(
    [FromQuery] PaginationRequest request,
    [FromQuery] ThongKeInBieuMauFilter filter)
        {
            var result = await Service.GetPaginatedAsync(
                request,
                include: q => q
                    .Include(x => x.BieuMau)
                    .Include(x => x.NguoiIn)
                    .Include(x => x.SinhVien)
                        .ThenInclude(sv => sv.LopHoc),
                filter: q =>
                    (filter.IdBieuMau == null || q.IdBieuMau == filter.IdBieuMau) &&
                    (filter.IdNguoiIn == null || q.IdNguoiIn == filter.IdNguoiIn) &&

                    (filter.NgayInFrom == null || q.NgayIn >= filter.NgayInFrom) &&
                    (filter.NgayInTo == null || q.NgayIn <= filter.NgayInTo) &&

                    (string.IsNullOrEmpty(filter.MaBieuMau) ||
                        (q.BieuMau != null &&
                         q.BieuMau.MaBieuMau.ToLower().Contains(filter.MaBieuMau.ToLower()))) &&

                    (string.IsNullOrEmpty(filter.MaSinhVien) ||
                        (q.SinhVien != null &&
                         q.SinhVien.MaSinhVien.ToLower().Contains(filter.MaSinhVien.ToLower()))) &&

                    (string.IsNullOrEmpty(filter.HoTen) ||
                        (q.SinhVien != null &&
                         (
                            q.SinhVien.Ten.ToLower().Contains(filter.HoTen.ToLower()) ||
                            (q.SinhVien.HoDem + " " + q.SinhVien.HoDem + " " + q.SinhVien.Ten).ToLower().Contains(filter.HoTen.ToLower())
                         )
                        )) &&

                    (filter.TrangThaiSinhVien == null ||
                        (q.SinhVien != null && q.SinhVien.TrangThai == filter.TrangThaiSinhVien)) &&

                    (string.IsNullOrEmpty(filter.MayIn) ||
                        (!string.IsNullOrEmpty(q.MayIn) &&
                         q.MayIn.ToLower().Contains(filter.MayIn.ToLower()))) &&

                    (string.IsNullOrEmpty(filter.NguoiIn) ||
                        (q.NguoiIn != null &&
                         (
                            q.NguoiIn.Email.ToLower().Contains(filter.NguoiIn.ToLower()) ||
                            q.NguoiIn.Ten.ToLower().Contains(filter.NguoiIn.ToLower()) ||
                            (q.NguoiIn.Ho + " " + q.NguoiIn.TenDem + q.NguoiIn.Ten).ToLower().Contains(filter.NguoiIn.ToLower())
                         )))
            );

            return result.ToResult();
        }
    }

    // Filter class for pagination
    public class ThongKeInBieuMauFilter
    {
        public Guid? IdBieuMau { get; set; }
        public Guid? IdNguoiIn { get; set; }
        public DateTime? NgayInFrom { get; set; }
        public DateTime? NgayInTo { get; set; }
        public string? MaBieuMau { get; set; }
        public string? MaSinhVien { get; set; }
        public string? HoTen { get; set; }
        public TrangThaiSinhVienEnum? TrangThaiSinhVien { get; set; }
        public string? MayIn { get; set; }
        public string? NguoiIn { get; set; }
    }
}