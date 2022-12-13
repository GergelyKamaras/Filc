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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Configuration;
using Filc.Services;
using Filc.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json");

var allowOrigins = builder.Configuration.GetValue<string>("AllowOrigins");

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyAllowedOrigins",
        policy =>
        {
            policy.WithOrigins(allowOrigins) // note the port is included 
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        });
});

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
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
.AddEntityFrameworkStores<ESContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Default Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 0;
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddTransient<IUserServiceFullAccess, UserTableQueryService>();
builder.Services.AddTransient<IRegistration, RegistrationService>();

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

//https://learn.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-6.0#middleware-order middleware order
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
     app.UseHsts();
}

var seedService = app.Services.CreateScope().ServiceProvider;
try
{
    await SeedRoles.InitRoleSeeds(seedService.GetRequiredService<RoleManager<IdentityRole>>());
    await SeedUsers.InitData(seedService.GetRequiredService<RoleManager<IdentityRole>>(),
        seedService.GetRequiredService<UserManager<ApplicationUser>>());
}
catch (Exception ex)
{
    var logger = seedService.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred while seeding the database.");
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSpaStaticFiles();
app.UseRouting();
app.UseCors("MyAllowedOrigins");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");


app.MapFallbackToFile("index.html");

app.Run();
