using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace atv_crud
{
    public static class Conexao
    {
        static MySqlConnection conexao;

        public static MySqlConnection Conectar()
        {
            try
            {
                string strconexao = "server=localhost;port=3360;uid=root;pwd=root;database=atv_crud";
                conexao = new MySqlConnection(strconexao);
                conexao.Open();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro de conexão {ex.Message}");
            }
            return conexao;
        }

        public static void FecharConexao()
        {
            conexao.Close();
        }
    }
}
