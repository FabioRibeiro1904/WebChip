
using System;

namespace WebChip.Domain.Entities
{
    public class Endereco
    {
        public Endereco(string cep, string rua, int numero, string complemento, string bairro, string cidade, string estado)
        {
            Cep = cep;
            Rua = rua;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
        }

        public int IdEndereco { get; private set; }

        public string Cep { get; private set; }

        public string Rua { get; private set; }

        public int Numero { get; private set; }

        public string Complemento { get; private set; }

        public string Bairro { get; private set; }

        public string Cidade { get; private set; }

        public string Estado { get; private set; }

        public Cliente Cliente { get; set; }


        public void AtualizaEndereco(string cep, string rua, int numero, string complemento, string bairro, string cidade, string estado)
        {
            Cep = cep;
            Rua = rua;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
        }
    }

}
