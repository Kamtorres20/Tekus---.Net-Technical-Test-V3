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

        public ActionResult SetCountry(int id, int idServ, string pais, string db)
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

                List<Country> Listfilter = new List<Country>();

                foreach (Country item in _context.Countrys.Where(i => i.Id_serv == idServ))
                {
                    Listfilter.Add(
                        new Country
                        {
                            Id = item.Id,
                            Id_serv = item.Id_serv,
                            Name = item.Name,
                        });
                }
                return PartialView("~/Views/Country/ListCountry.cshtml", Listfilter);

                
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

        public ActionResult GetCountry(string db, int idserv)
        {
            if (db == "in")
            {

                List<Country> Listfilter = new List<Country>();

                foreach (Country item in _context.Countrys.Where(i => i.Id_serv == idserv))
                {
                    Listfilter.Add(
                        new Country
                        {
                            Id = item.Id,
                            Id_serv = item.Id_serv,
                            Name = item.Name,                            
                        });
                }
                return PartialView("~/Views/Country/ListCountry.cshtml", Listfilter);

            }
            else
            {
                Country Country = new Models.Country();
                Country.Id = 0;
                Country.Id_serv = idserv;
                Country.Name = "";
                

                return PartialView("~/Views/Country/ListCountry.cshtml", CountryDAO.SetPais(Country, 2));

            }
        }
    }
}
