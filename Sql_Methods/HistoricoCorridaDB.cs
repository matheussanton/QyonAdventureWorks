﻿using Npgsql;
using QyonAdventureWorks.Models;
using System.Globalization;

namespace QyonAdventureWorks.Controllers
{
    public class HistoricoCorridaDB
    {

        public static string InsertHistoricoCorrida(HistoricoCorrida historico)
        {
            var resultado = "Erro";

            try
            {
                if (Convert.ToDateTime(historico.DataCorrida) > DateTime.Now)
                {
                    resultado = "Erro ao cadastrar histórico: Data da corrida não pode ser uma data futura.";
                    return resultado;
                }
                else
                {
                    NpgsqlConnection conexao = Conexao.OpenConexao();

                    string sql = "insert into HistoricoCorrida (id,competidorId,pistaCorridaId,dataCorrida,tempoGasto)" +
                        " values (DEFAULT,@competidorId,@pistaCorridaId,@dataCorrida,@tempoGasto)";

                    NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                    cmd.Parameters.Add("@competidorId", NpgsqlTypes.NpgsqlDbType.Integer).Value = Convert.ToInt32(historico.CompetidorId);
                    cmd.Parameters.Add("@pistaCorridaId", NpgsqlTypes.NpgsqlDbType.Integer).Value = Convert.ToInt32(historico.PistaCorridaId);
                    cmd.Parameters.Add("@dataCorrida", NpgsqlTypes.NpgsqlDbType.Date).Value = Convert.ToDateTime(historico.DataCorrida);
                    cmd.Parameters.Add("@tempoGasto", NpgsqlTypes.NpgsqlDbType.Numeric).Value = Convert.ToDouble(historico.TempoGasto);
                    int retorno = cmd.ExecuteNonQuery();

                    if (retorno > 0)
                    {
                        resultado = "Sucesso ao cadastrar histórico";
                        return resultado;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro de SQL:" + e.Message);
                throw e;
            }

            return resultado;
        }

        public static string AlterHistoricoCorrida(HistoricoCorrida historico)
        {
            var resultado = "Erro";

            try
            {
                if (Convert.ToDateTime(historico.DataCorrida) > DateTime.Now)
                {
                    resultado = "Erro ao alterar histórico: Data da corrida não pode ser uma data futura.";
                    return resultado;
                }
                else
                {
                    NpgsqlConnection conexao = Conexao.OpenConexao();

                    string sql = "update historicocorrida set competidorId = @competidorId, pistaCorridaId = @pistaCorridaId, dataCorrida = @dataCorrida, tempoGasto = @tempoGasto " +
                        "where id = @id";

                    NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                    cmd.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer).Value = Convert.ToInt32(historico.Id);
                    cmd.Parameters.Add("@competidorId", NpgsqlTypes.NpgsqlDbType.Integer).Value = Convert.ToInt32(historico.CompetidorId);
                    cmd.Parameters.Add("@pistaCorridaId", NpgsqlTypes.NpgsqlDbType.Integer).Value = Convert.ToInt32(historico.PistaCorridaId);
                    cmd.Parameters.Add("@dataCorrida", NpgsqlTypes.NpgsqlDbType.Date).Value = Convert.ToDateTime(historico.DataCorrida);
                    cmd.Parameters.Add("@tempoGasto", NpgsqlTypes.NpgsqlDbType.Numeric).Value = Convert.ToDouble(historico.TempoGasto);
                    int retorno = cmd.ExecuteNonQuery();

                    if (retorno > 0)
                    {
                        resultado = "Sucesso ao alterar histórico";
                        return resultado;
                    }
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
