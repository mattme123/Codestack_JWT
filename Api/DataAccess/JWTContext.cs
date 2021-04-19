using JWTClaimsDemo.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace JWTClaimsDemo.DataAccess
{
    public class JWTContext : DbContext
    {
        public readonly ILoggerFactory MyLoggerFactory;
        public JWTContext(DbContextOptions<JWTContext> options) : base(options)
        {
            MyLoggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountType> AccountTypes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseLoggerFactory(MyLoggerFactory);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasQueryFilter(x => x.IsDeleted == false)
                .HasIndex(x => new { x.Email, x.Password, x.IsDeleted });

            modelBuilder.Entity<User>()
                .Property(x => x.IsDeleted)
                .HasDefaultValue(false);
            modelBuilder.Entity<User>()
                .Property(x => x.RoleId)
                .HasDefaultValue(2);
            modelBuilder.Entity<User>()
                .Property(x => x.Created)
                .HasDefaultValue(DateTime.Now);



            modelBuilder.Entity<User>()
                .HasData(
                    new User
                    {
                        UserId = 1,
                        Password = "password",
                        FirstName = "Matthew",
                        LastName = "Hicks",
                        Email = "me@email.com",
                        RoleId = 1,
                        IsDeleted = false
                    },
                    new User
                    {
                        UserId = 2,
                        Password = "password",
                        FirstName = "Mattme",
                        LastName = "Hick",
                        Email = "i@email.com",
                        RoleId = 2,
                        IsDeleted = false
                    }
                );
           
            modelBuilder.Entity<UserRole>()
                .HasData(
                    new UserRole
                    {
                        UserRoleId = 1,
                        Name = "Admin"
                    },
                    new UserRole
                    {
                        UserRoleId = 2,
                        Name = "Standard"
                    }
                );

            modelBuilder.Entity<Account>()
                .HasData(
                    new Account
                    {
                        AccountId = 1,
                        UserId = 1,
                        AccountTypeId = 1,
                        Funds = 3245
                    },
                    new Account
                    {
                        AccountId = 2,
                        UserId = 1,
                        AccountTypeId = 2,
                        Funds = 32
                    },
                    new Account
                    {
                        AccountId = 3,
                        UserId = 2,
                        AccountTypeId = 1,
                        Funds = 200
                    },
                    new Account
                    {
                        AccountId = 4,
                        UserId = 2,
                        AccountTypeId = 2,
                        Funds = 111
                    }
                );

            modelBuilder.Entity<AccountType>()
                .HasData(
                    new AccountType
                    {
                        AccountTypeId = 1,
                        Name = "Checking"
                    },
                    new AccountType
                    {
                        AccountTypeId = 2,
                        Name = "Saving"
                    }
                );
        }
    }
}
