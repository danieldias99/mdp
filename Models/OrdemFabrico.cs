using MDP.Models.Shared;

namespace MDP.Models
{
    public class OrdemFabrico : ValueObject
    {
        public long Id_operacao { get; set; }
        public OrdemFabrico(long value) { this.Id_operacao = value; }

        public OrdemFabrico()
        {
        }
    }
}