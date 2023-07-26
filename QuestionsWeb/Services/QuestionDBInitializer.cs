using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

using QuestionsWeb.DAL.Context;
using QuestionsWeb.Data;
using QuestionsWeb.Domain.Entities.Identity;

namespace QuestionsWeb.Services;

public class QuestionDBInitializer
{
    private readonly QuestionsDB _DB;
    private readonly UserManager<User> _UserManager;
    private readonly RoleManager<Role> _RoleManager;
    private readonly ILogger<QuestionDBInitializer> _Logger;

    public QuestionDBInitializer(
        QuestionsDB db, 
        UserManager<User> UserManager,
        RoleManager<Role> RoleManager,
        ILogger<QuestionDBInitializer> Logger)
    {
        _DB = db;
        _UserManager = UserManager;
        _RoleManager = RoleManager;
        _Logger = Logger;
    }

    public async Task InitializeAsync()
    {
        //await _DB.Database.EnsureDeletedAsync().ConfigureAwait(false);

        var applied_migration = await _DB.Database.GetAppliedMigrationsAsync().ConfigureAwait(false);
        if (applied_migration.Any())
        {
            foreach (var migration in applied_migration)
                _Logger.LogInformation("К БД применены миграция {migration}", migration);
        }

        var pending_migrations = await _DB.Database.GetPendingMigrationsAsync().ConfigureAwait(false);
        if (pending_migrations.Any())
        {
            foreach (var migration in pending_migrations)
                _Logger.LogInformation("Применение миграции {migration}", migration);
        }

        await _DB.Database.MigrateAsync().ConfigureAwait(false);

        await SeedIdentityAsync().ConfigureAwait(false);
        await SeedTestDataAsync().ConfigureAwait(false);
    }

    protected async Task SeedIdentityAsync()
    {
        async Task CheckRoleAsync(string RoleName)
        {
            if (!await _RoleManager.RoleExistsAsync(RoleName))
            {
                await _RoleManager.CreateAsync(new Role { Name = RoleName });
                _Logger.LogInformation("Роль {role} добавлена", RoleName);
            }
            else
                _Logger.LogInformation("Роль {role} уже существует", RoleName);
        }

        await CheckRoleAsync(Role.Adinistrators);
        await CheckRoleAsync(Role.Users);

        if (await _UserManager.FindByNameAsync(User.Administrator) is null)
        {
            _Logger.LogInformation("Создание администратора");

            var admin = new User
            {
                UserName = User.Administrator
            };

            var creation_result = await _UserManager.CreateAsync(admin, User.DefaultAdminPassword);
            if (creation_result.Succeeded)
            {
                await _UserManager.AddToRoleAsync(admin, Role.Adinistrators);
                _Logger.LogInformation("Администратор создан успешно");
            }
            else
            {
                _Logger.LogCritical("Ошибка при создании администратора");

                foreach (var error in creation_result.Errors)
                    _Logger.LogError(error.Description);

                throw new InvalidOperationException($"Ошибка при создании администратора {string.Join(";", creation_result.Errors.Select(e => e.Description))}");
            }
        }
    }

    protected async Task SeedTestDataAsync()
    {
        await using var transaction = await _DB.Database.BeginTransactionAsync().ConfigureAwait(false);

        if(!_DB.Authors.Any())
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
