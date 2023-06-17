var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllers(); // WebAPI �� ������ ������������
builder.Services.AddControllersWithViews(); // �������������� MVC = ����������� + ������������� (Razor)
//builder.Services.AddRazorPages(); // ������ � ���-����������

/* --------------------------------------------------- */

var app = builder.Build();

app.UseRouting(); // ������ ���������

//var str = app.Configuration["TestString"];

//app.MapGet("/", () => "Hello World!");

//app.MapGet("Test", () => str);
app.MapGet("Test", () => app.Configuration["TestString"]);

//app.MapDefaultControllerRoute(); // ����������� ������������ �������� ��� MVC
app.MapControllerRoute("default", "/{controller=Home}/{action=Index}/{id?}"); // ����������� �������� �� ���������

/* --------------------------------------------------- */

app.Run();
