using System.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Net_Technical_Test_V3
{
    public class Config
    {
        private SqlConnection con;

        private static string connectionstring = "Data Source=DESKTOP-44TEPTJ\\SQLEXPRESS;Initial Catalog=TEKUSDB;Persist Security Info=True;User ID=sa;Password=euskadi;Connect Timeout=300;Max Pool Size=500";


        public static SqlCommand CreateCommand()
        {
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand comm = conn.CreateCommand();
            comm.CommandType = CommandType.StoredProcedure;
            return comm;
        }
        public static string ExecuteNonQuery(SqlCommand command)
        {

            string resul = "";
            try
            {
                command.Connection.Open();

                resul = command.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                command.Connection.Close();
            }

            return resul;
        }
    }
}
