using Eventmi.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventmi.Infrastructure.Data
{
    /// <summary>
    /// Context of database
    /// </summary>
    public class EventmiDbContext: DbContext
    {
        /// <summary>
        /// Constructor of database
        /// </summary>
        /// <param name="options">connection configurations</param>
        public EventmiDbContext(DbContextOptions<EventmiDbContext> options)
            : base(options)
        {
        }
        /// <summary>
        /// Eevents
        /// </summary>
        public DbSet<Event> Events { get; set; }
        /// <summary>
        /// Addresses
        /// </summary>
        public DbSet<Address> Addresses { get; set; }
        /// <summary>
        /// Towns
        /// </summary>
        public DbSet<Town> Towns { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>()
                .HasQueryFilter(e => e.IsActive);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EventmiDbContext).Assembly);
        }
    }
}
