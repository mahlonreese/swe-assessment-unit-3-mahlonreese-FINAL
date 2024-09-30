using Microsoft.EntityFrameworkCore;

public class AssessDbContext(string dbName = "animals") : DbContext
{
    private readonly string _connectionHost = "localhost";
    private readonly string _connectionDbName = dbName;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql($"Host={_connectionHost};Database={_connectionDbName}");
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<Animal> Animals { get; set; } = null!;
    public DbSet<Human> Humans { get; set; } = null!;
}

