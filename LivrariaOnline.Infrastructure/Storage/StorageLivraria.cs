using LivrariaOnline.Infrastructure.Entities;
using Newtonsoft.Json;

namespace LivrariaOnline.Infrastructure.Storage;

public class StorageLivraria
{
    private readonly string _fileLivroJson = Path.Combine(Directory.GetCurrentDirectory(), "AppData", "livros.json");
    public List<Livro> _listaLivros;

    public StorageLivraria()
    {
        if (File.Exists(_fileLivroJson))
        {
            var json = File.ReadAllText(_fileLivroJson);
            _listaLivros = JsonConvert.DeserializeObject<List<Livro>>(json) ?? new List<Livro>();
        }
        else
        {
            _listaLivros = new List<Livro>();
            SaveChanges();
        }
    }


    public void SaveChanges()
    {
        var json = JsonConvert.SerializeObject(_listaLivros, Formatting.Indented);
        File.WriteAllText(_fileLivroJson, json);
    }
}
