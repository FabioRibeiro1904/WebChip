using Flunt.Notifications;
using Flunt.Validations;
using WebChip.Domain.Commands.Contracts;

namespace WebChip.Domain.Commands
{
    public class CadastroClienteCommand : Notifiable, ICommand
    {
        public CadastroClienteCommand()
        {

        }
        public CadastroClienteCommand(string nome, string cpf, decimal credito, string telefone, bool statusAtual, int statusId)
        {
            Nome = nome;
            Cpf = cpf;
            Credito = credito;
            Telefone = telefone;
            StatusAtual = statusAtual;
            StatusId = statusId;
        }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public decimal Credito { get; set; }

        public string Telefone { get; set; }

        public bool StatusAtual { get; set; }

        public int StatusId { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .HasMinLen(Nome, 3, "Nome", "Por favor, digite o nome completo!")
                .HasMinLen(Cpf, 11, "Cpf", "Por favor, digite corretamente seu CPF")
                .HasMinLen(Telefone, 11, "Telefone", "Por favo, digite o telefone completo com DDD")

                );
        }
    }
}
