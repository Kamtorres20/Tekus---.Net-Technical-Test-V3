using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Net_Technical_Test_V3.Models
{
    public class HomeDAO
    {
        public static List<Home> SetResetDB()
        {
            List<Home> ListHome = new List<Home>();
            SqlCommand comm = Config.CreateCommand();
            comm.CommandText = "sp_Set_ResetDB";
            comm.Connection.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                ListHome.Add(
                     new Home
                     {
                         CantClient = Convert.ToInt32(reader["CantClient"]),
                         CantService = Convert.ToInt32(reader["CantService"]),
                         Country = Convert.ToString(reader["Country"]),
                         CantServicexCountry = Convert.ToInt32(reader["CantServicexCountry"]),
                     });
            }
            comm.Connection.Close();


            return ListHome;

        }
        public static List<Home> SGetInfo()
        {
            List<Home> ListHome = new List<Home>();
            SqlCommand comm = Config.CreateCommand();
            comm.CommandText = "sp_GetInfo_Dashboard";
            comm.Connection.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                ListHome.Add(
                     new Home
                     {
                         id = Convert.ToInt32(reader["id"]),
                         CantClient = Convert.ToInt32(reader["CantClient"]),
                         CantService = Convert.ToInt32(reader["CantService"]),
                         Country = Convert.ToString(reader["Country"]),
                         CantServicexCountry = Convert.ToInt32(reader["CantServicexCountry"]),
                     });
            }
            comm.Connection.Close();


            return ListHome;

        }

    }
}
