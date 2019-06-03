using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using I4GUI2019SommerWEB.Data;
using Microsoft.AspNetCore.Mvc;
using I4GUI2019SommerWEB.Models;
using Microsoft.AspNetCore.Authorization;

namespace I4GUI2019SommerWEB.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View(_context.Locations);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Filter(string filter)
        {
            if (filter != null)
            {
                return View("Index", _context.Locations.Where(x => x.Name.Contains(filter)));
            }
            return View("Index", _context.Locations);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
