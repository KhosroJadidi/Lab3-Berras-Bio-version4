using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3_Berras_Bio_version4.Models
{
    public class MockTicketRepository : ITicketRepository
    {
        private readonly MockUserRepository mockUserRepository = new MockUserRepository();
        private readonly MockShowingRepository mockShowingRepository = new MockShowingRepository();
        public IEnumerable<Ticket> users =>
            new List<Ticket> 
            {
                new Ticket
                {
                    Id=1,
                    User=mockUserRepository.GetUserById(1),
                    Showing= mockShowingRepository.GetShowingById(1)
                },
                new Ticket
                {
                    Id=2,
                    User=mockUserRepository.GetUserById(2),
                    Showing= mockShowingRepository.GetShowingById(2)
                }
            };
        
        public Ticket GetTicketById(int ticketId)
        {
            return users.FirstOrDefault(ticket=>ticket.Id==ticketId);
        }
    }
}
