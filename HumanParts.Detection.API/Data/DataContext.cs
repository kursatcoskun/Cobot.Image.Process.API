﻿using HumanParts.Detection.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanParts.Detection.API.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
           

        }
        public DbSet<DetectionModel> Detections { get; set; }
        public DbSet<DetectedObject> DetectedObjects { get; set; }
        public DbSet <Device> Devices { get; set; }
        public object Configuration { get; internal set; }
    }
}
