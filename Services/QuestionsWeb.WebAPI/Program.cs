using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;

using QuestionsWeb.DAL.Context;
using QuestionsWeb.DAL.Sqlite;
using QuestionsWeb.DAL.SqlServer;
using QuestionsWeb.Domain.Entities.Identity;
using QuestionsWeb.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddIdentity<User, Role>(/*opt => opt.User...*/)
    .AddEntityFrameworkStores<QuestionsDB>()
    .AddDefaultTokenProviders();

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

builder.Services.AddQuestionsWebServices(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
