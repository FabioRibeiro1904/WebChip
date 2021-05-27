using Flunt.Notifications;
using Flunt.Validations;
using System;
using WebChip.Domain.Commands.Contracts;

namespace WebChip.Domain.Commands
{
    public class OfertaClienteCommand : Notifiable, ICommand
    {
        public OfertaClienteCommand()
        {

        }
        public OfertaClienteCommand(int idCliente, string nome, string cpf, decimal credito, string telefone,
            int idEndereco, string cep, string rua, int numero, string complemento, string bairro,
            string cidade, string estado, int idProduto, string descricaoProduto, decimal preco, string tipo,
            int idStatus, string descricaoStatus, string finaliza, string contabilizaVenda, bool statusCliente, int codigoProduto)
        {
            IdCliente = idCliente;
            Nome = nome;
            Cpf = cpf;
            Credito = credito;
            Telefone = telefone;
            IdEndereco = idEndereco;
            Cep = cep;
            Rua = rua;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            IdProduto = idProduto;
            DescricaoProduto = descricaoProduto;
            Preco = preco;
            Tipo = tipo;
            IdStatus = idStatus;
            DescricaoStatus = descricaoStatus;
            Finaliza = finaliza;
            ContabilizaVenda = contabilizaVenda;
            StatusCliente = statusCliente;
            CodigoProduto = codigoProduto;
        }



        public int IdCliente { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public decimal Credito { get; set; }

        public string Telefone { get; set; }

        public int IdEndereco { get; set; }

        public string Cep { get; set; }

        public string Rua { get; set; }

        public int Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public int IdProduto { get; set; }

        public string DescricaoProduto { get; set; }

        public decimal Preco { get; set; }

        public string Tipo { get; set; }

        public int IdStatus { get; set; }

        public string DescricaoStatus { get; set; }

        public string Finaliza { get; set; }

        public string ContabilizaVenda { get; set; }

        public bool StatusCliente { get; private set; }

        public int CodigoProduto { get; set; }

        public DateTime DataOferta { get; set; }

        public int OfertaId { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .IsLowerThan(Credito, Preco, "Credito", "VocÊ não tem saldo para isso")
                .HasMinLen(Nome, 5, "Nome", "Por favor, Coloque o Primeiro e o último nome para pesquisar")
                .HasMinLen(Cpf, 9, "Cpf", "verifique se digitou o cpf corretamente")
                .HasMinLen(Telefone, 11, "Telefone", "Por favo, digite o telefone completo com DDD")
                .HasMinLen(Cep, 8, "Cep", "Verifique se digitou o  cep corretamente")
                .HasMinLen(Rua, 6, "Rua", "Digite o nome completo da rua")
                .HasMinLen(Complemento, 4, "Complemento", "Complemento Incompleto, detalhe mais por favor")
                .HasMinLen(Bairro, 3, "Bairro", "Verifique o nome do bairro por gentileza")
                .HasMinLen(Cidade, 3, "Cidade", "Digite sua cidade completo por gentileza")
                .HasMaxLen(Estado, 2, "Estado", "Por gentileza, digite apenas a sigla do seu estado")
                .HasMinLen(DescricaoProduto, 2, "DescricaoProduto", "Selecione um produto por gentileza")
                .HasMinLen(DescricaoStatus, 2, "DescricaoStatus", "Selecione um produto por gentileza"));


        }
    }

}
