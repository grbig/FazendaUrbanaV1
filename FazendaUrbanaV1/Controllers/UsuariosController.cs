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
#pragma warning disable CS8602 // Desrefer�ncia de uma refer�ncia possivelmente nula.
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
#pragma warning restore CS8602 // Desrefer�ncia de uma refer�ncia possivelmente nula.

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

    [HttpGet("{id}")]
    public async Task<ActionResult<Usuario>> GetUsuarioById(int id)
    {
        var usuario = await _context.Usuarios
            .Include(u => u.Funcao) // Inclui a Função relacionada
            .FirstOrDefaultAsync(u => u.Id == id);

        if (usuario == null)
        {
            return NotFound(); // Retorna 404 se o usuário não for encontrado
        }

        return usuario; // Retorna o usuário com sucesso
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUsuario(int id, Usuario usuarioAtualizado)
    {
        if (id != usuarioAtualizado.Id)
        {
            return BadRequest("ID da URL e ID do usuário não correspondem.");
        }

        var usuarioExistente = await _context.Usuarios.FindAsync(id);
        if (usuarioExistente == null)
        {
            return NotFound("Usuário não encontrado.");
        }

        // Atualiza os campos do usuário
        usuarioExistente.Nome = usuarioAtualizado.Nome;
        usuarioExistente.Email = usuarioAtualizado.Email;
        usuarioExistente.Senha = usuarioAtualizado.Senha;
        usuarioExistente.FuncaoId = usuarioAtualizado.FuncaoId;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UsuarioExists(id))
            {
                return NotFound("Usuário não existe.");
            }
            else
            {
                throw;
            }
        }

        return NoContent(); // Retorna 204 quando a atualização é bem-sucedida
    }

    private bool UsuarioExists(int id)
    {
        return _context.Usuarios.Any(e => e.Id == id);
    }
}
