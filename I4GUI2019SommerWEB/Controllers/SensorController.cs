using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using I4GUI2019SommerWEB.Data;
using I4GUI2019SommerWEB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace I4GUI2019SommerWEB.Controllers
{
    [Authorize]
    public class SensorController : Controller
    {
        private ApplicationDbContext _context;

        public SensorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            
            return View(_context.Sensors);
        }

        [HttpGet]
        public IActionResult Create(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = _context.Locations.SingleOrDefault(m => m.LocationId == id);
            if (location == null)
            {
                return NotFound();
            }

            var sensor = new Sensor
            {
                LocationId = (int)id
            };
            
            return View(sensor);
        }

        [HttpPost]
        public IActionResult Create([Bind("SensorId,LocationId,TreeSort,Latitude,Longitude")] Sensor sensor)
        {
            if (ModelState.IsValid)
            {
                _context.Sensors.Add(sensor);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index), "Sensor");
            }
            return View();
        }
    }
}
