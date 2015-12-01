using RoomM.Domain.UserModule.Aggregates;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RoomM.Infrastructure.Data.UnitOfWork.Mapping
{
    public class UserLoginConfiguration : EntityTypeConfiguration<UserLogin>
    {
        public UserLoginConfiguration()
        {
            // key
            this.HasKey(t => t.Id);

            // properties
            this.Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(t => t.UserId).IsOptional();
            this.Property(t => t.LoginProvider).IsOptional();
            this.Property(t => t.ProviderKey).IsOptional();

            // table
            this.ToTable("UserLogins");

            // relationship
            this.HasOptional(t => t.User)
                .WithMany(c => c.UserLogins)
                .HasForeignKey(t => t.UserId)
                .WillCascadeOnDelete(true);
        }
    }
}