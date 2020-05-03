using System.Collections.Generic;
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

        [HttpPost]
        public ActionResult OnPostBookingPreview(int showingId)
        {
            var showPreview = GetPreviewById(showingId);
            if (showPreview.BookableSeats>0)
            {
                var preview = new Preview
                {
                    Showing = showPreview.Showing,
                    User = GetThisUser(),
                    BookableSeats=showPreview.BookableSeats
                };
                return View(preview);
            }
            return View(null);
        }

        [HttpPost]
        public ActionResult OnPostConfirmBooking(int showingId, int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                var ticket = new Ticket
                {
                    Showing = GetPreviewById(showingId).Showing,
                    User = GetThisUser()
                };
                _appDbContext.Tickets.Add(ticket);
                _appDbContext.Showings
                    .FirstOrDefault(showing => showing.Id == showingId)
                    .OccupiedSeats++;
            }
            _appDbContext.SaveChanges();
            return View();
        }
#nullable enable
        public ViewResult OnPostGetUserTickets(string? orderBy)
        {
            switch (orderBy)
            {
                case "date":
                    var homeViewModelOrderedByDate = new TicketViewModel
                    {
                        Tickets = GetAllTickets()
                            .OrderBy(ticket=>ticket.Showing.StartHour.Date)
                    };
                    return View(homeViewModelOrderedByDate);
                case "seats":
                    var homeViewModelOrderedBySeats = new TicketViewModel
                    {
                        Tickets = GetAllTickets()
                            .OrderByDescending(ticket => ticket.Showing.Auditorium.AvailableSeats-ticket.Showing.OccupiedSeats)
                    };
                    return View(homeViewModelOrderedBySeats);
                default:
                    var homeViewModel = new TicketViewModel
                    {
                        Tickets = GetAllTickets()
                    };
                    return View(homeViewModel);
            }
        }
#nullable  disable
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

        private IdentityUser GetThisUser()
        {
            return _appDbContext.Users
                .FirstOrDefault(user => user.UserName == new ClaimsPrincipal(User)
                    .Identity
                    .Name);
        }
        
        private Preview GetPreviewById(int showingId)
        {
            var thisShowing = _appDbContext.Showings
                .Include(showing => showing.Movie)
                .Include(showing => showing.Auditorium)
                .FirstOrDefault(showingToSelect => showingToSelect.Id == showingId);
            var availableSeats = thisShowing.Auditorium.AvailableSeats - thisShowing.OccupiedSeats;
            var userOpenSlots =
                12 - _appDbContext.Tickets.Count(ticket => ticket.User.UserName == GetThisUser().UserName);
            var bookableSeats = (availableSeats >= userOpenSlots) ? userOpenSlots : availableSeats;
            var returnObject= new Preview
            {
                Showing = thisShowing,
                BookableSeats = bookableSeats
            };
            return returnObject;
        }

        private IEnumerable<Ticket> GetAllTickets()
        {
            return _appDbContext.Tickets
                .Include(ticket => ticket.Showing)
                .Include(ticket => ticket.Showing.Movie)
                .Include(ticket => ticket.Showing.Auditorium)
                .Where(ticket => ticket.User.UserName == GetThisUser().UserName);
        }
    }
}