using QRCoder;
using QuestionsWeb.Services;
using QuestionsWeb.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(); // Инфраструктура MVC = Контроллеры + представления (Razor)

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
