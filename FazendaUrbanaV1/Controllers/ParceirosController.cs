using FazendaUrbanaV1.Data;
using FazendaUrbanaV1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[Route("api/[controller]")]
[ApiController]
public class ParceirosController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ParceirosController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Categorias
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Parceiros>>> GetParceiros()
    {
        return await _context.Parceiros.ToListAsync();
    }

    // POST: api/Categorias
    [HttpPost]
    public async Task<ActionResult<Parceiros>> PostParceiro(Parceiros parceiros)
    {
        _context.Parceiros.Add(parceiros);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetParceiros), new { id = parceiros.Id }, parceiro);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Parceiros>> GetParceirosById(int id)
    {
        var parceiro = await _context.Parceiros
            .FirstOrDefaultAsync(u => u.Id == id);

        if (parceiro == null)
        {
            return NotFound(); // Retorna 404
        }

        return parceiro; 
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateParceiro(int id, Parceiros parceiroAtualizado)
    {
        if (id != parceiroAtualizado.Id)
        {
            return BadRequest("ID da URL e ID da Parceiro não correspondem.");
        }

        var parceiroExistente = await _context.Parceiros.FindAsync(id);
        if (parceiroExistente == null)
        {
            return NotFound("Parceiro não encontrada.");
        }

        parceiroExistente.Nome = parceiroAtualizado.Nome;
        parceiroExistente.Cliente = parceiroAtualizado.Cliente;
        parceiroExistente.Fornecedor = parceiroAtualizado.Fornecedor;
        
        
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ParceiroExists(id))
            {
                return NotFound("Parceiro não existe.");
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
        var lineDelete = await _context.Parceiros.FindAsync(id);
        if (lineDelete == null)
        {
            return NotFound("Objeto não encontrado.");
        }

        _context.Parceiros.Remove(lineDelete);
        await _context.SaveChangesAsync();

        return NoContent(); // Retorna 204 No Content para indicar que a exclusão foi bem-sucedida
    }

     private bool ParceiroExists(int id)
    {
        return _context.Parceiros.Any(e => e.Id == id);
    }


}
