namespace TNS.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private TNSExampleDbContext dbContext;

        public TNSExampleDbContext Init()
        {
            return dbContext ?? (dbContext = new TNSExampleDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}