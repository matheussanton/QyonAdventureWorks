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
            string result = HistoricoCorridaDB.InsertHistoricoCorrida(historico);
            return result;
        }

        //Altera HistoricoCorrida
        [HttpPut]
        public string PutHistoricoCorrida(HistoricoCorrida historico)
        {
            string result = HistoricoCorridaDB.AlterHistoricoCorrida(historico);
            return result;
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
