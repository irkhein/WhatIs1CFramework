using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WhatIs1CFramework.Data;
using WhatIs1CFramework.Models;

namespace WhatIs1CFramework.Pages.Articles
{
    public class DetailsModel : PageModel
    {
        private readonly WhatIs1CFramework.Data.WhatIs1CFrameworkContext _context;

        public DetailsModel(WhatIs1CFramework.Data.WhatIs1CFrameworkContext context)
        {
            _context = context;
        }

        public Article Article { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Article = await _context.Article
                .Include(s => s.Pictures)// added when Images added as a property to the Model
                .AsNoTracking().FirstOrDefaultAsync(m => m.ID == id);

            if (Article == null)
            {
                return NotFound();
            }
            return Page();
        }

    
    }
}
