﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using RoomM.Domain.AssetModule.Aggregates;

namespace RoomM.Infrastructure.Data.UnitOfWork.Mapping
{
    public class AssetHistoryConfiguration : EntityTypeConfiguration<AssetHistory>
    {
        public AssetHistoryConfiguration()
        { 
            // key
            this.HasKey(t => t.ID);

            // properties
            this.Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(t => t.Date);
            this.Property(t => t.AssetHistoryTypeId).IsOptional();
            this.Property(t => t.AssetId).IsOptional();
            this.Property(t => t.RoomId).IsOptional();
            this.Property(t => t.Room2).IsOptional();
            this.Property(t => t.Amount).IsOptional();

            // table
            this.ToTable("AssetHistorys");

            // relationship
            this.HasOptional(t => t.AssetHistoryType)
                .WithMany(c => c.AssetHistories)
                .HasForeignKey(t => t.AssetHistoryTypeId)
                .WillCascadeOnDelete(true);
            this.HasOptional(t => t.Asset)
                .WithMany(c => c.AssetHistories)
                .HasForeignKey(t => t.AssetId)
                .WillCascadeOnDelete(true);
            this.HasOptional(t => t.Room)
                .WithMany(c => c.AssetHistories)
                .HasForeignKey(t => t.RoomId)
                .WillCascadeOnDelete(true);
        }
    }
}