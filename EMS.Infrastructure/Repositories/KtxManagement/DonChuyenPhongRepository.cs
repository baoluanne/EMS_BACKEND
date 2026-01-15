using EMS.Domain.Entities.KtxManagement;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;
using EMS.Domain.Interfaces.Repositories.KtxManagement;


namespace EMS.Infrastructure.Repositories.KtxManagement
{
    public class DonChuyenPhongRepository(DbFactory db) 
        : AuditRepository<KtxDonChuyenPhong>(db),
        IDonChuyenPhongRepository
    {
    }
}
