using Mensageria.Models;
using System.Collections.Generic;

namespace Mensageria.Repositories
{
    public interface IFilmesRepository
    {
        void SaveProdutos(List<Filmess> filmes);
        IList<Filmes> GetFilmes();
    }
}