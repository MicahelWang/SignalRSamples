using System.Collections.Generic;
using SignalRSamples.Infrastructure;

namespace SignalRSamples.Data.Models
{
    public partial class User: IEntity
    {
        public User()
        {
            this.Messages = new List<Message>();
            this.MessageRelations = new List<MessageRelation>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public System.DateTime CreateTime { get; set; }
        public virtual Account Account { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<MessageRelation> MessageRelations { get; set; }
    }
}
