using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FazendaUrbanaV1.Data;
using FazendaUrbanaV1.Models;

namespace FazendaUrbanaV1.Pages.Parceiro
{
    public class DetailsModel : PageModel
    {
        private readonly FazendaUrbanaV1.Data.ApplicationDbContext _context;

        public DetailsModel(FazendaUrbanaV1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Parceiros Parceiros { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parceiros = await _context.Parceiros.FirstOrDefaultAsync(m => m.Id == id);
            if (parceiros == null)
            {
                return NotFound();
            }
            else
            {
                Parceiros = parceiros;
            }
            return Page();
        }
    }
}
