using System.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Net_Technical_Test_V3.Models
{
    public class ServiceDAO
    {

        public static List<Service> SetService(Service datos, int acc)
        {

            List<Service> Listserv = new List<Service>();
            SqlCommand comm = Config.CreateCommand();
            comm.CommandText = "sp_Set_Services";
            comm.Parameters.Clear();
            comm.Parameters.AddWithValue("@id", datos.Id);
            comm.Parameters.AddWithValue("@Id_Client", datos.Id_client);
            comm.Parameters.AddWithValue("@Name", datos.Name);
            comm.Parameters.AddWithValue("@HraUsd", datos.hrsUSD);
            comm.Parameters.AddWithValue("@accion", acc);


            comm.Connection.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                Listserv.Add(
                     new Service
                     {
                         Id = Convert.ToInt32(reader["Id"]),
                         Id_client = Convert.ToInt32(reader["Id_Client"]),
                         Name = Convert.ToString(reader["Name"]),
                         hrsUSD = Convert.ToString(reader["HraUsd"]),
                     });
            }
            comm.Connection.Close();

            return Listserv;


        }

    }
}
