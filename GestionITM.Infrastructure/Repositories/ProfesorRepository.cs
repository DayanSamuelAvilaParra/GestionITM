using GestionITM.Domain.Entities;
using GestionITM.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestionITM.Infrastructure.Repositories;

public class ProfesorRepository : IProfesorRepository 
{
    private readonly ApplicationDbContext _context;
    public ProfesorRepository(ApplicationDbContext context) => _context = context;

    public async Task<IEnumerable<Profesor>> GetAllAsync() => await _context.Set<Profesor>().ToListAsync();

    public async Task AddAsync(Profesor profesor) 
    {
        await _context.Set<Profesor>().AddAsync(profesor);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsByEmailAsync(string email) => 
        await _context.Set<Profesor>().AnyAsync(p => p.Email == email); // [cite: 45]
}
