using EFDataAccessLibrary.DataAccess;
using Filc.Services.DataBaseQueryServices;
using Filc.Services.Interfaces.EntityBasedInterfaces;
using EFDataAccessLibrary.Models;
using Filc.Services.Interfaces.RoleBasedInterfaces.ParentRole;
using Filc.Services.Interfaces.RoleBasedInterfaces.StudentRole;
using Filc.Services.Interfaces.RoleBasedInterfaces.TeacherRole;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json");

// add react Single page app rootpath
builder.Services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = "ClientApp/build";
});

// Add services to the container.
builder.Services.AddControllersWithViews();
// Add Entity Dbcontext
builder.Services.AddDbContext<ESContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
// Add Role and User To Database
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
.AddEntityFrameworkStores<ESContext>()
    .AddDefaultTokenProviders();

builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddTransient<IUserService, UserService>();

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


var seedService = app.Services.CreateScope().ServiceProvider;
try
{
    await SeedRoles.InitRoleSeeds(seedService.GetRequiredService<RoleManager<IdentityRole>>());
}
catch (Exception ex)
{
    var logger = seedService.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred while seeding the database.");
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSpaStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseAuthentication();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action=Index}/{id?}");
});

app.MapFallbackToFile("index.html");

app.UseSpa(spa =>
{
    spa.Options.SourcePath = "ClientApp";

    if (app.Environment.IsDevelopment())
    {
        spa.UseReactDevelopmentServer(npmScript: "start");
    }
});

app.Run();
