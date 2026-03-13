using Desafio_Tecnico.Domain.Models;

namespace Desafio_Tecnico.Application.Interfaces
{
    public interface IAssinaturaService
    {
        Task AddAsync(Assinatura cliente);
    }
}
