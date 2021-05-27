using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebChip.Domain.Consulta;
using WebChip.Domain.Entities;
using WebChip.Domain.Repository;
using WebChip.Infra.Context;

namespace WebChip.Infra
{
    public class RepositoryCliente : IRepositoryCliente
    {
        private readonly DataContext _context;

        public RepositoryCliente(DataContext context)
        {
            _context = context;
        }

        public void AtualizaClienteDados(Cliente cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Create(Cliente client)
        {
            _context.Cliente.Add(client);
            _context.SaveChanges();
        }

        public Cliente GetCpf(string cpf)
        {
            cpf = cpf.Trim().Replace(".", "").Replace("-", "");
            return (_context.Cliente.AsNoTracking().FirstOrDefault(ClienteStatusQueries.CpfDisponivel(cpf)));
        }

        public Cliente GetId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cliente> ListCpf(string cpf, string nome)
        {
            if (cpf == null)
            {
                try
                {
                    var resultadoNome = nome.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    var ofertaCliente = default(List<Cliente>);

                    if (resultadoNome != null && resultadoNome.Length > 1)
                    {
                        string firstName = resultadoNome[0];
                        string lastName = resultadoNome[resultadoNome.Length - 1];

                        ofertaCliente = _context.Cliente.Where(x => x.Nome.StartsWith(firstName) && x.Nome.EndsWith(lastName)).ToList();

                    }
                    else
                    {
                        ofertaCliente = _context.Cliente.Where(ClienteStatusQueries.NomeDisponivel(nome)).ToList();
                    }
                    return ofertaCliente;
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else 
            {
                cpf = cpf.Trim().Replace(".", "").Replace("-", "");
                return (_context.Cliente.AsNoTracking().Where(ClienteStatusQueries.CpfDisponivel(cpf)));
            }

        }

    }
}
