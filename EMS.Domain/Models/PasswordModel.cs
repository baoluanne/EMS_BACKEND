using System.ComponentModel.DataAnnotations;

namespace EMS.Domain.Models;

public class PasswordModel
{
    [Required]
    [DataType(DataType.Password)]
    [StringLength(50, ErrorMessage = "Mật khẩu phải dài từ 8 đến 50 kí tự", MinimumLength = 8)]
    public string Password { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    [StringLength(50, ErrorMessage = "Mật khẩu phải dài từ 8 đến 50 kí tự", MinimumLength = 8)]
    [Compare("Password")]
    public string PasswordConfirm { get; set; } = string.Empty;
}
