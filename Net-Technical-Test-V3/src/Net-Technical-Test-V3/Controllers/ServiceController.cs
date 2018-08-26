using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Net_Technical_Test_V3.Models;
using Microsoft.EntityFrameworkCore;

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
                    { Name = Name, hrsUSD = Horavlr,Id_client= idclient });
                    _context.SaveChanges();
                }
                else
                {
                    var Service = _context.Services.FirstOrDefault(i => i.Id == id );
                    if (Service == null)
                        return NotFound();

                    Service.Name = Name;
                    Service.hrsUSD = Horavlr;
                   
                    _context.Services.Update(Service);
                    _context.SaveChanges();
                }

                return PartialView("~/Views/Service/ListService.cshtml", _context.Services);
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

                List<Service> Listfilter = new List<Service>();
                
                foreach (Service item in _context.Services.Where(i=> i.Id_client == idclient))
                {
                    Listfilter.Add(
                        new Service
                        {
                            Id = item.Id,
                            Id_client = item.Id_client,
                            Name = item.Name,
                            hrsUSD = item.hrsUSD
                        });
                }
                return PartialView("~/Views/Service/ListService.cshtml", Listfilter);
              
               

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
