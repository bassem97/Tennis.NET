using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Jouer
    {
    
        [Range(0, int.MaxValue, ErrorMessage = "il faut nb positive")]
        public int Score { get; set; }
        
        public virtual Joueur Joueur { get; set; }
        
 
        public int JoueurFK { get; set; }
        
        public virtual Tournoi Tournoi { get; set; }
        
 
        public int TournoiFK { get; set; }

        
    }
}