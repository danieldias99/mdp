namespace MDP.Models
{

    public class TempoProducao
    {
        public int tempo_fabrico { get; set; }

        public TempoProducao() { }

        public TempoProducao(int tempo_fabrico)
        {
            this.tempo_fabrico = tempo_fabrico;
        }
    }
}