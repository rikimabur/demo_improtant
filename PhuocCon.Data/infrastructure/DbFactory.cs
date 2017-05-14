namespace PhuocCon.Data.infrastructure
{
    public class DbFactory : Disposable , IDbFactory
    {
        private PhuocConDbContext dbContext;
        public PhuocConDbContext Init()
        {
            return dbContext ?? (dbContext = new PhuocConDbContext());
        }
        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
