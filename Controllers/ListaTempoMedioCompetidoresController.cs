using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QyonAdventureWorks.Models;

namespace QyonAdventureWorks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListaTempoMedioCompetidoresController : ControllerBase
    {

        //Lista competidores
        [HttpGet]
        public List<ListaTempoMedioCompetidoresRetorno> ListaTempoMedioCompetidores()
        {
            var lista = competidoresDB.ListaTempoMedioCompetidores();
            return lista;
        }

    }
}
