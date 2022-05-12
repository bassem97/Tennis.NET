using System;
using System.Collections.Generic;
using ServicePattern;

namespace Service.Jouer
{
    public interface IJouerService : IService<Domain.Jouer>
    {
        double scoreFinale(Domain.Joueur joueur, DateTime annee);
        IList<Domain.Joueur> Meilleur10(DateTime date);
        
        double poucentage(Domain.Pays pays, DateTime date);
        
        
    }
}