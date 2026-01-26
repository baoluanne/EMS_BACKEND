using EMS.Application.Services.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Enums;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.KtxManagement;
using LanguageExt.Common;

namespace EMS.Application.Services.KtxService.Service
{
    public class ViPhamNoiQuyService : BaseService<KtxViPhamNoiQuy>, IViPhamNoiQuyService
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
                var allViPham = await _repository.ListAsync(filter: x =>
                    x.SinhVienId == entity.SinhVienId &&
                    x.LoaiViPham == entity.LoaiViPham);

                entity.LanViPham = allViPham.Count + 1;

                if (string.IsNullOrEmpty(entity.MaBienBan))
                {
                    entity.MaBienBan = GenerateMaBienBan(entity.LoaiViPham, entity.LanViPham);
                }

                if (entity.DiemTru == 0)
                {
                    entity.DiemTru = GetDefaultDiemTru(entity.LoaiViPham);
                }

                if (entity.NgayViPham == default)
                {
                    entity.NgayViPham = DateTime.UtcNow;
                }

                Repository.Add(entity);
                await UnitOfWork.CommitAsync();

                return new Result<KtxViPhamNoiQuy>(entity);
            }
            catch (Exception ex)
            {
                return new Result<KtxViPhamNoiQuy>(ex.InnerException ?? ex);
            }
        }

        private string GenerateMaBienBan(LoaiViPhamNoiQuy loai, int lan)
        {
            var prefix = loai switch
            {
                LoaiViPhamNoiQuy.SuDungChatCam => "VP-SDCC",
                LoaiViPhamNoiQuy.GayMatTratTu => "VP-GMTT",
                LoaiViPhamNoiQuy.KhongVeDungGio => "VP-KVDG",
                LoaiViPhamNoiQuy.NauAnTrongPhong => "VP-NATP",
                LoaiViPhamNoiQuy.DuaNguoiLaVaoPhong => "VP-DNLV",
                _ => "VP-GEN"
            };

            return $"{prefix}-{DateTime.Now:yyyyMMdd}-L{lan}";
        }

        private int GetDefaultDiemTru(LoaiViPhamNoiQuy loai)
        {
            return loai switch
            {
                LoaiViPhamNoiQuy.SuDungChatCam => 50,
                LoaiViPhamNoiQuy.GayMatTratTu => 10,
                LoaiViPhamNoiQuy.KhongVeDungGio => 5,
                LoaiViPhamNoiQuy.NauAnTrongPhong => 20,
                LoaiViPhamNoiQuy.DuaNguoiLaVaoPhong => 30,
                _ => 0
            };
        }

        protected override Task UpdateEntityProperties(KtxViPhamNoiQuy existingEntity, KtxViPhamNoiQuy newEntity)
        {
            existingEntity.SinhVienId = newEntity.SinhVienId;
            existingEntity.NoiDungViPham = newEntity.NoiDungViPham;
            existingEntity.HinhThucXuLy = newEntity.HinhThucXuLy;
            existingEntity.DiemTru = newEntity.DiemTru;
            existingEntity.NgayViPham = newEntity.NgayViPham;
            existingEntity.LoaiViPham = newEntity.LoaiViPham;

            return Task.CompletedTask;
        }
    }
}