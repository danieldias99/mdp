using MDP.Models.Shared;
using MDP.Models.DTO;

namespace MDP.Models
{
    public class PlanoFabrico : Entity
    {

        public long Id { get; set; }
        public OrdemFabrico [] operacoes {get; set;}
        public long Id_Produto;

        public PlanoFabricoDTO toDTO()
        {
            return new PlanoFabricoDTO(Id, Id_Produto, operacoes);
        }

    }
}