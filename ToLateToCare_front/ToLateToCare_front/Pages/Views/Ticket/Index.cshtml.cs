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
    public class TicketIndexModel : PageModel
    {
        private readonly ToLateToCare_front.Data.ContexteBDD _context;

        public TicketIndexModel(ToLateToCare_front.Data.ContexteBDD context)
        {
            _context = context;
        }

        public IList<Ticket> Ticket { get;set; }

        public async Task OnGetAsync()
        {
            Ticket = await _context.Tickets.ToListAsync();
        }
    }
}
