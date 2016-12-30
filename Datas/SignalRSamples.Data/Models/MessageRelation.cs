using SignalRSamples.Infrastructure;

namespace SignalRSamples.Data.Models
{
    public partial class MessageRelation:IEntity
    {
        public string Id { get; set; }
        public string MessageId { get; set; }
        public string Owner { get; set; }
        public int Type { get; set; }
        public System.DateTime CreateTime { get; set; }
        public virtual Message Message { get; set; }
        public virtual User User { get; set; }
    }
}
