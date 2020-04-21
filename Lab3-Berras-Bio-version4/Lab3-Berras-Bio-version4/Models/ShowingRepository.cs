using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3_Berras_Bio_version4.Models
{
    public class ShowingRepository : IShowingRepository
    {
        private readonly AppDbContext appDbContext;
        public ShowingRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public IEnumerable<Showing> Allshowings 
        {
            get 
            {
                return appDbContext.Showings;
            }
        }

        public Showing GetShowingById(int showId)
        {
            return appDbContext.Showings.FirstOrDefault(showing=>showing.Id==showId);
        }
    }
}
