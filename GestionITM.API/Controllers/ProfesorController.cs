using Microsoft.AspNetCore.Mvc;
using GestionITM.Domain.Dtos;
using GestionITM.Domain.Interfaces;

namespace GestionITM.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfesorController : ControllerBase 
{
    private readonly IProfesorService _service; // Inyección de la interfaz [cite: 28, 41]

    public ProfesorController(IProfesorService service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _service.GetAllAsync()); // [cite: 28, 41]

    [HttpPost]
    public async Task<IActionResult> Post(ProfesorCreateDto dto) => Ok(await _service.CreateAsync(dto)); // [cite: 28, 41]
}