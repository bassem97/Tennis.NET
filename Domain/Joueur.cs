using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Joueur
    {
        public int JoueurId { get; set; }
        
        [Required(ErrorMessage = "Le nom est obligatoire")]
        public string Nom { get; set; }
        
        [Required(ErrorMessage = "Le prenom est obligatoire")]
        public string Prenom { get; set; }
        
        public string Genre { get; set; }
        public string Photo { get; set; }
        
        public virtual IList<Jouer> Jouers { get; set; }
            
        public virtual Pays Pays { get; set; }
        public string PaysFK { get; set; }

    }
}