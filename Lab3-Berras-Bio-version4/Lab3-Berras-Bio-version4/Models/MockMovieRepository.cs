using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3_Berras_Bio_version4.Models
{
    public class MockMovieRepository : IMovieRepository
    {
        public IEnumerable<Movie> AllMovies =>
            new List<Movie> 
            {
                new Movie
                {
                    Id=1,
                    Title="shawshank redemption",
                    ImageURL="https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_.jpg"
                },
                new Movie
                {
                    Id=2,
                    Title="The Godfather",
                    ImageURL="https://m.media-amazon.com/images/M/MV5BM2MyNjYxNmUtYTAwNi00MTYxLWJmNWYtYzZlODY3ZTk3OTFlXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SY1000_CR0,0,704,1000_AL_.jpg"
                }
            };

        public Movie GetMovieById(int movieId)
        {
            return AllMovies.FirstOrDefault(movie=>movie.Id==movieId);
        }
    }
}
