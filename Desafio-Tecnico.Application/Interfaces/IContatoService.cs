using Desafio_Tecnico.Domain.Models;

namespace Desafio_Tecnico.Application.Interfaces
{
    public interface IContatoService
    {
        Task AddAsync(Contato cliente);
    }
}
