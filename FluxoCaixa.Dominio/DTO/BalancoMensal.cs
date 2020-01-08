namespace FluxoCaixa.Dominio.DTO
{
    public class BalancoMensal
    {
        public int Mes { get; set; }
        public string DescricaoMes { get; set; }
        public double SomaCredito { get; set; }
        public double SomaDebito { get; set; }
        public double SomaSaldo { get; set; }
        public int Ano { get; set; }
    }
}
