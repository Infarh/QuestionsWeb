using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using QRCoder;
using QuestionsWeb.DAL.Context;
using QuestionsWeb.Domain.Entities.Identity;
using QuestionsWeb.Services;
using QuestionsWeb.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(); // Инфраструктура MVC = Контроллеры + представления (Razor)

var db_connection_string = builder.Configuration.GetConnectionString("SQL");

var db_string_builder = new SqlConnectionStringBuilder(db_connection_string);

var user = builder.Configuration.GetSection("db")["User"];
var pass = builder.Configuration.GetSection("db")["Password"];

db_string_builder.UserID = user;
db_string_builder.Password = pass;

var edited_connection_string = db_string_builder.ConnectionString;
//builder.Services.AddDbContext<QuestionsDB>(opt => opt.UseSqlServer(edited_connection_string));

builder.Services.AddDbContext<QuestionsDB>(opt => opt.UseSqlServer(db_connection_string));

builder.Services
    .AddTransient<IQRCodeService, QRCodeService>()
    .AddSingleton<QRCodeGenerator>()
    //.AddScoped<IPersonsStore, InMemoryPersonsStore>();
    .AddSingleton<IPersonsStore, InMemoryPersonsStore>()
    //.AddSingleton<IBlogsData, InMemoryBlogsData>()
    .AddScoped<IBlogsData, DbBlogPostData>()
    .AddTransient<QuestionDBInitializer>();

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


app.MapGet("Test", () => app.Configuration["TestString"]);

//app.MapDefaultControllerRoute(); // Регистрация стандартного маршрута для MVC
app.MapControllerRoute("default", "/{controller=Home}/{action=Index}/{id?}"); // Определение маршрута по умолчанию

/* --------------------------------------------------- */

app.Run();
