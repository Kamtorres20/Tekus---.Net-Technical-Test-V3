using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Net_Technical_Test_V3.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Net_Technical_Test_V3.Controllers
{

   
    public class ClientController : Controller
    {
        private ApplicationDbContext _context;
        public IActionResult Index()
        {
            return View();
        }
        // GET: /<controller>/
        public ClientController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult SetClients(int id, string Name, string Email, string Nit, string db)
        {


            if (db == "in")
            {

                if (id == 0)
                {
                    _context.Clients.Add(new Client
                    { Name = Name, Email = Email, Nit = Nit });
                    _context.SaveChanges();
                }
                else
                {
                    var Client = _context.Clients.FirstOrDefault(i => i.Id == id);
                    if (Client == null)
                        return NotFound();

                    Client.Name = Name;
                    Client.Nit = Nit;
                    Client.Email = Email;

                    _context.Clients.Update(Client);
                    _context.SaveChanges();
                }

                return PartialView("~/Views/Client/ListClients.cshtml", _context.Clients);
            }
            else
            {
                Client cli = new Models.Client();
                cli.Nit = Nit;
                cli.Name = Name;
                cli.Email = Email;
                int acc = 0;
                if (id != 0){acc = 1; }
                  

                return PartialView("~/Views/Client/ListClients.cshtml", ClientsDAO.SetClient(cli, acc, id));
            }

        }


        public ActionResult GetClients(string db,string acc)
        {
            if (db == "in")
            {
                return PartialView("~/Views/Client/ListClients.cshtml", _context.Clients);

            }
            else
            {
                Client cli = new Models.Client();
                cli.Nit = "";
                cli.Name = "";
                cli.Email = "";
                return PartialView("~/Views/Client/ListClients.cshtml", ClientsDAO.SetClient(cli, 2, 0));

            }
        }

   
    }
}
