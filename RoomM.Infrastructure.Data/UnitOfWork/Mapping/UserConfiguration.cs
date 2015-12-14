using RoomM.Domain.UserModule.Aggregates;
using System.Data.Entity.ModelConfiguration;

namespace RoomM.Infrastructure.Data.UnitOfWork.Mapping
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            // key
            this.HasKey(t => t.Id);

            // properties
            this.Property(t => t.FullName).IsRequired();
            this.Property(t => t.UserName).IsRequired();
            this.Property(t => t.PasswordHash).IsRequired();
            this.Property(t => t.IsWorking).IsRequired();
            this.Property(t => t.Sex).IsOptional();
            this.Property(t => t.Phone).IsOptional();
            this.Property(t => t.Description).IsOptional();
            this.Property(t => t.LastLogin).IsOptional();
            this.Property(t => t.RoleId).IsOptional();

            this.Property(t => t.AccessFailedCount).IsOptional();
            this.Property(t => t.LockoutEnabled).IsOptional();
            this.Property(t => t.LockoutEndDateUtc).IsOptional();
            this.Property(t => t.TwoFactorEnabled).IsOptional();
            this.Property(t => t.SecurityStamp).IsOptional();

            // table
            this.ToTable("Users");

            // relationship
            this.HasOptional(t => t.Role)
                .WithMany(c => c.Users)
                .HasForeignKey(t => t.RoleId)
                .WillCascadeOnDelete(true);
        }
    }
}