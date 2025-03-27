using MediatR;
using Romanel.Evaluation.domain.Entities;
using Romanel.Evaluation.domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var cliente = new Cliente(request.Nome, request.CPF, request.DataNascimento, request.Telefone, request.Email, endereco);

            // Verificar unicidade de CPF e Email
            if (await _clienteRepository.ExistsByCPFAsync(request.CPF))
                throw new ApplicationException("CPF já cadastrado.");
            if (await _clienteRepository.ExistsByEmailAsync(request.Email))
                throw new ApplicationException("E-mail já cadastrado.");

            // Persistir o cliente e os eventos
            await _clienteRepository.AddAsync(cliente);
            await _eventStore.SaveEventsAsync(cliente.DomainEvents);

            return cliente.Id;
        }
    }
}
