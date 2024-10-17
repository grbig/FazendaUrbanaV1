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
}
