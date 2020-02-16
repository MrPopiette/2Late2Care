using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToLateToCare_front.Data;
using _2Late2CareBack;

namespace ToLateToCare_front
{
    public class ClassesDetailsModel : PageModel
    {
        private readonly ToLateToCare_front.Data.ContexteBDD _context;

        public ClassesDetailsModel(ToLateToCare_front.Data.ContexteBDD context)
        {
            _context = context;
        }

        public Classe Classe { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Classe = await _context.Classes.FirstOrDefaultAsync(m => m.libelle == id);

            if (Classe == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
