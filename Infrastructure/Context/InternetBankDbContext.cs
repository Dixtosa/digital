using Core.DBModel;
using Microsoft.EntityFrameworkCore;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;


namespace InternetBank.Models;

 public class InternetBankDbContext : DbContext
{
    public InternetBankDbContext(DbContextOptions<InternetBankDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<UserDetails> UserDetails => Set<UserDetails>();
    public DbSet<BankAccount> BankAccounts => Set<BankAccount>();
    public DbSet<AccountType> AccountTypes => Set<AccountType>();
    public DbSet<Card> Cards => Set<Card>();
    public DbSet<Transactions> Transactions => Set<Transactions>();
    public DbSet<Currency> Currencies => Set<Currency>();
    public DbSet<CurrencyRate> CurrencyRates => Set<CurrencyRate>();
    public DbSet<LoanLimits> LoanLimits => Set<LoanLimits>();
    public DbSet<Loans> Loans => Set<Loans>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasOne(u => u.Details)
            .WithOne(d => d.User)
            .HasForeignKey<UserDetails>(d => d.UserId);
        
        modelBuilder.Entity<BankAccount>()
            .HasOne(u => u.AccountType)
            .WithMany()
            .HasForeignKey(d => d.AccountTypeId);

        modelBuilder.Entity<BankAccount>()
            .HasMany(b => b.SentTransactions)
            .WithOne(t => t.SenderAccount)
            .HasForeignKey(t => t.SenderAccountId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<BankAccount>()
            .HasMany(b => b.ReceivedTransactions)
            .WithOne(t => t.ReceiverAccountNav)
            .HasForeignKey(t => t.ReceiverAccountId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<BankAccount>()
            .HasOne(b => b.Card);
    }
}
