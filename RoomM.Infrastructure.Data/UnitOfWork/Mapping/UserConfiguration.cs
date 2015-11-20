using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using RoomM.Domain.UserModule.Aggregates;

namespace RoomM.Infrastructure.Data.UnitOfWork.Mapping
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        { 
            // key
            this.HasKey(t => t.Id);

            // properties
            this.Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(t => t.FullName).IsRequired();
            this.Property(t => t.UserName).IsRequired();
            this.Property(t => t.PasswordHash).IsRequired();
            this.Property(t => t.IsWorking).IsRequired();
            this.Property(t => t.Sex).IsOptional();
            this.Property(t => t.Phone).IsOptional();
            this.Property(t => t.Description).IsOptional();

            this.Property(t => t.AccessFailedCount).IsOptional();
            this.Property(t => t.LockoutEnabled).IsOptional();
            this.Property(t => t.LockoutEndDateUtc).IsOptional();
            this.Property(t => t.TwoFactorEnabled).IsOptional();
            this.Property(t => t.SecurityStamp).IsOptional();

            // table
            this.ToTable("Users");

            // relationship
            this.HasMany(u => u.Roles).WithMany(r => r.Users).Map((config) =>
            {
                config
                    .ToTable("UsersInRoles")
                    .MapLeftKey("UserId")
                    .MapRightKey("RoleId");
            });
        }
    }
}
