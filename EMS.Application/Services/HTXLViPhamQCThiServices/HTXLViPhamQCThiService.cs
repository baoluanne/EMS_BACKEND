using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.HTXLViPhamQCThiServices
{
    public class HTXLViPhamQCThiService : BaseService<HTXLViPhamQCThi>, IHTXLViPhamQCThiService
    {
        public HTXLViPhamQCThiService(IUnitOfWork unitOfWork, IHTXLViPhamQCThiRepository htxlViPhamQCThiRepository) 
            : base(unitOfWork, htxlViPhamQCThiRepository)
        {
        }

        protected override Task UpdateEntityProperties(HTXLViPhamQCThi existingEntity, HTXLViPhamQCThi newEntity)
        {
            existingEntity.MaXLQC = newEntity.MaXLQC;
            existingEntity.TenXLQC = newEntity.TenXLQC;
            existingEntity.PhanTramDiemTru = newEntity.PhanTramDiemTru;
            existingEntity.MucDo = newEntity.MucDo;
            existingEntity.DiemTruRL = newEntity.DiemTruRL;
            existingEntity.GhiChu = newEntity.GhiChu;
            return Task.CompletedTask;
        }
    }
} 