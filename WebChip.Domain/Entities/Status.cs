namespace WebChip.Domain.Entities
{
    public class Status
    {
        public Status(string descricaoStatus)
        {
            DescricaoStatus = descricaoStatus;
        }

        public int IdStatus { get; private set; }

        public string DescricaoStatus { get; private set; }

        public string Finaliza { get; private set; }

        public string ContabilizaVenda { get; private set; }

        public bool StatusCliente { get; private set; }

        public Cliente Cliente { get; set; }
    }
}