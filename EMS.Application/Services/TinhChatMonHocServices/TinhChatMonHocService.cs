using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.TinhChatMonHocServices;

public class TinhChatMonHocService : BaseService<TinhChatMonHoc>, ITinhChatMonHocService
{
    public TinhChatMonHocService(IUnitOfWork unitOfWork, ITinhChatMonHocRepository tinhChatMonHocRepository) 
        : base(unitOfWork, tinhChatMonHocRepository)
    {
    }

    protected override Task UpdateEntityProperties(TinhChatMonHoc existingEntity, TinhChatMonHoc newEntity)
    {
        existingEntity.MaTinhChatMonHoc = newEntity.MaTinhChatMonHoc;
        existingEntity.TenTinhChatMonHoc = newEntity.TenTinhChatMonHoc;
        existingEntity.GhiChu = newEntity.GhiChu;
        
        return Task.CompletedTask;
    }
} 