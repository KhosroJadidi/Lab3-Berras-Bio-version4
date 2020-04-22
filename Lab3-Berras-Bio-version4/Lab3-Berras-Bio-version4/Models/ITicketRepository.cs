using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3_Berras_Bio_version4.Models
{
    public interface ITicketRepository
    {
        IEnumerable<Ticket> Alltickets { get; }
        Ticket GetTicketById(int ticketId);
    }
}
