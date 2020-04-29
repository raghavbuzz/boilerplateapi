using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class RepositoryContext: DbContext
    {
        public RepositoryContext(DbContextOptions options): base(options)
        {
        }

        // Seed Data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Adding AccountType Seed Data
            modelBuilder.Entity<AccountType>().HasData(new AccountType
            {
                Id = 1,
                AccountTypeCode = "CA",
                AccountTypeDescription = "Current Account"
            }, new AccountType {
                Id = 2,
                AccountTypeCode = "SA",
                AccountTypeDescription = "Saving Account"
            });
        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
    }
}
