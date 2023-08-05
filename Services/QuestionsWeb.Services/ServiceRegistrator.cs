using Microsoft.Extensions.DependencyInjection;

using QRCoder;

using QuestionsWeb.Services.Interfaces;

namespace QuestionsWeb.Services;

public static class ServiceRegistrator
{
    public static IServiceCollection AddQuestionsWebServices(this IServiceCollection services)
    {
        services.AddSingleton<QRCodeGenerator>();
        services.AddTransient<IQRCodeService, QRCodeService>();
        services.AddSingleton<IPersonsStore, InMemoryPersonsStore>();
        services.AddScoped<IBlogsData, DbBlogPostData>();
        services.AddTransient<QuestionDBInitializer>();

        return services;
    }
}
