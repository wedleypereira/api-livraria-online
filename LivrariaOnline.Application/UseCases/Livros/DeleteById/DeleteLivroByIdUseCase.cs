using LivrariaOnline.Communication.Responses;
using LivrariaOnline.Exceptions;
using LivrariaOnline.Infrastructure.Storage;

namespace LivrariaOnline.Application.UseCases.Livros.DeleteById;

public class DeleteLivroByIdUseCase
{
    public ResponseSuccessJson Execute(Guid idLivro)
    {
        var storage = new StorageLivraria();

        var livroDelete = storage._listaLivros.Find(x => x.Id.Equals(idLivro));
        if (livroDelete is null)
            throw new NotFoundException("Livro não encontrado no acervo, verifique o ID fornecido e tente novamente!");

        storage._listaLivros.Remove(livroDelete);
        storage.SaveChanges();

        return new ResponseSuccessJson("Livro excluído com sucesso.");
    }
}
