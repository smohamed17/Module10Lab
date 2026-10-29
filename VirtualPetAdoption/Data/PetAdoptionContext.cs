using Microsoft.EntityFrameworkCore;
using VirtualPetAdoption.Models;
 
namespace VirtualPetAdoption.Data
{
    public class PetAdoptionContext : DbContext
    { // we are using the special method called constructor to create a new petadoptioncontext. 
        public PetAdoptionContext(DbContextOptions<PetAdoptionContext> options)
            : base(options)
        {
        }
 // we are using the attribute that stores the database set that holds pets from a collection.
        public DbSet<Pet> Pets { get; set; }
 // we are using the method that is unique to the DBcontext, 
 // it will represents the table in the database and the data table.  
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { // it will create an entity 
            modelBuilder.Entity<Pet>().HasData(
                new Pet { Id = 1, Name = "Fluffy", Species = "Cat",
                    Description = "A calm cat who enjoys naps.",
                    Emoji = "", EnergyLevel = 2 },
                new Pet { Id = 2, Name = "Rex", Species = "Dog",
                    Description = "A dog who loves to play fetch.",                
                    Emoji = "", EnergyLevel = 5 },
                new Pet { Id = 3, Name = "Nibbles", Species = "Rabbit",
                    Description = "A friendly rabbit with medium energy.",
                    Emoji = "", EnergyLevel = 3 }
            );
        }
    }
}