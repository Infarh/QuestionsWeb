var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(); // Инфраструктура MVC = Контроллеры + представления (Razor)

/* --------------------------------------------------- */

var app = builder.Build();

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
