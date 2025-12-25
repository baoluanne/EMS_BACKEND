using EMS.Application.Services.NguoiDungServices.Dtos;
using EMS.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace EMS.Application.Services.NguoiDungServices.Mappers;

[Mapper]
public partial class NguoiDungMapper
{
    [MapperIgnoreSource(nameof(NguoiDung.HashedPassword))]
    public static partial NguoiDungDto ToNguoiDungDto(NguoiDung nguoiDung);
}
