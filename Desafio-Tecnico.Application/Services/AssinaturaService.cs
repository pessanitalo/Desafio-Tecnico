using Desafio_Tecnico.Application.Interfaces;
using Desafio_Tecnico.Domain.Models;


namespace Desafio_Tecnico.Application.Services
{
    public class AssinaturaService : IAssinaturaService
    {
        private readonly IAssinaturaRepository _assinaturaRepository;

        public AssinaturaService(IAssinaturaRepository clienteRepository)
        {
            _assinaturaRepository = clienteRepository;
        }
        public async Task AddAsync(Assinatura cliente)
        {
            await _assinaturaRepository.AddAsync(cliente);
        }

        public async Task<Assinatura> DeactivateAsync(int id)
        {
            var assinatura = await _assinaturaRepository.DeactivateAsync(id);
            return assinatura;
        }

        public async Task DeleteAsync(int id)
        {
            await _assinaturaRepository.DeleteAsync(id);
        }

        public async Task<ICollection<Assinatura>> GetAllAsync()
        {
            var assinaturas = await _assinaturaRepository.GetAllAsync();
            return assinaturas;
        }

        public async Task<Assinatura> GetByIdAsync(int id)
        {
            var assinatura = await _assinaturaRepository.GetByIdAsync(id);
            return assinatura;
        }
    }
}
