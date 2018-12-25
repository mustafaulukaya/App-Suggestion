using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uzman_Sistem.Model
{
    class appsuggestContext : DbContext
    {
        public DbSet<App> Apps { get; set; }
        public DbSet<Similarity> Similarities { get; set; }
        public DbSet<Rated> Rates { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<App>().ToTable("App", "public");
            modelBuilder.Entity<Similarity>().ToTable("Similarity", "public");
            modelBuilder.Entity<Rated>().ToTable("Rated", "public");
        }

    }
}
