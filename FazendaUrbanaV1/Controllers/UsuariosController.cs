using FazendaUrbanaV1.Data;
using FazendaUrbanaV1.Dto;
using FazendaUrbanaV1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class UsuariosController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public UsuariosController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Usuarios
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UsuarioDto>>> GetUsuarios()
    {
#pragma warning disable CS8602 // Desreferência de uma referência possivelmente nula.
        var usuarios = await _context.Usuarios
           .Include(u => u.Funcao)
           .Select(static u => new UsuarioDto
           {
               Id = u.Id,
               Nome = u.Nome,
               Email = u.Email,
               FuncaoId = u.FuncaoId,
               NomeFuncao = u.Funcao.Nome
           })
           .ToListAsync();
#pragma warning restore CS8602 // Desreferência de uma referência possivelmente nula.

        return usuarios;
    }

    // POST: api/Usuarios
    [HttpPost]
    public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetUsuarios), new { id = usuario.Id }, usuario);
    }
}
