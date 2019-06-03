using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using I4GUI2019SommerWEB.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace I4GUI2019SommerWEB.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Location>().HasData(new Location
            {
                LocationId = 1,
                Name = "Mindeparken",
                Street = "Carl Nielsens Vej",
                ZipCode = "8000",
                City = "Aarhus",
                Trees = "Birk: 5 Eg: 10"
                
            }, new Location
            {
                LocationId = 2,
                Name = "Finlandsgade",
                Street = "Finlandsgade",
                ZipCode = "8200",
                City = "Aarhus N",
                Trees = "Bøg: 9 Gran: 5"
                
            });
        }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Sensor> Sensors { get; set; }

    }
}
