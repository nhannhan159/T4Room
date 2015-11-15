using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;

using RoomM.Domain;
using RoomM.Domain.AssetModule.Aggregates;
using RoomM.Domain.RoomModule.Aggregates;
using RoomM.Domain.UserModule.Aggregates;
using RoomM.Infrastructure.Data.UnitOfWork.Mapping;
using RoomM.Infrastructure.Data.AssetModule.Repositories;
using RoomM.Infrastructure.Data.RoomModule.Repositories;
using RoomM.Infrastructure.Data.UserModule.Repositories;

namespace RoomM.Infrastructure.Data.UnitOfWork
{
    public class EFContext : DbContext, IUnitOfWork
    {
        public EFContext() : base("name=RoomDB") { } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AssetConfiguration());
            modelBuilder.Configurations.Add(new AssetDetailConfiguration());
            modelBuilder.Configurations.Add(new AssetHistoryConfiguration());
            modelBuilder.Configurations.Add(new AssetHistoryTypeConfiguration());
            modelBuilder.Configurations.Add(new RoomConfiguration());
            modelBuilder.Configurations.Add(new RoomTypeConfiguration());
            modelBuilder.Configurations.Add(new RoomRegConfiguration());
            modelBuilder.Configurations.Add(new RoomRegTypeConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new UserRoleConfiguration());
        }

        #region IUnitOfWork implement 

        private IRoomRepository roomRep;
        private IRepository<RoomType> roomTypeRep;
        private IRoomRegRepository roomRegRep;
        private IRepository<RoomRegType> roomRegTypeRep;

        private IAssetRepository assetRep;
        private IAssetDetailRepository assetDetailRep;
        private IAssetHistoryRepository assetHistoryRep;
        private IRepository<AssetHistoryType> assetHistoryTypeRep;

        private IUserRepository userRep;
        private IRepository<UserRole> userRoleRep;

        public void Commit() 
        { 
            base.SaveChanges(); 
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
                return roomRep;
            }
        }

        public IRepository<RoomType> RoomTypeRep
        {
            get
            {
                if (this.roomTypeRep == null)
                    this.roomTypeRep = new Repository<RoomType>(this);
                return roomTypeRep;
            }
        }

        public IRoomRegRepository RoomRegRep
        {
            get
            {
                if (this.roomRegRep == null)
                    this.roomRegRep = new RoomRegRepository(this);
                return roomRegRep;
            }
        }

        public IRepository<RoomRegType> RoomRegTypeRep
        {
            get
            {
                if (this.roomRegTypeRep == null)
                    this.roomRegTypeRep = new Repository<RoomRegType>(this);
                return roomRegTypeRep;
            }
        }

        public IAssetRepository AssetRep
        {
            get
            {
                if (this.assetRep == null)
                    this.assetRep = new AssetRepository(this);
                return assetRep;
            }
        }

        public IAssetDetailRepository AssetDetailRep
        {
            get
            {
                if (this.assetDetailRep == null)
                    this.assetDetailRep = new AssetDetailRepository(this);
                return assetDetailRep;
            }
        }

        public IAssetHistoryRepository AssetHistoryRep
        {
            get
            {
                if (this.assetHistoryRep == null)
                    this.assetHistoryRep = new AssetHistoryRepository(this);
                return assetHistoryRep;
            }
        }

        public IRepository<AssetHistoryType> AssetHistoryTypeRep
        {
            get
            {
                if (this.assetHistoryTypeRep == null)
                    this.assetHistoryTypeRep = new Repository<AssetHistoryType>(this);
                return assetHistoryTypeRep;
            }
        }

        public IUserRepository UserRep
        {
            get
            {
                if (this.userRep == null)
                    this.userRep = new UserRepository(this);
                return userRep;
            }
        }

        public IRepository<UserRole> UserRoleRep
        {
            get
            {
                if (this.userRoleRep == null)
                    this.userRoleRep = new Repository<UserRole>(this);
                return userRoleRep;
            }
        }

        #endregion
    }
}
