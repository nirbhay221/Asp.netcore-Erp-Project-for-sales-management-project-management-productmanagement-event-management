﻿// <auto-generated />
using System;
using EmpManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmpManagement.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmpManagement.Models.AlternateEmployee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Availability");

                    b.Property<DateTime>("Dob");

                    b.Property<DateTime>("EidaDate");

                    b.Property<string>("EmailAddress");

                    b.Property<string>("HomeAddress");

                    b.Property<string>("Location");

                    b.Property<DateTime>("MedicalInsuranceDate");

                    b.Property<string>("Name");

                    b.Property<string>("Objective");

                    b.Property<DateTime>("PassportDate");

                    b.Property<string>("ReportsTo");

                    b.Property<string>("Role");

                    b.Property<DateTime>("SalaryDate");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("AlternateEmployee");
                });

            modelBuilder.Entity("EmpManagement.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("City");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("EmpManagement.Models.AtRisk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Budget");

                    b.Property<string>("Category");

                    b.Property<string>("Lead");

                    b.Property<string>("Name");

                    b.Property<string>("Owner");

                    b.Property<int>("Profit");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("AtRisk");
                });

            modelBuilder.Entity("EmpManagement.Models.Behind", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Budget");

                    b.Property<string>("Category");

                    b.Property<string>("Lead");

                    b.Property<string>("Name");

                    b.Property<string>("Owner");

                    b.Property<int>("Profit");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("Behind");
                });

            modelBuilder.Entity("EmpManagement.Models.Blocked", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Budget");

                    b.Property<string>("Category");

                    b.Property<string>("Lead");

                    b.Property<string>("Name");

                    b.Property<string>("Owner");

                    b.Property<int>("Profit");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("Blocked");
                });

            modelBuilder.Entity("EmpManagement.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contact");

                    b.Property<string>("EmailAddress");

                    b.Property<int>("Employees");

                    b.Property<string>("HQ");

                    b.Property<string>("Industry");

                    b.Property<string>("Interactions");

                    b.Property<string>("Location");

                    b.Property<string>("Name");

                    b.Property<string>("Objectives");

                    b.Property<string>("PrimaryContact");

                    b.HasKey("Id");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("EmpManagement.Models.ClosedLost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ExpectedCloseDate");

                    b.Property<int>("ForeCastValue");

                    b.Property<DateTime>("LastContact");

                    b.Property<string>("Name");

                    b.Property<string>("Notes");

                    b.Property<string>("Priority");

                    b.Property<int>("Probability");

                    b.Property<string>("Rep");

                    b.Property<string>("SalesStage");

                    b.Property<int>("SignedContractValue");

                    b.HasKey("Id");

                    b.ToTable("ClosedLost");
                });

            modelBuilder.Entity("EmpManagement.Models.ClosedWon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ExpectedCloseDate");

                    b.Property<int>("ForeCastValue");

                    b.Property<DateTime>("LastContact");

                    b.Property<string>("Name");

                    b.Property<string>("Notes");

                    b.Property<string>("Priority");

                    b.Property<int>("Probability");

                    b.Property<string>("Rep");

                    b.Property<string>("SalesStage");

                    b.Property<int>("SignedContractValue");

                    b.HasKey("Id");

                    b.ToTable("ClosedWon");
                });

            modelBuilder.Entity("EmpManagement.Models.Coast", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("Coast");
                });

            modelBuilder.Entity("EmpManagement.Models.CoastStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("Status_Id");

                    b.HasKey("Id");

                    b.ToTable("CoastStatus");
                });

            modelBuilder.Entity("EmpManagement.Models.Complete", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Budget");

                    b.Property<string>("Category");

                    b.Property<string>("Lead");

                    b.Property<string>("Name");

                    b.Property<string>("Owner");

                    b.Property<int>("Profit");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("Complete");
                });

            modelBuilder.Entity("EmpManagement.Models.Contract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ExpectedCloseDate");

                    b.Property<int>("ForeCastValue");

                    b.Property<DateTime>("LastContact");

                    b.Property<string>("Name");

                    b.Property<string>("Notes");

                    b.Property<string>("Priority");

                    b.Property<int>("Probability");

                    b.Property<string>("Rep");

                    b.Property<string>("SalesStage");

                    b.Property<int>("SignedContractValue");

                    b.HasKey("Id");

                    b.ToTable("Contract");
                });

            modelBuilder.Entity("EmpManagement.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Department");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("PhotoPath");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EmpManagement.Models.Evaluation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ExpectedCloseDate");

                    b.Property<int>("ForeCastValue");

                    b.Property<DateTime>("LastContact");

                    b.Property<string>("Name");

                    b.Property<string>("Notes");

                    b.Property<string>("Priority");

                    b.Property<int>("Probability");

                    b.Property<string>("Rep");

                    b.Property<string>("SalesStage");

                    b.Property<int>("SignedContractValue");

                    b.HasKey("Id");

                    b.ToTable("Evaluation");
                });

            modelBuilder.Entity("EmpManagement.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Budget");

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Location");

                    b.Property<int>("Profit");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("EmpManagement.Models.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("Price");

                    b.Property<string>("Project");

                    b.Property<int>("Quantity");

                    b.Property<DateTime>("RentedFrom");

                    b.Property<DateTime>("RentedTo");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("Inventory");
                });

            modelBuilder.Entity("EmpManagement.Models.Jacket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("Priority");

                    b.Property<string>("Role");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("Jacket");
                });

            modelBuilder.Entity("EmpManagement.Models.Negotiation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ExpectedCloseDate");

                    b.Property<int>("ForeCastValue");

                    b.Property<DateTime>("LastContact");

                    b.Property<string>("Name");

                    b.Property<string>("Notes");

                    b.Property<string>("Priority");

                    b.Property<int>("Probability");

                    b.Property<string>("Rep");

                    b.Property<string>("SalesStage");

                    b.Property<int>("SignedContractValue");

                    b.HasKey("Id");

                    b.ToTable("Negotiation");
                });

            modelBuilder.Entity("EmpManagement.Models.NotInInventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("Price");

                    b.Property<string>("Project");

                    b.Property<int>("Quantity");

                    b.Property<DateTime>("RentedFrom");

                    b.Property<DateTime>("RentedTo");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("NotInInventory");
                });

            modelBuilder.Entity("EmpManagement.Models.OnTrack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Budget");

                    b.Property<string>("Category");

                    b.Property<string>("Lead");

                    b.Property<string>("Name");

                    b.Property<string>("Owner");

                    b.Property<int>("Profit");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("OnTrack");
                });

            modelBuilder.Entity("EmpManagement.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Products");
                });

            modelBuilder.Entity("EmpManagement.Models.ProductClient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Client_Id");

                    b.Property<int>("Price");

                    b.Property<int>("RentedFromClients_Id");

                    b.HasKey("Id");

                    b.ToTable("ProductClient");
                });

            modelBuilder.Entity("EmpManagement.Models.ProductSales", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Price");

                    b.Property<string>("Project_Name");

                    b.Property<int>("Sales_Id");

                    b.HasKey("Id");

                    b.ToTable("ProductSales");
                });

            modelBuilder.Entity("EmpManagement.Models.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("EmpManagement.Models.ProjectClient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Client_Id");

                    b.Property<string>("Project_Name");

                    b.HasKey("Id");

                    b.ToTable("ProjectClient");
                });

            modelBuilder.Entity("EmpManagement.Models.ProjectProduct", b =>
                {
                    b.Property<Guid>("ProjectId");

                    b.Property<Guid>("ProductId");

                    b.HasKey("ProjectId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProjectProducts");
                });

            modelBuilder.Entity("EmpManagement.Models.RentedForProject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("Price");

                    b.Property<string>("Project");

                    b.Property<int>("Quantity");

                    b.Property<DateTime>("RentedFrom");

                    b.Property<DateTime>("RentedTo");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("RentedForProject");
                });

            modelBuilder.Entity("EmpManagement.Models.RentedFromClients", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("Price");

                    b.Property<string>("Project");

                    b.Property<int>("Quantity");

                    b.Property<DateTime>("RentedFrom");

                    b.Property<DateTime>("RentedTo");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("RentedFromClients");
                });

            modelBuilder.Entity("EmpManagement.Models.Sales", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ExpectedCloseDate");

                    b.Property<int>("ForeCastValue");

                    b.Property<DateTime>("LastContact");

                    b.Property<string>("Name");

                    b.Property<string>("Notes");

                    b.Property<string>("Priority");

                    b.Property<int>("Probability");

                    b.Property<int>("Quantity");

                    b.Property<string>("Rep");

                    b.Property<string>("SalesStage");

                    b.Property<int>("SignedContractValue");

                    b.HasKey("Id");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("EmpManagement.Models.Timeline", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<DateTime>("Deadline");

                    b.Property<string>("Email");

                    b.Property<string>("Event");

                    b.Property<string>("Objective");

                    b.Property<string>("Project");

                    b.HasKey("Id");

                    b.ToTable("Timeline");
                });

            modelBuilder.Entity("EmpManagement.Models.UpNext", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Budget");

                    b.Property<string>("Category");

                    b.Property<string>("Lead");

                    b.Property<string>("Name");

                    b.Property<string>("Owner");

                    b.Property<int>("Profit");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("UpNext");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("EmpManagement.Models.ProjectProduct", b =>
                {
                    b.HasOne("EmpManagement.Models.Product", "Product")
                        .WithMany("Projects")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EmpManagement.Models.Project", "Project")
                        .WithMany("Products")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("EmpManagement.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("EmpManagement.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EmpManagement.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("EmpManagement.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}