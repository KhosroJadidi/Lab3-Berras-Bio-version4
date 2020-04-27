using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab3_Berras_Bio_version4.Models;
using Lab3_Berras_Bio_version4.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lab3_Berras_Bio_version4.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext appDbContext;
        public HomeController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public ViewResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel();
            homeViewModel.Showings = appDbContext.Showings.
                Include(showing=>showing.Movie).
                ToList();
            return View(homeViewModel);
        }

        [HttpPost]
        public ActionResult OnPostBookTicket(int userId, int showingId)
        {
            var user = appDbContext.Users.
                FirstOrDefault(user=>user.Id==userId);

            var showing = appDbContext.Showings.
                Include(showing=>showing.Movie).
                FirstOrDefault(showing=>showing.Id==showingId);

            //create ticket
            //https://stackoverflow.com/questions/30020892/taghelper-for-passing-route-values-as-part-of-a-link

            var ticket = new Ticket { Showing = showing, User = user };
            appDbContext.Tickets.Add(ticket);            
            appDbContext.SaveChanges();
            return View(ticket);
        }
    }
}
