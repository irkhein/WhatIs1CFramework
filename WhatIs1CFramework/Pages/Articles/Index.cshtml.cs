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
    public class IndexModel : PageModel
    {
        private readonly WhatIs1CFramework.Data.WhatIs1CFrameworkContext _context;

        public IndexModel(WhatIs1CFramework.Data.WhatIs1CFrameworkContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get;set; }

        public async Task OnGetAsync()
        {
            Article = await _context.Article.ToListAsync();
        }
    }
}
