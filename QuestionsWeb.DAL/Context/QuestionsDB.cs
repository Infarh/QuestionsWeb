using Microsoft.EntityFrameworkCore;
using QuestionsWeb.Domain.Entities;

namespace QuestionsWeb.DAL.Context;

public class QuestionsDB : DbContext
{
    public QuestionsDB(DbContextOptions<QuestionsDB> opt) : base(opt)
    {
        
    }

    public DbSet<BlogPost> BlogPosts { get; set; }

    public DbSet<BlogCategory> BlogCategories { get; set; }

    public DbSet<Author> Authors { get; set; }
}
