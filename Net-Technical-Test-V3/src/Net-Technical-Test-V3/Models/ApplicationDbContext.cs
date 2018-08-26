using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Net_Technical_Test_V3.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> context) : base(context)
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Service> Services { get; set; }

        public DbSet<Country> Countrys { get; set; }
    }
}
