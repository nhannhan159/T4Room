using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
            modelBuilder.Configurations.Add(new RoomConfiguration());
            modelBuilder.Configurations.Add(new RoomTypeConfiguration());
            modelBuilder.Configurations.Add(new RoomRegConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
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

        public IRoleRepository RoleRep
        {
            get
            {
                if (this.roleRep == null)
                    this.roleRep = new RoleRepository(this);
                return this.roleRep;
            }
        }

        #endregion

        public System.Data.Entity.DbSet<RoomM.Domain.AssetModule.Aggregates.AssetDetail> AssetDetails { get; set; }

        public System.Data.Entity.DbSet<RoomM.Domain.AssetModule.Aggregates.Asset> Assets { get; set; }

        public System.Data.Entity.DbSet<RoomM.Domain.RoomModule.Aggregates.Room> Rooms { get; set; }
    }
}
