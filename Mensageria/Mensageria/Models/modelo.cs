using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Mensageria.Models
{
    [DataContract]
    public class Modelo
    {
        [DataMember]
        public int Id { get; protected set; }
    }

    public class Filmes : Modelo
    {
        public Filmes()
        {

        }
        [Required]
        public string Codigo { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Sinopse { get; set; }
        [Required]
        public decimal Preco { get; set; }

        public Filmes(string codigo, string nome, string sinopse, decimal preco)
        {
            this.Codigo = codigo;
            this.Nome = nome;
            this.Sinopse = sinopse;
            this.Preco = preco;
        }
    }
    public class Cadastro : Modelo
    {
        public Cadastro()
        {
        }

        public virtual Pedido Pedido { get; set; }
        [Required]
        public string Nome { get; set; } = "";
        [Required]
        public string Email { get; set; } = "";
        [Required]
        public string Telefone { get; set; } = "";
        [Required]
        public string Endereco { get; set; } = "";
        [Required]
        public string Complemento { get; set; } = "";
        [Required]
        public string Bairro { get; set; } = "";
        [Required]
        public string Municipio { get; set; } = "";
        [Required]
        public string UF { get; set; } = "";
        [Required]
        public string CEP { get; set; } = "";
    }

    public class ItemPedido : Modelo
    {
        [Required]
        public Pedido Pedido { get; private set; }
        [Required]
        public Filmes Filmes { get; private set; }
        [Required]
        public int Quantidade { get; private set; }
        [Required]
        public decimal PrecoUnitario { get; private set; }

        public ItemPedido()
        {

        }

        public ItemPedido(Pedido pedido, Filmes filmes, int quantidade, decimal precoUnitario)
        {
            Pedido = pedido;
            Filmes = filmes;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
        }
    }

    public class Pedido : Modelo
    {
        public Pedido()
        {
            Cadastro = new Cadastro();
        }

        public Pedido(Cadastro cadastro)
        {
            Cadastro = cadastro;
        }

        public List<ItemPedido> Itens { get; private set; } = new List<ItemPedido>();
        [Required]
        public virtual Cadastro Cadastro { get; private set; }
    }
}
