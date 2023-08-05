using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using QuestionsWeb.DAL.Context;

namespace QuestionsWeb.DAL.SqlServer;

public static class ServicesRegistrator
{
    public static IServiceCollection AddQuestionsWebDBSqlServer(
        this IServiceCollection services,
        string ConnectionString)
    {
        services.AddDbContext<QuestionsDB>(
            opt => opt.UseSqlServer(
                ConnectionString,
                o => o.MigrationsAssembly(typeof(ServicesRegistrator).Assembly.GetName().ToString())));

        return services;
    }
}
