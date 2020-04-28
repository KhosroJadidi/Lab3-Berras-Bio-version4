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
        private readonly AppDbContext _appDbContext;
        public HomeController(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public ViewResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                Showings = _appDbContext.Showings.
                    Include(showing =>showing.Auditorium).
                    Include(showing=>showing.Movie).
                    ToList()
            };
            return View(homeViewModel);
        }

        //[HttpPost]
        //public ActionResult OnPostBookTicket(int userId, int showingId)
        //{
        //    var user = _appDbContext.Users.
        //        FirstOrDefault(user=>user.Id==userId);

        //    var showing = _appDbContext.Showings.
        //        Include(showing=>showing.Movie).
        //        FirstOrDefault(showing=>showing.Id==showingId);

        //    //create ticket
        //    //https://stackoverflow.com/questions/30020892/taghelper-for-passing-route-values-as-part-of-a-link

        //    var ticket = new Ticket { Showing = showing, User = user };
        //    _appDbContext.Tickets.Add(ticket);            
        //    _appDbContext.SaveChanges();
        //    return View(ticket);
        //}
    }
}
