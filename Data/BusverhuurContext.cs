using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jj_eskolina_silver_enigma.Models;
using Microsoft.EntityFrameworkCore;

namespace jj_eskolina_silver_enigma.Data
{
    public class BusverhuurContext : DbContext
    {
        public BusverhuurContext(DbContextOptions<BusverhuurContext> options)
            : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}