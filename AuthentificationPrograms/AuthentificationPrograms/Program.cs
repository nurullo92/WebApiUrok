using AuthentificationPrograms;
using AuthentificationPrograms.Logger;
using AuthentificationPrograms.LoggerCons;
using AuthentificationPrograms.Middleware;
using AuthentificationPrograms.Repository;
using AuthentificationService;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<ILoggers, Loggers>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddControllers(option => {
option.Filters.Add<ExceptionHandler>();}
);


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/User/Login";
    });

builder.Services.AddAuthorization();


var app = builder.Build();

app.UseLogMiddleware();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}




app.MapControllers();

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();


app.UseAuthentication();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
