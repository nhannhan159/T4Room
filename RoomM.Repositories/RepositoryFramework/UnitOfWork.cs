using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RoomM.Models;

namespace RoomM.Repositories
{
    public class UnitOfWork
    {
        private EFDataContext context;

        // from "Room"
        private IRoomRepository roomRepo;
        private IRepository<RoomType> roomTypeRepo;
        private IRoomAssetRepository roomAssRepo;
        private IRoomCalendarRepository roomCalRepo;
        private IRoomCalendarStatusRepository roomCalStatusRepo;

        // from "Asset"
        private IAssetRepository assRepo;
        private IRoomAssetHistoryRepository assHisRepo;
        private IRepository<HistoryType> assHistoryTypeRepo;

        // from "Staff"
        private IStaffRepository staffRepo;
        private IRepository<StaffType> staffTypeRepo;

        public UnitOfWork(EFDataContext _context)
        {
            this.context = _context;
        }

        public EFDataContext Context
        {
            set { this.context = value; }
        }

        public void Commit()
        {
            this.context.SaveChanges();
        }

        public IRoomRepository RoomRepository
        {
            get
            {
                if (this.roomRepo == null)
                {
                    this.roomRepo = new RoomRepository(this.context);
                }
                return roomRepo;
            }
        }

        public IRepository<RoomType> RoomTypeRepository
        {
            get
            {
                if (this.roomTypeRepo == null)
                {
                    this.roomTypeRepo = new RepositoryBase<RoomType>(this.context);
                }
                return roomTypeRepo;
            }
        }

        public IRoomAssetRepository RoomAssetRepository
        {
            get
            {
                if (this.roomAssRepo == null)
                {
                    this.roomAssRepo = new RoomAssetRepository(this.context);
                }
                return roomAssRepo;
            }
        }

        public IRoomCalendarRepository RoomCalendarRepository
        {
            get
            {
                if (this.roomCalRepo == null)
                {
                    this.roomCalRepo = new RoomCalendarRepository(this.context);
                }
                return roomCalRepo;
            }
        }

        public IRoomCalendarStatusRepository RoomCalendarStatusRepository
        {
            get
            {
                if (this.roomCalStatusRepo == null)
                {
                    this.roomCalStatusRepo = new RoomCalendarStatusRepository(this.context);
                }
                return roomCalStatusRepo;
            }
        }

        public IAssetRepository AssetRepository
        {
            get
            {
                if (this.assRepo == null)
                {
                    this.assRepo = new AssetRepository(this.context);
                }
                return assRepo;
            }
        }

        public IRoomAssetHistoryRepository RoomAssetHistoryRepository
        {
            get
            {
                if (this.assHisRepo == null)
                {
                    this.assHisRepo = new RoomAssetHistoryRepository(this.context);
                }
                return assHisRepo;
            }
        }

        public IRepository<HistoryType> RoomAssetHistoryTypeRepository
        {
            get
            {
                if (this.assHistoryTypeRepo == null)
                {
                    this.assHistoryTypeRepo = new RepositoryBase<HistoryType>(this.context);
                }
                return assHistoryTypeRepo;
            }
        }

        public IStaffRepository StaffRepository
        {
            get
            {
                if (this.staffRepo == null)
                {
                    this.staffRepo = new StaffRepository(this.context);
                }
                return staffRepo;
            }
        }

        public IRepository<StaffType> StaffTypeRepository
        {
            get
            {
                if (this.staffTypeRepo == null)
                {
                    this.staffTypeRepo = new RepositoryBase<StaffType>(this.context);
                }
                return staffTypeRepo;
            }
        }
    }
}
