var builder = WebApplication.CreateBuilder(args);


/* --------------------------------------------------- */

var app = builder.Build();

//var str = app.Configuration["TestString"];

app.MapGet("/", () => "Hello World!");

//app.MapGet("Test", () => str);
app.MapGet("Test", () => app.Configuration["TestString"]);

/* --------------------------------------------------- */

app.Run();
