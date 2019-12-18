using MDP.Models.Shared;
using MDP.Models.DTO;
using MDP.Models.Association;
using System.Collections.Generic;

namespace MDP.Models
{
    public class PlanoFabrico : Entity
    {

        public long Id { get; set; }
        public ICollection<OrdemFabrico> operacoes { get; set; }
        public Produto produto;

        public long Id_produto;

        public PlanoFabrico() { }

        public PlanoFabrico(long id, long id_produto, ICollection<long> operacoes)
        {
            this.Id = id;
            this.Id_produto = id_produto;
            setOperacoes(operacoes);
        }

        public PlanoFabrico(long id, long id_produto)
        {
            this.Id = id;
            this.Id_produto = id_produto;
        }

        public PlanoFabricoDTO toDTO()
        {
            return new PlanoFabricoDTO(Id, Id_produto, operacoes);
        }

        public void setOperacoes(ICollection<long> list)
        {
            this.operacoes = new List<OrdemFabrico>();
            foreach (long id_operacao in list)
            {
                this.operacoes.Add(new OrdemFabrico(id_operacao, this.Id));
            }
        }

    }
}