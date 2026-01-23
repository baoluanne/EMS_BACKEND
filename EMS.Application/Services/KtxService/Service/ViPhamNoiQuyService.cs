using EMS.Application.Services.Base;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.Repositories.KtxManagement;
using LanguageExt.Common;

namespace EMS.Application.Services.KtxService.Service
{
    public class ViPhamNoiQuyService : BaseService<KtxViPhamNoiQuy>, IViPhamNoiQuyKTXService
    {
        private readonly IViPhamNoiQuyKTXRepository _repository;

        public ViPhamNoiQuyService(IUnitOfWork unitOfWork, IViPhamNoiQuyKTXRepository repository)
            : base(unitOfWork, repository)
        {
            _repository = repository;
        }

        public override async Task<Result<KtxViPhamNoiQuy>> CreateAsync(KtxViPhamNoiQuy entity)
        {
            try
            {
                if (string.IsNullOrEmpty(entity.MaBienBan))
                {
                    entity.MaBienBan = $"BBVP-{DateTime.Now:yyyyMMdd}-{Guid.NewGuid().ToString()[..4].ToUpper()}";
                }
                var violations = await _repository.ListAsync(filter: x => x.SinhVienId == entity.SinhVienId);
                entity.LanViPham = (violations?.Count ?? 0) + 1;

                if (entity.LanViPham >= 3)
                {
                    entity.HinhThucXuLy = "Buộc rời khỏi Ký túc xá (Vi phạm lần thứ 3)";
                    entity.DiemTru = 100;
                }
                else if (entity.LanViPham == 2)
                {
                    entity.HinhThucXuLy = "Cảnh cáo toàn nội trú";
                }
                else
                {
                    entity.HinhThucXuLy = "Nhắc nhở / Trừ điểm rèn luyện";
                }

                _repository.Add(entity);
                await UnitOfWork.CommitAsync();

                return new Result<KtxViPhamNoiQuy>(entity);
            }
            catch (Exception ex)
            {
                return new Result<KtxViPhamNoiQuy>(ex.InnerException ?? ex);
            }
        }

        protected override Task UpdateEntityProperties(KtxViPhamNoiQuy existingEntity, KtxViPhamNoiQuy newEntity)
        {
            existingEntity.SinhVienId = newEntity.SinhVienId;
            existingEntity.NoiDungViPham = newEntity.NoiDungViPham;
            existingEntity.HinhThucXuLy = newEntity.HinhThucXuLy;
            existingEntity.DiemTru = newEntity.DiemTru;
            existingEntity.NgayViPham = newEntity.NgayViPham;
            return Task.CompletedTask;
        }
    }
}