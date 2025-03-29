using ClienteApp.Domain.Enums;
using MediatR;
using Romanel.Evaluation.domain.Entities;
using Romanel.Evaluation.domain.Interfaces;

namespace Romanel.Evaluation.Application.Commands
{
    public class CriarClienteCommandHandler : IRequestHandler<CriarClienteCommand, Guid>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IEventStore _eventStore;

        public CriarClienteCommandHandler(IClienteRepository clienteRepository, IEventStore eventStore)
        {
            _clienteRepository = clienteRepository;
            _eventStore = eventStore;
        }

        public async Task<Guid> Handle(CriarClienteCommand request, CancellationToken cancellationToken)
        {
            var endereco = new Endereco(request.CEP, request.Logradouro, request.Numero, request.Bairro, request.Cidade, request.Estado);
            var cliente = new Cliente(request.Nome, request.CPF, request.RazaoSocial, request.CNPJ, request.TipoCliente, request.DataNascimento, request.Telefone, request.Email, endereco);/// TODO: criar classe para reduzir nume de argu

            if (request.TipoCliente == TipoCliente.PessoaFisica && (string.IsNullOrEmpty(request.Nome) || string.IsNullOrEmpty(request.CPF)))
                throw new ArgumentException("Nome e CPF são obrigatórios para pessoa física.");
            if (request.TipoCliente == TipoCliente.PessoaJuridica && (string.IsNullOrEmpty(request.RazaoSocial) || string.IsNullOrEmpty(request.CNPJ)))
                throw new ArgumentException("Razão Social e CNPJ são obrigatórios para pessoa jurídica.");

            // Persiste o cliente e os eventos
            await _clienteRepository.AddAsync(cliente);
            await _eventStore.SaveEventsAsync(cliente.DomainEvents);

            return cliente.Id;
        }
    }
}
