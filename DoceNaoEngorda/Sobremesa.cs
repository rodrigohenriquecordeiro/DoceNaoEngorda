namespace DoceNaoEngorda
{
    public class Sobremesa
    {
        public int Codigo { get; set; }
        public string? Nome { get; set; }
        public DateTime DataDaFabricao { get; set; }
        public double Peso { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeEmEstoque { get; set; } = 0;


    }
}
