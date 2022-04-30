using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QyonAdventureWorks.Models;

namespace QyonAdventureWorks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListaCompetidoresSemHistoricoController : ControllerBase
    {
        //Lista Competidores que não participaram de nenhuma corrida
        [HttpGet]
        public List<Competidores> GetCompetirodresSemHistorico()
        {
            var lista = competidoresDB.GetCompetirodresSemHistorico();
            return lista;
        }
    }
}
