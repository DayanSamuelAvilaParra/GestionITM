using GestionITM.Domain.Dtos;
using GestionITM.Domain.Entities;
using GestionITM.Domain.Interfaces;

namespace GestionITM.Infrastructure.Services;

public class ProfesorService : IProfesorService 
{
    private readonly IProfesorRepository _repository;

    public ProfesorService(IProfesorRepository repository) => _repository = repository;

    public async Task<ProfesorDto> CreateAsync(ProfesorCreateDto dto) 
    {
        // 1. Regla: Validar especialidad no vacía [Requisito PDF]
        if (string.IsNullOrWhiteSpace(dto.Especialidad)) 
            throw new Exception("La Especialidad no puede ser vacía");

        // 2. Regla: Perfil Senior (Imprimir en consola) [Requisito PDF]
        if (dto.Especialidad.Equals("Arquitectura", StringComparison.OrdinalIgnoreCase)) 
            Console.WriteLine("Perfil Senior Detectado");

        // 3. RETO DE ROBUSTEZ: Error a propósito para el Middleware [Requisito PDF]
        if (dto.Nombre.Equals("Error", StringComparison.OrdinalIgnoreCase)) 
            throw new Exception("Error de prueba");

        // 4. BONUS NIVEL 5: Validar Email único [Requisito PDF]
        if (await _repository.ExistsByEmailAsync(dto.Email)) 
            throw new Exception("El email ya existe en la base de datos");

        // Mapeo de DTO a Entidad
        var profesor = new Profesor { 
            Nombre = dto.Nombre, 
            Especialidad = dto.Especialidad, 
            Email = dto.Email, 
            FechaContratacion = dto.FechaContratacion 
        };

        await _repository.AddAsync(profesor);
        
        // Retornar el DTO de lectura (No muestra la FechaContratacion) [Requisito PDF]
        return new ProfesorDto(profesor.Id, profesor.Nombre, profesor.Especialidad, profesor.Email);
    }

    public async Task<IEnumerable<ProfesorDto>> GetAllAsync() 
    {
        var profesores = await _repository.GetAllAsync();
        return profesores.Select(p => new ProfesorDto(p.Id, p.Nombre, p.Especialidad, p.Email));
    }
}
