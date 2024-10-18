using FazendaUrbanaV1.Data;
using FazendaUrbanaV1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[Route("api/[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ProdutosController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Produtos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Produtos>>> GetProdutos()
    {
        return await _context.Produtos.ToListAsync();
    }

    // POST: api/Produtos
    [HttpPost]
    public async Task<ActionResult<Produtos>> PostProduto(Produtos produto)
    {
        _context.Produtos.Add(produto);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProdutos), new { id = produto.Id }, produto);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Produtos>> GetProdutosById(int id)
    {
        var produto = await _context.Produtos
            .FirstOrDefaultAsync(u => u.Id == id);

        if (produto == null)
        {
            return NotFound(); // Retorna 404
        }

        return produto; 
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduto(int id, Produtos produtoAtualizado)
    {
        if (id != produtoAtualizado.Id)
        {
            return BadRequest("ID da URL e ID da Parceiro não correspondem.");
        }

        var produtoExistente = await _context.Produtos.FindAsync(id);
        if (produtoExistente == null)
        {
            return NotFound("Produto não encontrado.");
        }

        produtoExistente.Nome = produtoAtualizado.Nome;
        produtoExistente.ProducaoEmSegundos = produtoAtualizado.ProducaoEmSegundos;
        produtoExistente.ValidadeEmSegundos = produtoAtualizado.ValidadeEmSegundos;
        produtoExistente.Estoque = produtoAtualizado.Estoque;
        produtoExistente.Preco = produtoAtualizado.Preco;
        produtoExistente.VlrVenda = produtoAtualizado.VlrVenda;
        produtoExistente.VlrCusto = produtoAtualizado.VlrCusto;
        produtoExistente.Producao = produtoAtualizado.Producao;
        produtoExistente.Venda = produtoAtualizado.Venda;
        produtoExistente.CategoriaId = produtoAtualizado.CategoriaId;
        
        
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProdutoExists(id))
            {
                return NotFound("Produto não existe.");
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
        var lineDelete = await _context.Produtos.FindAsync(id);
        if (lineDelete == null)
        {
            return NotFound("Objeto não encontrado.");
        }

        _context.Produtos.Remove(lineDelete);
        await _context.SaveChangesAsync();

        return NoContent(); // Retorna 204 No Content para indicar que a exclusão foi bem-sucedida
    }

     private bool ProdutoExists(int id)
    {
        return _context.Produtos.Any(e => e.Id == id);
    }


}
