# EMS Backend Code Generation Guideline

## Overview
This document provides a comprehensive guideline for generating complete backend code from Entity Framework entities to API controllers in the EMS (Education Management System) project. The system follows Domain-Driven Design (DDD) principles with Clean Architecture patterns.

## Tech Stack and Framework

### Core Technologies
- **.NET 9.0** - Latest .NET framework
- **ASP.NET Core 9.0** - Web API framework
- **Entity Framework Core 9.0** - ORM with PostgreSQL provider
- **PostgreSQL** - Primary database
- **C# 12** - Programming language

### Key Libraries and Packages
- **FluentValidation** - Input validation
- **LanguageExt.Core** - Functional programming extensions
- **Scrutor** - Assembly scanning for dependency injection
- **Hangfire** - Background job processing
- **Serilog** - Structured logging
- **JWT Bearer** - Authentication
- **Newtonsoft.Json** - JSON serialization
- **ClosedXML** - Excel file processing
- **Swagger/OpenAPI** - API documentation
- **MailKit** - Email services

### Architecture Layers
1. **EMS.API** - Presentation layer (Controllers, Middlewares)
2. **EMS.Application** - Application layer (Services, DTOs, Business Logic)
3. **EMS.Domain** - Domain layer (Entities, Interfaces, Models)
4. **EMS.EFCore** - Data layer (DbContext, Configurations, Migrations)
5. **EMS.Infrastructure** - Infrastructure layer (Repositories, External Services)

## Full Development Flow

### 1. Entity Definition (EMS.Domain)
**Location**: `EMS.Domain/Entities/`

#### Base Entity Structure
All entities inherit from `AuditableEntity` which provides:
- `Id` (Guid) - Primary key
- `IdNguoiTao` (Guid?) - Creator user ID
- `NgayTao` (DateTime) - Creation date
- `IdNguoiCapNhap` (Guid?) - Last modifier user ID  
- `NgayCapNhat` (DateTime) - Last modification date
- `IsDeleted` (bool) - Soft delete flag

#### Entity Example
```csharp
using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class YourEntity : AuditableEntity
    {
        // Required properties
        public required string PropertyName { get; set; }
        
        // Optional properties
        public string? OptionalProperty { get; set; }
        
        // Foreign key relationships
        public required Guid IdRelatedEntity { get; set; }
        public RelatedEntity? RelatedEntity { get; set; }
        
        // Optional foreign keys
        public Guid? IdOptionalRelation { get; set; }
        public OptionalRelation? OptionalRelation { get; set; }
    }
}
```

### 2. Entity Configuration (EMS.EFCore)
**Location**: `EMS.EFCore/Configurations/`

#### Configuration Class Template
```csharp
using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class YourEntityConfiguration : IEntityTypeConfiguration<YourEntity>
    {
        public void Configure(EntityTypeBuilder<YourEntity> builder)
        {
            // Primary key (inherited from AuditableEntity)
            builder.HasKey(x => x.Id);

            // Required relationships
            builder.HasOne(x => x.RelatedEntity)
                .WithMany()
                .HasForeignKey(x => x.IdRelatedEntity)
                .IsRequired();

            // Optional relationships
            builder.HasOne(x => x.OptionalRelation)
                .WithMany()
                .HasForeignKey(x => x.IdOptionalRelation)
                .IsRequired(false);

            // Property configurations
            builder.Property(x => x.PropertyName)
                .IsRequired()
                .HasMaxLength(100);

            // Unique constraints if needed
            builder.HasIndex(x => x.PropertyName)
                .IsUnique();

            builder.Property(x => x.OptionalProperty)
                .HasMaxLength(200);
        }
    }
}
```

#### Update DbContext
Add to `EMS.EFCore/AppDbContext.cs`:
```csharp
// Add DbSet property
public DbSet<YourEntity> YourEntities { get; set; } = null!;

// Add configuration in OnModelCreating method
modelBuilder.ApplyConfiguration(new YourEntityConfiguration());
```

### 3. Repository Interface (EMS.Domain)
**Location**: `EMS.Domain/Interfaces/Repositories/`

#### Repository Interface Template
```csharp
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.Repositories.Base;

namespace EMS.Domain.Interfaces.Repositories
{
    public interface IYourEntityRepository : IAuditRepository<YourEntity>
    {
        // Add custom methods if needed
        // Task<List<YourEntity>> GetBySpecificCriteriaAsync(string criteria);
    }
}
```

### 4. Repository Implementation (EMS.Infrastructure)
**Location**: `EMS.Infrastructure/Repositories/`

#### Repository Implementation Template
```csharp
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.Repositories;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;

namespace EMS.Infrastructure.Repositories
{
    public class YourEntityRepository(DbFactory dbFactory) : AuditRepository<YourEntity>(dbFactory), IYourEntityRepository
    {
        // Implement custom methods if defined in interface
        // public async Task<List<YourEntity>> GetBySpecificCriteriaAsync(string criteria)
        // {
        //     return await DbSet.Where(x => x.PropertyName.Contains(criteria)).ToListAsync();
        // }
    }
}
```

### 5. Service Interface (EMS.Application)
**Location**: `EMS.Application/Services/YourEntityServices/`

#### Service Interface Template
```csharp
using EMS.Application.Services.Base;
using EMS.Domain.Entities;

namespace EMS.Application.Services.YourEntityServices
{
    public interface IYourEntityService : IBaseService<YourEntity>
    {
        // Add custom service methods if needed
        // Task<ImportResultResponse<YourEntityImportDto>> ImportAsync(byte[] fileBytes);
    }
}
```

### 6. Service Implementation (EMS.Application)
**Location**: `EMS.Application/Services/YourEntityServices/`

#### Service Implementation Template
```csharp
using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.YourEntityServices
{
    public class YourEntityService : BaseService<YourEntity>, IYourEntityService
    {
        public YourEntityService(IUnitOfWork unitOfWork, IYourEntityRepository repository) 
            : base(unitOfWork, repository)
        {
        }

        protected override Task UpdateEntityProperties(YourEntity existingEntity, YourEntity newEntity)
        {
            // Map all properties from newEntity to existingEntity
            existingEntity.PropertyName = newEntity.PropertyName;
            existingEntity.OptionalProperty = newEntity.OptionalProperty;
            existingEntity.IdRelatedEntity = newEntity.IdRelatedEntity;
            existingEntity.IdOptionalRelation = newEntity.IdOptionalRelation;
            
            return Task.CompletedTask;
        }
        
        // Implement custom methods if needed
        // public async Task<ImportResultResponse<YourEntityImportDto>> ImportAsync(byte[] fileBytes)
        // {
        //     // Implementation for Excel import functionality
        // }
    }
}
```

### 7. Controller Implementation (EMS.API)
**Location**: `EMS.API/Controllers/`

#### Controller Template
```csharp
using EMS.API.Controllers.Base;
using EMS.Application.Services.YourEntityServices;
using EMS.Domain.Entities;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers;

public class YourEntityController : BaseController<YourEntity>
{
    private readonly IYourEntityService _yourEntityService;

    public YourEntityController(IYourEntityService yourEntityService) : base(yourEntityService)
    {
        _yourEntityService = yourEntityService;
    }

    // Override GetAll to include related entities
    public override async Task<IActionResult> GetAll()
    {
        var result = await Service.GetAllAsync(q => q
            .Include(x => x.RelatedEntity)
            .Include(x => x.OptionalRelation)
        );
        return result.ToResult();
    }

    // Override GetPaginated with custom filtering
    [HttpGet("pagination")]
    public virtual async Task<IActionResult> GetPaginated(
        [FromQuery] PaginationRequest request,
        [FromQuery] YourEntityFilter filter)
    {
        var result = await Service.GetPaginatedAsync(
            request,
            include: q => q.Include(x => x.RelatedEntity)
                .Include(x => x.OptionalRelation),
            filter: q =>
                (filter.IdRelatedEntity == null || q.IdRelatedEntity == filter.IdRelatedEntity)
                && (string.IsNullOrEmpty(filter.PropertyName) || 
                    q.PropertyName.ToLower().Contains(filter.PropertyName.ToLower()))
        );
        return result.ToResult();
    }
}

// Filter class for pagination
public class YourEntityFilter
{
    public Guid? IdRelatedEntity { get; set; }
    public string? PropertyName { get; set; }
    // Add other filter properties as needed
}
```

## Code Generation Instructions

### Step 1: Create the Entity
1. Create entity class in `EMS.Domain/Entities/YourEntity.cs`
2. Inherit from `AuditableEntity`
3. Define required and optional properties
4. Add navigation properties for relationships

### Step 2: Create Entity Configuration
1. Create configuration class in `EMS.EFCore/Configurations/YourEntityConfiguration.cs`
2. Implement `IEntityTypeConfiguration<YourEntity>`
3. Configure relationships, constraints, and property mappings
4. Add DbSet property to `AppDbContext`
5. Register configuration in `OnModelCreating` method

### Step 3: Create Repository
1. Create interface in `EMS.Domain/Interfaces/Repositories/IYourEntityRepository.cs`
2. Inherit from `IAuditRepository<YourEntity>`
3. Create implementation in `EMS.Infrastructure/Repositories/YourEntityRepository.cs`
4. Inherit from `AuditRepository<YourEntity>`

### Step 4: Create Service
1. Create interface in `EMS.Application/Services/YourEntityServices/IYourEntityService.cs`
2. Inherit from `IBaseService<YourEntity>`
3. Create implementation in `EMS.Application/Services/YourEntityServices/YourEntityService.cs`
4. Inherit from `BaseService<YourEntity>`
5. Implement `UpdateEntityProperties` method

### Step 5: Create Controller
1. Create controller in `EMS.API/Controllers/YourEntityController.cs`
2. Inherit from `BaseController<YourEntity>`
3. Override methods as needed (GetAll, GetPaginated)
4. Create method Httpget "pagination" with custom filtering.
4. Add filter classes for pagination

### Step 6: Register Dependencies
Dependencies are automatically registered using Scrutor assembly scanning:
- Repository interfaces/implementations ending with "Repository"
- Service interfaces/implementations ending with "Service"

### Step 7: Add DTOs (Optional)
If import functionality is needed:
1. Create DTO in `EMS.Application/Services/YourEntityServices/Dtos/`
2. Create validator using FluentValidation
3. Implement import method in service

## Naming Conventions

### Files and Classes
- **Entity**: `YourEntity.cs`
- **Configuration**: `YourEntityConfiguration.cs`
- **Repository Interface**: `IYourEntityRepository.cs`
- **Repository Implementation**: `YourEntityRepository.cs`
- **Service Interface**: `IYourEntityService.cs`
- **Service Implementation**: `YourEntityService.cs`
- **Controller**: `YourEntityController.cs`
- **DTOs**: `YourEntityImportDto.cs`, `YourEntityFilter.cs`

### Folders
- **Entities**: `EMS.Domain/Entities/`
- **Configurations**: `EMS.EFCore/Configurations/`
- **Repository Interfaces**: `EMS.Domain/Interfaces/Repositories/`
- **Repository Implementations**: `EMS.Infrastructure/Repositories/`
- **Services**: `EMS.Application/Services/YourEntityServices/`
- **Controllers**: `EMS.API/Controllers/`
- **DTOs**: `EMS.Application/Services/YourEntityServices/Dtos/`

## Available Base Features

### From BaseController<T>
- `GET /api/yourentity` - Get all records
- `GET /api/yourentity/{id}` - Get by ID
- `POST /api/yourentity` - Create single record
- `POST /api/yourentity/multiple` - Create multiple records
- `PUT /api/yourentity/{id}` - Update record
- `DELETE /api/yourentity/{id}` - Soft delete record
- `GET /api/yourentity/paginated` - Get paginated records
- `POST /api/yourentity/copy` - Copy records by IDs
- `POST /api/yourentity/delete-multiple` - Delete multiple records
- `POST /api/yourentity/import` - Import from Excel (needs override)

### From BaseService<T>
- CRUD operations with error handling
- Pagination support
- Bulk operations (create, delete, copy)
- Excel import functionality
- Soft delete support
- Unit of Work pattern

### From Repository Base Classes
- Generic CRUD operations
- Soft delete filtering
- Pagination support
- Query including related entities
- Expression-based filtering

## Error Handling
The system uses:
- **Result<T>** pattern for service layer returns
- **Custom exceptions** (NotFoundException, ConflictException, etc.)
- **Global exception handler** middleware
- **FluentValidation** for input validation

## Authentication & Authorization
- **JWT Bearer token** authentication
- **Claims-based** authorization
- **HttpContextAccessor** for current user context
- **Audit trail** automatic tracking

## Important Notes

1. **Always inherit from AuditableEntity** for automatic audit trail
2. **Use Guid for all primary keys** (automatically generated)
3. **Implement soft delete** via IsDeleted property
4. **Follow naming conventions** strictly for auto-registration
5. **Use required keyword** for non-nullable reference types
6. **Configure relationships** properly in Entity Configuration
7. **Override UpdateEntityProperties** in service implementations
8. **Add Include statements** for related entities in controllers
9. **Create filter classes** for pagination endpoints
10. **Test migrations** in development environment first
11. **Entities** DO NOT add properties to newly created entities, sometimes it will be blank and to be confirmed.

This guideline provides a complete template for generating consistent, maintainable backend code following the established patterns in the EMS project.
