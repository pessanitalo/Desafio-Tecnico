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
        public async Task AddAsync(Assinatura assinatura)
        {

            assinatura.TempoAssinaturaMeses = CalcularTempoAssinatura(assinatura.DataInicioAssinatura);
            await _assinaturaRepository.AddAsync(assinatura);
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

        public async Task<Assinatura> GetByEmailAsync(string email)
        {
            return await _assinaturaRepository.GetByEmailAsync(email);
        }

        public async Task<Assinatura> GetByIdAsync(int id)
        {
            var assinatura = await _assinaturaRepository.GetByIdAsync(id);
            assinatura.TempoAssinaturaMeses = CalcularTempoAssinatura(assinatura.DataInicioAssinatura);

            return assinatura;
        }

        public async Task<Assinatura> UpdateAsync(Assinatura assinatura)
        {
            var obj = await _assinaturaRepository.UpdateAsync(assinatura);
            return obj;
        }

        private int CalcularTempoAssinatura(DateTime dataInicio)
        {
            var hoje = DateTime.Now;
            return ((hoje.Year - dataInicio.Year) * 12) + (hoje.Month - dataInicio.Month);
        }
    }
}
