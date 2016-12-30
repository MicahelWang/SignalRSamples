using System.Collections.Generic;
using SignalRSamples.Infrastructure;

namespace SignalRSamples.Data.Models
{
    public partial class Message: IEntity
    {
        public Message()
        {
            this.MessageRelations = new List<MessageRelation>();
        }

        public string Id { get; set; }
        public string Body { get; set; }
        public string CreateBy { get; set; }
        public System.DateTime CreateTime { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<MessageRelation> MessageRelations { get; set; }
    }
}
