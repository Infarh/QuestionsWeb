using Microsoft.EntityFrameworkCore;
using QuestionsWeb.DAL.Context;
using QuestionsWeb.Data;

namespace QuestionsWeb.Services;

public class QuestionDBInitializer
{
    private readonly QuestionsDB _DB;
    private readonly ILogger<QuestionDBInitializer> _Logger;

    public QuestionDBInitializer(QuestionsDB db, ILogger<QuestionDBInitializer> Logger)
    {
        _DB = db;
        _Logger = Logger;
    }

    public async Task InitializeAsync()
    {
        //await _DB.Database.EnsureDeletedAsync().ConfigureAwait(false);

        await _DB.Database.MigrateAsync().ConfigureAwait(false);

        await SeedTestDataAsync().ConfigureAwait(false);
    }

    protected async Task SeedTestDataAsync()
    {
        _DB.Authors.AddRange(TestData.Authors);
        _DB.BlogCategories.AddRange(TestData.Categories);
        _DB.BlogPosts.AddRange(TestData.Posts);

        await _DB.SaveChangesAsync();
    }
}
