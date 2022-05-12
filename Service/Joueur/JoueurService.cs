


using PS.Data.Infrastructure;


namespace Service.Joueur
{
    public class JoueurService : ServicePattern.Service<Domain.Joueur>,IJoueurService
    {
        public JoueurService(IUnitOfWork utwk) : base(utwk)
        {
        }

        
    }
}