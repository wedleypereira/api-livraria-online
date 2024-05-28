using LivrariaOnline.Communication.Responses;
using LivrariaOnline.Exceptions;
using LivrariaOnline.Infrastructure.Entities;
using LivrariaOnline.Infrastructure.Storage;

namespace LivrariaOnline.Application.UseCases.Livros.GetById;

public class GetLivroByIdUseCase
{
    public ResponseGetLivroByIdJson Execute(Guid idLivro)
    {
        var storage = new StorageLivraria();
        var livro = Validate(idLivro, storage);

        return new ResponseGetLivroByIdJson
        {
            Title = livro.Title,
            Author = livro.Author,
            Genre = livro.Genre,
            Price = livro.Price,
            Stock = livro.Stock
        };
    }

    Livro Validate(Guid idLivro, StorageLivraria storage)
    {
        var response = storage._listaLivros.Find(a => a.Id.Equals(idLivro));

        if (response is null)
            throw new NotFoundException("Livro não encontrado ou não cadastrado no acervo.");

        return response;
    }
}
