using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using TaskManagerPro.Business.Interface;
using TaskManagerPro.Business.Services;
using TaskManagerPro.Data.Ropos;
using TaskManagmentPro;
using TaskManagmentPro.Data;
using TaskManagmentPro.Data.Repositories;
using TaskManagmentPro.Data.Ropos;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddControllersWithViews();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "TaskManagmentPro",
        Version = "v1"
    });
});

// Repositories
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<ITaskItemRepository, TaskItemRepository>();

//Service
builder.Services.AddScoped<IEmployeeService, EmployeeServices>();
builder.Services.AddScoped<ITaskItemService, TaskItemService>();

builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(
            new JsonStringEnumConverter());
    });

// Database
string connection = builder.Configuration
    .GetConnectionString("Default")!;

builder.Services.AddDbContext<ContextTaskManager>(options =>
    options.UseSqlServer(connection));

// AutoMapper
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<MappingProfile>();
});
// Build
var app = builder.Build();

// HTTP pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint(
            "/swagger/v1/swagger.json",
            "TaskManagmentPro v1");
    });
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();