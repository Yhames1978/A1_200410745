using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using A1_200410745.Models;

namespace A1_200410745.Models
{
    public class A1_200410745Context : DbContext
    {
        public A1_200410745Context(DbContextOptions<A1_200410745Context> options)
            : base(options)
        {
        }

        public DbSet<A1_200410745.Models.PetFood> PetFood { get; set; }

        public DbSet<A1_200410745.Models.Animal> Animal { get; set; }
        // Seeded two entries for the Animal table and Two for the PetFood table
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Animal>().HasData(
                new Animal(1, "Cat", "Very Cute"),
                new Animal(2, "Dog", "Hairy")
                );
             modelBuilder.Entity<PetFood>().HasData(
              new PetFood()
              {   PetFoodId = 1,
                  Price = 13.00M,
                  Name = "Doggy Best",
                  Description = "Yummy Dog Food",
                  NutritionalInformation = "High in vitamins" ,
                  Weight = 4, Brand = "Prime",
                  AnimalId = 2},

               new PetFood()
               {
                   PetFoodId = 2,
                   Price = 14.00M,
                   Name = "One Cat Food",
                   Description = "High End Cat Food",
                   NutritionalInformation = "Made only from Chiken",
                   Weight = 20,
                   Brand = "One",
                   AnimalId = 1
               }

             );


        }
    }
}
