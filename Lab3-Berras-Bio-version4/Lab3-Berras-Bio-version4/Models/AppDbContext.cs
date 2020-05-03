using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Lab3_Berras_Bio_version4.Models
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        //public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Showing> Showings { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Auditorium> Auditoria { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }                
    }
}
