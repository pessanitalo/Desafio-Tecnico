using Desafio_Tecnico.Application.Interfaces;
using Desafio_Tecnico.Domain.Models;


namespace Desafio_Tecnico.Application.Services
{
    public class ContatoService : IContatoService
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoService(IContatoRepository clienteRepository)
        {
            _contatoRepository = clienteRepository;
        }
        public async Task AddAsync(Contato cliente)
        {
            await _contatoRepository.AddAsync(cliente);
        }
    }
}
