using EMS.Domain.Entities.ClassManagement;
using EMS.Domain.Interfaces.Repositories.ClassManagement;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;

namespace EMS.Infrastructure.Repositories.ClassManagement
{
    public class ChuyenLopRepository(DbFactory dbFactory) : AuditRepository<ChuyenLop>(dbFactory), IChuyenLopRepository
    {
        // Implement custom methods if defined in interface
        // public async Task<List<ChuyenLop>> GetByStudentIdAsync(Guid studentId)
        // {
        //     return await DbSet.Where(x => x.IdSinhVien == studentId).ToListAsync();
        // }
        
        // public async Task<List<ChuyenLop>> GetByClassIdAsync(Guid classId)
        // {
        //     return await DbSet.Where(x => x.IdLopCu == classId || x.IdLopMoi == classId).ToListAsync();
        // }
    }
}