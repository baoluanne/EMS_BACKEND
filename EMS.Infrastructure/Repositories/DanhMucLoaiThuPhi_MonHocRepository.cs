using EMS.Domain.Entities;
using EMS.Domain.Interfaces.Repositories;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;

namespace EMS.Infrastructure.Repositories
{
    public class DanhMucLoaiThuPhi_MonHocRepository(DbFactory dbFactory) : AuditRepository<DanhMucLoaiThuPhi_MonHoc>(dbFactory), IDanhMucLoaiThuPhi_MonHocRepository
    {
    }
}
