using FazendaUrbanaV1.Data;
using FazendaUrbanaV1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


[Route("api/[controller]")]
[ApiController]
public class VendasController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public VendasController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Vendas>>> GetVendas()
    {
        return await _context.Vendas
            .Include(u => u.vendasIte)
            .ToListAsync();
    }

    // POST: api/Vendas
    [HttpPost]
    public async Task<ActionResult<Vendas>> PostVenda(Vendas venda)
    {
        _context.Vendas.Add(venda);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetVendas), new { id = venda.Id }, venda);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Vendas>> GetVendaById(int id)
    {
        var venda = await _context.Vendas
            .Include(v => v.vendasIte)
            .FirstOrDefaultAsync(u => u.Id == id);

        if (venda == null)
        {
            return NotFound(); // Retorna 404 se o usuário não for encontrado
        }

        return venda; // Retorna o usuário com sucesso
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateVenda(int id, Vendas vendaAtualizada)
    {
        if (id != vendaAtualizada.Id)
        {
            return BadRequest("ID da URL e ID da Categoria não correspondem.");
        }

        var vendaExistente = await _context.Vendas.FindAsync(id);
        if (vendaExistente == null)
        {
            return NotFound("Categoria não encontrada.");
        }

        vendaExistente.DataFaturamento = vendaAtualizada.DataFaturamento;
        vendaExistente.IdParceiro = vendaAtualizada.IdParceiro;
        vendaExistente.IdUsuario = vendaAtualizada.IdUsuario;


        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!VendasExists(id))
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
        var lineDelete = await _context.Vendas.FindAsync(id);
        if (lineDelete == null)
        {
            return NotFound("Objeto não encontrado.");
        }

        _context.Vendas.Remove(lineDelete);
        await _context.SaveChangesAsync();

        return NoContent(); // Retorna 204 No Content para indicar que a exclusão foi bem-sucedida
    }

    private bool VendasExists(int id)
    {
        return _context.Vendas.Any(e => e.Id == id);
    }

}
