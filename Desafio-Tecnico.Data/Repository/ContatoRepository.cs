using Desafio_Tecnico.Application.Interfaces;
using Desafio_Tecnico.Data.Context;
using Desafio_Tecnico.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Desafio_Tecnico.Data.Repository
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly DataContext _context;
        private readonly string _connectionString;

        public ContatoRepository(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task AddAsync(Contato cliente)
        {
            await _context.Contatos.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<Contato> GetByIdAsync(int id)
        {
            return await _context.Contatos
           .Where(c => c.Id == id)
           .FirstOrDefaultAsync();
        }

        public async Task<ICollection<Contato>> GetAllAsync()
        {
            return await _context.Contatos
            .Where(c => c.Ativo == true)
            .ToListAsync();
        }
    }
}
