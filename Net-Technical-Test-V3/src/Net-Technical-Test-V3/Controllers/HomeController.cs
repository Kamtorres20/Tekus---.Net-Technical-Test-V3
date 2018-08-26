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
            
            return PartialView("~/Views/Home/ListHome.cshtml", HomeDAO.SetResetDB());
        }

        public ActionResult GetDashboard(string db)
        {
            if (db == "in")
            {

                return PartialView("~/Views/Home/ListHome.cshtml", HomeDAO.SGetInfo());

            }
            else
            {

                return PartialView("~/Views/Home/ListHome.cshtml", HomeDAO.SGetInfo());

            }
            
        }


    }
}
