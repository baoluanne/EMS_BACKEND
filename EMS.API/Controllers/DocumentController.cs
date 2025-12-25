using EMS.Domain.Interfaces.Storages;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers;

public class DocumentController : ControllerBase
{
    private readonly IStorageService _storageService;

    public DocumentController(IStorageService storageService)
    {
        _storageService = storageService;
    }

    [HttpGet("get-presigned-url")]
    public virtual async Task<IActionResult> GetPresignedUrlAsync([FromQuery] string path)
    {
        var result = await _storageService.GetPresignedUrlAsync(path);
        return Ok(result);
    }
}