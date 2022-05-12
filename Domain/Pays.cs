using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Pays
    {
        [Key]
        public string CodePays { get; set; }
        public string Nom { get; set; }
        public string Monnaie { get; set; }
        
        public virtual IList<Joueur> Joueurs { get; set; }
    }
}