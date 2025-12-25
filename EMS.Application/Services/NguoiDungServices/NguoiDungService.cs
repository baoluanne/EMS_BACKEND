using EMS.Application.Services.CurrentUserServices;
using EMS.Application.Services.NguoiDungServices.Dtos;
using EMS.Application.Services.NguoiDungServices.Mappers;
using EMS.Domain.Common;
using EMS.Domain.Entities;
using EMS.Domain.Exceptions;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;
using LanguageExt.Common;
using Microsoft.AspNetCore.Identity;

namespace EMS.Application.Services.NguoiDungServices;

public class NguoiDungService(
    IUnitOfWork unitOfWork,
    IPasswordHasher<NguoiDung> passwordHasher,
    ICurrentUserService currentUserService
) : INguoiDungService
{
    private readonly IPasswordHasher<NguoiDung> _passwordHasher = passwordHasher;

    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly INguoiDungRepository _nguoiDungRepository = unitOfWork.GetRepository<INguoiDungRepository>();
    private readonly ICurrentUserService _currentUserService = currentUserService;

    public async Task<Result<NguoiDungDto>> CreateNguoiDungAsync(CreateNguoiDungRequestDto request)
    {
        var existingNguoiDung = await _nguoiDungRepository.GetNguoiDungByEmailAsync(request.Email);
        if (existingNguoiDung is not null)
        {
            return new Result<NguoiDungDto>(new ConflictException("Email đã tồn tại"));
        }

        var nguoiDung = CreateNguoiDungRequestDto.ToNguoiDung(request);
        nguoiDung.HashedPassword = _passwordHasher.HashPassword(nguoiDung, Env.GetDefaultPassword());

        var result = _nguoiDungRepository.Add(nguoiDung);

        await _unitOfWork.CommitAsync();

        var nguoiDungDto = NguoiDungMapper.ToNguoiDungDto(result);

        return nguoiDungDto;
    }

    public async Task<Result<NguoiDungDto>> GetMeAsync()
    {
        var nguoiDung = await _currentUserService.GetCurrentUser();
        if (nguoiDung is null)
        {
            return new Result<NguoiDungDto>(new NotFoundException("Không tìm thấy người dùng"));
        }

        var nguoiDungDto = NguoiDungMapper.ToNguoiDungDto(nguoiDung);
        return nguoiDungDto;
    }
}
