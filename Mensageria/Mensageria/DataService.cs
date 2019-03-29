using Mensageria.Models;
using Mensageria.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Mensageria
{
    class DataService : IDataService
    {
        private readonly ApplicationContext contexto;
        private readonly IFilmesRepository filmesRepository;

        public DataService(ApplicationContext contexto, IFilmesRepository filmesRepository)
        {
            this.contexto = contexto;
            this.filmesRepository = filmesRepository;
        }

        public void InicializaDB()
        {
            contexto.Database.Migrate();

            //List<Filmess> filmes = GetFilmes();

            //filmesRepository.SaveProdutos(filmes);

        }
        
        private static List<Filmess> GetFilmes()
        {
            var json = File.ReadAllText("livros.json");
            var filmes = JsonConvert.DeserializeObject<List<Filmess>>(json);
            return filmes;
        }
    }


}
