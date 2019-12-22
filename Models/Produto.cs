using MDP.Models.Shared;
using MDP.Models.ValueObjects;
using MDP.Models.DTO;
using System.Collections.Generic;

namespace MDP.Models
{
    public class Produto : Entity, IAggregateRoot
    {

        public long Id { get; set; }
        public InfoProduto informacaoProduto { get; set; }
        public long planoFabricoId { get; set; }
        public PlanoFabrico planoFabrico { get; set; }

        public Produto() { }

        public Produto(long id, InfoProduto nomeProduto)
        {
            this.Id = id;
            this.informacaoProduto = nomeProduto;
        }

        public Produto(long id, string nomeProduto, string descricaoProduto, long id_plano_fabrico, ICollection<long> operacoes, int tempo_producao)
        {
            this.Id = id;
            this.informacaoProduto = new InfoProduto(nomeProduto, descricaoProduto);
            this.planoFabrico = new PlanoFabrico(id_plano_fabrico, this.Id, operacoes, tempo_producao);
        }

        public ProdutoDTO toDTO()
        {
            return new ProdutoDTO(Id, informacaoProduto.nomeProduto, informacaoProduto.descricaoProduto, planoFabrico.toDTO());
        }
    }


}