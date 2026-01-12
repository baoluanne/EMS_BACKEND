using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EMS.Application.Services.Base;
using EMS.Application.Services.EquipService.Dtos;
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
        public ThietBiService(
            IUnitOfWork unitOfWork,
            IThietBiRepository repository)
            : base(unitOfWork, repository)
        {
        }

        protected override Task UpdateEntityProperties(TSTBThietBi existingEntity, TSTBThietBi newEntity)
        {
            existingEntity.MaThietBi = newEntity.MaThietBi;
            existingEntity.TenThietBi = newEntity.TenThietBi;
            existingEntity.LoaiThietBiId = newEntity.LoaiThietBiId;
            existingEntity.NhaCungCapId = newEntity.NhaCungCapId;
            existingEntity.Model = newEntity.Model;
            existingEntity.SerialNumber = newEntity.SerialNumber;
            existingEntity.ThongSoKyThuat = newEntity.ThongSoKyThuat;
            existingEntity.NamSanXuat = newEntity.NamSanXuat;
            existingEntity.NgayMua = newEntity.NgayMua;
            existingEntity.NgayHetHanBaoHanh = newEntity.NgayHetHanBaoHanh;
            existingEntity.NguyenGia = newEntity.NguyenGia;
            existingEntity.GiaTriKhauHao = newEntity.GiaTriKhauHao;
            existingEntity.TrangThai = newEntity.TrangThai;
            existingEntity.GhiChu = newEntity.GhiChu;
            existingEntity.HinhAnhUrl = newEntity.HinhAnhUrl;
            return Task.CompletedTask;
        }

        public async Task<Result<List<TSTBThietBi>>> NhapHangLoatAsync(NhapHangLoatDto dto)
        {
            var list = new List<TSTBThietBi>();

            for (int i = 1; i <= dto.SoLuong; i++)
            {
                var maThietBi = string.IsNullOrEmpty(dto.PrefixMaThietBi)
                    ? $"TB-{DateTime.Now:yyyyMM}-{i:D4}"
                    : $"{dto.PrefixMaThietBi}{i:D4}";

                var tb = new TSTBThietBi
                {
                    MaThietBi = maThietBi,
                    TenThietBi = dto.TenThietBi,
                    LoaiThietBiId = dto.LoaiThietBiId,
                    NhaCungCapId = dto.NhaCungCapId,
                    Model = dto.Model,
                    ThongSoKyThuat = dto.ThongSoKyThuat,
                    NamSanXuat = dto.NamSanXuat,
                    NgayMua = dto.NgayMua,
                    NgayHetHanBaoHanh = dto.NgayHetHanBaoHanh,
                    NguyenGia = dto.NguyenGia,
                    GiaTriKhauHao = dto.GiaTriKhauHao,
                    TrangThai = dto.TrangThai,
                    GhiChu = dto.GhiChu,
                    PhongHocId = dto.PhongHocId
                };

                list.Add(tb);
            }

            Repository.AddRange(list);
            await UnitOfWork.CommitAsync();

            return new Result<List<TSTBThietBi>>(list);
        }
        public async Task<Result<bool>> PhanVaoPhongAsync(Guid phongHocId, List<Guid> thietBiIds)
        {
            try
            {
                var thietBis = await Repository.ListAsync(filter: x => thietBiIds.Contains(x.Id));

                foreach (var tb in thietBis)
                {
                    tb.PhongHocId = phongHocId;
                    tb.TrangThai = TrangThaiThietBiEnum.DangSuDung;
                    Repository.Update(tb);
                }

                await UnitOfWork.CommitAsync();
                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(ex);
            }
        }
    }
}