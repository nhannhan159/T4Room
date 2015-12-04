using Microsoft.AspNet.Identity;
using RoomM.WebApp.RoomManagementWS;
using RoomM.Domain.RoomModule.Aggregates;
using RoomM.WebApp.Models.RoomM;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RoomM.WebApp.Controllers
{
    public class RoomRegisterController : Controller
    {
        private RoomManagementWSClient roomManagementService;

        public RoomRegisterController(RoomManagementWSClient roomManagementService)
        {
            this.roomManagementService = roomManagementService;
        }

        // show add register of staff id
        public ActionResult Index()
        {
            IList<RoomType> allRoomType = this.roomManagementService.GetRoomTypeList();
            IList<Room> allRoom = this.roomManagementService.GetRoomList();

            ViewBag.RoomTypeId = new SelectList(allRoomType, "ID", "Name", allRoomType.Count > 0 ? allRoomType[0].Id : 0);
            ViewBag.RoomId = new SelectList(allRoom, "ID", "Name", allRoom.Count > 0 ? allRoom[0].Id : 0);

            // default day 1/5/2011
            IList<RoomReg> calInDate = this.roomManagementService.GetRoomRegListByDate(DateTime.Now, allRoom.Count > 0 ? allRoom[0].Id : -1);
            IList<RoomReg> calInWeek = this.roomManagementService.GetRoomRegListByWeek(DateTime.Now, allRoom.Count > 0 ? allRoom[0].Id : -1);

            DateTime currentDate = DateTime.Now;
            DateTime startDateOfWeek = getStartDayOfWeek(currentDate);
            DateTime endDateOfWeek = getEndDayOfWeek(currentDate);

            ViewBag.StartDay = startDateOfWeek.ToShortDateString();
            ViewBag.EndDay = endDateOfWeek.ToShortDateString();

            // init for lesson list
            var startLst = buildStartList(calInDate);

            ViewBag.TimeTbl = buildTimeTableList(calInWeek);
            return View();
        }

        [Authorize(Roles = "Teacher")]
        public ActionResult RoomRegistered(string messageConfirm)
        {
            IList<RoomReg> calLst = this.roomManagementService.GetRoomRegListByWatchedState(false, User.Identity.GetUserId<Int64>());
            ViewBag.MessageConfirm = messageConfirm;
            return View(calLst);
        }

        [Authorize(Roles = "Teacher")]
        public ActionResult RoomRegisteredAccept(int id)
        {
            RoomReg rc = this.roomManagementService.GetRoomReg(id);
            rc.IsWatched = true;
            this.roomManagementService.EditRoomReg(rc);

            string message = "";
            if (rc.RoomRegTypeId == 3) // huy dk tu quan tri vien
                message = "Xác nhận hủy đăng kí phòng " + rc.Room.Name + " vào ngày "
                + rc.Date.ToShortDateString() + " từ tiết " + rc.Start + " đến tiết " + (rc.Start + rc.Length - 1);
            else // dk thanh cong
                message = "Xác nhận đăng kí phòng " + rc.Room.Name + " vào ngày "
                + rc.Date.ToShortDateString() + " từ tiết " + rc.Start + " đến tiết " + (rc.Start + rc.Length - 1);

            return RedirectToAction("RoomRegistered", new { messageConfirm = message });
        }

        [Authorize(Roles = "Teacher")]
        public ActionResult RoomRegisteredReject(int id)
        {
            RoomReg rc = this.roomManagementService.GetRoomReg(id);

            string message = "Xác nhận hủy đăng kí phòng " + rc.Room.Name + " vào ngày "
                + rc.Date.ToShortDateString() + " từ tiết " + rc.Start + " đến tiết " + (rc.Start + rc.Length - 1);

            this.roomManagementService.DeleteRoomReg(id);
            return RedirectToAction("RoomRegistered", new { messageConfirm = message });
        }

        [Authorize(Roles = "Teacher")]
        public ActionResult HistoryRegistered()
        {
            IList<RoomReg> calLst = this.roomManagementService.GetRoomRegListByWatchedState(true, User.Identity.GetUserId<Int64>());
            return View(calLst);
        }

        // make register room by staff

        // create with params date time vs room
        [Authorize(Roles = "Teacher")]
        public ActionResult Create(string messageConfirm = "", bool isErrorMessage = false, int roomIdBefore = -1)
        {
            // IList<RoomType> allRoomType = roomTypeRepo.GetAll();
            IList<Room> allRoom = this.roomManagementService.GetRoomList();

            // ViewBag.RoomTypeId = new SelectList(allRoomType, "ID", "Name", allRoomType.Count > 0 ? allRoomType[0].ID : 0);

            // default day 1/5/2011
            IList<RoomReg> calInDate;
            IList<RoomReg> calInWeek;

            if (roomIdBefore > 0)
            {
                ViewBag.RoomId = new SelectList(allRoom, "ID", "Name", roomIdBefore);
                calInDate = this.roomManagementService.GetRoomRegListByDate(DateTime.Now, roomIdBefore);
                calInWeek = this.roomManagementService.GetRoomRegListByWeek(DateTime.Now, roomIdBefore);
            }
            else
            {
                ViewBag.RoomId = new SelectList(allRoom, "ID", "Name", allRoom.Count > 0 ? allRoom[0].Id : 0);
                calInDate = this.roomManagementService.GetRoomRegListByDate(DateTime.Now, allRoom.Count > 0 ? allRoom[0].Id : -1);
                calInWeek = this.roomManagementService.GetRoomRegListByWeek(DateTime.Now, allRoom.Count > 0 ? allRoom[0].Id : -1);
            }

            DateTime currentDate = DateTime.Now;
            DateTime startDateOfWeek = getStartDayOfWeek(currentDate);
            DateTime endDateOfWeek = getEndDayOfWeek(currentDate);

            ViewBag.StartDay = startDateOfWeek.ToShortDateString();
            ViewBag.EndDay = endDateOfWeek.ToShortDateString();

            // init for lesson list
            var startLst = buildStartList(calInDate);

            if (startLst.Count == 0)
                startLst.Add(new ItemList
                {
                    ID = "0_0",
                    Value = "bận"
                });

            ViewBag.StartDump = new SelectList(startLst, "ID", "Value", startLst[0].ID);

            ViewBag.Length = new SelectList(startLst);
            ViewBag.TimeTbl = buildTimeTableList(calInWeek);

            if (messageConfirm != null)
            {
                ViewBag.MessageConfirm = messageConfirm;
                ViewBag.IsErrorMessage = isErrorMessage;
            }

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public ActionResult Create(RoomReg roomCal)
        {
            if (ModelState.IsValid)
            {
                if (roomCal.Date < DateTime.Now.Date)
                {
                    string message = "Bạn không thể đăng kí phòng trước ngày hiện tại " + DateTime.Now.ToShortDateString();
                    return RedirectToAction("Create", new { messageConfirm = message, isErrorMessage = true, roomIdBefore = roomCal.RoomId });
                }
                else
                {
                    roomCal.RoomRegTypeId = 1; // wait
                    roomCal.UserId = User.Identity.GetUserId<Int64>();

                    // save
                    //this.uow.RoomCalendarRepository.Add(roomCal);
                    //this.uow.Commit();

                    //string message = "Phòng " + this.uow.RoomRepository.GetSingle(roomCal.RoomId).Name + " đã được đăng kí từ tiết " + roomCal.Start + " đến tiết " + (roomCal.Start + roomCal.Length - 1);
                    //return RedirectToAction("Create", new { messageConfirm = message, isErrorMessage = false, roomIdBefore = roomCal.RoomId });
                }
            }

            return View();
        }

        [HttpPost]
        public ActionResult ChangeSelect(int day, int month, int year, int roomId)
        {
            DateTime currentDate = new DateTime(year, month, day);
            IList<RoomReg> calInDate = this.roomManagementService.GetRoomRegListByDate(currentDate, roomId);
            IList<RoomReg> calInWeek = this.roomManagementService.GetRoomRegListByWeek(currentDate, roomId);

            DateTime startDateOfWeek = getStartDayOfWeek(currentDate);
            DateTime endDateOfWeek = getEndDayOfWeek(currentDate);

            var result = new JsonRegisterViewModel
            {
                TimeTableList = buildTimeTableList(calInWeek),
                StartList = buildStartList(calInDate),
                TimeTableChange = true,
                StartDay = startDateOfWeek.ToShortDateString(),
                EndDay = endDateOfWeek.ToShortDateString()
            };

            return Json(result);
        }

        private List<ItemList> buildStartList(IList<RoomReg> calInDate)
        {
            bool[] offsetday = new Boolean[15]; // false is free
            for (int i = 1; i <= 13; ++i)
            {
                offsetday[i] = false;
            }
            offsetday[14] = true;

            foreach (RoomReg rc in calInDate)
            {
                for (int i = rc.Start; i <= rc.Start + rc.Length - 1; ++i)
                    offsetday[i] = true;
            }

            // init start list
            List<ItemList> startLst = new List<ItemList>();

            for (int i = 1; i <= 13; ++i)
            {
                if (!offsetday[i])
                {
                    int j = i + 1, c = 1;
                    while (!offsetday[j]) { j++; c++; }

                    startLst.Add(new ItemList
                    {
                        ID = i + "_" + c,
                        Value = "tiết " + i,
                    });
                }
            }

            return startLst;
        }

        private List<List<int>> buildTimeTableList(IList<RoomReg> calInWeek)
        {
            // init time table
            // 0 is free
            // 1 is wait
            // 2 is setup
            List<List<int>> timeTblList = new List<List<int>>();
            timeTblList.Add(new List<int>());

            // init slot
            for (int i = 1; i <= 13; ++i)
            {
                List<int> lst = new List<int>();
                lst.Add(0);
                for (int j = 1; j <= 7; ++j)
                {
                    lst.Add(0);
                }
                timeTblList.Add(lst);
            }

            foreach (RoomReg rc in calInWeek)
            {
                int dayOfWeek = (int)rc.Date.DayOfWeek;
                if (dayOfWeek == 0) dayOfWeek = 7;

                for (int i = rc.Start; i <= rc.Start + rc.Length - 1; ++i)
                {
                    timeTblList[i][dayOfWeek] = (int)rc.RoomRegTypeId;
                }
            }

            return timeTblList;
        }

        private DateTime getStartDayOfWeek(DateTime currentDate)
        {
            while (currentDate.DayOfWeek != DayOfWeek.Monday)
                currentDate = currentDate.AddDays(-1);

            return currentDate;
        }

        public DateTime getEndDayOfWeek(DateTime currentDate)
        {
            while (currentDate.DayOfWeek != DayOfWeek.Sunday)
                currentDate = currentDate.AddDays(1);

            return currentDate;
        }
    }
}