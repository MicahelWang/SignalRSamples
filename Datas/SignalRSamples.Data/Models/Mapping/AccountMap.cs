using System.Data.Entity.ModelConfiguration;

namespace SignalRSamples.Data.Models.Mapping
{
    public class AccountMap : EntityTypeConfiguration<Account>
    {
        public AccountMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.AccountName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Password)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Account");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.AccountName).HasColumnName("AccountName");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.LastLoginTime).HasColumnName("LastLoginTime");

            // Relationships
            this.HasRequired(t => t.User)
                .WithOptional(t => t.Account);

        }
    }
}
