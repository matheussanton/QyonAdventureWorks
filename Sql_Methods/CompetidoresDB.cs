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


        public static List<CadastroCompetidorRetorno> InsertCompetidores(Competidores competidores)
        {

            try
            {
                bool problemaValidacao = false;

                string statusRetorno = "Erro";
                List<ProblemaCadastroCompetidor> problemasValidacao = ValidaDadosCompetidor(competidores);

                // se nao voltar nenhum, não há problemas de validação nos dados
                foreach (ProblemaCadastroCompetidor problema in problemasValidacao)
                {
                    problemaValidacao = true;
                }

                if (!problemaValidacao)
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
                        statusRetorno = "Sucesso";
                    }
                }
                else
                {
                    statusRetorno = "Erro";
                }

                List<CadastroCompetidorRetorno> retornoAlterCompetidores = new List<CadastroCompetidorRetorno>();
                retornoAlterCompetidores.Add(new CadastroCompetidorRetorno()
                {
                    Retorno = statusRetorno,
                    Problema = problemasValidacao
                });

                return retornoAlterCompetidores;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro de SQL:" + e.Message);
                throw e;
            }
        }

        public static List<CadastroCompetidorRetorno> AlterCompetidores(Competidores competidores)
        {
            try
            {
                bool problemaValidacao = false;

                string statusRetorno = "Erro";
                List<ProblemaCadastroCompetidor> problemasValidacao = ValidaDadosCompetidor(competidores);

                // se nao voltar nenhum, não há problemas de validação nos dados
                foreach (ProblemaCadastroCompetidor problema in problemasValidacao)
                {
                    problemaValidacao = true;
                }

                if (!problemaValidacao)
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
                        statusRetorno = "Sucesso";
                    }
                }
                else
                {
                    statusRetorno = "Erro";
                }

                List<CadastroCompetidorRetorno> retornoAlterCompetidores = new List<CadastroCompetidorRetorno>();
                retornoAlterCompetidores.Add(new CadastroCompetidorRetorno()
                {
                    Retorno = statusRetorno,
                    Problema = problemasValidacao
                });

                return retornoAlterCompetidores;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro de SQL:" + e.Message);
                throw e;
            }
        }

        public static List<ProblemaCadastroCompetidor> ValidaDadosCompetidor(Competidores competidores)
        {
            List<ProblemaCadastroCompetidor> problemasValidacao = new List<ProblemaCadastroCompetidor>();

            if (competidores.Nome == null)
            {
                problemasValidacao.Add(new ProblemaCadastroCompetidor() { Descricao = "Nome do competidor não pode ser nulo." });
            }

            if (competidores.TemperaturaMediaCorpo == null)
            {
                problemasValidacao.Add(new ProblemaCadastroCompetidor() { Descricao = "Temperatura média corporal do competidor não pode ser nula." });
            }
            else
            {
                var TempMedCorp = Convert.ToDouble(competidores.TemperaturaMediaCorpo);
                if (TempMedCorp < 36 || TempMedCorp > 38)
                {
                    problemasValidacao.Add(new ProblemaCadastroCompetidor() { Descricao = "Temperatura média corporal do competidor precisa estar entre 36 e 38." });
                }
            }

            if (competidores.Sexo == null)
            {
                problemasValidacao.Add(new ProblemaCadastroCompetidor() { Descricao = "Sexo do competidor não pode ser nulo." });
            }
            else
            {
                string SexoComp = competidores.Sexo.ToString();
                if (SexoComp != "M" && SexoComp != "F" && SexoComp != "O")
                {
                    problemasValidacao.Add(new ProblemaCadastroCompetidor() { Descricao = "Sexo do competidor não pode ser diferente de: M, F ou O." });
                }
            }

            if (competidores.Peso == null || competidores.Altura == null)
            {
                problemasValidacao.Add(new ProblemaCadastroCompetidor() { Descricao = "Peso ou Altura não podem ser nulos." });
            }
            else
            {
                var PesoComp = Convert.ToDouble(competidores.Peso);
                var AlturaComp = Convert.ToDouble(competidores.Altura);
                if (PesoComp <= 0 || AlturaComp <= 0)
                {
                    problemasValidacao.Add(new ProblemaCadastroCompetidor() { Descricao = "Altura ou Peso do competidor não pode ser valor negativo." });
                }
            }

            return problemasValidacao;
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

        public static List<Competidores> GetCompetirodresSemHistorico()
        {

            List<Competidores> lista = new List<Competidores>();

            try
            {
                NpgsqlConnection conexao = Conexao.OpenConexao();

                string sql = "SELECT * FROM competidores c " +
                    "WHERE c.id not in (" +
                    "SELECT DISTINCT competidorid " +
                    "FROM historicocorrida)";

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

        public static List<ListaTempoMedioCompetidoresRetorno> ListaTempoMedioCompetidores()
        {

            List<ListaTempoMedioCompetidoresRetorno> lista = new List<ListaTempoMedioCompetidoresRetorno>();

            try
            {
                NpgsqlConnection conexao = Conexao.OpenConexao();

                string sql = "SELECT COUNT(h.id) as QTD, SUM(h.tempogasto) as SomaTempos, c.id as Id, c.nome as Nome FROM historicocorrida h INNER JOIN competidores c on c.id = h.competidorid Group By c.id";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                NpgsqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    double Media = (Convert.ToDouble(dr["somatempos"]) / Convert.ToInt32(dr["qtd"]));
                    ListaTempoMedioCompetidoresRetorno ListaTempoMedioCompetidores = new ListaTempoMedioCompetidoresRetorno()
                    {
                        Id = dr["id"].ToString(),
                        Nome = dr["nome"].ToString(),
                        TempoMedio = Media.ToString()
                    };

                    lista.Add(ListaTempoMedioCompetidores);
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
