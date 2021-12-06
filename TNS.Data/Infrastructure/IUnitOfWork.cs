namespace TNS.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}