using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Tekus___.Net_Technical_Test_V3.Controllers
{
    public class ClientController : Controller
    {
        // GET: /<controller>/

        private Models.ApplicationDbContext _context;
        public IActionResult Index()
        {
            return View();
        }

        public ClientController(Models.ApplicationDbContext context)
        {

            _context = context;
            if (!_context.Clients.Any())
            {
                _context.Clients.Add(new Models.Client
                { Nit ="123456", Name = "Event Management", Email = "Shweta" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Models.Client> GetWorkshops()
        {
            return _context.Clients;
        }
    }
}
