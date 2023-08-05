using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuestionsWeb.Domain.Entities;
using QuestionsWeb.Domain.Entities.Identity;

namespace QuestionsWeb.DAL.Context;

public class QuestionsDB : IdentityDbContext<User, Role, string>
{
    public QuestionsDB(DbContextOptions<QuestionsDB> opt) : base(opt)
    {
       
    }

    public DbSet<BlogPost> BlogPosts { get; set; }

    public DbSet<BlogCategory> BlogCategories { get; set; }

    public DbSet<Author> Authors { get; set; }

    public DbSet<Tag> Tags { get; set; }

    protected override void OnModelCreating(ModelBuilder db)
    {
        base.OnModelCreating(db);

        //db.Entity<BlogPost>().ToTable("DbPosts");

        //db.Entity<Tag>().Property(typeof(string), "Description");
        //db.Entity<Tag>().HasIndex(tag => tag.Name, "TagName").IsUnique();
    }
}
