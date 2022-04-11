using Microsoft.EntityFrameworkCore;

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public ApplicationContext()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=helloapp.db");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().Property("Id").HasField("id");
        modelBuilder.Entity<User>().Property("Age").HasField("age");
        modelBuilder.Entity<User>().Property("name");
    }

}
public class User
{
    int id;
    string name;
    int age;
    public int Id => id;
    public int Age => age;
    public User(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    public void Print() => Console.WriteLine($"{id}. {name} - {age}");
}

