using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Net_Technical_Test_V3.Models
{
    public class HomeDAO
    {
        public static string SetResetDB(string db)
        {
            
            SqlCommand comm = Config.CreateCommand();
            comm.CommandText = "sp_Set_ResetDB";
            comm.Connection.Open();
            comm.ExecuteNonQuery();
            comm.Connection.Close();
            return "";
            
        }

   }
}
