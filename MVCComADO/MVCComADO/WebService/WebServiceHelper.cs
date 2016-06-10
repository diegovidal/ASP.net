using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MVCComADO.Models;
using System.Data;

namespace MVCComADO.WebService
{
    class WebServiceHelper
    {

        private SqlConnection con;

        private void Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["MyDbConn1"].ToString();
            this.con = new SqlConnection(constr);
        }

        // Adiciona um time
        public bool AdicionaTime(Time time)
        {
            Connection();
            int i;

            using(SqlCommand command  = new SqlCommand("incluirTime", this.con))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@nome", time.Nome);
                command.Parameters.AddWithValue("@estado", time.Estado);
                command.Parameters.AddWithValue("@cores", time.Cores);

                this.con.Open();
                i = command.ExecuteNonQuery();

            }

            this.con.Close();

            return i >= 1;

        }

        // Lista os times
        public List<Time> ObterTimes() {

            Connection();
            List<Time> times = new List<Time>();

            //using (SqlCommand command = new SqlCommand("obterTimes", this.con))
            using (SqlCommand command = new SqlCommand("SELECT * FROM Time", this.con))
            {
                //command.CommandType = CommandType.StoredProcedure;
                this.con.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Time time = new Time
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Nome = Convert.ToString(reader["nome"]),
                        Estado = Convert.ToString(reader["estado"]),
                        Cores = Convert.ToString(reader["cores"])
                    };

                    times.Add(time);

                }

                this.con.Close();
                return times;
            }
        }

        // Atualiza um time
        public bool AtualizarTime(Time time)
        {
            Connection();
            int i;

            using (SqlCommand command = new SqlCommand("atualizarTime", this.con))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@id", time.Id);
                command.Parameters.AddWithValue("@nome", time.Nome);
                command.Parameters.AddWithValue("@estado", time.Estado);
                command.Parameters.AddWithValue("@cores", time.Cores);

                this.con.Open();
                i = command.ExecuteNonQuery();

            }

            this.con.Close();

            return i >= 1;

        }

        // Exclui um time
        public bool ExcluirTime(int id)
        {
            Connection();
            int i;

            using (SqlCommand command = new SqlCommand("excluirTimePorId", this.con))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@id", id);
                

                this.con.Open();
                i = command.ExecuteNonQuery();

            }

            this.con.Close();
            return i >= 1;
           

        }

         


    }
}