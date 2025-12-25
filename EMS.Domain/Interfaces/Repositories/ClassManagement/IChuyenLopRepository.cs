using EMS.Domain.Entities.ClassManagement;
using EMS.Domain.Interfaces.Repositories.Base;

namespace EMS.Domain.Interfaces.Repositories.ClassManagement
{
    public interface IChuyenLopRepository : IAuditRepository<ChuyenLop>
    {
        // Add custom methods if needed in the future
        // Task<List<ChuyenLop>> GetByStudentIdAsync(Guid studentId);
        // Task<List<ChuyenLop>> GetByClassIdAsync(Guid classId);
    }
}