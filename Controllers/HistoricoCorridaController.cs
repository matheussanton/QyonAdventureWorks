using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QyonAdventureWorks.Models;

namespace QyonAdventureWorks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoricoCorridaController : ControllerBase
    {

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
    }
}
