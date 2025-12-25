# EMS Backend API Development Guide

This guide provides step-by-step instructions for creating new APIs in the EMS (Education Management System) backend project. The project follows Clean Architecture principles with clear separation of concerns across multiple layers.

## Table of Contents

1. [Project Architecture Overview](#project-architecture-overview)
2. [Prerequisites](#prerequisites)
3. [Step-by-Step API Creation Process](#step-by-step-api-creation-process)
4. [Code Examples](#code-examples)
5. [Best Practices](#best-practices)
6. [Testing](#testing)
7. [Troubleshooting](#troubleshooting)

## Project Architecture Overview

The EMS backend follows Clean Architecture with the following layers:

```
EMS.API/           - Controllers and API endpoints
EMS.Application/   - Business logic and services
EMS.Domain/        - Entities, interfaces, and domain models
EMS.Infrastructure/ - Data access and external services
EMS.EFCore/        - Database context and configurations
```

### Key Patterns Used:
- **Repository Pattern** - Data access abstraction
- **Unit of Work Pattern** - Transaction management
- **Service Layer Pattern** - Business logic encapsulation
- **DTO Pattern** - Data transfer objects
- **Dependency Injection** - IoC container management

## Prerequisites

Before creating a new API, ensure you have:

1. **Development Environment Setup**
   - .NET 8.0 SDK
   - PostgreSQL database
   - Visual Studio 2022 or VS Code
   - Git

2. **Project Dependencies**
   - Entity Framework Core
   - AutoMapper (Mapperly)
   - LanguageExt (for Result pattern)
   - Scrutor (for dependency scanning)
   - Serilog (for logging)

## Step-by-Step API Creation Process

### Step 1: Create the Domain Entity

First, create your entity in the `EMS.Domain/Entities/` folder:

```csharp
// EMS.Domain/Entities/YourEntity.cs
using EMS.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace EMS.Domain.Entities;

public class YourEntity : AuditableEntity
{
    [Required]
    public string Name { get; set; } = string.Empty;
    
    public string? Description { get; set; }
    
    public bool IsActive { get; set; } = true;
    
    // Foreign key relationships
    public Guid? ParentId { get; set; }
    public YourEntity? Parent { get; set; }
}
```

**Key Points:**
- Always inherit from `AuditableEntity` for audit fields
- Use `[Required]` for mandatory fields
- Include navigation properties for relationships

### Step 2: Create the Repository Interface

Create the repository interface in `EMS.Domain/Interfaces/Repositories/`:

```csharp
// EMS.Domain/Interfaces/Repositories/IYourEntityRepository.cs
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.Repositories.Base;

namespace EMS.Domain.Interfaces.Repositories;

public interface IYourEntityRepository : IAuditRepository<YourEntity>
{
    // Add custom repository methods if needed
    Task<YourEntity?> GetByNameAsync(string name);
    Task<List<YourEntity>> GetActiveEntitiesAsync();
}
```

### Step 3: Create the Repository Implementation

Implement the repository in `EMS.Infrastructure/Repositories/`:

```csharp
// EMS.Infrastructure/Repositories/YourEntityRepository.cs
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.Repositories;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;

namespace EMS.Infrastructure.Repositories;

public class YourEntityRepository(DbFactory dbFactory) 
    : AuditRepository<YourEntity>(dbFactory), IYourEntityRepository
{
    public async Task<YourEntity?> GetByNameAsync(string name)
    {
        return await GetFirstNotDeletedAsync(x => x.Name == name);
    }

    public async Task<List<YourEntity>> GetActiveEntitiesAsync()
    {
        return await ListAsync(query => query.Where(x => x.IsActive));
    }
}
```

### Step 4: Create the Service Interface

Create the service interface in `EMS.Application/Services/YourEntityServices/`:

```csharp
// EMS.Application/Services/YourEntityServices/IYourEntityService.cs
using EMS.Application.Services.Base;
using EMS.Domain.Entities;

namespace EMS.Application.Services.YourEntityServices;

public interface IYourEntityService : IBaseService<YourEntity>
{
    // Add custom service methods if needed
    Task<Result<YourEntity>> CreateWithValidationAsync(YourEntity entity);
    Task<Result<List<YourEntity>>> GetActiveEntitiesAsync();
}
```

### Step 5: Create the Service Implementation

Implement the service in `EMS.Application/Services/YourEntityServices/`:

```csharp
// EMS.Application/Services/YourEntityServices/YourEntityService.cs
using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;
using LanguageExt.Common;

namespace EMS.Application.Services.YourEntityServices;

public class YourEntityService : BaseService<YourEntity>, IYourEntityService
{
    private readonly IYourEntityRepository _repository;

    public YourEntityService(IUnitOfWork unitOfWork, IYourEntityRepository repository) 
        : base(unitOfWork, repository)
    {
        _repository = repository;
    }

    public async Task<Result<YourEntity>> CreateWithValidationAsync(YourEntity entity)
    {
        // Add custom business logic here
        var existing = await _repository.GetByNameAsync(entity.Name);
        if (existing != null)
        {
            return new Result<YourEntity>(new ConflictException("Entity with this name already exists"));
        }

        return await CreateAsync(entity);
    }

    public async Task<Result<List<YourEntity>>> GetActiveEntitiesAsync()
    {
        try
        {
            var entities = await _repository.GetActiveEntitiesAsync();
            return new Result<List<YourEntity>>(entities);
        }
        catch (Exception ex)
        {
            return new Result<List<YourEntity>>(ex);
        }
    }

    protected override Task UpdateEntityProperties(YourEntity existingEntity, YourEntity newEntity)
    {
        existingEntity.Name = newEntity.Name;
        existingEntity.Description = newEntity.Description;
        existingEntity.IsActive = newEntity.IsActive;
        existingEntity.ParentId = newEntity.ParentId;

        return Task.CompletedTask;
    }
}
```

### Step 6: Create DTOs (Optional but Recommended)

Create DTOs for complex operations in `EMS.Application/Services/YourEntityServices/Dtos/`:

```csharp
// EMS.Application/Services/YourEntityServices/Dtos/CreateYourEntityRequestDto.cs
using System.ComponentModel.DataAnnotations;

namespace EMS.Application.Services.YourEntityServices.Dtos;

public class CreateYourEntityRequestDto
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;
    
    [StringLength(500)]
    public string? Description { get; set; }
    
    public bool IsActive { get; set; } = true;
    
    public Guid? ParentId { get; set; }
}
```

```csharp
// EMS.Application/Services/YourEntityServices/Dtos/YourEntityDto.cs
namespace EMS.Application.Services.YourEntityServices.Dtos;

public class YourEntityDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    public Guid? ParentId { get; set; }
    public DateTime NgayTao { get; set; }
    public DateTime NgayCapNhat { get; set; }
}
```

### Step 7: Create Mappers (Optional)

Create mappers using Mapperly in `EMS.Application/Services/YourEntityServices/Mappers/`:

```csharp
// EMS.Application/Services/YourEntityServices/Mappers/YourEntityMapper.cs
using EMS.Application.Services.YourEntityServices.Dtos;
using EMS.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace EMS.Application.Services.YourEntityServices.Mappers;

[Mapper]
public partial class YourEntityMapper
{
    public static partial YourEntityDto ToYourEntityDto(YourEntity entity);
    public static partial List<YourEntityDto> ToYourEntityDtoList(List<YourEntity> entities);
}
```

### Step 8: Create the Controller

Create the controller in `EMS.API/Controllers/`:

**Option A: Simple Controller (inherits from BaseController)**
```csharp
// EMS.API/Controllers/YourEntityController.cs
using EMS.Application.Services.YourEntityServices;
using EMS.Domain.Entities;
using EMS.API.Controllers.Base;

namespace EMS.API.Controllers;

public class YourEntityController : BaseController<YourEntity>
{
    public YourEntityController(IYourEntityService yourEntityService) : base(yourEntityService)
    {
    }
}
```

**Option B: Custom Controller (for complex operations)**
```csharp
// EMS.API/Controllers/YourEntityController.cs
using EMS.Application.Services.YourEntityServices;
using EMS.Application.Services.YourEntityServices.Dtos;
using EMS.Domain.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class YourEntityController(IYourEntityService yourEntityService) : ControllerBase
{
    private readonly IYourEntityService _yourEntityService = yourEntityService;

    [HttpPost("custom")]
    [Authorize]
    public async Task<IActionResult> CreateCustomAsync([FromBody] CreateYourEntityRequestDto request)
    {
        var entity = new YourEntity
        {
            Name = request.Name,
            Description = request.Description,
            IsActive = request.IsActive,
            ParentId = request.ParentId
        };

        var result = await _yourEntityService.CreateWithValidationAsync(entity);
        return result.ToResult();
    }

    [HttpGet("active")]
    public async Task<IActionResult> GetActiveEntitiesAsync()
    {
        var result = await _yourEntityService.GetActiveEntitiesAsync();
        return result.ToResult();
    }
}
```

### Step 9: Create Database Configuration

Create the Entity Framework configuration in `EMS.EFCore/Configurations/`:

```csharp
// EMS.EFCore/Configurations/YourEntityConfiguration.cs
using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations;

public class YourEntityConfiguration : IEntityTypeConfiguration<YourEntity>
{
    public void Configure(EntityTypeBuilder<YourEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Description)
            .HasMaxLength(500);

        builder.Property(x => x.IsActive)
            .HasDefaultValue(true);

        // Configure relationships
        builder.HasOne(x => x.Parent)
            .WithMany()
            .HasForeignKey(x => x.ParentId)
            .OnDelete(DeleteBehavior.Restrict);

        // Configure indexes
        builder.HasIndex(x => x.Name).IsUnique();
        builder.HasIndex(x => x.IsActive);
    }
}
```

### Step 10: Register Dependencies

The project uses automatic dependency scanning with Scrutor, so most services and repositories are automatically registered. However, if you need manual registration, add them to the respective `DependencyInjection.cs` files:

**For Services (EMS.Application/DependencyInjection.cs):**
```csharp
// Add to ManualRegister method if needed
services.AddScoped<IYourEntityService, YourEntityService>();
```

**For Repositories (EMS.Infrastructure/DependencyInjection.cs):**
```csharp
// Add to ManualRegister method if needed
services.AddScoped<IYourEntityRepository, YourEntityRepository>();
```

### Step 11: Create Database Migration

Run the following commands to create and apply the database migration:

```bash
# Navigate to the project root
cd EMS-backend

# Create migration
dotnet ef migrations add AddYourEntity --project EMS.EFCore --startup-project EMS.API

# Update database
dotnet ef database update --project EMS.EFCore --startup-project EMS.API
```

## Code Examples

### Complete Example: Student Management API

Here's a complete example of creating a Student management API:

#### 1. Entity
```csharp
// EMS.Domain/Entities/Student.cs
using EMS.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace EMS.Domain.Entities;

public class Student : AuditableEntity
{
    [Required]
    public string StudentCode { get; set; } = string.Empty;
    
    [Required]
    public string FirstName { get; set; } = string.Empty;
    
    [Required]
    public string LastName { get; set; } = string.Empty;
    
    public string? Email { get; set; }
    
    public DateTime? DateOfBirth { get; set; }
    
    public Guid ClassId { get; set; }
    public Class? Class { get; set; }
}
```

#### 2. Repository Interface
```csharp
// EMS.Domain/Interfaces/Repositories/IStudentRepository.cs
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.Repositories.Base;

namespace EMS.Domain.Interfaces.Repositories;

public interface IStudentRepository : IAuditRepository<Student>
{
    Task<Student?> GetByStudentCodeAsync(string studentCode);
    Task<List<Student>> GetByClassIdAsync(Guid classId);
}
```

#### 3. Repository Implementation
```csharp
// EMS.Infrastructure/Repositories/StudentRepository.cs
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.Repositories;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;

namespace EMS.Infrastructure.Repositories;

public class StudentRepository(DbFactory dbFactory) 
    : AuditRepository<Student>(dbFactory), IStudentRepository
{
    public async Task<Student?> GetByStudentCodeAsync(string studentCode)
    {
        return await GetFirstNotDeletedAsync(x => x.StudentCode == studentCode);
    }

    public async Task<List<Student>> GetByClassIdAsync(Guid classId)
    {
        return await ListAsync(query => query.Where(x => x.ClassId == classId));
    }
}
```

#### 4. Service Interface
```csharp
// EMS.Application/Services/StudentServices/IStudentService.cs
using EMS.Application.Services.Base;
using EMS.Domain.Entities;

namespace EMS.Application.Services.StudentServices;

public interface IStudentService : IBaseService<Student>
{
    Task<Result<Student>> CreateStudentAsync(CreateStudentRequestDto request);
    Task<Result<List<Student>>> GetStudentsByClassAsync(Guid classId);
}
```

#### 5. Service Implementation
```csharp
// EMS.Application/Services/StudentServices/StudentService.cs
using EMS.Application.Services.Base;
using EMS.Application.Services.StudentServices.Dtos;
using EMS.Domain.Entities;
using EMS.Domain.Exceptions;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;
using LanguageExt.Common;

namespace EMS.Application.Services.StudentServices;

public class StudentService : BaseService<Student>, IStudentService
{
    private readonly IStudentRepository _studentRepository;

    public StudentService(IUnitOfWork unitOfWork, IStudentRepository studentRepository) 
        : base(unitOfWork, studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<Result<Student>> CreateStudentAsync(CreateStudentRequestDto request)
    {
        var existingStudent = await _studentRepository.GetByStudentCodeAsync(request.StudentCode);
        if (existingStudent != null)
        {
            return new Result<Student>(new ConflictException("Student with this code already exists"));
        }

        var student = new Student
        {
            StudentCode = request.StudentCode,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            DateOfBirth = request.DateOfBirth,
            ClassId = request.ClassId
        };

        return await CreateAsync(student);
    }

    public async Task<Result<List<Student>>> GetStudentsByClassAsync(Guid classId)
    {
        try
        {
            var students = await _studentRepository.GetByClassIdAsync(classId);
            return new Result<List<Student>>(students);
        }
        catch (Exception ex)
        {
            return new Result<List<Student>>(ex);
        }
    }

    protected override Task UpdateEntityProperties(Student existingEntity, Student newEntity)
    {
        existingEntity.StudentCode = newEntity.StudentCode;
        existingEntity.FirstName = newEntity.FirstName;
        existingEntity.LastName = newEntity.LastName;
        existingEntity.Email = newEntity.Email;
        existingEntity.DateOfBirth = newEntity.DateOfBirth;
        existingEntity.ClassId = newEntity.ClassId;

        return Task.CompletedTask;
    }
}
```

#### 6. DTOs
```csharp
// EMS.Application/Services/StudentServices/Dtos/CreateStudentRequestDto.cs
using System.ComponentModel.DataAnnotations;

namespace EMS.Application.Services.StudentServices.Dtos;

public class CreateStudentRequestDto
{
    [Required]
    [StringLength(20)]
    public string StudentCode { get; set; } = string.Empty;
    
    [Required]
    [StringLength(50)]
    public string FirstName { get; set; } = string.Empty;
    
    [Required]
    [StringLength(50)]
    public string LastName { get; set; } = string.Empty;
    
    [EmailAddress]
    public string? Email { get; set; }
    
    public DateTime? DateOfBirth { get; set; }
    
    [Required]
    public Guid ClassId { get; set; }
}
```

#### 7. Controller
```csharp
// EMS.API/Controllers/StudentController.cs
using EMS.Application.Services.StudentServices;
using EMS.Application.Services.StudentServices.Dtos;
using EMS.Domain.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController(IStudentService studentService) : ControllerBase
{
    private readonly IStudentService _studentService = studentService;

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateStudentAsync([FromBody] CreateStudentRequestDto request)
    {
        var result = await _studentService.CreateStudentAsync(request);
        return result.ToResult();
    }

    [HttpGet("class/{classId:guid}")]
    public async Task<IActionResult> GetStudentsByClassAsync(Guid classId)
    {
        var result = await _studentService.GetStudentsByClassAsync(classId);
        return result.ToResult();
    }
}
```

#### 8. Database Configuration
```csharp
// EMS.EFCore/Configurations/StudentConfiguration.cs
using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.StudentCode)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(x => x.FirstName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.LastName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Email)
            .HasMaxLength(100);

        builder.HasOne(x => x.Class)
            .WithMany()
            .HasForeignKey(x => x.ClassId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => x.StudentCode).IsUnique();
        builder.HasIndex(x => x.Email);
        builder.HasIndex(x => x.ClassId);
    }
}
```

## Best Practices

### 1. Naming Conventions
- **Entities**: PascalCase, singular (e.g., `Student`, `Course`)
- **Controllers**: PascalCase + "Controller" suffix (e.g., `StudentController`)
- **Services**: PascalCase + "Service" suffix (e.g., `StudentService`)
- **Repositories**: PascalCase + "Repository" suffix (e.g., `StudentRepository`)
- **DTOs**: PascalCase + descriptive suffix (e.g., `CreateStudentRequestDto`)

### 2. Error Handling
- Use the `Result<T>` pattern for consistent error handling
- Throw appropriate domain exceptions (`NotFoundException`, `ConflictException`, etc.)
- Always handle exceptions in service methods

### 3. Validation
- Use data annotations for input validation
- Implement business rule validation in services
- Validate foreign key relationships

### 4. Security
- Use `[Authorize]` attribute for protected endpoints
- Validate user permissions in service methods
- Sanitize input data

### 5. Performance
- Use async/await patterns consistently
- Implement proper indexing in database configurations
- Use pagination for large datasets
- Consider caching for frequently accessed data

### 6. Database Design
- Always inherit from `AuditableEntity` for audit fields
- Use appropriate data types and constraints
- Implement proper foreign key relationships
- Add indexes for frequently queried columns

## Testing

### Unit Testing
Create unit tests for your services:

```csharp
// Tests/EMS.Application.Tests/Services/StudentServiceTests.cs
using EMS.Application.Services.StudentServices;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;
using Moq;
using Xunit;

namespace EMS.Application.Tests.Services;

public class StudentServiceTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly Mock<IStudentRepository> _studentRepositoryMock;
    private readonly StudentService _studentService;

    public StudentServiceTests()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _studentRepositoryMock = new Mock<IStudentRepository>();
        _studentService = new StudentService(_unitOfWorkMock.Object, _studentRepositoryMock.Object);
    }

    [Fact]
    public async Task CreateStudentAsync_WithValidData_ShouldReturnSuccess()
    {
        // Arrange
        var request = new CreateStudentRequestDto
        {
            StudentCode = "STU001",
            FirstName = "John",
            LastName = "Doe",
            ClassId = Guid.NewGuid()
        };

        _studentRepositoryMock.Setup(x => x.GetByStudentCodeAsync(request.StudentCode))
            .ReturnsAsync((Student?)null);

        // Act
        var result = await _studentService.CreateStudentAsync(request);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(request.StudentCode, result.Value.StudentCode);
    }
}
```

### Integration Testing
Create integration tests for your controllers:

```csharp
// Tests/EMS.API.Tests/Controllers/StudentControllerTests.cs
using EMS.API.Controllers;
using EMS.Application.Services.StudentServices;
using EMS.Application.Services.StudentServices.Dtos;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace EMS.API.Tests.Controllers;

public class StudentControllerTests
{
    private readonly Mock<IStudentService> _studentServiceMock;
    private readonly StudentController _controller;

    public StudentControllerTests()
    {
        _studentServiceMock = new Mock<IStudentService>();
        _controller = new StudentController(_studentServiceMock.Object);
    }

    [Fact]
    public async Task CreateStudent_WithValidData_ShouldReturnOk()
    {
        // Arrange
        var request = new CreateStudentRequestDto
        {
            StudentCode = "STU001",
            FirstName = "John",
            LastName = "Doe",
            ClassId = Guid.NewGuid()
        };

        var student = new Student { StudentCode = request.StudentCode };
        _studentServiceMock.Setup(x => x.CreateStudentAsync(request))
            .ReturnsAsync(new Result<Student>(student));

        // Act
        var result = await _controller.CreateStudentAsync(request);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }
}
```

## Troubleshooting

### Common Issues and Solutions

#### 1. Dependency Injection Errors
**Problem**: Service not registered in DI container
**Solution**: Ensure your service implements the correct interface and follows naming conventions for automatic registration

#### 2. Database Migration Issues
**Problem**: Migration fails or doesn't apply
**Solution**: 
- Check connection string in `appsettings.json`
- Ensure all entity configurations are properly set up
- Verify foreign key relationships

#### 3. Repository Not Found
**Problem**: Repository interface not found
**Solution**: Ensure repository interface is in the correct namespace and implements `IAuditRepository<T>`

#### 4. Validation Errors
**Problem**: DTO validation not working
**Solution**: 
- Check data annotations are properly applied
- Ensure `[ApiController]` attribute is present on controller
- Verify model binding attributes (`[FromBody]`, `[FromQuery]`, etc.)

#### 5. Authentication Issues
**Problem**: `[Authorize]` attribute not working
**Solution**: 
- Ensure JWT configuration is correct in `Program.cs`
- Check token is properly formatted and not expired
- Verify authentication middleware is registered before authorization

### Debugging Tips

1. **Enable Detailed Logging**
   ```csharp
   // In appsettings.Development.json
   {
     "Serilog": {
       "MinimumLevel": {
         "Default": "Debug",
         "Override": {
           "Microsoft": "Information",
           "System": "Warning"
         }
       }
     }
   }
   ```

2. **Use Swagger for API Testing**
   - Navigate to `/swagger` in development mode
   - Test endpoints directly from the browser
   - Verify request/response models

3. **Database Query Logging**
   ```csharp
   // In AppDbContext.cs
   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
       if (Environment.IsDevelopment())
       {
           optionsBuilder.LogTo(Console.WriteLine);
       }
   }
   ```

## Conclusion

This guide provides a comprehensive approach to creating new APIs in the EMS backend project. By following these patterns and best practices, you can ensure consistency, maintainability, and scalability of your codebase.

Remember to:
- Always follow the established patterns
- Write comprehensive tests
- Document your APIs properly
- Consider performance implications
- Implement proper error handling
- Follow security best practices

For additional help or questions, refer to the existing codebase examples or consult with the development team.
