namespace WebChip.Domain.Entities
{
    public class Cliente
    {
        public Cliente(string nome, string cpf, decimal credito, string telefone)
        {
            Nome = nome;
            Cpf = cpf;
            Credito = credito;
            Telefone = telefone;
            StatusId = 1;
        }



        public int IdCliente { get; private set; }

        public int HistoricoOfertaId { get; private set; }

        public string Nome { get; private set; }

        public string Cpf { get; private set; }

        public decimal Credito { get; private set; }

        public string Telefone { get; private set; }

        public int StatusId { get; private set; }

        public int EnderecoId { get; private set; }

        public Status Status { get; private set; }

        public Endereco Endereco { get; set; }

        public HistoricoOferta HistoricoOferta { get; set; }


        public void AtualizaCliente(string nome, string telefone)
        {
            Nome = nome;
            Telefone = telefone;
        }

        public void AtualizaSaldo(decimal preco)
        {
            var saldo = Credito - preco;
            Credito = saldo;
        }

        public void AtualizaStatus(int id)
        {
            StatusId = id;
        }
    }
}
