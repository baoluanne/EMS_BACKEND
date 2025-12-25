using EMS.Application.Services.Base;
using EMS.Application.Services.TinhThanhServices;
using EMS.Application.Services.ToBoMonServices;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.QuanHuyenServices;

public class QuanHuyenService : BaseService<QuanHuyen>, IQuanHuyenService
{
    public QuanHuyenService(IUnitOfWork unitOfWork, IQuanHuyenRepository quanHuyenRepository) 
        : base(unitOfWork, quanHuyenRepository)
    {
    }

    protected override Task UpdateEntityProperties(QuanHuyen existingEntity, QuanHuyen newEntity) 
    {
        existingEntity.MaQuanHuyen = newEntity.MaQuanHuyen;
        existingEntity.TenQuanHuyen = newEntity.TenQuanHuyen;
        existingEntity.GhiChu = newEntity.GhiChu;
        
        return Task.CompletedTask;
    }
} 