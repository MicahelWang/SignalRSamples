using EntityFramework.Batch;
using EntityFrameworkExtended = EntityFramework;

namespace SignalRSamples.Infrastructure.Data.Ef
{
    public class EfBootstrap
    {
        public static void UseMySql()
        {
            EntityFrameworkExtended.Locator.Current.Register<IBatchRunner>(() => new MySqlBatchRunner());
        }
    }
}
