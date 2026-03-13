using Desafio_Tecnico.Domain.Models;

namespace Desafio_Tecnico.Application.Interfaces
{
    public interface IAssinaturaService
    {
        Task AddAsync(Assinatura cliente);
        Task<ICollection<Assinatura>> GetAllAsync();
        Task<Assinatura> GetByIdAsync(int id); 
        Task<Assinatura> UpdateAsync(Assinatura assinatura);
        Task<Assinatura> DeactivateAsync(int id);
        Task DeleteAsync(int id);
    }
}
