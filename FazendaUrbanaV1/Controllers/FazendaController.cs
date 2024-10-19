using FazendaUrbanaV1.Data;
using FazendaUrbanaV1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[Route("api/[controller]")]
[ApiController]
public class FazendaController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public FazendaController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Fazenda
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Fazenda>>> GetFazenda()
    {
        return await _context.Fazendas.ToListAsync();
    }

    // POST: api/Fazenda
    [HttpPost]
    public async Task<ActionResult<Fazenda>> PostFazenda(Fazenda fazenda)
    {
        _context.Fazendas.Add(fazenda);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetFazenda), new { id = fazenda.Id }, fazenda);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Fazenda>> GetFazendaById(int id)
    {
        var fazenda = await _context.Fazendas
            .FirstOrDefaultAsync(u => u.Id == id);

        if (fazenda == null)
        {
            return NotFound(); // Retorna 404
        }

        return fazenda; 
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateFazenda(int id, Fazenda fazendaAtualizada)
    {
        if (id != fazendaAtualizada.Id)
        {
            return BadRequest("ID da URL e ID da Fazenda não correspondem.");
        }

        var fazendaExistente = await _context.Fazendas.FindAsync(id);
        if (fazendaExistente == null)
        {
            return NotFound("Fazenda não encontrada.");
        }

        fazendaExistente.Nome = fazendaAtualizada.Nome;
        fazendaExistente.AreaX = fazendaAtualizada.AreaX;
        fazendaExistente.AreaY = fazendaAtualizada.AreaY;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!FazendaExists(id))
            {
                return NotFound("Fazenda não existe.");
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
        var lineDelete = await _context.Fazendas.FindAsync(id);
        if (lineDelete == null)
        {
            return NotFound("Objeto não encontrado.");
        }

        _context.Fazendas.Remove(lineDelete);
        await _context.SaveChangesAsync();

        return NoContent(); // Retorna 204 No Content para indicar que a exclusão foi bem-sucedida
    }

     private bool FazendaExists(int id)
    {
        return _context.Fazendas.Any(e => e.Id == id);
    }


}
