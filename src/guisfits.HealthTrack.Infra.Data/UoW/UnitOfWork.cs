using guisfits.HealthTrack.Infra.Data.Context;

namespace guisfits.HealthTrack.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HealthTrackContext _context;

        public UnitOfWork(HealthTrackContext context)
        {
            _context = context;
        }   

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
