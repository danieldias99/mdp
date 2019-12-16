

namespace MDP.Models.DTO
{

    public class PlanoFabricoDTO
    {

        public long Id { get; set; }
        public OrdemFabrico [] operacoes {get; set;}

        public long Id_Produto {get;set;}

        public PlanoFabricoDTO(long Id, long Id_produto, OrdemFabrico [] operacoes)
        {
            this.Id = Id;
            this.Id_Produto = Id_Produto;
            this.operacoes = operacoes;  
        }


    }
}