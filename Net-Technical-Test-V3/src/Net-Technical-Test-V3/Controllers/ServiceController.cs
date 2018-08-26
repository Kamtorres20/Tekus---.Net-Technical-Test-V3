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

        public ActionResult SetService(int id, int idclient, string Name, string Horavlr, string db)
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

                return PartialView("~/Views/Service/ListService.cshtml", _context.Clients);
            }
            else
            {
                Service Serv = new Models.Service();
                Serv.Id = id;
                Serv.Id_client = idclient;
                Serv.Name = Name;
                Serv.hrsUSD = Horavlr;
               
                int acc = 0;
                if (id != 0) { acc = 1; }


                return PartialView("~/Views/Service/ListService.cshtml", ServiceDAO.SetService(Serv, acc));
            }

        }

        public ActionResult GetService(string db, int idclient)
        {
            if (db == "in")
            {
                return PartialView("~/Views/Service/ListService.cshtml", _context.Clients);

            }
            else
            {
                Service Serv = new Models.Service();
                Serv.Id = 0;
                Serv.Id_client = idclient;
                Serv.Name = "";
                Serv.hrsUSD = "";
                return PartialView("~/Views/Service/ListService.cshtml", ServiceDAO.SetService(Serv, 2));

            }
        }
    }
}
