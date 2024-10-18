using FazendaUrbanaV1.Data;
using FazendaUrbanaV1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[Route("api/[controller]")]
[ApiController]
public class CategoriaController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public FuncaoController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Categorias
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Categorias>>> GetCategorias()
    {
        return await _context.Categorias.ToListAsync();
    }

    // POST: api/Categorias
    [HttpPost]
    public async Task<ActionResult<Categorias>> PostCategoria(Categorias categoria)
    {
        _context.Categorias.Add(categoria);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCategorias), new { id = categoria.Id }, categoria);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Categorias>> GetCategoriaById(int id)
    {
        var categoria = await _context.Categorias
            .FirstOrDefaultAsync(u => u.Id == id);

        if (categoria == null)
        {
            return NotFound(); // Retorna 404 se o usuário não for encontrado
        }

        return categoria; // Retorna o usuário com sucesso
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategoria(int id, Categorias categoriaAtualizada)
    {
        if (id != categoriaAtualizada.Id)
        {
            return BadRequest("ID da URL e ID da Categoria não correspondem.");
        }

        var categoriaExistente = await _context.Categorias.FindAsync(id);
        if (categoriaExistente == null)
        {
            return NotFound("Categoria não encontrada.");
        }

        categoriaExistente.Categoria = usuarioAtualizado.Categoria;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CategoriaExists(id))
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
        var lineDelete = await _context.Categorias.FindAsync(id);
        if (lineDelete == null)
        {
            return NotFound("Objeto não encontrado.");
        }

        _context.Categorias.Remove(lineDelete);
        await _context.SaveChangesAsync();

        return NoContent(); // Retorna 204 No Content para indicar que a exclusão foi bem-sucedida
    }

     private bool CategoriaExists(int id)
    {
        return _context.Categorias.Any(e => e.Id == id);
    }


}
