using Microsoft.EntityFrameworkCore;
using System;
using Core.Entities;
using System.Collections.Generic;
using System.Text;

namespace InfraStracture
{
  public  class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
           : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Onwer>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<PortfilioItem>().Property(x => x.Id).HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Onwer>().HasData(
                new Onwer()
                {
                    Id = Guid.NewGuid(),
                    Avatar = "avatar.jpg",
                    FullName = "Mustafa Al-Saffar",
                    Profil = "Teacher , Web Developer"
                }
                );
        }

        public DbSet<Onwer> Owner { get; set; }
        public DbSet<PortfilioItem> PortfolioItems { get; set; }

    }
}
