namespace WebChip.Domain.Entities
{
    public class Produtos
    {
        public Produtos(string descricaoProduto, decimal preco, string tipo, int codigoProduto)
        {
            DescricaoProduto = descricaoProduto;
            Preco = preco;
            Tipo = tipo;
            CodigoProduto = codigoProduto;
        }

        public int IdProduto { get; private set; }

        public string DescricaoProduto { get; private set; }

        public decimal Preco { get; private set; }

        public string Tipo { get; private set; }

        public int CodigoProduto { get; private set; }

        public HistoricoOferta HistoricoOferta { get; private set; }
    }
}