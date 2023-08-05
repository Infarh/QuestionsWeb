using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using QuestionsWeb.DAL.Context;
using QuestionsWeb.DAL.Sqlite;
using QuestionsWeb.DAL.SqlServer;
using QuestionsWeb.Domain.Entities.Identity;
using QuestionsWeb.Infrastructure.Conventions;
using QuestionsWeb.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(opt =>
{
    opt.Conventions.Add(new AreaControllerConvention());
}); // Инфраструктура MVC = Контроллеры + представления (Razor)

var db_config = builder.Configuration.GetSection("QuestionWebDB");
var db_type = db_config["type"];

var db_connection_string = db_config.GetConnectionString(db_type);

var user = db_config["User"];
var pass = db_config["Password"];

if (!string.IsNullOrWhiteSpace(user) && !string.IsNullOrWhiteSpace(pass))
{
    var db_string_builder = new SqlConnectionStringBuilder(db_connection_string)
    {
        UserID = user,
        Password = pass
    };

    db_connection_string = db_string_builder.ConnectionString;
}

switch (db_type?.ToLowerInvariant())
{
    case "sql":
        builder.Services.AddQuestionsWebDBSqlServer(db_connection_string);
        break;

    case "sqlite":
        builder.Services.AddQuestionsWebDBSqlite(db_connection_string);
        break;
}


builder.Services.AddQuestionsWebServices();
    

builder.Services.AddIdentity<User, Role>(/*opt => opt.User...*/)
    .AddEntityFrameworkStores<QuestionsDB>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(opt =>
{
#if DEBUG
    opt.Password.RequireDigit = false;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireUppercase = false;
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequiredLength = 3;
    opt.Password.RequiredUniqueChars = 3;
#endif

    opt.User.RequireUniqueEmail = false;
    opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIGKLMNOPQRSTUVWXYZ1234567890";

    opt.Lockout.AllowedForNewUsers = false;
    opt.Lockout.MaxFailedAccessAttempts = 10;
    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
});

builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.Cookie.Name = "Question.Cookie";
    opt.Cookie.HttpOnly = true;

    opt.LoginPath = "/Account/Login";
    opt.LogoutPath = "/Account/Logout";
    opt.AccessDeniedPath = "/Account/AccessDenied";

    opt.SlidingExpiration = true;
});

/* --------------------------------------------------- */

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db_initializer = scope.ServiceProvider.GetRequiredService<QuestionDBInitializer>();
    await db_initializer.InitializeAsync();
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles(/*new StaticFileOptions { ServeUnknownFileTypes = true }*/);

app.UseRouting(); // Разбор маршрутов

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("Test", () => app.Configuration["TestString"]);

//app.MapDefaultControllerRoute(); // Регистрация стандартного маршрута для MVC

app.MapControllerRoute(
    "areas",
    "{area:exists}/{controller=Home}/{action=Index}/{id?}"); 

app.MapControllerRoute(
    "default",
    "{controller=Home}/{action=Index}/{id?}"); // Определение маршрута по умолчанию

/* --------------------------------------------------- */

app.Run();
