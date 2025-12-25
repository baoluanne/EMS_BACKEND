using EMS.API.Controllers.Base;
using EMS.Application.Services.DanhSachSinhVienDuocInTheServices;
using EMS.Domain.Entities.StudentManagement;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers.StudentManagement
{
    public class DanhSachSinhVienDuocInTheController : BaseController<DanhSachSinhVienDuocInThe>
    {
        private readonly IDanhSachSinhVienDuocInTheService _danhSachSinhVienDuocInTheService;

        public DanhSachSinhVienDuocInTheController(IDanhSachSinhVienDuocInTheService danhSachSinhVienDuocInTheService) 
            : base(danhSachSinhVienDuocInTheService)
        {
            _danhSachSinhVienDuocInTheService = danhSachSinhVienDuocInTheService;
        }

        // Override GetAll to include related entities
        public override async Task<IActionResult> GetAll()
        {
            var result = await Service.GetAllAsync(q => q
                .Include(x => x.SinhVien)
            );
            return result.ToResult();
        }

        // Override GetPaginated with custom filtering
        [HttpGet("pagination")]
        public virtual async Task<IActionResult> GetPagination(
            [FromQuery] PaginationRequest request,
            [FromQuery] DanhSachSinhVienDuocInTheFilter filter)
        {
            var result = await Service.GetPaginatedAsync(
                request,
                include: q => q.Include(x => x.SinhVien),
                filter: q =>
                    (filter.IdSinhVien == null || q.IdSinhVien == filter.IdSinhVien) ||
                    (filter.CoHinhTheSv == null || q.CoHinhTheSv == filter.CoHinhTheSv) ||
                    (filter.NgayImportHinhTheSvFrom == null || q.NgayImportHinhTheSv >= filter.NgayImportHinhTheSvFrom) ||
                    (filter.NgayImportHinhTheSvTo == null || q.NgayImportHinhTheSv <= filter.NgayImportHinhTheSvTo)
            );
            return result.ToResult();
        }
    }

    // Filter class for pagination
    public class DanhSachSinhVienDuocInTheFilter
    {
        public Guid? IdSinhVien { get; set; }
        public bool? CoHinhTheSv { get; set; }
        public DateTime? NgayImportHinhTheSvFrom { get; set; }
        public DateTime? NgayImportHinhTheSvTo { get; set; }
    }
}