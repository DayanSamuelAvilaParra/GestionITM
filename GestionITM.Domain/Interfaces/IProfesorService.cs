using GestionITM.Domain.Dtos;

namespace GestionITM.Domain.Interfaces;

public interface IProfesorService 
{
    Task<IEnumerable<ProfesorDto>> GetAllAsync(); // [cite: 28, 41]
    Task<ProfesorDto> CreateAsync(ProfesorCreateDto dto); // [cite: 28, 41]
}
