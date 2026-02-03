using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Application.Services.Base;
using EMS.Domain.Entities.EquipmentManagement;
using EMS.Domain.Enums.EquipmentManagement;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.EquipManagement;
using EMS.Domain.Models;
using LanguageExt.Common;

namespace EMS.Application.Services.EquipService.Service
{
    public class ThietBiService : BaseService<TSTBThietBi>, IThietBiService
    {
        private const string DEFAULT_DEVICE_CODE_PREFIX = "TB";
        private const int DEVICE_CODE_PADDING = 4;

        public ThietBiService(
            IUnitOfWork unitOfWork,
            IThietBiRepository repository)
            : base(unitOfWork, repository)
        {
        }

        public new async Task<Result<TSTBThietBi[]>> CreateManyAsync(TSTBThietBi[] entities)
        {
            try
            {
                ValidateEntities(entities);
                PrepareEntitiesForCreation(entities);

                Repository.AddRange(entities);
                await UnitOfWork.CommitAsync();

                return new Result<TSTBThietBi[]>(entities);
            }
            catch (Exception ex)
            {
                return new Result<TSTBThietBi[]>(ex.InnerException ?? ex);
            }
        }

        protected override Task UpdateEntityProperties(TSTBThietBi existingEntity, TSTBThietBi newEntity)
        {
            MapEntityProperties(existingEntity, newEntity);
            return Task.CompletedTask;
        }

        public async Task<Result<bool>> PhanVaoPhongAsync(Guid targetId, List<Guid> thietBiIds, bool isKtx)
        {
            try
            {
                var thietBis = await GetDevicesByIds(thietBiIds);
                AssignDevicesToRoom(thietBis, targetId, isKtx);

                await UnitOfWork.CommitAsync();
                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(ex);
            }
        }

        #region Private Methods

        private void ValidateEntities(TSTBThietBi[] entities)
        {
            if (entities == null || entities.Length == 0)
                throw new ArgumentException("Entities cannot be null or empty");
        }

        private void PrepareEntitiesForCreation(TSTBThietBi[] entities)
        {
            var timestamp = DateTime.UtcNow;

            for (int i = 0; i < entities.Length; i++)
            {
                var entity = entities[i];

                InitializeEntity(entity, timestamp);
                GenerateDeviceCodeIfNeeded(entity, timestamp, i);
                SetDefaultStatusIfNeeded(entity);
            }
        }

        private void InitializeEntity(TSTBThietBi entity, DateTime timestamp)
        {
            entity.Id = Guid.NewGuid();
            entity.NgayTao = timestamp;
        }

        private void GenerateDeviceCodeIfNeeded(TSTBThietBi entity, DateTime timestamp, int index)
        {
            if (string.IsNullOrWhiteSpace(entity.MaThietBi))
            {
                entity.MaThietBi = GenerateUniqueDeviceCode(timestamp, index);
            }
        }

        private string GenerateUniqueDeviceCode(DateTime timestamp, int index)
        {
            var dateTimePart = timestamp.ToString("yyyyMMddHHmmss");
            var sequencePart = (index + 1).ToString($"D{DEVICE_CODE_PADDING}");

            return $"{DEFAULT_DEVICE_CODE_PREFIX}-{dateTimePart}-{sequencePart}";
        }

        private void SetDefaultStatusIfNeeded(TSTBThietBi entity)
        {
            if (entity.TrangThai == null)
            {
                entity.TrangThai = TrangThaiThietBiEnum.MoiNhap;
            }
        }

        private void MapEntityProperties(TSTBThietBi target, TSTBThietBi source)
        {
            target.MaThietBi = source.MaThietBi;
            target.TenThietBi = source.TenThietBi;
            target.LoaiThietBiId = source.LoaiThietBiId;
            target.NhaCungCapId = source.NhaCungCapId;
            target.Model = source.Model;
            target.SerialNumber = source.SerialNumber;
            target.ThongSoKyThuat = source.ThongSoKyThuat;
            target.NamSanXuat = source.NamSanXuat;
            target.NgayMua = source.NgayMua;
            target.NgayHetHanBaoHanh = source.NgayHetHanBaoHanh;
            target.NguyenGia = source.NguyenGia;
            target.GiaTriKhauHao = source.GiaTriKhauHao;
            target.TrangThai = source.TrangThai;
            target.GhiChu = source.GhiChu;
            target.HinhAnhUrl = source.HinhAnhUrl;
            target.PhongHocId = source.PhongHocId;
            target.PhongKtxId = source.PhongKtxId;
        }

        private async Task<IEnumerable<TSTBThietBi>> GetDevicesByIds(List<Guid> deviceIds)
        {
            return await Repository.ListAsync(filter: x => deviceIds.Contains(x.Id));
        }

        private void AssignDevicesToRoom(IEnumerable<TSTBThietBi> devices, Guid roomId, bool isKtx)
        {
            foreach (var device in devices)
            {
                AssignDeviceToRoom(device, roomId, isKtx);
                UpdateDeviceStatus(device);
                Repository.Update(device);
            }
        }

        private void AssignDeviceToRoom(TSTBThietBi device, Guid roomId, bool isKtx)
        {
            if (isKtx)
            {
                device.PhongKtxId = roomId;
                device.PhongHocId = null;
            }
            else
            {
                device.PhongHocId = roomId;
                device.PhongKtxId = null;
            }
        }

        private void UpdateDeviceStatus(TSTBThietBi device)
        {
            device.TrangThai = TrangThaiThietBiEnum.DangSuDung;
        }

        #endregion
    }
}