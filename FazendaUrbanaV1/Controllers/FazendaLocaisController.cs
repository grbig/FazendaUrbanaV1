using FazendaUrbanaV1.Data;
using FazendaUrbanaV1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[Route("api/[controller]")]
[ApiController]
public class FazendaLocaisController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public FazendaLocaisController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/FazendaLocais
    [HttpGet]
    public async Task<ActionResult<IEnumerable<FazendaLocais>>> GetFazendaLocais()
    {
        return await _context.FazendaLocais.ToListAsync();
    }

    // POST: api/FazendaLocais
    [HttpPost]
    public async Task<ActionResult<FazendaLocais>> PostFazendaLocal(FazendaLocais fazendaLocal)
    {
        _context.FazendaLocais.Add(fazendaLocal);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetFazendaLocais), new { id = fazendaLocal.Id }, fazendaLocal);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Fazenda>> GetFazendaLocalById(int id)
    {
        var fazendaLocal = await _context.FazendaLocais
            .FirstOrDefaultAsync(u => u.Id == id);

        if (fazendaLocal == null)
        {
            return NotFound(); // Retorna 404
        }

        return fazendaLocal; 
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateFazendaLocal(int id, FazendaLocais fazendaLocalAtualizada)
    {
        if (id != fazendaLocalAtualizada.Id)
        {
            return BadRequest("ID da URL e ID do Local da Fazenda não correspondem.");
        }

        var fazendaLocalExistente = await _context.FazendaLocais.FindAsync(id);
        if (fazendaLocalExistente == null)
        {
            return NotFound("Local da Fazenda não encontrada.");
        }

        fazendaLocalExistente.Status = fazendaLocalAtualizada.Status;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!FazendaLocalExists(id))
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
        var lineDelete = await _context.FazendaLocais.FindAsync(id);
        if (lineDelete == null)
        {
            return NotFound("Objeto não encontrado.");
        }

        _context.FazendaLocais.Remove(lineDelete);
        await _context.SaveChangesAsync();

        return NoContent(); // Retorna 204 No Content para indicar que a exclusão foi bem-sucedida
    }


     private bool FazendaLocalExists(int id)
    {
        return _context.FazendaLocais.Any(e => e.Id == id);
    }


}
