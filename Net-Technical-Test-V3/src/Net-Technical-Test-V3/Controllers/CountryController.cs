using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Net_Technical_Test_V3.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Net_Technical_Test_V3.Controllers
{
    public class CountryController : Controller
    {
        // GET: /<controller>/
        private ApplicationDbContext _context;
        public CountryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult SetPais(int id, int idServ, string pais, string db)
        {


            if (db == "in")
            {

                if (id == 0)
                {
                    _context.Countrys.Add(new Country
                    { Name = pais, Id = id, Id_serv = idServ });
                    _context.SaveChanges();
                }
                else
                {
                    var Countrys = _context.Countrys.FirstOrDefault(i => i.Id == id);
                    if (Countrys == null)
                        return NotFound();
                    Countrys.Id = id;
                    Countrys.Name = pais;
                    Countrys.Id_serv = idServ;

                    _context.Countrys.Update(Countrys);
                    _context.SaveChanges();
                }

                return PartialView("~/Views/Country/ListCountry.cshtml", _context.Clients);
            }
            else
            {
                Country Country = new Models.Country();
                Country.Id = id;
                Country.Id_serv = idServ;
                Country.Name = pais;


                int acc = 0;
                if (id != 0) { acc = 1; }


                return PartialView("~/Views/Country/ListCountry.cshtml", CountryDAO.SetPais(Country, acc));
            }

        }

        public ActionResult GetService(string db, int idserv)
        {
            if (db == "in")
            {
                return PartialView("~/Views/Country/ListCountry.cshtml", _context.Clients);

            }
            else
            {
                Service Serv = new Models.Service();
                Serv.Id = 0;
                Serv.Id_client = idserv;
                Serv.Name = "";
                Serv.hrsUSD = "";

                return PartialView("~/Views/Country/ListCountry.cshtml", ServiceDAO.SetService(Serv, 2));

            }
        }
    }
}
