using Desafio_Tecnico.Domain.Models;

namespace Desafio_Tecnico.Application.Interfaces
{
    public interface IContatoRepository
    {
        Task AddAsync(Contato cliente);
        Task <ICollection<Contato>> GetAllAsync(); // ok retorna só os ativos
        Task <Contato> GetByIdAsync(int id); // ok 
    }
}
