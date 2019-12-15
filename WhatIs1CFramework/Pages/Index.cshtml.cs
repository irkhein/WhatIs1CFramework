using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WhatIs1CFramework.Models;

namespace WhatIs1CFramework.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly WhatIs1CFramework.Data.WhatIs1CFrameworkContext _context;
        public IList<Article> Article { get; set; }

        public IndexModel(ILogger<IndexModel> logger, WhatIs1CFramework.Data.WhatIs1CFrameworkContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            Article = _context.Article.ToList();
        }
    }
}
