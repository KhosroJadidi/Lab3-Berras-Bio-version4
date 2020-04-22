using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3_Berras_Bio_version4.Models
{
    public class TicketRepository : ITicketRepository
    {
        private readonly AppDbContext appDbContext;

        public TicketRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<Ticket> Alltickets => appDbContext.Tickets;

        //public IEnumerable<Ticket> Alltickets 
        //{
        //    get 
        //    {
        //        return appDbContext.Tickets;
        //    }
        //}

        public Ticket GetTicketById(int ticketId)
        {
            return appDbContext.Tickets.FirstOrDefault(ticket=>ticket.Id==ticketId);
        }
    }
}
