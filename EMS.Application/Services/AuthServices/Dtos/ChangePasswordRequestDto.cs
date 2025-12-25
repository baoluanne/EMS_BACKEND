using System.ComponentModel.DataAnnotations;
using EMS.Domain.Models;

namespace EMS.Application.Services.AuthServices.Dtos;

public class ChangePasswordRequestDto : PasswordModel
{
    [Required]
    [DataType(DataType.Password)]
    [StringLength(50, ErrorMessage = "Mật khẩu phải dài từ 8 đến 50 kí tự", MinimumLength = 8)]
    public string OldPassword { get; set; } = string.Empty;
}
