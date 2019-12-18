namespace MDP.Models.Association
{
    public class OrdemFabrico
    {
        public long Id_operacao { get; set; }

        public PlanoFabrico planoFabrico { get; set; }

        public long Id_planoFabrico { get; set; }

        public OrdemFabrico() { }

        public OrdemFabrico(long Id_operacao, long Id_planoFabrico)
        {
            this.Id_operacao = Id_operacao;
            this.Id_planoFabrico = Id_planoFabrico;
        }
    }
}