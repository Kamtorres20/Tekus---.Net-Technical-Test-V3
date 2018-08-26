using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Net_Technical_Test_V3.Models
{
    public class CountryDAO
    {
        public static List<Country> SetPais(Country datos, int acc)
        {

            List<Country> ListCountry = new List<Country>();
            SqlCommand comm = Config.CreateCommand();
            comm.CommandText = "sp_Set_Pais";
            comm.Parameters.Clear();
            comm.Parameters.AddWithValue("@id", datos.Id);
            comm.Parameters.AddWithValue("@Id_Serv", datos.Id_serv);
            comm.Parameters.AddWithValue("@Name", datos.Name);
           

            comm.Parameters.AddWithValue("@accion", acc);


            comm.Connection.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                ListCountry.Add(
                     new Country
                     {
                         Id = Convert.ToInt32(reader["Id"]),
                         Id_serv = Convert.ToInt32(reader["Id_Service"]),
                         Name = Convert.ToString(reader["Pais"]),                        
                     });
            }
            comm.Connection.Close();

            return ListCountry;


        }
    }
}
