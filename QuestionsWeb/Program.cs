var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllers(); // WebAPI на основе контроллеров
builder.Services.AddControllersWithViews(); // Инфраструктура MVC = Контроллеры + представления (Razor)
//builder.Services.AddRazorPages(); // Работа с веб-страницами

/* --------------------------------------------------- */

var app = builder.Build();

app.UseRouting(); // Разбор маршрутов

//var str = app.Configuration["TestString"];

//app.MapGet("/", () => "Hello World!");

//app.MapGet("Test", () => str);
app.MapGet("Test", () => app.Configuration["TestString"]);

//app.MapDefaultControllerRoute(); // Регистрация стандартного маршрута для MVC
app.MapControllerRoute("default", "/{controller=Home}/{action=Index}/{id?}"); // Определение маршрута по умолчанию

/* --------------------------------------------------- */

app.Run();
