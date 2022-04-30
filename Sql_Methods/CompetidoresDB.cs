using Npgsql;
using QyonAdventureWorks.Models;

namespace QyonAdventureWorks.Controllers
{
    public class competidoresDB
    {

        public static List<Competidores> GetCompetidores()
        {

            List<Competidores> lista = new List<Competidores>();

            try
            {
                NpgsqlConnection conexao = Conexao.OpenConexao();

                string sql = "SELECT * FROM competidores ORDER BY Id";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                NpgsqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Competidores competidores = new Competidores()
                    {
                        Id = dr["Id"].ToString(),
                        Nome = dr["Nome"].ToString(),
                        Sexo = dr["Sexo"].ToString(),
                        TemperaturaMediaCorpo = dr["TemperaturaMediaCorpo"].ToString(),
                        Peso = dr["Peso"].ToString(),
                        Altura = dr["Altura"].ToString()
                    };

                    lista.Add(competidores);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro de SQL:" + e.Message);
                throw e;
            }

            return lista;
        }


        public static bool InsertCompetidores(Competidores competidores)
        {
            var resultado = false;

            try
            {
                NpgsqlConnection conexao = Conexao.OpenConexao();

                string sql = "insert into competidores (id,nome,sexo,temperaturamediacorpo,peso,altura)" +
                    "values (DEFAULT,@nome,@sexo,@temperaturamediacorpo,@peso,@altura)";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@nome", NpgsqlTypes.NpgsqlDbType.Varchar).Value = competidores.Nome;
                cmd.Parameters.Add("@sexo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = competidores.Sexo;
                cmd.Parameters.Add("@temperaturamediacorpo", NpgsqlTypes.NpgsqlDbType.Numeric).Value = Convert.ToDouble(competidores.TemperaturaMediaCorpo);
                cmd.Parameters.Add("@peso", NpgsqlTypes.NpgsqlDbType.Numeric).Value = Convert.ToDouble(competidores.Peso);
                cmd.Parameters.Add("@altura", NpgsqlTypes.NpgsqlDbType.Numeric).Value = Convert.ToDouble(competidores.Altura);
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

        public static bool AlterCompetidores(Competidores competidores)
        {
            var resultado = false;

            try
            {
                NpgsqlConnection conexao = Conexao.OpenConexao();

                string sql = "update competidores set nome = @nome, sexo = @sexo, temperaturamediacorpo = @temperaturamediacorpo, peso = @peso, altura = @altura " +
                    "where id = @id";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer).Value = Convert.ToInt32(competidores.Id);
                cmd.Parameters.Add("@nome", NpgsqlTypes.NpgsqlDbType.Varchar).Value = competidores.Nome;
                cmd.Parameters.Add("@sexo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = competidores.Sexo;
                cmd.Parameters.Add("@temperaturamediacorpo", NpgsqlTypes.NpgsqlDbType.Numeric).Value = Convert.ToDouble(competidores.TemperaturaMediaCorpo);
                cmd.Parameters.Add("@peso", NpgsqlTypes.NpgsqlDbType.Numeric).Value = Convert.ToDouble(competidores.Peso);
                cmd.Parameters.Add("@altura", NpgsqlTypes.NpgsqlDbType.Numeric).Value = Convert.ToDouble(competidores.Altura);
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

        public static bool DeleteCompetidores(Competidores competidores)
        {
            var resultado = false;

            try
            {
                NpgsqlConnection conexao = Conexao.OpenConexao();

                string sql = "delete from competidores " +
                    "where id = @id";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer).Value = Convert.ToInt32(competidores.Id);
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

    }
}
