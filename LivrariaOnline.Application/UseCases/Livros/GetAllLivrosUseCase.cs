using LivrariaOnline.Communication.Responses;
using LivrariaOnline.Exceptions;
using LivrariaOnline.Infrastructure.Storage;

namespace LivrariaOnline.Application.UseCases.Livros;

public class GetAllLivrosUseCase
{
    public ResponseAllLivrosJson Execute()
    {
        var storage = new StorageLivraria();
        var livros = storage._listaLivros;

        if (livros.Count == 0) throw new NotFoundException("Nenhum livro cadastrado no nosso acervo até o momento.");

        return new ResponseAllLivrosJson
        {
            Livros = livros
        };
    }
}
