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
        await _DB.Database.EnsureDeletedAsync().ConfigureAwait(false);

        await _DB.Database.MigrateAsync().ConfigureAwait(false);

        await SeedTestDataAsync().ConfigureAwait(false);
    }

    protected async Task SeedTestDataAsync()
    {
        await using var transaction = await _DB.Database.BeginTransactionAsync().ConfigureAwait(false);

        try
        {
            _DB.Authors.AddRange(TestData.Authors);

            //await _DB.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Authors] ON").ConfigureAwait(false);
            await _DB.SaveChangesAsync();
            //await _DB.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Authors] OFF").ConfigureAwait(false);


            _DB.BlogCategories.AddRange(TestData.Categories);

            //await _DB.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[BlogCategories] ON").ConfigureAwait(false);
            await _DB.SaveChangesAsync();
            //await _DB.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[BlogCategories] OFF").ConfigureAwait(false);

            _DB.BlogPosts.AddRange(TestData.Posts);

            //await _DB.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[BlogPosts] ON").ConfigureAwait(false);
            await _DB.SaveChangesAsync();
            //await _DB.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[BlogPosts] OFF").ConfigureAwait(false);

            await transaction.CommitAsync().ConfigureAwait(false);
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}
