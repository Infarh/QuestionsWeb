using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using QRCoder;
using QuestionsWeb.Interfaces.Services;
using QuestionsWeb.Services.Interfaces;

namespace QuestionsWeb.Services;

public static class ServiceRegistrator
{
    public static IServiceCollection AddQuestionsWebServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddSingleton<QRCodeGenerator>();
        services.AddTransient<IQRCodeService, QRCodeService>();
        services.AddSingleton<IPersonsStore, InMemoryPersonsStore>();
        services.AddScoped<IBlogsData, DbBlogPostData>();
        services.AddTransient<QuestionDBInitializer>();

        //services.AddTransient<IWeatherService, WeatherApiComService>();
        //services.AddTransient<HttpClient>()

        services.AddHttpClient("WeatherAPI.com", client =>
        {
            client.BaseAddress = new("http://api.weatherapi.com");
            client.DefaultRequestHeaders.Add("key", config["WeatherAPIKey"]);
        })
            .AddTypedClient<IWeatherService, WeatherApiComService>();

        return services;
    }
}
