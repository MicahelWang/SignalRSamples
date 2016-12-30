using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRChat.Data
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
