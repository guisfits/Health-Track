namespace guisfits.HealthTrack.Infra.Data.UoW
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
