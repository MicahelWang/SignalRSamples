using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SignalRChat.Data.Models.Mapping
{
    public class MessageRelationMap : EntityTypeConfiguration<MessageRelation>
    {
        public MessageRelationMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.MessageId)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Owner)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("MessageRelation");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.MessageId).HasColumnName("MessageId");
            this.Property(t => t.Owner).HasColumnName("Owner");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");

            // Relationships
            this.HasRequired(t => t.Message)
                .WithMany(t => t.MessageRelations)
                .HasForeignKey(d => d.MessageId);
            this.HasRequired(t => t.User)
                .WithMany(t => t.MessageRelations)
                .HasForeignKey(d => d.Owner);

        }
    }
}
