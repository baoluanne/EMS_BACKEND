using EMS.Application.Services.Base;
using EMS.Domain.Entities.Base;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using EMS.Domain.Models.Import;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers.Base;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseController<T> : ControllerBase where T : AuditableEntity
{
    protected readonly IBaseService<T> Service;

    protected BaseController(IBaseService<T> service)
    {
        Service = service;
    }

    /// <summary>
    /// Get all records
    /// </summary>
    [HttpGet]
    public virtual async Task<IActionResult> GetAll()
    {
        var result = await Service.GetAllAsync();
        return result.ToResult();
    }

    /// <summary>
    /// Get a record by ID
    /// </summary>
    [HttpGet("{id:guid}")]
    public virtual async Task<IActionResult> GetById(Guid id)
    {
        var result = await Service.GetByIdAsync(id);
        return result.ToResult();
    }

    /// <summary>
    /// Create a new record
    /// </summary>
    [HttpPost]
    public virtual async Task<IActionResult> Create([FromBody] T entity)
    {
        var result = await Service.CreateAsync(entity);
        return result.ToResult();
    }

    /// <summary>
    /// Create multiple records
    /// </summary>
    [HttpPost("multiple")]
    public virtual async Task<IActionResult> CreateMany([FromBody] T[] entities)
    {
        var result = await Service.CreateManyAsync(entities);
        return result.ToResult();
    }

    /// <summary>
    /// Update an existing record
    /// </summary>
    [HttpPut("{id:guid}")]
    public virtual async Task<IActionResult> Update(Guid id, [FromBody] T entity)
    {
        var result = await Service.UpdateAsync(id, entity);
        return result.ToResult();
    }

    /// <summary>
    /// Delete a record
    /// </summary>
    [HttpDelete("{id:guid}")]
    public virtual async Task<IActionResult> Delete(Guid id)
    {
        var result = await Service.DeleteAsync(id);
        return result.ToResult();
    }

    /// <summary>
    /// Get paginated records
    /// </summary>
    [HttpGet("paginated")]
    public virtual async Task<IActionResult> GetPaginated([FromQuery] PaginationRequest request)
    {
        var result = await Service.GetPaginatedAsync(request);
        return result.ToResult();
    }

    /// <summary>
    /// Copy (duplicate) records by a list of IDs
    /// </summary>
    [HttpPost("copy")]
    public virtual async Task<IActionResult> Copy([FromBody] List<Guid> ids)
    {
        var result = await Service.CopyAsync(ids);
        return result.ToResult();
    }

    /// <summary>
    /// Delete multiple records by a list of IDs
    /// </summary>
    [HttpPost("delete-multiple")]
    public virtual async Task<IActionResult> DeleteMultiple([FromBody] List<Guid> ids)
    {
        var result = await Service.DeleteMultipleAsync(ids);
        return result.ToResult();
    }

    [HttpPost("import")]
    public virtual async Task<IActionResult> Import([FromBody] ImportRequest request)
    {
        if (request?.File == null || request.File.Length == 0)
            return BadRequest("File is invalid");

        return BadRequest("Hãy override Import trong controller để chỉ định DTO + mapping.");
    }
}