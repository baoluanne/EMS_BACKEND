using System.Linq.Expressions;
using EMS.Application.Services.ChuongTrinhKhungTinChiServices.Mappers;
using EMS.Domain.Dtos;
using EMS.Domain.Entities;
using EMS.Domain.Entities.ClassManagement;
using EMS.Domain.Interfaces;
using EMS.Domain.Interfaces.Repositories;
using EMS.Domain.Models;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EMS.Infrastructure.Repositories
{
    public class ChuongTrinhKhungTinChiRepository : AuditRepository<ChuongTrinhKhungTinChi>, IChuongTrinhKhungTinChiRepository
    {
        private readonly DbFactory _dbFactory;
        public ChuongTrinhKhungTinChiRepository(DbFactory dbFactory) : base(dbFactory)
        {
            _dbFactory = dbFactory;
        }
        
        public PaginationResponse<ChuongTrinhKhungTinChiResponseDto> GetPaginatedDtoResponse(
                PaginationRequest request,
                Expression<Func<ChuongTrinhKhungTinChi, bool>>? filters = null,
                Func<IQueryable<ChuongTrinhKhungTinChi>, IQueryable<ChuongTrinhKhungTinChi>>? include = null)
            {
                var ctkQuery = DbSet.AsNoTracking();
                
                var total = ctkQuery.Count();
                
                if (filters != null)
                {
                    ctkQuery = ctkQuery.Where(filters);
                }

                if (IsSoftDeletable)
                {
                    ctkQuery = ctkQuery.Where(x => !((ISoftDeletable)x).IsDeleted);
                }

                if (include != null)
                {
                    ctkQuery = include(ctkQuery);
                }
                
                ctkQuery = ctkQuery
                    .Skip((request.Page - 1) * request.PageSize)
                    .Take(request.PageSize);

                var lopHocQuery = _dbFactory.DbContext.Set<LopHoc>().AsNoTracking();

                var listCtkDtos = new  List<ChuongTrinhKhungTinChiResponseDto>();
                
                foreach (var ctk in ctkQuery)
                {
                    var ctkDto = ChuongTrinhKhungTinChiMapper.ToDto(ctk);
                    var matchedLophoc = lopHocQuery.Where(lop =>
                        lop.IdCoSoDaoTao == ctk.IdCoSoDaoTao &&
                        lop.IdBacDaoTao == ctk.IdBacDaoTao &&
                        lop.IdLoaiDaoTao == ctk.IdLoaiDaoTao &&
                        lop.IdNganhHoc == ctk.IdNganhHoc &&
                        lop.IdChuyenNganh == ctk.IdChuyenNganh &&
                        lop.IdKhoaHoc == ctk.IdKhoaHoc).ToList();

                    ctkDto.DanhSachLopHoc = matchedLophoc.Select(x => new LopHocResponseDto()
                        {
                            MaLop = x.MaLop,
                            TenLop = x.TenLop
                        })
                        .ToList();
                    listCtkDtos.Add(ctkDto);
                }
                
                return new PaginationResponse<ChuongTrinhKhungTinChiResponseDto>
                {
                    CurrentPage = request.Page,
                    PageSize = request.PageSize,
                    TotalCount = total,
                    TotalPages = (int)Math.Ceiling(total / (decimal)request.PageSize),
                    Result = listCtkDtos
                };
            }
    }
} 