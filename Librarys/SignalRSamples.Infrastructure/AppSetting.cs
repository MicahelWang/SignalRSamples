using System.Configuration;

namespace SignalRSamples.Infrastructure
{
    public static class AppSetting
    {
        static AppSetting()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["ChatDbContext"].ConnectionString;
        }

        public static string ConnectionString { get; private set; }
    }
}
