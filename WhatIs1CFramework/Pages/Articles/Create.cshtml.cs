using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
// manually added
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using WhatIs1CFramework.Data;
using WhatIs1CFramework.Models;
using System.IO;

namespace WhatIs1CFramework.Pages.Articles
{
    public class CreateModel : PageModel
    {
        private readonly WhatIs1CFramework.Data.WhatIs1CFrameworkContext _context;

        public CreateModel(WhatIs1CFramework.Data.WhatIs1CFrameworkContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Article Article { get; set; }
        public ICollection<Picture> Pictures { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.

       
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Article.Add(Article);
            await _context.SaveChangesAsync();

            //_context.Article.Add(Article);
            //await _context.SaveChangesAsync();
            var files = HttpContext.Request.Form.Files;
            if (Request.Form.Files.Count > 0)
            {
                //files[0].CopyToAsync
                using (var memoryStream = new MemoryStream())
                {
                    await files[0].CopyToAsync(memoryStream);

                    // Upload the file if less than 2 MB
                    Picture NewPicture = new Picture();//Article.Pictures
                    NewPicture.ImageTitle = files[0].FileName;
                    NewPicture.ArticleID = Article.ID;
                    NewPicture.ImageByte = memoryStream.ToArray();
                    //_context.Entry(Article)
                    //.Collection(art => art.Pictures)
                    //.Load();
                    //_context.Entry(Article).Collection(art => art.Pictures).Query();

                    //_context.Article.Include(s => s.Pictures).ToList().Single().Pictures.Add(NewPicture);

                    //_context.ChangeTracker.Entries.
                    //.Load();
                    _context.Entry(Article)
                    .Collection(art => art.Pictures)
                    .Load();
                    Article.Pictures.Add(NewPicture);
                    _context.Picture.Add(NewPicture);
                    await _context.SaveChangesAsync();
                }
                
            }
            
            return RedirectToPage("./Index");
        }
    }
}
