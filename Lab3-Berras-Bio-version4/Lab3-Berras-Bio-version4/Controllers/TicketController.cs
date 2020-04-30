using Lab3_Berras_Bio_version4.Models;
using Lab3_Berras_Bio_version4.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;

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
            return _appDbContext.Users
                .FirstOrDefault(user => user.UserName == new ClaimsPrincipal(User)
                    .Identity
                    .Name);
        }

        private bool UserCanBook()
        {
            return _appDbContext.Tickets.Count(ticket => ticket.User.UserName == GetThisUser().UserName)
                    < 12;
        }

        [HttpPost]
        public ActionResult OnPostBookingPreview(int showingId)
        {
            var showing = _appDbContext.Showings
                .Include(showing => showing.Movie)
                .Include(showing => showing.Auditorium)
                .FirstOrDefault(showingToSelect => showingToSelect.Id == showingId);

            //create ticket
            //https://stackoverflow.com/questions/30020892/taghelper-for-passing-route-values-as-part-of-a-link

            var ticket = new Ticket
            {
                Showing = showing,
                User = GetThisUser()
            };

            return (UserCanBook())
                ? View(ticket)
                : View(null);
        }

        public ViewResult OnPostGetUserTickets()
        {
            var ticketViewModel = new TicketViewModel
            {
                Tickets = _appDbContext.Tickets
                    .Include(ticket => ticket.Showing)
                    .Include(ticket => ticket.Showing.Movie)
                    .Include(ticket => ticket.Showing.Auditorium)
                    .Where(ticket => ticket.User.UserName == GetThisUser().UserName)
            };

            return View(ticketViewModel);
        }

        [HttpPost]
        public ActionResult OnPostConfirmBooking(int showingId)
        {
            var ticket = new Ticket
            {
                Showing = _appDbContext.Showings.FirstOrDefault(showing => showing.Id == showingId),
                User = GetThisUser()
            };
            _appDbContext.Tickets.Add(ticket);
            _appDbContext.Showings
                .FirstOrDefault(showing => showing.Id == showingId)
                .OccupiedSeats++;
            _appDbContext.SaveChanges();
            return View();
        }

        [HttpPost]
        public ActionResult OnPostRemoveBooking(int ticketId)
        {
            var ticket = _appDbContext.Tickets
                .Include(ticket => ticket.Showing)
                .FirstOrDefault(ticket => ticket.Id == ticketId);
            _appDbContext.Remove(ticket);
            var showingOnTicket = _appDbContext.Showings
                .FirstOrDefault(showing => showing.Id == ticket.Showing.Id);
            _appDbContext.Showings
                .FirstOrDefault(showing => showing.Id == showingOnTicket.Id)
                .OccupiedSeats--;
            _appDbContext.SaveChanges();
            return View();
        }
    }
}