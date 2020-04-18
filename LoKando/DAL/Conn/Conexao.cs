using System.Configuration;
using System.Data.SqlClient;

namespace LoKando.DAL.Conn
{
    public class Conexao
    {
        public SqlConnection ConexaoDatabase()
        {
            return new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        }
    }
}