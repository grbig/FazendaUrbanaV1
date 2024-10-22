using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FazendaUrbanaV1.Data;
using FazendaUrbanaV1.Models;

namespace FazendaUrbanaV1.Pages.Funcoes
{
    public class DeleteModel : PageModel
    {
        private readonly FazendaUrbanaV1.Data.ApplicationDbContext _context;

        public DeleteModel(FazendaUrbanaV1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Funcao Funcao { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcao = await _context.Funcoes.FirstOrDefaultAsync(m => m.Id == id);

            if (funcao == null)
            {
                return NotFound();
            }
            else
            {
                Funcao = funcao;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcao = await _context.Funcoes.FindAsync(id);
            if (funcao != null)
            {
                Funcao = funcao;
                _context.Funcoes.Remove(Funcao);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
