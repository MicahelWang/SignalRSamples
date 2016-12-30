using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using SignalRChat.Data.Models.Mapping;

namespace SignalRChat.Data.Models
{
    public partial class ChatDbContext : DbContext
    {
        static ChatDbContext()
        {
            Database.SetInitializer<ChatDbContext>(null);
        }

        public ChatDbContext()
            : base(AppSetting.ConnectionString)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageRelation> MessageRelations { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AccountMap());
            modelBuilder.Configurations.Add(new MessageMap());
            modelBuilder.Configurations.Add(new MessageRelationMap());
            modelBuilder.Configurations.Add(new UserMap());
        }
    }
}
