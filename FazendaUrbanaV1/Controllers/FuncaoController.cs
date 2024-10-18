using FazendaUrbanaV1.Data;
using FazendaUrbanaV1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class FuncaoController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public FuncaoController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Usuarios
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Funcao>>> GetFuncao()
    {
        return await _context.Funcoes.ToListAsync();
    }

    // POST: api/Usuarios
    [HttpPost]
    public async Task<ActionResult<Funcao>> PostFuncao(Funcao funcao)
    {
        _context.Funcoes.Add(funcao);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetFuncao), new { id = funcao.Id }, funcao);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Funcao>> GetFuncaoById(int id)
    {
        var funcao = await _context.Funcoes
            .FirstOrDefaultAsync(u => u.Id == id);

        if (funcao == null)
        {
            return NotFound(); // Retorna 404 se o usuário não for encontrado
        }

        return funcao; // Retorna o usuário com sucesso
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateFuncao(int id, Funcao funcaoAtualizada)
    {
        if (id != funcaoAtualizada.Id)
        {
            return BadRequest("ID da URL e ID da Função não correspondem.");
        }

        var funcaoExistente = await _context.Usuarios.FindAsync(id);
        if (funcaoExistente == null)
        {
            return NotFound("Função não encontrada.");
        }

        // Atualiza os campos do usuário
        funcaoExistente.Nome = funcaoAtualizada.Nome;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!FuncaoExists(id))
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
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLine(int id)
    {
        var lineDelete = await _context.Funcoes.FindAsync(id);
        if (lineDelete == null)
        {
            return NotFound("Objeto não encontrado.");
        }

        _context.Funcoes.Remove(lineDelete);
        await _context.SaveChangesAsync();

        return NoContent(); // Retorna 204 No Content para indicar que a exclusão foi bem-sucedida
    }
    

     private bool FuncaoExists(int id)
    {
        return _context.Funcoes.Any(e => e.Id == id);
    }

}
