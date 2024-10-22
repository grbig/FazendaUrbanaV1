using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FazendaUrbanaV1.Data;
using FazendaUrbanaV1.Models;

namespace FazendaUrbanaV1.Pages.Usuarios
{
    public class IndexModel : PageModel
    {
        private readonly FazendaUrbanaV1.Data.ApplicationDbContext _context;

        public IndexModel(FazendaUrbanaV1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Usuario> Usuario { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Usuario = await _context.Usuarios
                .Include(u => u.Funcao).ToListAsync();
        }
    }
}
