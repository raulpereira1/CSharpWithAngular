using PrimeiraApi.Models;

namespace PrimeiraApi.Rotas
{
    public static class PessoaRotas
    {
        public static List<Pessoa> pessoas = new List<Pessoa>() 
        { 
            new Pessoa(id:Guid.NewGuid(),nome:"Raul"),
            new Pessoa(id:Guid.NewGuid(),nome:"Carla"),
            new Pessoa(id:Guid.NewGuid(),nome:"Vicenzo")
        };
        public static void MapPessoasRotas(this WebApplication app)
        {
            app.MapGet("/pessoas", () => pessoas);
        }
    }
}
