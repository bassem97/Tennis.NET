


using PS.Data.Infrastructure;


namespace Service.Tournoi
{
    public class TournoiService : ServicePattern.Service<Domain.Tournoi>,ITournoiService
    {
        public TournoiService(IUnitOfWork utwk) : base(utwk)
        {
        }

        
    }
}