using MediatR;
using Romanel.Evaluation.Application.Dtos;
using Romanel.Evaluation.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Romanel.Evaluation.Application.Queries
{
    public class ObterClienteQueryHandler : IRequestHandler<ObterClienteQuery, ClienteDto>
    {
        private readonly IClienteReadRepository _clienteReadRepository;

        public ObterClienteQueryHandler(IClienteReadRepository clienteReadRepository)
        {
            _clienteReadRepository = clienteReadRepository;
        }

        public async Task<ClienteDto> Handle(ObterClienteQuery request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteReadRepository.GetByIdAsync(request.Id);
            if (cliente == null) return null;

            return new ClienteDto
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                CPF = cliente.CPF,
                DataNascimento = cliente.DataNascimento,
                Telefone = cliente.Telefone,
                Email = cliente.Email,
                Endereco = new EnderecoDto
                {
                    CEP = cliente.Endereco.CEP,
                    Logradouro = cliente.Endereco.Logradouro,
                    Numero = cliente.Endereco.Numero,
                    Bairro = cliente.Endereco.Bairro,
                    Cidade = cliente.Endereco.Cidade,
                    Estado = cliente.Endereco.Estado
                }
            };
        }
    }
}
