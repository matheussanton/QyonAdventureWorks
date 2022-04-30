using Npgsql;
using QyonAdventureWorks.Models;

namespace QyonAdventureWorks.Controllers
{
    public class PistaCorridaDB
    {

        public static List<PistaCorrida> GetPistas()
        {

            List<PistaCorrida> lista = new List<PistaCorrida>();

            try
            {
                NpgsqlConnection conexao = Conexao.OpenConexao();

                string sql = "SELECT * FROM pistacorrida ORDER BY Id";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                NpgsqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    PistaCorrida pista = new PistaCorrida()
                    {
                        Id = dr["Id"].ToString(),
                        Descricao = dr["Descricao"].ToString(),
                    };

                    lista.Add(pista);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro de SQL:" + e.Message);
                throw e;
            }

            return lista;
        }

        public static bool InsertPista(PistaCorrida pista)
        {
            var resultado = false;

            try
            {
                NpgsqlConnection conexao = Conexao.OpenConexao();

                string sql = "insert into pistacorrida (id,descricao)" +
                            "values (DEFAULT,@descricao)";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@descricao", NpgsqlTypes.NpgsqlDbType.Varchar).Value = pista.Descricao;
                int retorno = cmd.ExecuteNonQuery();

                if (retorno > 0)
                {
                    resultado = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro de SQL:" + e.Message);
                throw e;
            }

            return resultado;
        }

        public static bool AlterPista(PistaCorrida pista)
        {
            var resultado = false;

            try
            {
                NpgsqlConnection conexao = Conexao.OpenConexao();

                string sql = "update pistacorrida set descricao = @descricao " +
                    "where id = @id";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer).Value = Convert.ToInt32(pista.Id);
                cmd.Parameters.Add("@descricao", NpgsqlTypes.NpgsqlDbType.Varchar).Value = pista.Descricao;
                int retorno = cmd.ExecuteNonQuery();

                if (retorno > 0)
                {
                    resultado = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro de SQL:" + e.Message);
                throw e;
            }

            return resultado;
        }

        public static bool DeletePista(PistaCorrida pista)
        {
            var resultado = false;

            try
            {
                NpgsqlConnection conexao = Conexao.OpenConexao();

                string sql = "delete from pistacorrida " +
                    "where id = @id";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer).Value = Convert.ToInt32(pista.Id);
                int retorno = cmd.ExecuteNonQuery();

                if (retorno > 0)
                {
                    resultado = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro de SQL:" + e.Message);
                throw e;
            }

            return resultado;
        }

        public static List<PistaCorrida> GetPistasUtilizadas()
        {

            List<PistaCorrida> lista = new List<PistaCorrida>();

            try
            {
                NpgsqlConnection conexao = Conexao.OpenConexao();

                string sql = "SELECT * FROM pistacorrida p " +
                    "WHERE p.id in (" +
                    "SELECT DISTINCT pistacorridaid " +
                    "FROM historicocorrida)";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                NpgsqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    PistaCorrida pista = new PistaCorrida()
                    {
                        Id = dr["Id"].ToString(),
                        Descricao = dr["Descricao"].ToString(),
                    };

                    lista.Add(pista);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro de SQL:" + e.Message);
                throw e;
            }

            return lista;
        }
    }
}
