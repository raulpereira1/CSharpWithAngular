using PrimeiraApi.Models;

namespace PrimeiraApi.Rotas
{
    public static class PessoaRotas
    {
        public static List<Pessoa> Pessoas = new List<Pessoa>() 
        { 
            new Pessoa(id:Guid.NewGuid(),nome:"Raul"),
            new Pessoa(id:Guid.NewGuid(),nome:"Carla"),
            new Pessoa(id:Guid.NewGuid(),nome:"Vicenzo")
        };
        public static void MapPessoasRotas(this WebApplication app)
        {
            app.MapGet("/pessoas", () => Pessoas);

            app.MapGet(pattern:"/pessoas/{nome}", 
                handler:(string nome) => Pessoas.Find(x => x.Nome == nome));

            app.MapPost("pessoas",(Pessoa pessoa) =>
            {
                Pessoas.Add(pessoa);
                return pessoa;
            });
            app.MapPut("/pessoas/{id:guid}", (Guid id, Pessoa pessoa) => 
            { 
                var encontrado = Pessoas.Find(x => x.Id == id); 
                if (encontrado == null)
                
                    return Results.NotFound();
                
                encontrado.Nome = pessoa.Nome;
                return Results.Ok(encontrado);

            });
        }

    }
}
