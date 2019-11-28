using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WhatIs1CFramework.Models;

namespace WhatIs1CFramework.Data
{
    public class WhatIs1CFrameworkContext : DbContext
    {
        public WhatIs1CFrameworkContext(DbContextOptions<WhatIs1CFrameworkContext> options)
            : base(options)
        {
            
        }

        public DbSet<WhatIs1CFramework.Models.Article> Article { get; set; }
        public DbSet<WhatIs1CFramework.Models.Picture> Picture { get; set; }
        // add when Model changed (added Picture)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Picture>().ToTable("Picture");
            modelBuilder.Entity<Article>().HasMany(s => s.Pictures).WithOne(s => s.Article);
        }
    }
}
