using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mensageria.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Mensageria.Models
{
    public class PedidoController : Controller
    {
        private readonly IFilmesRepository filmesRepository;
        private readonly IPedidoRepository pedidoRepository;

        public PedidoController(IFilmesRepository filmesRepository, IPedidoRepository pedidoRepository)
        {
            this.filmesRepository = filmesRepository;
            this.pedidoRepository = pedidoRepository;
        }

        public IActionResult Carrossel()
        {
            return View(filmesRepository.GetFilmes());
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Carrinho(string codigo)
        {
            if (!string.IsNullOrEmpty(codigo))
            {
                pedidoRepository.addItem(codigo);
            }

            Pedido pedido = pedidoRepository.GetPedido();
            return View(pedido.Itens);
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        public IActionResult Resumo()
        {
            Pedido pedido = pedidoRepository.GetPedido();
            return View(pedido);
        }
    }
}