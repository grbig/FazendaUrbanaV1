using FazendaUrbanaV1.Data;
using FazendaUrbanaV1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]

public class VendasIteController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public VendasIteController(ApplicationDbContext context)
    {
        _context = context;
    }
    // GET: api/Categorias
    [HttpGet]
    public async Task<ActionResult<IEnumerable<VendasIte>>> GetVendasIte()
    {
        return await _context.VendasIte
            .ToListAsync();
    }

    // POST: api/Categorias
    [HttpPost]
    public async Task<ActionResult<VendasIte>> PostCategoria(VendasIte vendaIte)
    {
        _context.VendasIte.Add(vendaIte);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetVendasIte), new { id = vendaIte.Id }, vendaIte);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<VendasIte>> GetVendaIteById(int id)
    {
        var vendaIte = await _context.VendasIte
            .FirstOrDefaultAsync(u => u.Id == id);

        if (vendaIte == null)
        {
            return NotFound(); // Retorna 404 se o usuário não for encontrado
        }

        return vendaIte; // Retorna o usuário com sucesso
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategoria(int id, VendasIte vendaIteAtualizada)
    {
        if (id != vendaIteAtualizada.Id)
        {
            return BadRequest("ID da URL e ID da Venda não correspondem.");
        }

        var vendaIteExistente = await _context.VendasIte.FindAsync(id);
        if (vendaIteExistente == null)
        {
            return NotFound("Categoria não encontrada.");
        }

        vendaIteExistente.VendaId = vendaIteAtualizada.VendaId;
        vendaIteExistente.IdProduto = vendaIteAtualizada.IdProduto;
        vendaIteExistente.Quantidade = vendaIteAtualizada.Quantidade;
        vendaIteExistente.PercDesc = vendaIteAtualizada.PercDesc;
        vendaIteExistente.VlrUnit = vendaIteAtualizada.VlrUnit;
        vendaIteExistente.VlrTotal = vendaIteAtualizada.VlrTotal;


        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!VendasIteExists(id))
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
        var lineDelete = await _context.VendasIte.FindAsync(id);
        if (lineDelete == null)
        {
            return NotFound("Objeto não encontrado.");
        }

        _context.VendasIte.Remove(lineDelete);
        await _context.SaveChangesAsync();

        return NoContent(); // Retorna 204 No Content para indicar que a exclusão foi bem-sucedida
    }

    private bool VendasIteExists(int id)
    {
        return _context.VendasIte.Any(e => e.Id == id);
    }
}
