

using System.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Net_Technical_Test_V3.Models
{
    public class ClientsDAO
    {
        
        public static List<Client> SetClient(Client datos,int acc,int id)
        {
            
            List<Client> Listclie = new List<Client>();
            SqlCommand comm = Config.CreateCommand();
            comm.CommandText = "sp_Set_Clients";
            comm.Parameters.Clear();
            comm.Parameters.AddWithValue("@id", id);
            comm.Parameters.AddWithValue("@Nit", datos.Nit);
            comm.Parameters.AddWithValue("@Name", datos.Name);
            comm.Parameters.AddWithValue("@Email", datos.Email);
            comm.Parameters.AddWithValue("@accion", acc);


            comm.Connection.Open();
             SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                Listclie.Add(
                     new Client
                     {
                         Id = Convert.ToInt32(reader["Id"]),
                         Nit = Convert.ToString(reader["Nit"]),
                         Name = Convert.ToString(reader["Name"]),
                         Email = Convert.ToString(reader["Email"]),
                     });
            }
            comm.Connection.Close();

            return Listclie;

        
        }
    }
}
