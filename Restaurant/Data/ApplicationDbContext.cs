using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Restaurant.Models;

namespace Restaurant.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
        }
        public DbSet<Dish> Dishes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Dish>().HasData(
                new Dish { Id=1,Price=20,Name="pizza",Reccomendation="Da",Calories=1024,Description="Nu"}
            
                );
            modelBuilder.Entity<Drink>().HasData(
                new Drink { Id = 1, Price = 7, Name = "Coca-Cola", Calories = 444 });

        }

        public DbSet<Drink> Drinks { get; set; }
    }
}
