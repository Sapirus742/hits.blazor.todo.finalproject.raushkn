using Microsoft.EntityFrameworkCore;
using TheFinalProject.Models;

namespace TheFinalProject.Data
{
    public class JournalDbContext : DbContext
    {
        public JournalDbContext(DbContextOptions<JournalDbContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Branch> Branches { get; set; } // Добавили DbSet для филиалов
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Intern> Interns { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Настройка наследования для Account (TPH)
            modelBuilder.Entity<Account>()
                .HasDiscriminator<string>("AccountType")
                .HasValue<Account>("Regular")
                .HasValue<Intern>("Intern");

            // Настройка наследования для Department (TPH)
            modelBuilder.Entity<Department>()
                .HasDiscriminator<string>("DepartmentType")
                .HasValue<Department>("MainOffice")
                .HasValue<Branch>("Branch");
        }
    }
}
