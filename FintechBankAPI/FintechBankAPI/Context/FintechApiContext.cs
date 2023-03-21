using FintechBankAPI.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics.Metrics;

namespace FintechBankAPI.Context
{
    public class FintechApiContext : IdentityDbContext
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
           
        
        }
    }
}
