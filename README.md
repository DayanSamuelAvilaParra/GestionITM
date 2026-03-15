Para facilitar la verificación de los componentes creados y modificados, detallo la ubicación de los archivos clave:

1. Lógica de Negocio y Entidades (Domain)

Entidad y DTOs: GestionITM.Domain/Entities/Profesor.cs y carpeta GestionITM.Domain/Dtos/.

Interfaces: IProfesorRepository.cs e IProfesorService.cs en GestionITM.Domain/Interfaces/.

2. Implementación y Acceso a Datos (Infrastructure)

Servicio: GestionITM.Infrastructure/Services/ProfesorService.cs (Aquí se implementó la validación de especialidad "Arquitectura" que imprime en consola).

Repositorio: GestionITM.Infrastructure/Repositories/ProfesorRepository.cs.

Contexto: ApplicationDbContext.cs (Configuración de la tabla Profesores).

