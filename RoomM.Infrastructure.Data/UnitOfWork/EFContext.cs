using RoomM.Infrastructure.Data.UnitOfWork.Mapping;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Migrations.History;

namespace RoomM.Infrastructure.Data.UnitOfWork
{
    public class EFContext : DbContext
    {
        public EFContext() : base("name=RoomDB_MySql")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AssetConfiguration());
            modelBuilder.Configurations.Add(new AssetDetailConfiguration());
            modelBuilder.Configurations.Add(new AssetHistoryConfiguration());
            modelBuilder.Configurations.Add(new RoomConfiguration());
            modelBuilder.Configurations.Add(new RoomTypeConfiguration());
            modelBuilder.Configurations.Add(new RoomRegConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new UserClaimConfiguration());
            modelBuilder.Configurations.Add(new UserLoginConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
        }
    }

    public class MySqlHistoryContext : HistoryContext
    {
        public MySqlHistoryContext(DbConnection connection, string defaultSchema) : base(connection, defaultSchema)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<HistoryRow>().Property(h => h.MigrationId).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<HistoryRow>().Property(h => h.ContextKey).HasMaxLength(200).IsRequired();
        }
    }
}