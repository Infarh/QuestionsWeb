using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using QuestionsWeb.DAL.Context;

namespace QuestionsWeb.DAL.Sqlite;

public static class ServicesRegistrator
{
    public static IServiceCollection AddQuestionsWebDBSqlite(
        this IServiceCollection services,
        string ConnectionString)
    {
        services.AddDbContext<QuestionsDB>(
            opt => opt.UseSqlite(
                ConnectionString,
                o => o.MigrationsAssembly(typeof(ServicesRegistrator).Assembly.GetName().ToString())));

        return services;
    }
}
