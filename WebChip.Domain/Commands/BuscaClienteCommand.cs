using Flunt.Notifications;
using Flunt.Validations;
using WebChip.Domain.Commands.Contracts;

namespace WebChip.Domain.Commands
{
    public class BuscaClienteCommand : Notifiable, ICommand
    {
        public BuscaClienteCommand()
        {

        }
        public BuscaClienteCommand(string cpf, string nome)
        {
            Cpf = cpf;
            Nome = nome;
        }

        public string Cpf { get; set; }

        public string Nome { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .HasMinLen(Nome, 3, "Nome", "Por favor, Coloque o Primeiro e o último nome para pesquisar")
                .HasMinLen(Cpf, 9, "Cpf", "verifique se digitou o cpf corretamente"));

        }
    }
}
