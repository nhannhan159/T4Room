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
            this.HasKey(t => t.ID);

            // properties
            this.Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(t => t.UserRoleId).IsOptional();
            this.Property(t => t.Name).IsRequired();
            this.Property(t => t.Sex);
            this.Property(t => t.Phone);
            this.Property(t => t.UserName).IsRequired();
            this.Property(t => t.PasswordStored).IsRequired();
            this.Property(t => t.IsWorking).IsRequired();
            this.Property(t => t.Description).IsOptional();

            // table
            this.ToTable("Users");

            // relationship
            this.HasOptional(t => t.UserRole)
                .WithMany(c => c.Users)
                .HasForeignKey(t => t.UserRoleId)
                .WillCascadeOnDelete(true);
        }
    }
}
