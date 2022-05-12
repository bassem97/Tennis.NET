using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Configurations;

namespace Data
{
    public class Context: DbContext
    {
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data source= (localdb)\MSSQLLOCALDB; INITIAL CATALOG= bassem; INTEGRATED SECURITY= TRUE").UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration( new JouerConfig());
            modelBuilder.ApplyConfiguration( new JoueurConfig());

        }
    }
}
