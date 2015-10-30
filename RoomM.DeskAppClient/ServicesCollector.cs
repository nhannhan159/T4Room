using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RoomM.DeskApp.RoomService;
using RoomM.DeskApp.RoomTypeService;
using RoomM.DeskApp.RoomAssetService;
using RoomM.DeskApp.RoomCalenderService;
using RoomM.DeskApp.RoomCalendarStatusService;
using RoomM.DeskApp.AssetService;
using RoomM.DeskApp.RoomAssetHistoryService;
using RoomM.DeskApp.RoomAssetHistoryTypeService;
using RoomM.DeskApp.StaffService;
using RoomM.DeskApp.StaffTypeService;

namespace RoomM.DeskApp
{
    public class ServicesCollector
    {
        // from "Room"
        private RoomServiceClient roomService;
        private RoomTypeServiceClient roomTypeService;
        private RoomAssetServiceClient roomAssService;
        private RoomCalenderServiceClient roomCalService;
        private RoomCalendarStatusServiceClient roomCalStatusService;

        // from "Asset"
        private AssetServiceClient assService;
        private RoomAssetHistoryServiceClient assHisService;
        private RoomAssetHistoryTypeServiceClient assHistoryTypeService;

        // from "Staff"
        private StaffServiceClient staffService;
        private StaffTypeServiceClient staffTypeService;

        public RoomServiceClient RoomService
        {
            get
            {
                if (this.roomService == null)
                {
                    this.roomService = new RoomServiceClient();
                }
                return roomService;
            }
        }

        public RoomTypeServiceClient RoomTypeService
        {
            get
            {
                if (this.roomTypeService == null)
                {
                    this.roomTypeService = new RoomTypeServiceClient();
                }
                return roomTypeService;
            }
        }

        public RoomAssetServiceClient RoomAssetService
        {
            get
            {
                if (this.roomAssService == null)
                {
                    this.roomAssService = new RoomAssetServiceClient();
                }
                return roomAssService;
            }
        }

        public RoomCalenderServiceClient RoomCalendarService
        {
            get
            {
                if (this.roomCalService == null)
                {
                    this.roomCalService = new RoomCalenderServiceClient();
                }
                return roomCalService;
            }
        }

        public RoomCalendarStatusServiceClient RoomCalendarStatusService
        {
            get
            {
                if (this.roomCalStatusService == null)
                {
                    this.roomCalStatusService = new RoomCalendarStatusServiceClient();
                }
                return roomCalStatusService;
            }
        }

        public AssetServiceClient AssetService
        {
            get
            {
                if (this.assService == null)
                {
                    this.assService = new AssetServiceClient();
                }
                return assService;
            }
        }

        public RoomAssetHistoryServiceClient RoomAssetHistoryService
        {
            get
            {
                if (this.assHisService == null)
                {
                    this.assHisService = new RoomAssetHistoryServiceClient();
                }
                return assHisService;
            }
        }

        public RoomAssetHistoryTypeServiceClient RoomAssetHistoryTypeService
        {
            get
            {
                if (this.assHistoryTypeService == null)
                {
                    this.assHistoryTypeService = new RoomAssetHistoryTypeServiceClient();
                }
                return assHistoryTypeService;
            }
        }

        public StaffServiceClient StaffService
        {
            get
            {
                if (this.staffService == null)
                {
                    this.staffService = new StaffServiceClient();
                }
                return staffService;
            }
        }

        public StaffTypeServiceClient StaffTypeService
        {
            get
            {
                if (this.staffTypeService == null)
                {
                    this.staffTypeService = new StaffTypeServiceClient();
                }
                return staffTypeService;
            }
        }
    }
}
