using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QyonAdventureWorks.Models;

namespace QyonAdventureWorks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListaPistasUtilizadasController : ControllerBase
    {

        //Lista Pistas Utilizadas
        [HttpGet]
        public List<PistaCorrida> GetPistasUtilizadas()
        {
            var lista = PistaCorridaDB.GetPistasUtilizadas();
            return lista;
        }
    }
}
