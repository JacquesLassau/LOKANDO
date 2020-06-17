using System.Data.SqlClient;
using System.Configuration;
using System;

namespace LoKando.DAL.Conn
{
    public class Conexao
    {        
        private String connString = ConfigurationManager.ConnectionStrings["c22cea0060c8be6d840cf930d784e07b"].ConnectionString;
        public SqlConnection ConexaoDatabase()
        {
            return new SqlConnection(connString);
        }
    }
}