using FoodFileMgt.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodFileMgt.Context
{
    public class FoodContext : DbContext
    {
        public FoodContext(DbContextOptions<FoodContext> options) : base(options)
        {
            
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodBranch> FoodBranches { get; set; }
        public DbSet<FoodOrder> FoodOrders { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>().HasData
            (
                new Role
                {
                    Id = "abcd",
                    Name = "SuperAdmin",
                    IsDeleted = false,
                    
                }
            );

            modelBuilder.Entity<User>().HasData
            (
                new User
                {
                    Id = "efgh",
                    Email = "super@gmail.com",
                    Password = "pass",
                    IsDeleted = false,
                    RoleId = "abcd",
                }
            );
        }
    }
}
