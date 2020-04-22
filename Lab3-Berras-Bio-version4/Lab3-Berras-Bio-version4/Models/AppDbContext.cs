using Microsoft.EntityFrameworkCore;
using System;

namespace Lab3_Berras_Bio_version4.Models
{
    public class AppDbContext : DbContext
    {        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Showing> Showings { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }
        

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    seed users

        //    modelBuilder.Entity<User>().HasData(new User
        //    {
        //        Id = 1,
        //        Email = "Khosro@mail.com",
        //        Password = "1234"
        //    });
        //    modelBuilder.Entity<User>().HasData(new User
        //    {
        //        Id = 2,
        //        Email = "Pontus@mail.com",
        //        Password = "5678"
        //    });

        //    seed movies

        //    modelBuilder.Entity<Movie>().HasData(new Movie
        //    {
        //        Id = 1,
        //        Title = "shawshank redemption",
        //        ImageURL = "https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_.jpg"
        //    });
        //    modelBuilder.Entity<Movie>().HasData(new Movie
        //    {
        //        Id = 2,
        //        Title = "The Godfather",
        //        ImageURL = "https://m.media-amazon.com/images/M/MV5BM2MyNjYxNmUtYTAwNi00MTYxLWJmNWYtYzZlODY3ZTk3OTFlXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SY1000_CR0,0,704,1000_AL_.jpg"
        //    });

        //    seed showings

        //    modelBuilder.Entity<Showing>().OwnsOne(showing => showing.Movie).HasData(new Showing
        //    {
        //        Id = 1,
        //        StartHour = new DateTime(2020, 4, 25, 17, 30, 0),
        //        Movie = new Movie
        //        {
        //            Id = 1,
        //            Title = "shawshank redemption",
        //            ImageURL = "https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_.jpg"
        //        },
        //        TotalSeats = 50,
        //        OccupiedSeats = 30
        //    });

        //    modelBuilder.Entity<Showing>().OwnsOne(showing => showing.Movie).HasData(new Showing
        //    {
        //        Id = 2,
        //        StartHour = new DateTime(2020, 4, 25, 20, 00, 0),
        //        Movie = new Movie
        //        {
        //            Id = 2,
        //            Title = "The Godfather",
        //            ImageURL = "https://m.media-amazon.com/images/M/MV5BM2MyNjYxNmUtYTAwNi00MTYxLWJmNWYtYzZlODY3ZTk3OTFlXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SY1000_CR0,0,704,1000_AL_.jpg"
        //        },
        //        TotalSeats = 50,
        //        OccupiedSeats = 50
        //    });

        //    //seed tickets

        //    modelBuilder.Entity<Ticket>().HasData(new Ticket
        //    {
        //        Id = 1,
        //        User =
        //        {
        //            Id=1,
        //            Email="Khosro@mail.com",
        //            Password="1234"
        //        },
        //        Showing =
        //        {
        //            Id = 1,
        //            StartHour = new DateTime(2020, 4, 25, 17, 30, 0),
        //            Movie =
        //            {
        //                Id = 1,
        //                Title = "shawshank redemption",
        //                ImageURL = "https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_.jpg"
        //            },
        //            TotalSeats = 50,
        //            OccupiedSeats = 30
        //        }
        //    });
        //    modelBuilder.Entity<Ticket>().HasData(new Ticket
        //    {
        //        Id = 2,
        //        User =
        //        {
        //            Id=2,
        //            Email="Pontus@mail.com",
        //            Password="5678"
        //        },
        //        Showing =
        //        {
        //            Id = 2,
        //            StartHour = new DateTime(2020, 4, 25, 20, 00, 0),
        //            Movie =
        //            {
        //                Id = 2,
        //                Title = "The Godfather",
        //                ImageURL = "https://m.media-amazon.com/images/M/MV5BM2MyNjYxNmUtYTAwNi00MTYxLWJmNWYtYzZlODY3ZTk3OTFlXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SY1000_CR0,0,704,1000_AL_.jpg"
        //            },
        //            TotalSeats = 50,
        //            OccupiedSeats = 50
        //        }
        //    });
        //}
    }
}
