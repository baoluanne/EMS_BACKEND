namespace EMS.Domain.Interfaces;

/// <summary>
/// Interface for entities that support soft deletion
/// </summary>
public interface ISoftDeletable
{
    /// <summary>
    /// Gets or sets a value indicating whether the entity is deleted
    /// </summary>
    bool IsDeleted { get; set; }
} 