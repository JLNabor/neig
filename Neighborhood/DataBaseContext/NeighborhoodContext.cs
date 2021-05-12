using Microsoft.EntityFrameworkCore;
using Neighborhood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neighborhood.DataBaseContext
{
    public class NeighborhoodContext: DbContext
    {
        public NeighborhoodContext(DbContextOptions<NeighborhoodContext> dbContextOptions): 
            base(dbContextOptions) 
        {
        }

        public DbSet<House> Houses { get; set; }
        public DbSet<Owner> Owners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<House>().HasData(
                new House { Id=1, Address="Santa Fe 1", OwnerId=1 },
                new House { Id = 2, Address = "Santa Fe 2", OwnerId = 1 },
                new House { Id = 3, Address = "Santa Fe 3", OwnerId = 2 },
                new House { Id = 4, Address = "Santa Fe 4", OwnerId = 3 },
                new House { Id = 5, Address = "Santa Fe 5", OwnerId = 4 },
                new House { Id = 6, Address = "Santa Fe 6", OwnerId = 1 },
                new House { Id = 7, Address = "Santa Fe 7", OwnerId = 2 },
                new House { Id = 8, Address = "Santa Fe 8", OwnerId = 1 },
                new House { Id = 9, Address = "Santa Fe 9", OwnerId = 1 }
                );

            modelBuilder.Entity<Owner>().HasData(
                    new Owner { Id = 1, Name = "Karina", Phone="987654321", Email="karina@mail.com" },
                    new Owner { Id = 2, Name = "Marissa", Phone = "123456789", Email = "marissa@mail.com" },
                    new Owner { Id = 3, Name = "Mayte", Phone = "987654322", Email = "mayte@mail.com" },
                    new Owner { Id = 4, Name = "Cristina", Phone = "987654323", Email = "cristina@mail.com" }
                );

            modelBuilder.Entity<Owner>()
                .HasMany<House>(x => x.Houses);

        }
    }
}
