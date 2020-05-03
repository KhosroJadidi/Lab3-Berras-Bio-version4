using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Lab3_Berras_Bio_version4.Models;
using Lab3_Berras_Bio_version4.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using Microsoft.AspNetCore.Routing;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
#nullable enable
        public ViewResult Index(string? orderBy)
        {
            switch (orderBy)
            {
                case "date":
                    var homeViewModelOrderedByDate = new HomeViewModel
                    {
                        Showings = GetAllShowings().OrderBy(showing=>showing.StartHour.Date)
                    };
                    return View(homeViewModelOrderedByDate);
                case "seats":
                    var homeViewModelOrderedBySeats = new HomeViewModel
                    {
                        Showings = GetAllShowings().OrderByDescending(showing => showing.Auditorium.AvailableSeats-showing.OccupiedSeats)
                    };
                    return View(homeViewModelOrderedBySeats);
                default:
                    var homeViewModel = new HomeViewModel
                    {
                        Showings = GetAllShowings()
                    };
                    return View(homeViewModel);
            }
        }
#nullable  disable
        private IEnumerable<Showing> GetAllShowings()
        {
            return _appDbContext.Showings.Include(showing => showing.Auditorium)
                .Include(showing => showing.Movie).ToList();
        }
    }
}
