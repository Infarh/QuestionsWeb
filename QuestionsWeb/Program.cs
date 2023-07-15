using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using QRCoder;
using QuestionsWeb.DAL.Context;
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
    .AddSingleton<IBlogsData, InMemoryBlogsData>();

/* --------------------------------------------------- */

var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var service_manager = scope.ServiceProvider;

//    var persons = service_manager.GetRequiredService<IPersonsStore>();
//}

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
