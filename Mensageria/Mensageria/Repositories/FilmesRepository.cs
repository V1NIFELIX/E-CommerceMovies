using Mensageria.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mensageria.Repositories
{
    public class FilmesRepository : BaseRepository<Filmes>, IFilmesRepository
    {
        public FilmesRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public IList<Filmes> GetFilmes()
        {
            return dbSet.ToList();
        }

        public void SaveProdutos(List<Filmess> filmes)
        {
            foreach (var filme in filmes)
            {

                if (!dbSet.Where(p => p.Codigo == filme.Codigo).Any())
                {
                    dbSet.Add(new Filmes(filme.Codigo, filme.Nome, filme.Sinopse, filme.Preco));

                }
            }
            contexto.SaveChanges();
        }
    }

    public class Filmess
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Sinopse { get; set; }

    }
}
