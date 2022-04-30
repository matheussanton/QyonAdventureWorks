using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QyonAdventureWorks.Models;

namespace QyonAdventureWorks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoricoCorridaController : ControllerBase
    {

        //Lista HistoricoCorrida
        [HttpGet]
        public List<HistoricoCorrida> GetHistoricoCorrida()
        {
            var lista = HistoricoCorridaDB.GetHistoricoCorrida();
            return lista;
        }

        //Insere HistoricoCorrida
        [HttpPost]
        public string PostCompetidores(HistoricoCorrida historico)
        {
            bool result = HistoricoCorridaDB.InsertHistoricoCorrida(historico);
            if (result)
            {
                return "Historico cadastrado com sucesso";
            }
            else
            {
                return "Erro ao cadastrar Historico";
            }
        }

        //Altera HistoricoCorrida
        [HttpPut]
        public string PutHistoricoCorrida(HistoricoCorrida historico)
        {
            bool result = HistoricoCorridaDB.AlterHistoricoCorrida(historico);
            if (result)
            {
                return "Historico alterado com sucesso";
            }
            else
            {
                return "Erro ao cadastrar Historico";
            }
        }

        ////Deleta HistoricoCorrida
        //[HttpDelete]
        //public string DeleteHistoricoCorrida(HistoricoCorrida historico)
        //{
        //    bool result = HistoricoCorridaDB.DeleteHistoricoCorrida(historico);
        //    if (result)
        //    {
        //        return "Historico excluído com sucesso";
        //    }
        //    else
        //    {
        //        return "Erro ao cadastrar Historico";
        //    }
        //}
    }
}
