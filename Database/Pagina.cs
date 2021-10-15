using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Database
{
    public class Pagina
    {
        private string sqlConn()
        {
            return ConfigurationManager.AppSettings["SqlConn"];
        }
        public DataTable Lista()
        {
            //STRING CONEXAO DO SELECT NO SQL SERVER
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "select * from paginas";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);

                return table;


            }


        }
        //STRING INSERT NO BANCO NO SQL SERVER
        public void Salvar(int id, string nome, string conteudo, DateTime data)
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "insert into paginas(nome, data, conteudo) values('" + nome + "', '" + data.ToString("yyyy-MM-dd HH:mm:sss") + "' , '" + conteudo + "') ";

                if (id != 0)
                {
                    queryString = "update paginas set nome= '" + nome + "', data='" + data.ToString("yyyy-MM-dd HH:mm:sss") + "',conteudo='" + conteudo + "' where id=" + id;
                }

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
         
            
            }
        }

        //STRING DE EXCLUIR DO BANCO DE DADOS  
        public void Excluir(int id)
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))

            {
                string queryString = "delete from paginas where id=" + id;

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }


        }

        //STRING CONEXAO DO SELECT NO SQL SERVER
        //BUSCANDO PELO ID.
        public DataTable BuscaPorId(int id)
        {

            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "select * from paginas where id=" + id;
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);

                return table;


            }

        }
    }
  }