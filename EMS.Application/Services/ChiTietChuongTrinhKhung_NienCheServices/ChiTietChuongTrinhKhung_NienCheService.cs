using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.ChiTietChuongTrinhKhung_NienCheServices
{
    public class ChiTietChuongTrinhKhung_NienCheService : BaseService<ChiTietChuongTrinhKhung_NienChe>, IChiTietChuongTrinhKhung_NienCheService
    {
        public ChiTietChuongTrinhKhung_NienCheService(IUnitOfWork unitOfWork, IChiTietChuongTrinhKhung_NienCheRepository repository) 
            : base(unitOfWork, repository)
        {
        }

        protected override Task UpdateEntityProperties(ChiTietChuongTrinhKhung_NienChe existingEntity, ChiTietChuongTrinhKhung_NienChe newEntity)
        {
            existingEntity.IsBatBuoc = newEntity.IsBatBuoc;
            existingEntity.IdChuongTrinhKhung = newEntity.IdChuongTrinhKhung;
            existingEntity.ChuongTrinhKhungNienChe = newEntity.ChuongTrinhKhungNienChe;
            existingEntity.IdMonHocBacDaoTao = newEntity.IdMonHocBacDaoTao;
            existingEntity.HocKy = newEntity.HocKy;

            return Task.CompletedTask;
        }
    }
} 