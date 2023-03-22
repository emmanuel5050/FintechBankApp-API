using FintechBankAPI.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics.Metrics;

namespace FintechBankAPI.Context
{
    public class FintechApiContext : IdentityDbContext<AppUser>
    {
        public FintechApiContext(DbContextOptions<FintechApiContext> options) : base(options)
        {
        }
        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Currency> Currencies { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Transaction> Transactions { get; set; } = null!;
        public virtual DbSet<Card> Cards { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.AccountNumber).HasMaxLength(15);

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.Property(e => e.CurrencyCode).HasMaxLength(10);

                entity.Property(e => e.CurrencyName).HasMaxLength(10);
            });


            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.Property(e => e.Remark).HasMaxLength(50);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

        }
    }
}
