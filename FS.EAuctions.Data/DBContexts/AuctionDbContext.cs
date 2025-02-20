using FS.EAuctions.Data.Base;
using FS.EAuctions.Domain.Auctions;
using FS.EAuctions.Domain.Bids;
using Microsoft.EntityFrameworkCore;

namespace FS.EAuctions.Data.DBContexts;

public class AuctionDbContext : AuditableModelDbContextBase
{
    public DbSet<BuyerAuction> BuyerAuctions { get; set; }
    public DbSet<Bid> Bids { get; set; }

    public AuctionDbContext(DbContextOptions<AuctionDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AuctionDbContext).Assembly);

        // SeedData(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }

    // private static void SeedData(ModelBuilder modelBuilder)
    // {
    //     var recipe1 = Recipe.Create("Ugali", "A Kenyan dish");
    //     var recipe2 = Recipe.Create("Chapati", "A kenyan dish like indian roti");
    //
    //     modelBuilder.Entity<Recipe>()
    //         .HasData(recipe1, recipe2);
    //
    //     modelBuilder.Entity<Ingredient>()
    //         .HasData(
    //             Ingredient.Create(recipe1.Id, "Maize flour", 1, "cups"),
    //             Ingredient.Create(recipe1.Id, "Water", 1, "cups"),
    //             Ingredient.Create(recipe2.Id, "Wheat flour", 1, "cups"),
    //             Ingredient.Create(recipe2.Id, "Salt", 1, "spoons")
    //         );
    // }
}
