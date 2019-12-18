using MDP.Models.Association;
using System.Collections.Generic;

namespace MDP.Models.DTO
{

    public class PlanoFabricoDTO
    {

        public long Id { get; set; }
        public long Id_produto { get; set; }
        public ICollection<long> operacoes { get; set; }

        public PlanoFabricoDTO() { }

        public PlanoFabricoDTO(long Id, long Id_produto, ICollection<long> operacoes)
        {
            this.Id = Id;
            this.Id_produto = Id_produto;
            this.operacoes = operacoes;
        }

        public PlanoFabricoDTO(long Id, long Id_produto, ICollection<OrdemFabrico> operacoes)
        {
            this.Id = Id;
            this.Id_produto = Id_produto;
            setOperacoes(operacoes);
        }

        public void setOperacoes(ICollection<OrdemFabrico> list)
        {
            this.operacoes = new List<long>();
            foreach (OrdemFabrico ordem in list)
            {
                this.operacoes.Add(ordem.Id_operacao);
            }
        }


    }
}