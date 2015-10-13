using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

using RoomM.WebApp.Models.RoomM;
using RoomM.Repositories.RepositoryFramework;
using RoomM.Repositories;
using RoomM.Models;

namespace RoomM.WebApp.Controllers
{
    public class RoomRegisterController : Controller
    {
        IStaffRepository staffRep = RepositoryFactory.GetRepository<IStaffRepository, Staff>();
        IRoomRepository roomRepo = RepositoryFactory.GetRepository<IRoomRepository, Room>();
        IRoomTypeRepository roomTypeRepo = RepositoryFactory.GetRepository<IRoomTypeRepository, RoomType>();
        IRoomCalendarRepository roomCalRepo = RepositoryFactory.GetRepository<IRoomCalendarRepository, RoomCalendar>();
        IRoomCalendarStatusRepository roomCalStatusRepo = RepositoryFactory.GetRepository<IRoomCalendarStatusRepository, RoomCalendarStatus>();
        
        //
        // GET: /RoomRegister/

        // show add register of staff id
        public ActionResult Index()
        {
            IList<RoomType> allRoomType = roomTypeRepo.GetAll();
            IList<Room> allRoom = roomRepo.GetAll();

            ViewBag.RoomTypeId = new SelectList(allRoomType, "ID", "Name", allRoomType.Count > 0 ? allRoomType[0].ID : 0);
            ViewBag.RoomId = new SelectList(allRoom, "ID", "Name", allRoom.Count > 0 ? allRoom[0].ID : 0);

            // default day 1/5/2011
            IList<RoomCalendar> calInDate = roomCalRepo.GetByDateAndRoomId(DateTime.Now, allRoom.Count > 0 ? allRoom[0].ID : -1);
            IList<RoomCalendar> calInWeek = roomCalRepo.GetByWeekAndRoomId(DateTime.Now, allRoom.Count > 0 ? allRoom[0].ID : -1);

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
            // IList<RoomCalendar> calLst1 = roomCalRepo.GetAll();

            IList<RoomCalendar> calLst = roomCalRepo.GetByWatchedState(false, staffRep.GetUserId(User.Identity.Name));
            ViewBag.MessageConfirm = messageConfirm;
            return View(calLst);
        }

        [Authorize(Roles = "Teacher")]
        public ActionResult RoomRegisteredAccept(int id)
        {
            RoomCalendar rc = roomCalRepo.GetSingle(id);
            rc.IsWatched = true;
            roomCalRepo.Edit(rc);
            roomCalRepo.Save();

            string message = "";
            if (rc.RoomCalendarStatusId == 3) // huy dk tu quan tri vien
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
            RoomCalendar rc = roomCalRepo.GetSingle(id);

            RoomCalendar rcInfo = new RoomCalendar
            {
                Room = rc.Room,
                Start = rc.Start,
                Length = rc.Length,
                Date = rc.Date
            };

            /*
            // check mark register for room
            Room room = roomRepo.GetSingle(rc.RoomId);
            bool haveRegistered = true;

            foreach (RoomCalendar rcal in room.RoomCalendars)
            {
                if (rcal.RoomCalendarStatusId == 1)
                    haveRegistered = false;
            }

            room.IsHaveRegistered = haveRegistered;
            roomRepo.Edit(room);
            roomRepo.Save();
             */

            // rc.IsWatched = true;
            // roomCalRepo.Edit(rc);
            roomCalRepo.Delete(id);
            roomCalRepo.Save();

            string message = "Xác nhận hủy đăng kí phòng " + rcInfo.Room.Name + " vào ngày "
                + rcInfo.Date.ToShortDateString() + " từ tiết " + rcInfo.Start + " đến tiết " + (rcInfo.Start + rcInfo.Length - 1);
            return RedirectToAction("RoomRegistered", new { messageConfirm = message });
        }

        [Authorize(Roles = "Teacher")]
        public ActionResult HistoryRegistered()
        {
            IList<RoomCalendar> calLst = roomCalRepo.GetByWatchedState(true, staffRep.GetUserId(User.Identity.Name));
            return View(calLst);
        }

        // make register room by staff

        // create with params date time vs room
        [Authorize(Roles = "Teacher")]
        public ActionResult Create(string messageConfirm = "", bool isErrorMessage = false, int roomIdBefore = -1)
        {
            // IList<RoomType> allRoomType = roomTypeRepo.GetAll();
            IList<Room> allRoom = roomRepo.GetAll();

            // ViewBag.RoomTypeId = new SelectList(allRoomType, "ID", "Name", allRoomType.Count > 0 ? allRoomType[0].ID : 0);

            // default day 1/5/2011
            IList<RoomCalendar> calInDate;
            IList<RoomCalendar> calInWeek;

            if (roomIdBefore > 0)
            {
                ViewBag.RoomId = new SelectList(allRoom, "ID", "Name", roomIdBefore);
                calInDate = roomCalRepo.GetByDateAndRoomId(DateTime.Now, roomIdBefore);
                calInWeek = roomCalRepo.GetByWeekAndRoomId(DateTime.Now, roomIdBefore);
            }
            else
            {
                ViewBag.RoomId = new SelectList(allRoom, "ID", "Name", allRoom.Count > 0 ? allRoom[0].ID : 0);
                calInDate = roomCalRepo.GetByDateAndRoomId(DateTime.Now, allRoom.Count > 0 ? allRoom[0].ID : -1);
                calInWeek = roomCalRepo.GetByWeekAndRoomId(DateTime.Now, allRoom.Count > 0 ? allRoom[0].ID : -1);
            }

            // default day 1/5/2011
            // IList<RoomCalendar> calInDate = roomCalRepo.GetByDateAndRoomId(DateTime.Now, allRoom.Count > 0 ? allRoom[0].ID : -1);
            // IList<RoomCalendar> calInWeek = roomCalRepo.GetByWeekAndRoomId(DateTime.Now, allRoom.Count > 0 ? allRoom[0].ID : -1);

            DateTime currentDate = DateTime.Now;
            DateTime startDateOfWeek = getStartDayOfWeek(currentDate);
            DateTime endDateOfWeek = getEndDayOfWeek(currentDate);

            ViewBag.StartDay = startDateOfWeek.ToShortDateString();
            ViewBag.EndDay = endDateOfWeek.ToShortDateString();

            // init for lesson list
            var startLst = buildStartList(calInDate);

            if (startLst.Count == 0)
                startLst.Add(new ItemList{
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
        public ActionResult Create(RoomCalendar roomCal) {

            if (ModelState.IsValid)
            {
                if (roomCal.Date < DateTime.Now.Date)
                {
                    string message = "Bạn không thể đăng kí phòng trước ngày hiện tại " + DateTime.Now.ToShortDateString();
                    return RedirectToAction("Create", new { messageConfirm = message, isErrorMessage = true, roomIdBefore = roomCal.RoomId });
                }
                else
                {
                    // roomCal.Room = roomRepo.GetSingle(roomCal.RoomId);
                    roomCal.RoomCalendarStatusId = 1; // wait
                    roomCal.StaffId = staffRep.GetUserId(User.Identity.Name);


                    Room room = roomRepo.GetSingle(roomCal.RoomId);
                    //room.IsHaveRegistered = true;
                    roomRepo.Edit(room);
                    roomRepo.Save();

                    // save
                    roomCalRepo.Add(roomCal);
                    roomCalRepo.Save();


                    string message = "Phòng " + roomRepo.GetSingle(roomCal.RoomId).Name + " đã được đăng kí từ tiết " + roomCal.Start + " đến tiết " + (roomCal.Start + roomCal.Length - 1);
                    return RedirectToAction("Create", new { messageConfirm = message, isErrorMessage = false, roomIdBefore = roomCal.RoomId });
                }
            }

            return View();
        }

        [HttpPost]
        public ActionResult ChangeSelect(int day, int month, int year, int roomId)
        {
            DateTime currentDate = new DateTime(year, month, day);
            IList<RoomCalendar> calInDate = roomCalRepo.GetByDateAndRoomId(currentDate, roomId);
            IList<RoomCalendar> calInWeek = roomCalRepo.GetByWeekAndRoomId(currentDate, roomId);
            
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


        private List<ItemList> buildStartList(IList<RoomCalendar> calInDate)
        {

            bool[] offsetday = new Boolean[15]; // false is free
            for (int i = 1; i <= 13; ++i)
            {
                offsetday[i] = false;
            }
            offsetday[14] = true;

            foreach (RoomCalendar rc in calInDate)
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

        private List<List<int>> buildTimeTableList(IList<RoomCalendar> calInWeek)
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

            foreach (RoomCalendar rc in calInWeek)
            {
                int dayOfWeek = (int)rc.Date.DayOfWeek;
                if (dayOfWeek == 0) dayOfWeek = 7;

                for (int i = rc.Start; i <= rc.Start + rc.Length - 1; ++i)
                {
                    timeTblList[i][dayOfWeek] = (int) rc.RoomCalendarStatusId;
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
