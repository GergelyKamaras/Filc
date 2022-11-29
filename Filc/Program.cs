using EFDataAccessLibrary.DataAccess;
using Filc.Services.DataBaseQueryServices;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.FullAccess;
using EFDataAccessLibrary.Models;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.ParentRole;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.StudentRole;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.TeacherRole;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.SchoolAdminRole;

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

builder.Services.AddTransient<IUserServiceFullAccess, UserTableQueryService>();

// Register entity based query service interface implementations
builder.Services.AddTransient<IGovernmentAdminServiceFullAccess, GovernmentAdminTableQueryService>();
builder.Services.AddTransient<IParentServiceFullAccess, ParentTableQueryService>();
builder.Services.AddTransient<IStudentServiceFullAccess, StudentTableQueryService>();
builder.Services.AddTransient<ITeacherServiceFullAccess, TeacherTableQueryService>();
builder.Services.AddTransient<ISchoolAdminServiceFullAccess, SchoolAdminTableQueryService>();
builder.Services.AddTransient<ISchoolServiceFullAccess, SchoolTableQueryService>();
builder.Services.AddTransient<ILessonServiceFullAccess, LessonTableQueryService>();
builder.Services.AddTransient<IMarkServiceFullAccess, MarkTableQueryService>();

// Register role based query service interface implementations
builder.Services.AddTransient<IMarkServiceForParentRole, MarkTableQueryService>();
builder.Services.AddTransient<ILessonServiceForParentRole, LessonTableQueryService>();
builder.Services.AddTransient<IParentServiceForParentRole, ParentTableQueryService>();
builder.Services.AddTransient<ISchoolServiceForParentRole, SchoolTableQueryService>();
builder.Services.AddTransient<IStudentServiceForParentRole, StudentTableQueryService>();

builder.Services.AddTransient<ISchoolAdminServiceFullAccess, SchoolAdminTableQueryService>();
builder.Services.AddTransient<ISchoolAdminServiceForSchoolAdminRole, SchoolAdminTableQueryService>();
builder.Services.AddTransient<ISchoolServiceForSchoolAdminRole, SchoolTableQueryService>();

builder.Services.AddTransient<ILessonServiceForStudentRole, LessonTableQueryService>();
builder.Services.AddTransient<IMarkServiceForStudentRole, MarkTableQueryService>();
builder.Services.AddTransient<ISchoolServiceForStudentRole, SchoolTableQueryService>();
builder.Services.AddTransient<IStudentServiceForStudentRole, StudentTableQueryService>();

builder.Services.AddTransient<ILessonServiceForTeacherRole, LessonTableQueryService>();
builder.Services.AddTransient<ISchoolServiceForTeacherRole, SchoolTableQueryService>();
builder.Services.AddTransient<IStudentServiceForTeacherRole, StudentTableQueryService>();
builder.Services.AddTransient<ITeacherServiceForTeacherRole, TeacherTableQueryService>();



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
