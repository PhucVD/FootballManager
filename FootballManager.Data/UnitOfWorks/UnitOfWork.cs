using System;
using System.Data.Entity;
using FootballManager.Data.Repository;

namespace FootballManager.Data.UnitOfWorks
{
    public class UnitOfWork: IUnitOfWork, IDisposable
    {
        private FootballContext context;

        public DbContext GetDbContext() => context ?? new FootballContext();

        public UnitOfWork()
        {
            context = new FootballContext();
        }

        public int Commit()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (context != null)
                {
                    context.Dispose();
                    context = null;
                }
            }
        }
    }
}
