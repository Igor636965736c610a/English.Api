using English.Core.Domain;
using English.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English.Infrastructure.MyContext
{
    public class EnglishAppContext : DbContext
    {
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Word> Words { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Word>().ToTable("Words")
                .HasOne(p => p.Collection)
                .WithMany(b => b.Word)
                .HasForeignKey(p => p.CollectionId);
        }
        
        public EnglishAppContext(DbContextOptions options) : base(options)
        {
        }
    }
}
