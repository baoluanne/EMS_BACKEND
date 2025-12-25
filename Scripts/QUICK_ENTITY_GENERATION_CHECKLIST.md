# Quick Entity Generation Checklist

## Prerequisites
- Entity class already exists in `EMS.Domain/Entities/` inheriting from `AuditableEntity`
- Entity follows proper naming conventions and property definitions

## Files to Create/Update (in order):

### 1. Entity Configuration
**File**: `EMS.EFCore/Configurations/{EntityName}Configuration.cs`
```csharp
public class {EntityName}Configuration : IEntityTypeConfiguration<{EntityName}>
{
    public void Configure(EntityTypeBuilder<{EntityName}> builder)
    {
        // Configure primary key, properties, relationships, constraints
    }
}
```

### 2. Update AppDbContext
**File**: `EMS.EFCore/AppDbContext.cs`
- Add DbSet property: `public DbSet<{EntityName}> {EntityName}s { get; set; } = null!;`
- Add configuration in OnModelCreating: `modelBuilder.ApplyConfiguration(new {EntityName}Configuration());`

### 3. Repository Interface
**File**: `EMS.Domain/Interfaces/Repositories/I{EntityName}Repository.cs`
```csharp
public interface I{EntityName}Repository : IAuditRepository<{EntityName}>
{
    // Add custom methods if needed
}
```

### 4. Repository Implementation
**File**: `EMS.Infrastructure/Repositories/{EntityName}Repository.cs`
```csharp
public class {EntityName}Repository(DbFactory dbFactory) : AuditRepository<{EntityName}>(dbFactory), I{EntityName}Repository
{
    // Implement custom methods if any
}
```

### 5. Service Interface
**File**: `EMS.Application/Services/{EntityName}Services/I{EntityName}Service.cs`
```csharp
public interface I{EntityName}Service : IBaseService<{EntityName}>
{
    // Add custom service methods if needed
}
```

### 6. Service Implementation
**File**: `EMS.Application/Services/{EntityName}Services/{EntityName}Service.cs`
```csharp
public class {EntityName}Service : BaseService<{EntityName}>, I{EntityName}Service
{
    public {EntityName}Service(IUnitOfWork unitOfWork, I{EntityName}Repository repository) 
        : base(unitOfWork, repository) { }

    protected override Task UpdateEntityProperties({EntityName} existingEntity, {EntityName} newEntity)
    {
        // Map all properties from newEntity to existingEntity
        return Task.CompletedTask;
    }
}
```

### 7. Controller
**File**: `EMS.API/Controllers/{EntityName}Controller.cs`
```csharp
public class {EntityName}Controller : BaseController<{EntityName}>
{
    private readonly I{EntityName}Service _{entityName}Service;

    public {EntityName}Controller(I{EntityName}Service {entityName}Service) : base({entityName}Service)
    {
        _{entityName}Service = {entityName}Service;
    }

    [HttpGet("pagination")]
    public virtual async Task<IActionResult> GetPagination(
        [FromQuery] PaginationRequest request,
        [FromQuery] {EntityName}Filter filter)
    {
        // Implement pagination with filtering
    }
}

public class {EntityName}Filter
{
    // Add filter properties
}
```

## Key Points to Remember:

### Naming Conventions:
- **Entity**: `{EntityName}` (e.g., `CaHoc`)
- **Configuration**: `{EntityName}Configuration` (e.g., `CaHocConfiguration`)
- **Repository Interface**: `I{EntityName}Repository` (e.g., `ICaHocRepository`)
- **Repository Implementation**: `{EntityName}Repository` (e.g., `CaHocRepository`)
- **Service Interface**: `I{EntityName}Service` (e.g., `ICaHocService`)
- **Service Implementation**: `{EntityName}Service` (e.g., `CaHocService`)
- **Controller**: `{EntityName}Controller` (e.g., `CaHocController`)
- **Filter**: `{EntityName}Filter` (e.g., `CaHocFilter`)

### Folder Structure:
- **Configurations**: `EMS.EFCore/Configurations/`
- **Repository Interfaces**: `EMS.Domain/Interfaces/Repositories/`
- **Repository Implementations**: `EMS.Infrastructure/Repositories/`
- **Services**: `EMS.Application/Services/{EntityName}Services/`
- **Controllers**: `EMS.API/Controllers/`

### Important Notes:
1. **Alphabetical Order**: Add DbSet and Configuration in alphabetical order in AppDbContext
2. **Primary Constructor**: Use primary constructor pattern in repositories: `(DbFactory dbFactory)`
3. **UpdateEntityProperties**: Must implement this method in service to map all entity properties
4. **Pagination Filter**: Create filter class with relevant searchable properties
5. **Auto-Registration**: Dependencies are automatically registered via Scrutor (no manual DI needed)
6. **Include Statements**: Add `.Include()` statements in controller if entity has navigation properties
7. **Unique Constraints**: Add unique indexes in configuration if needed
8. **Enum Conversion**: Use `.HasConversion<int>()` for enum properties in configuration

### Standard API Endpoints (inherited from BaseController):
- `GET /api/{entityname}` - Get all
- `GET /api/{entityname}/{id}` - Get by ID
- `GET /api/{entityname}/pagination` - Get paginated with filtering
- `POST /api/{entityname}` - Create single
- `POST /api/{entityname}/multiple` - Create multiple
- `PUT /api/{entityname}/{id}` - Update
- `DELETE /api/{entityname}/{id}` - Soft delete
- `POST /api/{entityname}/copy` - Copy records
- `POST /api/{entityname}/delete-multiple` - Delete multiple

### Next Steps After Generation:
1. Create and run database migration
2. Test API endpoints
3. Add custom business logic if needed
4. Implement Excel import/export if required
5. Add validation rules using FluentValidation if needed