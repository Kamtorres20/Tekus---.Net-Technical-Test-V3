using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Net_Technical_Test_V3.Models;

namespace Net_Technical_Test_V3.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        public IActionResult Index()
        {
            return View();
        }

        public HomeController(ApplicationDbContext context)
        {

            _context = context;
            if (!_context.Clients.Any())
            {
                _context.Clients.Add(new Client
                { Name = "Livier Torres", Email = "Kamtorres20@gmail.com", Nit = "123456" });
                _context.SaveChanges();
            }
        }

 

        public ActionResult GetClients(string id)
        {
            IEnumerable<Client>  cl = _context.Clients;

            ModelState.Clear();
            return PartialView("~/Views/Home/ListClients.cshtml", cl);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
