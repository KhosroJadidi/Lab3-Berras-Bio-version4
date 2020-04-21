using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab3_Berras_Bio_version4.Models;
using Lab3_Berras_Bio_version4.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lab3_Berras_Bio_version4.Controllers
{
    public class HomeController : Controller
    {
        private readonly IShowingRepository showingRepository;
        public HomeController(IShowingRepository showingRepository)
        {
            this.showingRepository = showingRepository;
        }

        public ViewResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel();
            homeViewModel.Showings = showingRepository.Allshowings;
            return View(homeViewModel);
        }
    }
}
