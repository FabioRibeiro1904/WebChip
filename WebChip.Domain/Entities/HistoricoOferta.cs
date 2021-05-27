using System;

namespace WebChip.Domain.Entities
{

    public class HistoricoOferta
    {
        public HistoricoOferta(DateTime dataOferta, int produtoId)
        {
            DataOferta = dataOferta;
            ProdutoId = produtoId;
        }

        public int IdHistoricoOferta { get; private set; }

        public DateTime DataOferta { get; private set; }

        public int ProdutoId { get; private set; }

        public Produtos Produtos { get; private set; }

        public Cliente Clientes { get; set; }

        public void AddProduto(int produtoId)
        {
            ProdutoId = produtoId;
        }



    }


}
