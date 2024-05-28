using LivrariaOnline.Communication.Requests;
using LivrariaOnline.Communication.Responses;
using LivrariaOnline.Exceptions;
using LivrariaOnline.Infrastructure.Entities;
using LivrariaOnline.Infrastructure.Storage;

namespace LivrariaOnline.Application.UseCases.Livros.Register;

public class RegisterLivroUseCase
{
    public ResponseRegisteredJson Execute(RequestRegisterLivroJson request)
    {
        StorageLivraria storage = new StorageLivraria();
        Validate(request, storage);

        var entity = new Livro
        {
            Title = request.Title,
            Author = request.Author,
            Genre = request.Genre,
            Price = request.Price,
            Stock = request.Stock,
        };

        storage._listaLivros.Add(entity);
        storage.SaveChanges();

        return new ResponseRegisteredJson
        {
            Id = entity.Id,
            Title = entity.Title,
            Author = entity.Author,
            Genre = entity.Genre,
            Price = entity.Price,
            Stock = entity.Stock,
        };
    }

    private void Validate(RequestRegisterLivroJson request, StorageLivraria storage)
    {
        if (string.IsNullOrWhiteSpace(request.Title))
            throw new ErrorOnValidationException("Campo 'Título' vazio, preencha e tente novamente.");

        if (string.IsNullOrWhiteSpace(request.Author))
            throw new ErrorOnValidationException("Campo 'Autor' vazio, preencha e tente novamente.");

        if (string.IsNullOrWhiteSpace(request.Genre))
            throw new ErrorOnValidationException("Campo 'Gênero' vazio, preencha e tente novamente.");

        if (request.Price <= 0)
            throw new ErrorOnValidationException("Campo 'Preço' vazio, preencha e tente novamente.");

        if (request.Stock <= 0)
            throw new ErrorOnValidationException("Campo 'Quantidade em estoque' vazio, preencha e tente novamente.");

        var livro = storage._listaLivros.Find(a => a.Title.ToLower().Equals(request.Title.ToLower()));
        if (livro is not null)
            throw new ConflictException("Livro já cadastrado no acervo, caso queira alterar alguma informação do mesmo, tente usar o método UPDATE.");
    }
}
