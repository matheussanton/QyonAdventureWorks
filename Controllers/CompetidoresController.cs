using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QyonAdventureWorks.Models;

namespace QyonAdventureWorks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetidoresController : ControllerBase
    {

        //Lista competidores
        [HttpGet]
        public List<Competidores> GetCompetidores()
        {
            var lista = competidoresDB.GetCompetidores();
            return lista;
        }

        //Insere competidores
        [HttpPost]
        public List<CadastroCompetidorRetorno> PostCompetidores(Competidores competidores)
        {
            List<CadastroCompetidorRetorno> result = competidoresDB.InsertCompetidores(competidores);

            return result;
        }

        //Altera competidores
        [HttpPut]
        public List<CadastroCompetidorRetorno> PutCompetidores(Competidores competidores)
        {
            List<CadastroCompetidorRetorno> result = competidoresDB.AlterCompetidores(competidores);

            return result;
        }

        //Deleta competidores
        [HttpDelete]
        public string DeleteCompetidores(Competidores competidores)
        {
            bool result = competidoresDB.DeleteCompetidores(competidores);
            if (result)
            {
                return "Competidor excluído com sucesso";
            }
            else
            {
                return "Erro ao cadastrar competidor";
            }
        }

    }
}
