using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab3_Berras_Bio_version4.Models;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPost]
        public ActionResult OnPostBookTicket(string userId, int showingId)
        {
            var user = _appDbContext.Users.
                FirstOrDefault(user => user.Id == userId);

            var showing = _appDbContext.Showings.
                Include(showing => showing.Movie).
                Include(showing=>showing.Auditorium).
                FirstOrDefault(showing => showing.Id == showingId);

            //create ticket
            //https://stackoverflow.com/questions/30020892/taghelper-for-passing-route-values-as-part-of-a-link

            var ticket = new Ticket { Showing = showing, User = user };
            
            _appDbContext.Tickets.Add(ticket);
            _appDbContext.SaveChanges();
            return View(ticket);
        }
    }
}
