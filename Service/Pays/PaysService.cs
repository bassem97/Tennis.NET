


using PS.Data.Infrastructure;


namespace Service.Pays
{
    public class PaysService : ServicePattern.Service<Domain.Pays>,IPaysService
    {
        public PaysService(IUnitOfWork utwk) : base(utwk)
        {
        }

        
    }
}