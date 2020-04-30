using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Lab3_Berras_Bio_version4.Models;
using Lab3_Berras_Bio_version4.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab3_Berras_Bio_version4.Controllers
{
    [Authorize]
    public class TicketController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public TicketController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        private IdentityUser GetThisUser()
        {
            return _appDbContext.Users.
                FirstOrDefault(user => user.UserName == new ClaimsPrincipal(User).
                    Identity.
                    Name);
        }

        private bool UserCanBook()
        {
            return (_appDbContext.Tickets.Where(ticket => ticket.User.UserName == GetThisUser().UserName)
                .Count() < 12);
        }

        [HttpPost]
        public ActionResult OnPostBookingPreview(int showingId)
        {
            
            var showing = _appDbContext.Showings.Include(showing => showing.Movie)
                .Include(showing => showing.Auditorium)
                .FirstOrDefault(showingToSelect => showingToSelect.Id == showingId);

            //create ticket
            //https://stackoverflow.com/questions/30020892/taghelper-for-passing-route-values-as-part-of-a-link

            var ticket = new Ticket
            {
                Showing = showing,
                User = GetThisUser()
            };
#nullable enable
            Ticket? nullTicket = null;
#nullable disable
            return (UserCanBook())
                ? View(ticket)
                : View(nullTicket);
        }

        public ViewResult OnPostGetUserTickets()
        {
            var ticketViewModel = new TicketViewModel
            {
                Tickets = _appDbContext.Tickets.
                    Include(ticket=>ticket.Showing).
                    Include(ticket=>ticket.Showing.Movie).
                    Where(ticket => ticket.User.UserName == GetThisUser().UserName)
            };
            //var bookings = _appDbContext.Tickets.Where(ticket => ticket.User.UserName == GetThisUser().UserName).ToList();
            return View(ticketViewModel);
        }


    }
}
