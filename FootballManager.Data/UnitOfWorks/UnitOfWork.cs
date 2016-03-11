using System;
using System.Data.Entity;
using FootballManager.Data.Repository;

namespace FootballManager.Data.UnitOfWorks
{
    public class UnitOfWork: IUnitOfWork, IDisposable
    {
        private IFootballContext context;

        public IFootballContext GetDbContext() => context;

        public UnitOfWork(IFootballContext _context)
        {
            context = _context;
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
