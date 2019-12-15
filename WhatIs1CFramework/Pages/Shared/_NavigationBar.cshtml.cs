using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WhatIs1CFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace WhatIs1CFramework.Pages.Shared
{
    public class _NavigationBarModel : PageModel
    {
        private readonly WhatIs1CFramework.Data.WhatIs1CFrameworkContext _context;
        public IList<Article> Article { get; set; }

        public _NavigationBarModel(WhatIs1CFramework.Data.WhatIs1CFrameworkContext context)
        {
            _context = context;
            Article = _context.Article
                .Where(s => s.Display == true)
                .OrderBy(s => s.SortOrder)
                .ToList();
        }
        public void OnGet()
        {
            //Article = _context.Article.ToList();
        }
    }
}
