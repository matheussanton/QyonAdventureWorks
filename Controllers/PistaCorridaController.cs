using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QyonAdventureWorks.Models;

namespace QyonAdventureWorks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PistaCorridaController : ControllerBase
    {

        //Lista pistas
        [HttpGet]
        public List<PistaCorrida> GetPistaCorrida()
        {
            var lista = PistaCorridaDB.GetPistas();
            return lista;
        }


        //Insere pista
        [HttpPost]
        public string PostPistaCorrida(PistaCorrida pista)
        {
            bool result = PistaCorridaDB.InsertPista(pista);
            if (result)
            {
                return "Pista cadastrada com sucesso";
            }
            else
            {
                return "Erro ao cadastrar Pista";


            }
        }

        //Altera pista
        [HttpPut]
        public string PutPistaCorrida(PistaCorrida pista)
        {
            bool result = PistaCorridaDB.AlterPista(pista);
            if (result)
            {
                return "Pista alterada com sucesso";
            }
            else
            {
                return "Erro ao cadastrar Pista";
            }
        }

        //Deleta pista
        [HttpDelete]
        public string DeletePistaCorrida(PistaCorrida pista)
        {
            bool result = PistaCorridaDB.DeletePista(pista);
            if (result)
            {
                return "Pista excluída com sucesso";
            }
            else
            {
                return "Erro ao cadastrar competidor";
            }
        }
    }
}
