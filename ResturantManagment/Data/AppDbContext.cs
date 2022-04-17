using Microsoft.EntityFrameworkCore;
using ResturantManagment.Models;

namespace ResturantManagment.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Resturant Food
            modelBuilder.Entity<ResturantFood>().HasKey(sc => new { sc.ResturantId, sc.FoodId });

            modelBuilder.Entity<ResturantFood>()
                .HasOne(r => r.Resturnat)
                .WithMany(f => f.ResturantFoods)
                .HasForeignKey(i => i.ResturantId);

            modelBuilder.Entity<ResturantFood>()
                .HasOne(s => s.Food)
                .WithMany(f => f.ResturantFoods)
                .HasForeignKey(i => i.FoodId);

            //Food Ingredients
            modelBuilder.Entity<FoodIngredient>().HasKey(sc => new { sc.FoodId, sc.IngredientId });

            modelBuilder.Entity<FoodIngredient>()
                .HasOne(r => r.Food)
                .WithMany(f => f.FoodIngredients)
                .HasForeignKey(i => i.FoodId);

            modelBuilder.Entity<FoodIngredient>()
                .HasOne(r => r.Ingredient)
                .WithMany(f => f.FoodIngredients)
                .HasForeignKey(i => i.IngredientId);
        }
        public DbSet<Resturant> Resturats { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<ResturantFood> ResturantFoods { get; set; }
        public DbSet<FoodIngredient> FoodIngredients { get; set; }
    }
}
