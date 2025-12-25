using System.ComponentModel.DataAnnotations;

namespace EMS.Domain.Models;

public class PaginationRequest
{
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Page must be a positive number")]
    public int Page { get; set; } = 1;
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "PageSize must be a positive number")]
    public int PageSize { get; set; } = int.MaxValue;

    public string SortField { get; set; } = "NgayTao";
    public bool IsDesc { get; set; }
}
