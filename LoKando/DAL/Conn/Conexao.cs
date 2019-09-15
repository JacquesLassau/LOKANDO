using System.Data.SqlClient;
using System.Configuration;

namespace LoKando.DAL.Conn
{
    public class Conexao
    {
        private const string stringConn = @"Server=DESKTOP-1T99VF9; Database=DB_LOKANDO; User Id=sa; Password=123@qwe;";

        public SqlConnection ConexaoDatabase()
        {
            return new SqlConnection(stringConn);
        }
    }
}