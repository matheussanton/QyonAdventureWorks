using Npgsql;

namespace QyonAdventureWorks.Controllers
{
    public class Conexao
    {
        public static NpgsqlConnection OpenConexao()
        {
            NpgsqlConnection conexao = null;

            try
            {
                conexao = new NpgsqlConnection("Server=localhost;Port=5432;User Id=postgres;Password=admin;Database=qyonadventureworks;");
                conexao.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro de conexao:" + e.Message);
                throw e;
            }

            return conexao;
        }

        public static void CloseConexao(NpgsqlConnection conexao)
        {

            if (conexao != null)
            {
                try
                {
                    conexao.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Erro de fechamento da conexao:" + e.Message);
                    throw e;
                }
            }

        }
    }
}
