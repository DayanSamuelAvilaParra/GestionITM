using GestionITM.Domain.Entities;

namespace GestionITM.Domain.Interfaces;

public interface IProfesorRepository 
{
    Task<IEnumerable<Profesor>> GetAllAsync(); // [cite: 14, 41]
    Task AddAsync(Profesor profesor); // [cite: 14, 41]
    Task<bool> ExistsByEmailAsync(string email); // Bonus Nivel 5 [cite: 45]
}
