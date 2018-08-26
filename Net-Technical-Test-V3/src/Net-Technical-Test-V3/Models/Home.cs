using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net_Technical_Test_V3.Models
{
    public class Home
    {
        public int id { get; set; }
        public int CantClient { get; set; }
        public int CantService { get; set; }
        public string Country { get; set; }
        public int CantServicexCountry { get; set; }
    }
}
