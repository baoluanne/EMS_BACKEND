using EMS.API.Common;
using EMS.API.Middlewares;
using EMS.Application;
using EMS.Application.Services.MonHocServices.Validation;
using EMS.Domain.Common;
using EMS.Domain.Models;
using EMS.EFCore;
using EMS.Infrastructure;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Minio;
using Serilog;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

var builder = WebApplication.CreateBuilder(args);

var minioSettingsSection = builder.Configuration.GetSection("MinIO");
builder.Services.Configure<MinioSettings>(minioSettingsSection);

builder.Services.AddSingleton<IMinioClient>(sp =>
{
    var minioSettings = minioSettingsSection.Get<MinioSettings>()
        ?? throw new InvalidOperationException("MinIO settings are not configured.");

    return new MinioClient()
        .WithEndpoint(minioSettings.ServiceURL)
        .WithCredentials(minioSettings.AccessKey, minioSettings.SecretKey)
        .WithSSL(minioSettings.UseSsl)
        .Build();
});

// Add services to the container
builder.Services.AddDatabase();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplicationServices();

// Exception handlers
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

// Authentication & Authorization
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer((opts) => JwtHelpers.ConfigureJwtBearer(opts, Env.GetJwtKey()));
builder.Services.AddAuthorization();

// CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            var origins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>() ?? [];
            policy.WithOrigins(origins)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
        });
});

// Config json
builder.Services
    .AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });

// Add FluentValidation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<MonHocImportDtoValidator>();
ValidatorOptions.Global.DefaultClassLevelCascadeMode = CascadeMode.Stop;
ValidatorOptions.Global.DefaultRuleLevelCascadeMode = CascadeMode.Stop;

// API document
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApiDoc();

// Current user
builder.Services.AddHttpContextAccessor();

// Logger
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

await builder.Services.RunMigrationAsync();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.UseExceptionHandler();

app.MapControllers();

app.Run();
