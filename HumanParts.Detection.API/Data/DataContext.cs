using HumanParts.Detection.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanParts.Detection.API.Data
{
    public class DataContext: DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<DetectionModel>()
                        .HasOne(a => a.device)
                        .WithMany();
            modelBuilder.Entity<DetectionModel>()
                        .HasOne(x => x.detectedObject)
                        .WithMany();
        }
   
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
           

        }
        public DbSet<DetectionModel> Detections { get; set; }
        public DbSet<DetectedObject> DetectedObjects { get; set; }
        public DbSet <Device> Devices { get; set; }

    }
}
