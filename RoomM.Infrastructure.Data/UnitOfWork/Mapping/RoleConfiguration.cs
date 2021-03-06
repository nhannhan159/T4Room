﻿using RoomM.Domain.UserModule.Aggregates;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RoomM.Infrastructure.Data.UnitOfWork.Mapping
{
    public class RoleConfiguration : EntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
        {
            // key
            this.HasKey(t => t.Id);

            // properties
            this.Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(t => t.Name);

            // table
            this.ToTable("Roles");
        }
    }
}