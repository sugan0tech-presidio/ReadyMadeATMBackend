using Microsoft.EntityFrameworkCore;
using ReadyMadeATMBackend.Models;

namespace ReadyMadeATMBackend.Context;

public class ReadyMadeATMContext: DbContext
{
    public ReadyMadeATMContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seeds
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Name = "Alice", AtmNumber = "1234567890", Pin = 1234, Balance = 1000 },
            new User { Id = 2, Name = "Bob", AtmNumber = "1234567891", Pin = 1234, Balance = 2000 },
            new User { Id = 3, Name = "Charlie", AtmNumber = "1234567892", Pin = 1234, Balance = 3000 },
            new User { Id = 4, Name = "Diana", AtmNumber = "1234567893", Pin = 1234, Balance = 4000 }
        );
        
        modelBuilder.Entity<Transaction>().HasData(
            new Transaction { Id = 1, Type = "Deposit", Amount = 500, Timestamp = DateTime.Now.AddMonths(-2), CurrentBalance = 1500, SenderId = 1 },
            new Transaction { Id = 2, Type = "Withdraw", Amount = 200, Timestamp = DateTime.Now.AddMonths(-1), CurrentBalance = 1300, SenderId = 1 },
            new Transaction { Id = 3, Type = "Deposit", Amount = 1000, Timestamp = DateTime.Now.AddMonths(-1), CurrentBalance = 3000, SenderId = 2 },
            new Transaction { Id = 4, Type = "Withdraw", Amount = 500, Timestamp = DateTime.Now.AddMonths(-2), CurrentBalance = 2500, SenderId = 2 }
        );
        
        modelBuilder.Entity<User>()
            .HasMany<Transaction>(user => user.Transactions)
            .WithOne(transaction => transaction.Sender)
            .HasForeignKey(transaction => transaction.SenderId)
            .OnDelete(DeleteBehavior.NoAction);
        
    }
}