using RoomM.Domain.UserModule.Aggregates;
using System.Data.Entity.ModelConfiguration;

namespace RoomM.Infrastructure.Data.UnitOfWork.Mapping
{
    public class UserClaimConfiguration : EntityTypeConfiguration<UserClaim>
    {
        public UserClaimConfiguration()
        {
            // key
            this.HasKey(t => t.Id);

            // properties
            this.Property(t => t.UserId).IsOptional();
            this.Property(t => t.ClaimType).IsOptional();
            this.Property(t => t.ClaimValue).IsOptional();

            // table
            this.ToTable("UserClaims");

            // relationship
            this.HasOptional(t => t.User)
                .WithMany(c => c.UserClaims)
                .HasForeignKey(t => t.UserId)
                .WillCascadeOnDelete(true);
        }
    }
}