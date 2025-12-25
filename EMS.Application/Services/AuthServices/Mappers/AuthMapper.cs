using EMS.Application.Services.NguoiDungServices.Dtos;
using EMS.Domain.Entities;
using EMS.Domain.Models;
using Riok.Mapperly.Abstractions;

namespace EMS.Application.Services.AuthServices.Mappers;

[Mapper]
public partial class AuthMapper
{
    public static partial JwtModel ToJwtModel(NguoiDung nguoiDung);
}
