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
        modelBuilder.Entity<User>()
            .HasMany<Transaction>(user => user.Transactions)
            .WithOne(transaction => transaction.Sender)
            .HasForeignKey(transaction => transaction.SenderId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}