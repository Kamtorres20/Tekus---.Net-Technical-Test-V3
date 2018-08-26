using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Net_Technical_Test_V3.Models;
using Microsoft.EntityFrameworkCore;

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
        }

        public ActionResult SetResetDb(string db)
        {
            if (db == "in")
            {
                _context.Clients.RemoveRange();
                _context.Countrys.RemoveRange();
                _context.Services.RemoveRange();
                _context.SaveChanges();

                int cli = _context.Clients.Count();
                int ser = _context.Services.Count();

                List<Home> Listfilter = new List<Home>();
                var numberGroups = _context.Countrys.GroupBy(i => i.Name)
                   .Select(grp => new {
                       pais = grp.Key,
                       total = grp.Count(),
                   })
                   .ToArray();

                foreach (var item in numberGroups)
                {
                    Listfilter.Add(
                        new Home
                        {
                            CantClient = cli,
                            CantService = ser,
                            Country = item.pais,
                            CantServicexCountry = item.total,
                        });
                }

                if (Listfilter.Count == 0)
                {
                    Listfilter.Add(
                                new Home
                                {
                                    CantClient = cli,
                                    CantService = ser,
                                    Country = "No Hay Registro",
                                    CantServicexCountry = 0,
                                });
                }

                return PartialView("~/Views/Home/ListHome.cshtml", Listfilter);
                
            }
            else
            {
                return PartialView("~/Views/Home/ListHome.cshtml", HomeDAO.SetResetDB());
            }
            
        }


        public ActionResult GetDashboard(string db)
        {
            if (db == "in")
            {
                int cli = _context.Clients.Count();
                int ser = _context.Services.Count();

                List<Home> Listfilter = new List<Home>();
                var numberGroups = _context.Countrys.GroupBy(i => i.Name)
                   .Select(grp => new {
                       pais = grp.Key,
                       total = grp.Count(),                       
                   })
                   .ToArray();

                foreach (var  item in numberGroups)
                {
                    Listfilter.Add(
                        new Home
                        {
                            CantClient = cli,
                            CantService = ser,
                            Country = item.pais,
                            CantServicexCountry = item.total,
                        });
                }

                if (Listfilter.Count == 0)
                {
                    Listfilter.Add(
                                new Home
                                {
                                    CantClient = cli,
                                    CantService = ser,
                                    Country = "No Hay Registro",
                                    CantServicexCountry = 0,
                                });
                }

                return PartialView("~/Views/Home/ListHome.cshtml", Listfilter);

            }
            else
            {

                return PartialView("~/Views/Home/ListHome.cshtml", HomeDAO.SGetInfo());

            }
            
        }


    }
}
