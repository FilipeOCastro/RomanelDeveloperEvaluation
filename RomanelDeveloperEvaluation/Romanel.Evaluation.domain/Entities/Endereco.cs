using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Romanel.Evaluation.domain.Entities
{
    public class Endereco
    {
        private Endereco() { }

        public Endereco(string cep, string logradouro, string numero, string bairro, string cidade, string estado)
        {
            CEP = ValidateCEP(cep);
            Logradouro = ValidateLogradouro(logradouro);
            Numero = ValidateNumero(numero);
            Bairro = ValidateBairro(bairro);
            Cidade = ValidateCidade(cidade);
            Estado = ValidateEstado(estado);
        }

        public string CEP { get; private set; }
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
                

        #region validacoes

        private string ValidateCEP(string cep)
        {
            if (string.IsNullOrWhiteSpace(cep) || cep.Length != 8 || !cep.All(char.IsDigit))
                throw new ArgumentException("CEP deve conter exatamente 8 dígitos numéricos.");
            return cep;
        }

        private string ValidateLogradouro(string logradouro)
        {
            if (string.IsNullOrWhiteSpace(logradouro) || logradouro.Length > 200)
                throw new ArgumentException("Logradouro é obrigatório e deve ter até 200 caracteres.");
            return logradouro;
        }

        private string ValidateNumero(string numero)
        {
            if (string.IsNullOrWhiteSpace(numero) || numero.Length > 10)
                throw new ArgumentException("Número é obrigatório e deve ter até 10 caracteres.");
            return numero;
        }

        private string ValidateBairro(string bairro)
        {
            if (string.IsNullOrWhiteSpace(bairro) || bairro.Length > 100)
                throw new ArgumentException("Bairro é obrigatório e deve ter até 100 caracteres.");
            return bairro;
        }

        private string ValidateCidade(string cidade)
        {
            if (string.IsNullOrWhiteSpace(cidade) || cidade.Length > 100)
                throw new ArgumentException("Cidade é obrigatória e deve ter até 100 caracteres.");
            return cidade;
        }

        private string ValidateEstado(string estado)
        {
            if (string.IsNullOrWhiteSpace(estado) || estado.Length != 2)
                throw new ArgumentException("Estado deve conter exatamente 2 caracteres.");
            return estado.ToUpper();
        }

        #endregion
    }
}
