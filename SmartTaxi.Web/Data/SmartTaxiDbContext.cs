using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SmartTaxi.Web.Domain;

namespace SmartTaxi.Web.Data
{
    public class SmartTaxiDbContext : DbContext
    {
        public SmartTaxiDbContext() 
            :base("name=SmartTaxiContext") 
        {
           // Database.SetInitializer(new MigrateDatabaseToLatestVersion<SmartTaxiDbContext, Migrations.Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>().Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Vehicle>().Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Comment>().Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
    }
}