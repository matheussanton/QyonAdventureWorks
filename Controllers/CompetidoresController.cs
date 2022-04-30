using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QyonAdventureWorks.Models;
using Newtonsoft.Json;

namespace QyonAdventureWorks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetidoresController : ControllerBase
    {
        public static List<Competidores> lista = new List<Competidores>();

        [HttpGet]
        public List<Competidores> GetCompetidores()
        {
            return lista;
        }

        [HttpPost]
        public string PostCompetidores(Competidores competidores)
        {
            lista.Add(competidores);
            return "Estado cadastrado com sucesso";
        }

        [HttpPut]
        public string PutCompetidores(Competidores competidores)
        {
            Competidores competidorAux = lista.Where(x => x.Id == competidores.Id).FirstOrDefault();
            competidorAux.Nome = competidores.Nome;
            return "Estado alterado com sucesso";
        }


        [HttpDelete]
        public string DeleteCompetidores(Competidores competidores)
        {
            Competidores competidorAux = lista.Where(x => x.Id == competidores.Id).FirstOrDefault();
            lista.Remove(competidorAux);
            return "Estado excluído com sucesso";
        }

    }
}
