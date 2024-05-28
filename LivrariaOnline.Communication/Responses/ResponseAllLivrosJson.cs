using LivrariaOnline.Infrastructure.Entities;

namespace LivrariaOnline.Communication.Responses;

public class ResponseAllLivrosJson
{
    public List<Livro> Livros { get; set; } = [];
}
