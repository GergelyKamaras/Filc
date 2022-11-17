using EFDataAccessLibrary.DataAccess;
using Filc.Services.DataBaseQueryServices;
using Filc.Services.Interfaces.EntityBasedInterfaces;
using EFDataAccessLibrary.Models;
using Filc.Services.Interfaces.RoleBasedInterfaces.ParentRole;
using Filc.Services.Interfaces.RoleBasedInterfaces.StudentRole;
using Filc.Services.Interfaces.RoleBasedInterfaces.TeacherRole;
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

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ESContext>()
    .AddDefaultTokenProviders();



builder.Services.AddTransient<UserService, UserService>();

// Register entity based query service interface implementations
builder.Services.AddTransient<IGovernmentAdminService, GovernmentAdminService>();
builder.Services.AddTransient<IParentService, ParentService>();
builder.Services.AddTransient<IStudentService, StudentService>();
builder.Services.AddTransient<ITeacherService, TeacherService>();
builder.Services.AddTransient<ISchoolAdminService, SchoolAdminService>();
builder.Services.AddTransient<ISchoolService, SchoolService>();
builder.Services.AddTransient<ILessonService, LessonService>();
builder.Services.AddTransient<IMarkService, MarkService>();

// Register role based query service interface implementations
builder.Services.AddTransient<IParentRoleMarkService, MarkService>();
builder.Services.AddTransient<IParentRoleLessonService, LessonService>();
builder.Services.AddTransient<IParentRoleParentService, ParentService>();
builder.Services.AddTransient<IParentRoleSchoolService, SchoolService>();
builder.Services.AddTransient<IParentRoleStudentService, StudentService>();

builder.Services.AddTransient<ISchoolAdminService, SchoolAdminService>();

builder.Services.AddTransient<IStudentRoleLessonService, LessonService>();
builder.Services.AddTransient<IStudentRoleMarkService, MarkService>();
builder.Services.AddTransient<IStudentRoleSchoolService, SchoolService>();
builder.Services.AddTransient<IStudentRoleStudentService, StudentService>();

builder.Services.AddTransient<ITeacherRoleLessonService, LessonService>();
builder.Services.AddTransient<ITeacherRoleSchoolService, SchoolService>();
builder.Services.AddTransient<ITeacherRoleStudentService, StudentService>();
builder.Services.AddTransient<ITeacherRoleTeacherService, TeacherService>();



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
