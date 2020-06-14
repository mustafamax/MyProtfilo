using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork<Onwer> _owner;

        public IUnitOfWork<PortfilioItem> _Portfolio { get; }

        public HomeController(
            IUnitOfWork<Onwer> owner,
            IUnitOfWork<PortfilioItem> portfolio
            )
        {
            _owner = owner;
            _Portfolio = portfolio;
        }
        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                Owner = _owner.Entity.GetAll().First(),
                PortfilioItems = _Portfolio.Entity.GetAll().ToList()
        };

            return View(homeViewModel);
        }
        public IActionResult About()
        {
            return View();
        }
    }
}
