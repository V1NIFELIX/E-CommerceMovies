using Mensageria.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mensageria.Repositories
{

    public interface IPedidoRepository
    {
        Pedido GetPedido();
        void addItem(string codigo);
    }

    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        private readonly IHttpContextAccessor contextAccessor;

        public PedidoRepository(ApplicationContext contexto, IHttpContextAccessor contextAccessor) : base(contexto)
        {
            this.contextAccessor = contextAccessor;
           
        }

        public void addItem(string codigo)
        {
            var filmes = contexto.Set<Filmes>().Where(p => p.Codigo == codigo).SingleOrDefault();

            if (filmes == null)
            {
                throw new ArgumentException("Produto não encontrado"); 
            }
            var pedido = GetPedido();

            var itemPedido = contexto.Set<ItemPedido>().Where(i => i.Filmes.Codigo == codigo && i.Pedido.Id == pedido.Id).SingleOrDefault();

            if (itemPedido == null)
            {
                itemPedido = new ItemPedido(pedido, filmes, 1, filmes.Preco);
                contexto.Set<ItemPedido>().Add(itemPedido);

                contexto.SaveChanges();
            }
        }

        public Pedido GetPedido()
        {
            var pedidoId = GetPedidoId();
            var pedido = dbSet.Include(p => p.Itens)
                    .ThenInclude(i => i.Filmes)
                .Where(p => p.Id == pedidoId)
                .SingleOrDefault();

            if (pedido == null)
            {
                pedido = new Pedido();
                dbSet.Add(pedido);

                contexto.SaveChanges();
                SetPedidoId(pedido.Id);
            }
            return pedido;
        }

        private int? GetPedidoId()
        {
            return contextAccessor.HttpContext.Session.GetInt32("pedidoId");
        }

        private void SetPedidoId(int pedidoId)
        {
            contextAccessor.HttpContext.Session.SetInt32("pedidoId", pedidoId);
        }
    }
}
