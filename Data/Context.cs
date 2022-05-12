using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Configurations;
using Domain;

namespace Data
{
    public class Context: DbContext
    {
        public DbSet<Joueur> Joueur { get; set; }
        public DbSet<Jouer> Jouer { get; set; }
        public DbSet<Tournoi> Tournoi { get; set; }
        public DbSet<Pays> Pays { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data source= (localdb)\MSSQLLOCALDB; INITIAL CATALOG= basem; INTEGRATED SECURITY= TRUE").UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)  
        {
        
            
           
            
            modelBuilder.ApplyConfiguration( new JouerConfig());
            modelBuilder.ApplyConfiguration( new JoueurConfig());

        }
    }
}
