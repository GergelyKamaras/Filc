using EFDataAccessLibrary.DataAccess;
using Filc.Services.DataBaseQueryServices;
using Filc.Services.Interfaces.EntityBasedInterfaces;
using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ESContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ESContext>();

builder.Services.AddTransient<IGovernmentAdminService, GovernmentAdminService>();
builder.Services.AddTransient<IParentService, IParentService>();
builder.Services.AddTransient<IStudentService, IStudentService>();
builder.Services.AddTransient<ITeacherService, ITeacherService>();
builder.Services.AddTransient<ISchoolAdminService, ISchoolAdminService>();
builder.Services.AddTransient<ISchoolAdminService, ISchoolAdminService>();
builder.Services.AddTransient<ISchoolService, ISchoolService>();
builder.Services.AddTransient<ILessonService, ILessonService>();
builder.Services.AddTransient<IMarkService, IMarkService>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
