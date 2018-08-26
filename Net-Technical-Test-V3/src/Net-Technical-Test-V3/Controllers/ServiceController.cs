using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Net_Technical_Test_V3.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Net_Technical_Test_V3.Controllers
{
    public class ServiceController : Controller
    {
        private ApplicationDbContext _context;
        public ServiceController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult SetService(int id, string Name, string Horavlr, string db)
        {


            if (db == "in")
            {

                if (id == 0)
                {
                    _context.Services.Add(new Service
                    { Name = Name, hrsUSD = Horavlr });
                    _context.SaveChanges();
                }
                else
                {
                    var Service = _context.Services.FirstOrDefault(i => i.Id == id);
                    if (Service == null)
                        return NotFound();

                    Service.Name = Name;
                    Service.hrsUSD = Horavlr;
                    _context.Services.Update(Service);
                    _context.SaveChanges();
                }

                return PartialView("~/Views/Client/ListClients.cshtml", _context.Clients);
            }
            else
            {
                Service Serv = new Models.Service();
                Serv.Name = Name;
                Serv.hrsUSD = Horavlr;
               
                int acc = 0;
                if (id != 0) { acc = id; }


                return PartialView("~/Views/Client/ListClients.cshtml", ClientsDAO.SetClient(Serv, acc, id));
            }

        }
    }
}
