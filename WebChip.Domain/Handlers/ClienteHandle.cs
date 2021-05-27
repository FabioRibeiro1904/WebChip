using Flunt.Notifications;
using System;
using WebChip.Domain.Commands;
using WebChip.Domain.Commands.Contracts;
using WebChip.Domain.Entities;
using WebChip.Domain.Repository;

namespace WebChip.Domain.Handlers
{
    public class ClienteHandler : Notifiable, IHandler<CadastroClienteCommand>,
        IHandler<BuscaClienteCommand>, IHandler<OfertaClienteCommand>

    {
        private readonly IRepositoryCliente _repositoryClient;
        private readonly IRepositoryEndereco _repositoryEndereco;
        private readonly IRepositoryProduto _repositoryProduto;
        private readonly IRepositoryStatus _repositoryStatus;
        private readonly IRepositoryHistoricoOferta _repositoryHistoricoOferta;

        public ClienteHandler(IRepositoryCliente repositoryClient, IRepositoryEndereco repositoryEndereco,
            IRepositoryProduto repositoryProduto, IRepositoryStatus repositoryStatus, IRepositoryHistoricoOferta repositoryHistoricoOferta)
        {
            _repositoryClient = repositoryClient;
            _repositoryEndereco = repositoryEndereco;
            _repositoryProduto = repositoryProduto;
            _repositoryStatus = repositoryStatus;
            _repositoryHistoricoOferta = repositoryHistoricoOferta;
        }

        public ICommandResult Handle(CadastroClienteCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "por favor verifique os campos digitados",
                    command.Notifications);

            var cpfvalid = _repositoryClient.GetCpf(command.Cpf);

            if (cpfvalid != null)
                return new GenericCommandResult(false, "Cpf já cadastrado", command.Cpf);

            var client = new Cliente(command.Nome, command.Cpf, command.Credito, command.Telefone);

            _repositoryClient.Create(client);


            return new GenericCommandResult(true, "Cadastro realizado com sucesso,", command.Nome);
        }

        public ICommandResult Handle(BuscaClienteCommand command)
        {
            command.Validate();
            if (String.IsNullOrEmpty(command.Nome) || String.IsNullOrEmpty(command.Cpf))
                return new GenericCommandResult(false, "Erro na busca", command.Notifications);


            var cpfvalid = _repositoryClient.ListCpf(command.Cpf, command.Nome);
            return new GenericCommandResult(true, "", cpfvalid);
        }

        public ICommandResult Handle(OfertaClienteCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Verifique se todos os camppos foram preenchidos",
                    command.Notifications);

            var client = _repositoryClient.GetId(command.IdCliente);
            if (client.Nome != command.Nome || client.Telefone != command.Telefone)
                client.AtualizaCliente(command.Nome, command.Telefone);

            var enderec = _repositoryEndereco.GetIdEndereco(command.IdEndereco);
            if (enderec == null)
            {
                enderec = new Endereco(command.Cep, command.Rua, command.Numero, command.Complemento, command.Bairro, command.Cidade,
                command.Estado);
                _repositoryEndereco.Create(enderec);
            }
            enderec.AtualizaEndereco(command.Cep, command.Rua, command.Numero, command.Complemento, command.Bairro, command.Cidade,
                command.Estado);
            _repositoryEndereco.AtualizarEndereco(enderec);

            var produto = _repositoryProduto.GetProduto(command.IdProduto);

            client.AtualizaSaldo(produto.Preco);
            _repositoryClient.AtualizaClienteDados(client);

            var historicoOferta = new HistoricoOferta(command.DataOferta, command.IdProduto);
            _repositoryHistoricoOferta.Create(historicoOferta);

            var status = _repositoryStatus.GetStatus(command.IdStatus);
            client.AtualizaStatus(status.IdStatus);
            _repositoryClient.AtualizaClienteDados(client);


            return new GenericCommandResult(true, "Oferta realizada com sucesso.", historicoOferta);


        }
    }
}
