using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3_Berras_Bio_version4.Models
{
    public class MockShowingRepository : IShowingRepository
    {
        private readonly MockMovieRepository mockMovieRepository = new MockMovieRepository();
        public IEnumerable<Showing> Allshowings =>
            new List<Showing> 
            {
                new Showing
                {
                    Id=1,
                    StartHour= new DateTime(2020,4,25,17,30,0),
                    Movie=mockMovieRepository.GetMovieById(1),
                    TotalSeats=50,
                    OccupiedSeats=30
                },
                new Showing
                {
                    Id=2,
                    StartHour= new DateTime(2020,4,25,20,00,0),
                    Movie=mockMovieRepository.GetMovieById(2),
                    TotalSeats=50,
                    OccupiedSeats=45
                }
            };

        public Showing GetShowingById(int showId)
        {
            return Allshowings.FirstOrDefault(show=>show.Id==showId);
        }
    }
}
