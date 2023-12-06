using Microsoft.EntityFrameworkCore;
public class ApiContext : DbContext
{
    public string DbPath { get; private set; }

    public DbSet<User> Users { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Fav> Favs { get; set; }
    public DbSet<Picture> Pictures { get; set; }

    public ApiContext()
    {
        // Path to SQLite database file
        DbPath = "BDD/ApiCarteBlanche.db";
    }


    // The following configures EF to create a SQLite database file locally
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // Use SQLite as database
        options.UseSqlite($"Data Source={DbPath}");
        // Optional: log SQL queries to console
        //options.LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);
    }
}
