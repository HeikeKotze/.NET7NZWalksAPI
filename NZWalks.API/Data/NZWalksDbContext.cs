using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;
using static System.Net.WebRequestMethods;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {
            
        }

        //DbSet - collection of entities in the database
        //Creates tables inside the database
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Difficulties
            //Easy, Medium, Hard

            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("4eabb0c0-e9de-49cf-a923-37f0c8cb928d"),
                    Name = "Easy"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("50d9d0ad-6a65-49cc-b4f2-11aeaebbd37a"),
                    Name = "Medium"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("8f68da09-2a5f-4926-a586-45e3e81c6cc3"),
                    Name = "Hard"
                },
            };

            // Seed difficulties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            // Seed data for Regions

            var regions = new List<Region>()
            {
                new Region()
                {
                    Id = Guid.Parse("0a59e642-d2f2-4703-9780-29db063dc387"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region()
                {
                    Id = Guid.Parse("cd226cec-185d-4bce-b4e3-269371940945"),
                    Name = "Northland",
                    Code = "NTL",
                    RegionImageUrl = null
                },
                new Region()
                {
                    Id = Guid.Parse("045a66a0-b083-41f1-b0cc-e6c1d373df29"),
                    Name = "Bay of Plenty",
                    Code = "BOP",
                    RegionImageUrl = null
                },
                new Region()
                {
                    Id = Guid.Parse("36942c10-2f18-4694-8426-93feccb2385e"),
                    Name = "Wellington",
                    Code = "WGN",
                    RegionImageUrl = "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region()
                {
                    Id = Guid.Parse("6f1407ae-2864-4e8e-ad4b-790b08f4c58b"),
                    Name = "Nelson",
                    Code = "NSN",
                    RegionImageUrl = "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region()
                {
                    Id = Guid.Parse("36aab4af-aa37-4fae-a6e5-5d41a22d8cb1"),
                    Name = "Southland",
                    Code = "STL",
                    RegionImageUrl = null
                },
            };

            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
