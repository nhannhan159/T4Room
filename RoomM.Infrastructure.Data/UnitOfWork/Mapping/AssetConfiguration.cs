﻿using RoomM.Domain.AssetModule.Aggregates;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RoomM.Infrastructure.Data.UnitOfWork.Mapping
{
    public class AssetConfiguration : EntityTypeConfiguration<Asset>
    {
        public AssetConfiguration()
        {
            // key
            this.HasKey(t => t.Id);

            // properties
            this.Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(t => t.Name).IsRequired();
            this.Property(t => t.IsUsing).IsRequired();
            this.Property(t => t.Amount).IsRequired();
            this.Property(t => t.Description).IsOptional();

            // table
            this.ToTable("Assets");
        }
    }
}