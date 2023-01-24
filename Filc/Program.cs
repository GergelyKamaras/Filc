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
using Serilog;
using Filc.Services;
using Filc.Services.Interfaces;
using Filc.Services.ModelConverter;

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
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

// Add Entity Dbcontext
builder.Services.AddDbContext<ESContext>(options =>
{
    //options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
    options.UseInMemoryDatabase("Memorydb");
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
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddTransient<IUserServiceFullAccess, UserTableQueryService>();
builder.Services.AddTransient<IRegistration, RegistrationService>();
builder.Services.AddTransient<ILogin, LoginService>();
builder.Services.AddTransient<IJwtTokenGenerator, JwtTokenGeneratorService>();
builder.Services.AddTransient<IDBModelService, DBModelService>();
builder.Services.AddTransient<IInputDTOConverter, InputDtoConverter>();


// Register entity based query service interface implementations
builder.Services.AddTransient<IGovernmentAdminServiceFullAccess, GovernmentAdminTableQueryService>();
builder.Services.AddTransient<IParentServiceFullAccess, ParentTableQueryService>();
builder.Services.AddTransient<IStudentServiceFullAccess, StudentTableQueryService>();
builder.Services.AddTransient<ITeacherServiceFullAccess, TeacherTableQueryService>();
builder.Services.AddTransient<ISchoolAdminServiceFullAccess, SchoolAdminTableQueryService>();
builder.Services.AddTransient<ISchoolServiceFullAccess, SchoolTableQueryService>();
builder.Services.AddTransient<ILessonServiceFullAccess, LessonTableQueryService>();
builder.Services.AddTransient<ISubjectServiceFullAccess, SubjectTableQueryService>();
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

if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error-development");
    app.UseHsts();
}
else
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

var seedService = app.Services.CreateScope().ServiceProvider;
try
{
    await SeedRoles.InitRoleSeeds(seedService.GetRequiredService<RoleManager<IdentityRole>>());
    await SeedUsers.InitData(seedService.GetRequiredService<IGovernmentAdminServiceFullAccess>(),
        seedService.GetRequiredService<ISchoolAdminServiceFullAccess>(),
        seedService.GetRequiredService<IStudentServiceFullAccess>(),
        seedService.GetRequiredService<ITeacherServiceFullAccess>(),
        seedService.GetRequiredService<IParentServiceFullAccess>(),
        seedService.GetRequiredService<IRegistration>(),
        seedService.GetRequiredService<ISchoolServiceFullAccess>(),
        seedService.GetRequiredService<IDBModelService>());
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

Log.Information("Server started");

app.MapFallbackToFile("index.html");

app.Run();
