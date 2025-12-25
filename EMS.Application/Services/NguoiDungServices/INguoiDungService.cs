using EMS.Application.Services.NguoiDungServices.Dtos;
using LanguageExt.Common;

namespace EMS.Application.Services.NguoiDungServices;

public interface INguoiDungService
{
    Task<Result<NguoiDungDto>> CreateNguoiDungAsync(CreateNguoiDungRequestDto request);
    Task<Result<NguoiDungDto>> GetMeAsync();
}
