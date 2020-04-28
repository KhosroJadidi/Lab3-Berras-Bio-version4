using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Lab3_Berras_Bio_version4.Models;
using Lab3_Berras_Bio_version4.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lab3_Berras_Bio_version4.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public HomeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
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

        [HttpPost]
        public ActionResult RedirectToOnPostBookTicket( int showingId )
        {
            var name= new ClaimsPrincipal(User).Identity.Name;
            var userId = _appDbContext.Users.FirstOrDefault(user => user.UserName == name).Id;
            
            
            return RedirectToAction(actionName:"OnPostBookTicket",
                controllerName:"Ticket",
                routeValues:new {userId= userId, showingId=showingId});
        }
    }
}
