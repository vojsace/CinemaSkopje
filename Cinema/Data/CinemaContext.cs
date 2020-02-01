using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cinema.Models;

namespace Cinema.Data
{
    public class CinemaContext : DbContext
    {
        public CinemaContext (DbContextOptions<CinemaContext> options)
            : base(options)
        {
        }

        public DbSet<Hall> Halls { get; set; }
        public DbSet<BookTicket> BookTickets { get; set; }
        public DbSet<Movie> Movies { get; set; }
    }
}
