using MDP.Models.Shared;
using System.Collections.Generic;
using MDP.Models.Association;

namespace MDP.Models.DTO
{

    public class ProdutoDTO
    {

        public long Id { get; set; }
        public string nomeProduto { get; set; }
        public string descricaoProduto { get; set; }
        public PlanoFabricoDTO planofabrico { get; set; }

        public ProdutoDTO() { }

        public ProdutoDTO(long Id, string nomeProduto, string descricaoProduto, PlanoFabricoDTO planoFabrico)
        {
            this.Id = Id;
            this.nomeProduto = nomeProduto;
            this.descricaoProduto = descricaoProduto;
            this.planofabrico = planoFabrico;
        }
    }
}