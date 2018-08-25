using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Net_Technical_Test_V3.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Net_Technical_Test_V3.Controllers
{

   
    public class ClientController : Controller
    {
        private ApplicationDbContext _context;
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public  ClientController(ApplicationDbContext context)
        {

            _context = context;
            if (!_context.Clients.Any())
            {
                _context.Clients.Add(new Client
                { Name = "Livier Torres", Email = "Kamtorres20@gmail.com",Nit="123456" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Client> GetClients()
        {
            return _context.Clients;
        }
    }
}
