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
    public class TicketDetailsModel : PageModel
    {
        private readonly ToLateToCare_front.Data.ContexteBDD _context;

        public TicketDetailsModel(ToLateToCare_front.Data.ContexteBDD context)
        {
            _context = context;
        }

        public Ticket Ticket { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ticket = await _context.Tickets.FirstOrDefaultAsync(m => m.Id == id);

            if (Ticket == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
