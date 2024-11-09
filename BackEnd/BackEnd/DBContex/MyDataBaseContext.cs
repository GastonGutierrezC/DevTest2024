using BackEnd.Entitys;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.DBContex;

public class MyDataBaseContext
{
    public MyDataBaseContext(DbContextOptions<MyDataBaseContext> options) : base(options) { }
    
    public DbSet<Poll> polls { get; set; }
    public DbSet<Votes> votes { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<polls>()
            .HasMany(u => u.votes)
            .WithMany(); 
    }
}