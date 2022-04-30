namespace QyonAdventureWorks.Models
{
    public class CadastroCompetidorRetorno
    {
        public string Retorno { get; set; }
        public List<ProblemaCadastroCompetidor>? Problema { get; set; }
    }

    public class ProblemaCadastroCompetidor
    {
        public string? Descricao { get; set; }
    }
}
