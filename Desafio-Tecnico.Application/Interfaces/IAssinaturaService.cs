using Desafio_Tecnico.Domain.Models;

namespace Desafio_Tecnico.Application.Interfaces
{
    public interface IAssinaturaService
    {
        Task AddAsync(Assinatura cliente); //ok
        Task<ICollection<Assinatura>> GetAllAsync(); //ok
        Task<Assinatura> GetByIdAsync(int id); // ok 
        Task<Assinatura> DeactivateAsync(int id); //ok
        Task DeleteAsync(int id); // ok
    }
}
