using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpManagement.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
        public DbSet<AltProject> AltProject { get; set; }
        public DbSet<AltProduct> AltProduct { get; set; }
        public DbSet<Coast> Coast { get; set; }
        public DbSet<CoastStatus> CoastStatus { get; set; }
        public DbSet<ProductClient> ProductClient { get; set; }
        public DbSet<ProjectClient> ProjectClient { get; set; }
        public DbSet<Timeline> Timeline { get; set; }
        public DbSet<AlternateEmployee> AlternateEmployee { get; set; }
        public DbSet<ProductSales> ProductSales { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Evaluation> Evaluation { get; set; }
        public DbSet<Negotiation> Negotiation { get; set; }
        public DbSet<Contract>Contract { get; set; }
        public DbSet<ClosedWon> ClosedWon { get; set; }
        public DbSet<ClosedLost> ClosedLost { get; set; }
        public DbSet<Jacket> Jacket { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Complete> Complete { get; set; }
        public DbSet<UpNext> UpNext { get; set; }
        public DbSet<Behind> Behind { get; set; }
        public DbSet<Blocked> Blocked { get; set; }
        public DbSet<OnTrack> OnTrack { get; set; }
        public DbSet<AtRisk> AtRisk { get; set; }




        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<NotInInventory> NotInInventory { get; set; }
        public DbSet<RentedForProject>RentedForProject  { get; set; }
        public DbSet<RentedFromClients> RentedFromClients { get; set; }
        public DbSet<Project> Projects { set; get; }

        public DbSet<Product> Products { set; get; }

        public DbSet<ProjectProduct> ProjectProducts { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasIndex(i => i.Name).IsUnique();
            modelBuilder.Entity<Project>().HasIndex(p => p.Name).IsUnique();
            modelBuilder.Entity<ProjectProduct>()
                .HasOne(pi => pi.Project)
                .WithMany(p => p.Products)
                .HasForeignKey(pi => pi.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProjectProduct>()
                .HasOne(pi => pi.Product)
                .WithMany(i => i.Projects)
                .HasForeignKey(pi => pi.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProjectProduct>()
                .HasKey(pi => new
                {
                    pi.ProjectId,
                    pi.ProductId
                });


            base.OnModelCreating(modelBuilder);

        }




    }
}
