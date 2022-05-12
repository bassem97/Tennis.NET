


using System;
using System.Collections.Generic;
using System.Linq;
using PS.Data.Infrastructure;
using Service.Joueur;


namespace Service.Jouer
{
    public class JouerService : ServicePattern.Service<Domain.Jouer>,IJouerService
    
    {
        
        private readonly  IJoueurService _joueurService;
        public JouerService(IUnitOfWork utwk,IJoueurService _joueurService) : base(utwk)
        {
            
        }


        public double scoreFinale(Domain.Joueur joueur, DateTime annee)
        {
            return GetMany(jouer => jouer.Joueur.JoueurId == joueur.JoueurId)
                .Where(jouer => jouer.Tournoi.Date.Year == annee.Year)
                .Sum(jouer => jouer.Score * jouer.Tournoi.Coef);
        }

        public IList<Domain.Joueur> Meilleur10(DateTime date)
        {
            return GetMany().Where(jouer => jouer.Tournoi.Date.Year == date.Year)
                .OrderByDescending(jouer => jouer.Score)
                .Take(10)
                .Select(jouer => jouer.Joueur)
                .ToList();
        }

        public double poucentage(Domain.Pays pays, DateTime date)
        {

            return _joueurService.GetMany().ToList().Count() /
                GetMany(jouer => jouer.Joueur.Pays.CodePays == pays.CodePays)
                    .Count(jouer => jouer.Tournoi.Date == date) * 100;
        }
    }
}