using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using RoomM.WebApp.Models.RoomM;
using RoomM.Repositories.RepositoryFramework;
using RoomM.Repositories;
using RoomM.Models;

namespace RoomM.WebApp.Controllers
{
    public class RoomAssetsController : Controller
    {

        IRoomAssetRepository roomAssetsRepo = RepositoryFactory.GetRepository<IRoomAssetRepository, RoomAsset>();
        IAssetRepository assetsTypeRepo = RepositoryFactory.GetRepository<IAssetRepository, Asset>();
        IRoomRepository roomRepo = RepositoryFactory.GetRepository<IRoomRepository, Room>();
        IRoomTypeRepository roomTypeRepo = RepositoryFactory.GetRepository<IRoomTypeRepository, RoomType>();

        //
        // GET: /RoomAssets/

        [Authorize(Roles = "Manager")]
        public ActionResult Index()
        {
            // get room list
            IList<Room> roomLst = roomRepo.GetAll();

            // get room tyle
            IList<RoomType> roomTypeLst = roomTypeRepo.GetAll();

            // get all room assets 
            IList<RoomAsset> roomAssetsLst = roomAssetsRepo.GetAll();

            // get all assets type
            IList<Asset> assetsTypeLst = assetsTypeRepo.GetAll();

            ViewBag.RoomList = new SelectList(roomLst, "ID", "Name", roomLst[0].ID);
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
                roomLst = roomRepo.GetByRoomTypeId(roomTypeId) as List<Room>;
            else
                roomLst = roomRepo.GetAll() as List<Room>;

            List<RoomViewModel> roomVMList = new List<RoomViewModel>();
            foreach (Room r in roomLst)
            {
                roomVMList.Add(new RoomViewModel
                {
                    RoomId = r.ID,
                    RoomName = r.Name
                });
            }

            return Json(roomVMList);
        }

        
        [HttpPost]
        [Authorize(Roles = "Manager")]
        public ActionResult ChangeOptions(int roomId, int assetsTypeId)
        {
            var roomAssetsLst = roomAssetsRepo.GetByRoomId(roomId);
            if (assetsTypeId > 0) {
                List<RoomAsset> roomFilter = (from p in roomAssetsLst 
                             where p.Asset.ID == assetsTypeId
                             select p).ToList();
                roomAssetsLst = roomFilter;
            }

            List<RoomAssetViewModel> result = new List<RoomAssetViewModel>();
            foreach (RoomAsset rs in roomAssetsLst)
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
