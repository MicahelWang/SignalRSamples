using SignalRSamples.Infrastructure;

namespace SignalRSamples.Data.Models
{
    public partial class Account: IEntity
    {
        public string Id { get; set; }
        public string AccountName { get; set; }
        public string Password { get; set; }
        public System.DateTime CreateTime { get; set; }
        public System.DateTime LastLoginTime { get; set; }
        public virtual User User { get; set; }
    }
}
