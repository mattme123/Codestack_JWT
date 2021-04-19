﻿// <auto-generated />
using System;
using JWTClaimsDemo.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JWTClaimsDemo.Migrations
{
    [DbContext(typeof(JWTContext))]
    [Migration("20210417190609_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("JWTClaimsDemo.Entities.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccountTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Funds")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AccountId");

                    b.HasIndex("AccountTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            AccountId = 1,
                            AccountTypeId = 1,
                            Funds = 3245,
                            UserId = 1
                        },
                        new
                        {
                            AccountId = 2,
                            AccountTypeId = 2,
                            Funds = 32,
                            UserId = 1
                        },
                        new
                        {
                            AccountId = 3,
                            AccountTypeId = 1,
                            Funds = 200,
                            UserId = 2
                        },
                        new
                        {
                            AccountId = 4,
                            AccountTypeId = 2,
                            Funds = 111,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("JWTClaimsDemo.Entities.AccountType", b =>
                {
                    b.Property<int>("AccountTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("AccountTypeId");

                    b.ToTable("AccountTypes");

                    b.HasData(
                        new
                        {
                            AccountTypeId = 1,
                            Name = "Checking"
                        },
                        new
                        {
                            AccountTypeId = 2,
                            Name = "Saving"
                        });
                });

            modelBuilder.Entity("JWTClaimsDemo.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValue(new DateTime(2021, 4, 17, 12, 6, 8, 670, DateTimeKind.Local).AddTicks(661));

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(false);

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(2);

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.HasIndex("Email", "Password", "IsDeleted");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "me@email.com",
                            FirstName = "Matthew",
                            IsDeleted = false,
                            LastName = "Hicks",
                            Password = "password",
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 2,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "i@email.com",
                            FirstName = "Mattme",
                            IsDeleted = false,
                            LastName = "Hick",
                            Password = "password",
                            RoleId = 2
                        });
                });

            modelBuilder.Entity("JWTClaimsDemo.Entities.UserRole", b =>
                {
                    b.Property<int>("UserRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("UserRoleId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            UserRoleId = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            UserRoleId = 2,
                            Name = "Standard"
                        });
                });

            modelBuilder.Entity("JWTClaimsDemo.Entities.Account", b =>
                {
                    b.HasOne("JWTClaimsDemo.Entities.AccountType", "AccountType")
                        .WithMany()
                        .HasForeignKey("AccountTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JWTClaimsDemo.Entities.User", "User")
                        .WithMany("Accounts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccountType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("JWTClaimsDemo.Entities.User", b =>
                {
                    b.HasOne("JWTClaimsDemo.Entities.UserRole", "UserRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("JWTClaimsDemo.Entities.User", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
