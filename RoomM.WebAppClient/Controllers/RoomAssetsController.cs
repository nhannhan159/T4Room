using RoomM.WebApp.AssetManagementWS;
using RoomM.WebApp.RoomManagementWS;
using RoomM.Domain.AssetModule.Aggregates;
using RoomM.Domain.RoomModule.Aggregates;
using RoomM.WebApp.Models.RoomM;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RoomM.WebApp.Controllers
{
    public class RoomAssetsController : Controller
    {
        private AssetManagementWSClient assetManagementService;
        private RoomManagementWSClient roomManagementService;

        public RoomAssetsController(
            AssetManagementWSClient assetManagementService,
            RoomManagementWSClient roomManagementService)
        {
            this.assetManagementService = assetManagementService;
            this.roomManagementService = roomManagementService;
        }

        [Authorize(Roles = "Manager")]
        public ActionResult Index()
        {
            // get room list
            IList<Room> roomLst = this.roomManagementService.GetRoomList();

            // get room tyle
            IList<RoomType> roomTypeLst = this.roomManagementService.GetRoomTypeList();

            // get all room assets
            IList<AssetDetail> roomAssetsLst = this.assetManagementService.GetAssetDetailList();

            // get all assets type
            IList<Asset> assetsTypeLst = this.assetManagementService.GetAssetList();

            ViewBag.RoomList = new SelectList(roomLst, "ID", "Name", roomLst[0].Id);
            ViewBag.RoomTypeList = new SelectList(roomTypeLst, "ID", "Name");
            ViewBag.AssetsTypeList = new SelectList(assetsTypeLst, "ID", "Name");

            ViewBag.Message = roomAssetsLst.Count == 0 ? "Dữ liệu rỗng" : "";
            return View(roomAssetsLst);
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public ActionResult ChangeRoomTypeOptions(int roomTypeId, int assetsTypeId)
        {
            List<Room> roomLst;
            if (roomTypeId > 0)
                roomLst = this.roomManagementService.GetRoomListByRoomId(roomTypeId) as List<Room>;
            else
                roomLst = this.roomManagementService.GetRoomList() as List<Room>;

            List<RoomViewModel> roomVMList = new List<RoomViewModel>();
            foreach (Room r in roomLst)
            {
                roomVMList.Add(new RoomViewModel
                {
                    RoomId = r.Id,
                    RoomName = r.Name
                });
            }
            return Json(roomVMList);
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public ActionResult ChangeOptions(int roomId, int assetsTypeId)
        {
            var roomAssetsLst = this.assetManagementService.GetAssetDetailListByRoomId(roomId);
            if (assetsTypeId > 0)
            {
                List<AssetDetail> roomFilter = (from p in roomAssetsLst
                                                where p.AssetId == assetsTypeId
                                                select p).ToList();
                roomAssetsLst = roomFilter;
            }

            List<RoomAssetViewModel> result = new List<RoomAssetViewModel>();
            foreach (AssetDetail rs in roomAssetsLst)
            {
                result.Add(new RoomAssetViewModel
                {
                    RoomName = rs.Room.Name,
                    AssetName = rs.Asset.Name,
                    Amount = rs.Amount
                });
            }
            return Json(result);
        }
    }
}