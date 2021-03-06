﻿using RoomM.Domain;
using RoomM.Domain.AssetModule.Aggregates;
using RoomM.Domain.RoomModule.Aggregates;
using RoomM.Domain.UserModule.Aggregates;
using RoomM.Infrastructure.Data.AssetModule.Repositories;
using RoomM.Infrastructure.Data.RoomModule.Repositories;
using RoomM.Infrastructure.Data.UnitOfWork.Mapping;
using RoomM.Infrastructure.Data.UserModule.Repositories;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Migrations.History;

namespace RoomM.Infrastructure.Data.UnitOfWork
{
    public class EFContext : DbContext, IUnitOfWork
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

        #region IUnitOfWork implement

        private IRoomRepository roomRep;
        private IRepository<RoomType> roomTypeRep;
        private IRoomRegRepository roomRegRep;

        private IAssetRepository assetRep;
        private IAssetDetailRepository assetDetailRep;
        private IAssetHistoryRepository assetHistoryRep;

        private IUserRepository userRep;
        private IUserClaimRepository userClaimRep;
        private IUserLoginRepository userLoginRep;
        private IRoleRepository roleRep;

        public void Commit()
        {
            this.SaveChanges();
        }

        public void EnableWSMode()
        {
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
        }

        public IRoomRepository RoomRep
        {
            get
            {
                if (this.roomRep == null)
                    this.roomRep = new RoomRepository(this);
                return this.roomRep;
            }
        }

        public IRepository<RoomType> RoomTypeRep
        {
            get
            {
                if (this.roomTypeRep == null)
                    this.roomTypeRep = new Repository<RoomType>(this);
                return this.roomTypeRep;
            }
        }

        public IRoomRegRepository RoomRegRep
        {
            get
            {
                if (this.roomRegRep == null)
                    this.roomRegRep = new RoomRegRepository(this);
                return this.roomRegRep;
            }
        }

        public IAssetRepository AssetRep
        {
            get
            {
                if (this.assetRep == null)
                    this.assetRep = new AssetRepository(this);
                return this.assetRep;
            }
        }

        public IAssetDetailRepository AssetDetailRep
        {
            get
            {
                if (this.assetDetailRep == null)
                    this.assetDetailRep = new AssetDetailRepository(this);
                return this.assetDetailRep;
            }
        }

        public IAssetHistoryRepository AssetHistoryRep
        {
            get
            {
                if (this.assetHistoryRep == null)
                    this.assetHistoryRep = new AssetHistoryRepository(this);
                return this.assetHistoryRep;
            }
        }

        public IUserRepository UserRep
        {
            get
            {
                if (this.userRep == null)
                    this.userRep = new UserRepository(this);
                return this.userRep;
            }
        }

        public IUserClaimRepository UserClaimRep
        {
            get
            {
                if (this.userClaimRep == null)
                    this.userClaimRep = new UserClaimRepository(this);
                return this.userClaimRep;
            }
        }

        public IUserLoginRepository UserLoginRep
        {
            get
            {
                if (this.userLoginRep == null)
                    this.userLoginRep = new UserLoginRepository(this);
                return this.userLoginRep;
            }
        }

        public IRoleRepository RoleRep
        {
            get
            {
                if (this.roleRep == null)
                    this.roleRep = new RoleRepository(this);
                return this.roleRep;
            }
        }

        #endregion IUnitOfWork implement
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