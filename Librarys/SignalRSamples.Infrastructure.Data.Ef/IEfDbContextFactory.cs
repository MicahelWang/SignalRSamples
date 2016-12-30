using System.Data.Entity;

namespace SignalRSamples.Infrastructure.Data.Ef
{
    public interface IEfDbContextFactory
    {
        DbContext GetDbContext();
    }
}