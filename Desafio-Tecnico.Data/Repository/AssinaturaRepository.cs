using Desafio_Tecnico.Application.Interfaces;
using Desafio_Tecnico.Data.Context;
using Desafio_Tecnico.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Desafio_Tecnico.Data.Repository
{
    public class AssinaturaRepository : IAssinaturaRepository
    {
        private readonly DataContext _context;
        private readonly string _connectionString;

        public AssinaturaRepository(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task AddAsync(Assinatura cliente)
        {
            await _context.Assinaturas.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<Assinatura> GetByIdAsync(int id)
        {
            return await _context.Assinaturas
           .Where(c => c.Id == id && c.StatusAssinatura == true)
           .FirstOrDefaultAsync();
        }

        public async Task<ICollection<Assinatura>> GetAllAsync()
        {
            return await _context.Assinaturas
            .Where(c => c.StatusAssinatura == true)
            .ToListAsync();
        }

        public async Task<Assinatura> DeactivateAsync(int id)
        {
            var assinatura = await _context.Assinaturas.FindAsync(id);

            if (assinatura == null)
                return null;

            assinatura.StatusAssinatura = false;
            await _context.SaveChangesAsync();

            return assinatura;
        }

        public async Task DeleteAsync(int id)
        {
            var assinatura = await _context.Assinaturas.FindAsync(id);

            if (assinatura == null)
                return;

            _context.Assinaturas.Remove(assinatura);
            await _context.SaveChangesAsync();
        }

        public async Task<Assinatura> UpdateAsync(Assinatura assinatura)
        {
            var existente = await _context.Assinaturas.FindAsync(assinatura.Id);

            if (existente == null)
                return null;

            _context.Entry(existente).CurrentValues.SetValues(assinatura);
            await _context.SaveChangesAsync();

            return existente;
        }

        public async Task<Assinatura> GetByEmailAsync(string email)
        {
            return await _context.Assinaturas
            .FirstOrDefaultAsync(a => a.Email == email);
        }
    }
}
