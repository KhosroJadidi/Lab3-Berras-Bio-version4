using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3_Berras_Bio_version4.Models
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext appDbContext;
        public MovieRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<Movie> AllMovies => appDbContext.Movies;
        

        public Movie GetMovieById(int movieId)
        {
            return appDbContext.Movies.FirstOrDefault(movie=>movie.Id==movieId);
        }
    }
}
