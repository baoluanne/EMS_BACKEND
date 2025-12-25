# Hướng Dẫn Phát Triển API Cho EMS Backend

Tài liệu này cung cấp hướng dẫn từng bước để tạo API mới trong dự án backend EMS (Education Management System). Dự án tuân theo nguyên tắc Clean Architecture với sự phân tách rõ ràng giữa các tầng.

## Mục Lục

1. [Tổng Quan Kiến Trúc Dự Án](#tong-quan-kien-truc-du-an)
2. [Yêu Cầu Chuẩn Bị](#yeu-cau-chuan-bi)
3. [Quy Trình Tạo API Từng Bước](#quy-trinh-tao-api-tung-buoc)
4. [Ví Dụ Mã Nguồn](#vi-du-ma-nguon)
5. [Thực Hành Tốt](#thuc-hanh-tot)
6. [Kiểm Thử](#kiem-thu)
7. [Khắc Phục Sự Cố](#khac-phuc-su-co)

## Tổng Quan Kiến Trúc Dự Án

Backend EMS áp dụng Clean Architecture với các tầng sau:

```
EMS.API/            - Controllers và các endpoint API
EMS.Application/    - Nghiệp vụ và services
EMS.Domain/         - Entities, interfaces, và domain models
EMS.Infrastructure/ - Truy cập dữ liệu và dịch vụ bên ngoài
EMS.EFCore/         - DbContext và cấu hình Entity Framework
```

### Mẫu Thiết Kế Sử Dụng
- **Repository Pattern** - Trừu tượng hoá truy cập dữ liệu
- **Unit of Work Pattern** - Quản lý giao dịch
- **Service Layer Pattern** - Đóng gói logic nghiệp vụ
- **DTO Pattern** - Đối tượng truyền dữ liệu
- **Dependency Injection** - Quản lý phụ thuộc qua IoC container

## Yêu Cầu Chuẩn Bị

Trước khi tạo API mới, hãy đảm bảo bạn đã có:

1. **Môi Trường Phát Triển**
   - .NET 8.0 SDK
   - Cơ sở dữ liệu PostgreSQL
   - Visual Studio 2022 hoặc VS Code
   - Git

2. **Phụ Thuộc Dự Án**
   - Entity Framework Core
   - AutoMapper (Mapperly)
   - LanguageExt (cho Result pattern)
   - Scrutor (scan và đăng ký DI)
   - Serilog (ghi log)

## Quy Trình Tạo API Từng Bước

### Bước 1: Tạo Domain Entity

Tạo entity trong thư mục `EMS.Domain/Entities/`:

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

**Lưu ý quan trọng:**
- Luôn kế thừa từ `AuditableEntity` để có các trường audit
- Dùng `[Required]` cho trường bắt buộc
- Thêm navigation properties cho các quan hệ

### Bước 2: Tạo Repository Interface

Tạo interface trong `EMS.Domain/Interfaces/Repositories/`:

```csharp
// EMS.Domain/Interfaces/Repositories/IYourEntityRepository.cs
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.Repositories.Base;

namespace EMS.Domain.Interfaces.Repositories;

public interface IYourEntityRepository : IAuditRepository<YourEntity>
{
    // Thêm phương thức tuỳ chỉnh nếu cần
    Task<YourEntity?> GetByNameAsync(string name);
    Task<List<YourEntity>> GetActiveEntitiesAsync();
}
```

### Bước 3: Triển Khai Repository

Triển khai trong `EMS.Infrastructure/Repositories/`:

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

### Bước 4: Tạo Service Interface

Tạo interface trong `EMS.Application/Services/YourEntityServices/`:

```csharp
// EMS.Application/Services/YourEntityServices/IYourEntityService.cs
using EMS.Application.Services.Base;
using EMS.Domain.Entities;

namespace EMS.Application.Services.YourEntityServices;

public interface IYourEntityService : IBaseService<YourEntity>
{
    // Thêm phương thức tuỳ chỉnh nếu cần
    Task<Result<YourEntity>> CreateWithValidationAsync(YourEntity entity);
    Task<Result<List<YourEntity>>> GetActiveEntitiesAsync();
}
```

### Bước 5: Triển Khai Service

Triển khai trong `EMS.Application/Services/YourEntityServices/`:

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
        // Logic nghiệp vụ tuỳ chỉnh
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

### Bước 6: Tạo DTO (Khuyến Nghị)

Tạo DTO cho các thao tác phức tạp trong `EMS.Application/Services/YourEntityServices/Dtos/`:

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

### Bước 7: Tạo Mapper (Tuỳ Chọn)

Tạo mapper với Mapperly trong `EMS.Application/Services/YourEntityServices/Mappers/`:

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

### Bước 8: Tạo Controller

Tạo controller trong `EMS.API/Controllers/`:

**Tuỳ chọn A: Controller đơn giản (kế thừa BaseController)**
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

**Tuỳ chọn B: Controller tuỳ chỉnh (cho thao tác phức tạp)**
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

### Bước 9: Cấu Hình Entity Framework

Tạo cấu hình trong `EMS.EFCore/Configurations/`:

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

        // Quan hệ
        builder.HasOne(x => x.Parent)
            .WithMany()
            .HasForeignKey(x => x.ParentId)
            .OnDelete(DeleteBehavior.Restrict);

        // Indexes
        builder.HasIndex(x => x.Name).IsUnique();
        builder.HasIndex(x => x.IsActive);
    }
}
```

### Bước 10: Đăng Ký DI

Dự án dùng Scrutor để scan và đăng ký tự động, hầu hết services/repositories sẽ được đăng ký. Nếu cần đăng ký thủ công, thêm vào các file `DependencyInjection.cs` tương ứng:

**Service (EMS.Application/DependencyInjection.cs):**
```csharp
// Thêm vào phương thức ManualRegister nếu cần
services.AddScoped<IYourEntityService, YourEntityService>();
```

**Repository (EMS.Infrastructure/DependencyInjection.cs):**
```csharp
// Thêm vào phương thức ManualRegister nếu cần
services.AddScoped<IYourEntityRepository, YourEntityRepository>();
```

### Bước 11: Tạo Migration CSDL

Chạy các lệnh sau để tạo và áp dụng migration:

```bash
# Di chuyển tới thư mục gốc dự án
cd EMS-backend

# Tạo migration
dotnet ef migrations add AddYourEntity --project EMS.EFCore --startup-project EMS.API

# Cập nhật CSDL
dotnet ef database update --project EMS.EFCore --startup-project EMS.API
```

## Ví Dụ Mã Nguồn

### Ví dụ đầy đủ: API Quản Lý Student

Ví dụ hoàn chỉnh tạo API quản lý Student:

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
    public string FirstName { get; set; } = string.empty;
    
    [Required]
    public string LastName { get; set; } = string.empty;
    
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

#### 8. Cấu Hình EF
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

## Thực Hành Tốt

### 1. Quy Ước Đặt Tên
- **Entities**: PascalCase, số ít (ví dụ: `Student`, `Course`)
- **Controllers**: PascalCase + hậu tố "Controller" (ví dụ: `StudentController`)
- **Services**: PascalCase + "Service" (ví dụ: `StudentService`)
- **Repositories**: PascalCase + "Repository" (ví dụ: `StudentRepository`)
- **DTOs**: PascalCase + hậu tố mô tả (ví dụ: `CreateStudentRequestDto`)

### 2. Xử Lý Lỗi
- Dùng `Result<T>` để thống nhất xử lý lỗi
- Ném đúng loại exception miền (`NotFoundException`, `ConflictException`, ...)
- Luôn bắt/bao lỗi trong service

### 3. Kiểm Tra Hợp Lệ
- Dùng data annotations cho validation đầu vào
- Kiểm tra quy tắc nghiệp vụ trong services
- Xác thực quan hệ khoá ngoại

### 4. Bảo Mật
- Dùng `[Authorize]` cho các endpoint bảo vệ
- Kiểm tra quyền người dùng trong services
- Làm sạch dữ liệu đầu vào

### 5. Hiệu Năng
- Dùng async/await nhất quán
- Thêm index phù hợp trong cấu hình CSDL
- Dùng phân trang cho dữ liệu lớn
- Cân nhắc cache cho dữ liệu truy cập thường xuyên

### 6. Thiết Kế CSDL
- Luôn kế thừa `AuditableEntity` cho audit
- Dùng kiểu dữ liệu và ràng buộc phù hợp
- Cấu hình quan hệ khoá ngoại đúng
- Thêm index cho các cột truy vấn nhiều

## Kiểm Thử

### Unit Test
Tạo unit test cho services:

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

### Integration Test
Tạo integration test cho controllers:

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

## Khắc Phục Sự Cố

### Lỗi Thường Gặp và Cách Xử Lý

#### 1. Lỗi Dependency Injection
**Vấn đề**: Service chưa được đăng ký trong DI
**Giải pháp**: Đảm bảo service triển khai đúng interface và tuân theo quy ước đặt tên để được scan tự động

#### 2. Lỗi Migration CSDL
**Vấn đề**: Migration lỗi hoặc không áp dụng được
**Giải pháp**:
- Kiểm tra chuỗi kết nối trong `appsettings.json`
- Đảm bảo cấu hình entity đầy đủ
- Xác thực quan hệ khoá ngoại

#### 3. Không Tìm Thấy Repository
**Vấn đề**: Thiếu interface repository
**Giải pháp**: Đảm bảo interface đúng namespace và kế thừa `IAuditRepository<T>`

#### 4. Lỗi Validation
**Vấn đề**: Validation không hoạt động
**Giải pháp**:
- Kiểm tra data annotations
- Đảm bảo controller có `[ApiController]`
- Xác thực binding (`[FromBody]`, `[FromQuery]`, ...)

#### 5. Lỗi Xác Thực (Auth)
**Vấn đề**: `[Authorize]` không hiệu lực
**Giải pháp**:
- Kiểm tra cấu hình JWT trong `Program.cs`
- Xác thực token hợp lệ và chưa hết hạn
- Bảo đảm middleware Authentication chạy trước Authorization

### Mẹo Debug

1. **Bật Log Chi Tiết**
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

2. **Dùng Swagger để thử API**
   - Truy cập `/swagger` ở môi trường Development
   - Thử endpoint trực tiếp trên trình duyệt
   - Kiểm tra request/response models

3. **Log Truy Vấn CSDL**
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

## Kết Luận

Tài liệu này mô tả đầy đủ quy trình tạo API mới trong dự án EMS backend. Hãy tuân theo các mẫu thiết kế và thực hành tốt để đảm bảo tính nhất quán, dễ bảo trì và khả năng mở rộng.

Ghi nhớ:
- Tuân thủ pattern đã có
- Viết test đầy đủ
- Tài liệu hoá API rõ ràng
- Cân nhắc hiệu năng
- Xử lý lỗi đúng đắn
- Tuân thủ thực hành bảo mật

Nếu cần thêm trợ giúp, hãy tham khảo các ví dụ có sẵn trong codebase hoặc trao đổi với nhóm phát triển.

