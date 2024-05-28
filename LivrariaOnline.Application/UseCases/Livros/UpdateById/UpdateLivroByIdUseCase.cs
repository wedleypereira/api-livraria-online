using LivrariaOnline.Communication.Requests;
using LivrariaOnline.Communication.Responses;
using LivrariaOnline.Exceptions;
using LivrariaOnline.Infrastructure.Entities;
using LivrariaOnline.Infrastructure.Storage;

namespace LivrariaOnline.Application.UseCases.Livros.UpdateById;

public class UpdateLivroByIdUseCase
{
    public ResponseUpdateLivroJson Execute(Guid idLivro, RequestUpdateLivroJson request)
    {
        var storage = new StorageLivraria();
        var livroEdit = Validate(idLivro, request, storage);

        var entity = new ResponseUpdateLivroJson()
        {
            Title = string.IsNullOrWhiteSpace(request.Title) ? livroEdit.Title : request.Title,
            Author = string.IsNullOrWhiteSpace(request.Author) ? livroEdit.Author : request.Author,
            Genre = string.IsNullOrWhiteSpace(request.Genre) ? livroEdit.Genre : request.Genre,
            Price = request.Price ?? livroEdit.Price,
            Stock = request.Stock ?? livroEdit.Stock
        };

        int idList = storage._listaLivros.FindIndex(a => a.Id.Equals(idLivro));

        storage._listaLivros[idList].Title = entity.Title;
        storage._listaLivros[idList].Author = entity.Author;
        storage._listaLivros[idList].Genre = entity.Genre;
        storage._listaLivros[idList].Price = entity.Price;
        storage._listaLivros[idList].Stock = entity.Stock;

        storage.SaveChanges();

        return entity;
    }

    Livro Validate(Guid idLivro, RequestUpdateLivroJson request, StorageLivraria storage)
    {
        var livro = storage._listaLivros.Find(a => a.Id.Equals(idLivro));
        if (livro is null)
            throw new NotFoundException("Livro não encontrado no acervo, verifique o ID fornecido e tente novamente!");

        if (string.IsNullOrWhiteSpace(request.Title) &&
           string.IsNullOrWhiteSpace(request.Author) &&
           string.IsNullOrWhiteSpace(request.Genre) &&
           request.Price is null &&
           request.Stock is null)
            throw new ErrorOnValidationException("Nenhum valor foi fornecido para ser atualizado.");

        return livro;
    }
}
