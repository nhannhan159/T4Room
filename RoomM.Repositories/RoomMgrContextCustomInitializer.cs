using RoomM.Models.Rooms;
using RoomM.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomM.Models.Assets;
using RoomM.Models.Staffs;

namespace RoomM.Repositories
{
    public class RoomMgrContextCustomInitializer : DropCreateDatabaseAlways<EFDataContext>
    {

        protected override void Seed(EFDataContext context)
        {

            /* 
            1	Chuyển thiết bị
            2	Thanh lí thiết bị
            3	Nhập thiết bị
            */

            RoomType roomTH = new RoomType { Name = "Thực hành tin học" };
            RoomType roomHO = new RoomType { Name = "Thực hành hóa" };
            RoomType roomLI = new RoomType { Name = "Thực hành lý" };
            RoomType roomSI = new RoomType { Name = "Thực hành sinh học" };
            RoomType roomDT = new RoomType { Name = "Thực hành điện tử" };
            RoomType roomVM = new RoomType { Name = "Thực hành vi mạch" };
            RoomType roomCK = new RoomType { Name = "Thực hành cơ khí" };
            RoomType roomCD = new RoomType { Name = "Thực hành cơ điện" };

            HistoryType devicehistorytype1 = new HistoryType { Name = "Chuyển thiết bị" };
            HistoryType devicehistorytype2 = new HistoryType { Name = "Thanh lí thiết bị" };
            HistoryType devicehistorytype3 = new HistoryType { Name = "Nhập thiết bị" };
            HistoryType devicehistorytype4 = new HistoryType { Name = "Nhận thiết bị" };

            StaffType usertype0 = new StaffType { Name = "Quản trị viên" };
            StaffType usertype1 = new StaffType { Name = "Giảng viên" };
            StaffType usertype2 = new StaffType { Name = "Nhân viên quản lý" };

            RoomCalendarStatus roomcalendarstatus1 = new RoomCalendarStatus { Name = "Chờ xác nhận" };
            RoomCalendarStatus roomcalendarstatus2 = new RoomCalendarStatus { Name = "Đã đăng ký" };
            RoomCalendarStatus roomcalendarstatus3 = new RoomCalendarStatus { Name = "Hủy đăng ký" };

            #region room tin hoc
            Room room0 = new Room
            {
                Name = "A100",
                DateCreate = new DateTime(2011, 1, 1),
                RoomType = roomTH
            };

            Room room1 = new Room
            {
                Name = "A101",
                DateCreate = new DateTime(2011, 1, 1),
                RoomType = roomTH
            };

            Room room2 = new Room
            {
                Name = "A102",
                DateCreate = new DateTime(2011, 1, 1),
                RoomType = roomTH
            };

            Room room3 = new Room
            {
                Name = "A103",
                DateCreate = new DateTime(2011, 1, 1),
                RoomType = roomTH
            };

            Room room4 = new Room
            {
                Name = "A104",
                DateCreate = new DateTime(2011, 1, 1),
                RoomType = roomTH
            };

            Room room5 = new Room
            {
                Name = "A105",
                DateCreate = new DateTime(2011, 1, 1),
                RoomType = roomTH
            };

            Room room6 = new Room
            {
                Name = "A106",
                DateCreate = new DateTime(2011, 1, 1),
                RoomType = roomTH
            };

            Room room7 = new Room
            {
                Name = "A107",
                DateCreate = new DateTime(2011, 1, 1),
                RoomType = roomTH
            };

            Room room8 = new Room
            {
                Name = "A108",
                DateCreate = new DateTime(2011, 1, 1),
                RoomType = roomTH
            };

            Room room9 = new Room
            {
                Name = "A109",
                DateCreate = new DateTime(2011, 1, 1),
                RoomType = roomTH
            };

            #endregion

            #region vat li
            Room room10 = new Room
            {
                Name = "B000",
                DateCreate = new DateTime(2011, 1, 2),
                RoomType = roomLI,
            };

            Room room11 = new Room
            {
                Name = "B001",
                DateCreate = new DateTime(2011, 1, 2),
                RoomType = roomLI,
            };

            Room room12 = new Room
            {
                Name = "B002",
                DateCreate = new DateTime(2011, 1, 2),
                RoomType = roomLI,
            };

            Room room13 = new Room
            {
                Name = "B003",
                DateCreate = new DateTime(2011, 1, 2),
                RoomType = roomLI,
            };

            Room room14 = new Room
            {
                Name = "B004",
                DateCreate = new DateTime(2011, 1, 2),
                RoomType = roomLI,
            };

            Room room15 = new Room
            {
                Name = "B005",
                DateCreate = new DateTime(2011, 1, 2),
                RoomType = roomLI,
            };

            #endregion

            #region mix room
            Room room16 = new Room
            {
                Name = "A112",
                DateCreate = new DateTime(2011, 1, 3),
                RoomType = roomTH,
            };
            Room room17 = new Room
            {
                Name = "B015",
                DateCreate = new DateTime(2011, 1, 5),
                RoomType = roomHO,
            };
            Room room18 = new Room
            {
                Name = "A112",
                DateCreate = new DateTime(2011, 1, 7),
                RoomType = roomVM,
            };
            Room room19 = new Room
            {
                Name = "B016",
                DateCreate = new DateTime(2011, 1, 8),
                RoomType = roomCK,
            };

            #endregion

            #region init asset
            Asset device1 = new Asset
            {
                Name = "Quạt trần 4M",
            };

            Asset device2 = new Asset
            {
                Name = "Quạt trần 2M",
            };
            Asset device3 = new Asset
            {
                Name = "Đèn huỳnh quang 4m",
            };
            Asset device4 = new Asset
            {
                Name = "Đèn huỳnh quang 12m",
            };
            Asset device5 = new Asset
            {
                Name = "Bàn học gỗ",
            };
            Asset device6 = new Asset
            {
                Name = "Ghế MH4",
            };
            Asset device7 = new Asset
            {
                Name = "Khăn trải bàn GV",
            };
            Asset device8 = new Asset
            {
                Name = "Khăn trải bàn GV",
            };
            Asset device9 = new Asset
            {
                Name = "Giá treo",
            };
            Asset device10 = new Asset
            {
                Name = "Máy chiếu KH0103",
            };
            Asset device11 = new Asset
            {
                Name = "Màn chiếu",
            };
            Asset device12 = new Asset
            {
                Name = "Phấn ABC",
            };
            Asset device13 = new Asset
            {
                Name = "Ghế nhựa đơn",
            };
            Asset device14 = new Asset
            {
                Name = "Ghế thép",
            };
            Asset device15 = new Asset
            {
                Name = "PC corei3",
            };

            Asset device16 = new Asset
            {
                Name = "PC corei5",
            };

            Asset device17 = new Asset
            {
                Name = "PC Server 8Ghz",
            };

            Asset device18 = new Asset
            {
                Name = "Switch 28port",
            };

            Asset device19 = new Asset
            {
                Name = "Swith 32port",
            };

            Asset device20 = new Asset
            {
                Name = "Cáp nối mạng 4M",
            };

            #endregion
            
            #region room A100
            RoomAsset roomD1 = new RoomAsset
            {
                Asset = device17,
                Amount = 1,
                Room = room1
            };

            RoomAsset roomD2 = new RoomAsset
            {
                Asset = device16,
                Amount = 30,
                Room = room1
            };

            RoomAsset roomD3 = new RoomAsset
            {
                Asset = device1,
                Amount = 10,
                Room = room1
            };

            RoomAsset roomD4 = new RoomAsset
            {
                Asset = device11,
                Amount = 1,
                Room = room1
            };

            RoomAsset roomD5 = new RoomAsset
            {
                Asset = device10,
                Amount = 1,
                Room = room1
            };

            #endregion

            #region mix
            RoomAsset roomD6 = new RoomAsset
            {
                Asset = device3,
                Amount = 5,
                Room = room1
            };

            RoomAsset roomD7 = new RoomAsset
            {
                Asset = device4,
                Amount = 100,
                Room = room2
            };
            #endregion 

            RoomAssetHistory devicehistory1 = new RoomAssetHistory
            {
                Date = new DateTime(2011, 1, 1),
                HistoryType = devicehistorytype1,
                Asset = device3,
                Room = room6,
            };
            RoomAssetHistory devicehistory2 = new RoomAssetHistory
            {
                Date = new DateTime(2011, 1, 3),
                HistoryType = devicehistorytype1,
                Asset = device1,
                Room = room1,
            };
            RoomAssetHistory devicehistory3 = new RoomAssetHistory
            {
                Date = new DateTime(2011, 1, 5),
                HistoryType = devicehistorytype2,
                Asset = device2,
                Room = room2,
            };
            
            #region staff

            Staff user0 = new Staff
            {
                Name = "Triệu Linh Nhi",
                Sex = true,
                Phone = "0123456789",
                StaffType = usertype0,
                UserName = "admin",
                PasswordStored = CryptorEngine.Encrypt("admin", true),
                LastLogin = new DateTime(2011, 1, 5),
            };

            Staff user1 = new Staff
            {
                Name = "Lý Tiêu Diêu",
                Sex = false,
                Phone = "0123456790",
                StaffType = usertype1,
                UserName = "user1",
                PasswordStored = CryptorEngine.Encrypt("user", true),
                LastLogin = new DateTime(2011, 1, 7),
            };

            Staff user2 = new Staff
            {
                Name = "Điền Bá Quang",
                Sex = false,
                Phone = "0123456790",
                StaffType = usertype1,
                UserName = "user2",
                PasswordStored = CryptorEngine.Encrypt("user", true),
                LastLogin = new DateTime(2011, 1, 8),
            };

            Staff user3 = new Staff
            {
                Name = "Đổng Lợi Văn",
                Sex = true,
                Phone = "0123456790",
                StaffType = usertype1,
                UserName = "user3",
                PasswordStored = CryptorEngine.Encrypt("user", true),
                LastLogin = new DateTime(2011, 1, 9),
            };

            Staff user4 = new Staff
            {
                Name = "Cao Long",
                Sex = false,
                Phone = "0123456790",
                StaffType = usertype1,
                UserName = "user4",
                PasswordStored = CryptorEngine.Encrypt("user", true),
                LastLogin = new DateTime(2011, 1, 11),
            };

            Staff user5 = new Staff
            {
                Name = "Bạch Ngọc Đường",
                Sex = false,
                Phone = "0123456790",
                StaffType = usertype1,
                UserName = "user5",
                PasswordStored = CryptorEngine.Encrypt("user", true),
                LastLogin = new DateTime(2011, 1, 12),
            };

            Staff user6 = new Staff
            {
                Name = "Lý Mạc Sầu",
                Sex = true,
                Phone = "0123456790",
                StaffType = usertype1,
                UserName = "user6",
                PasswordStored = CryptorEngine.Encrypt("user", true),
                LastLogin = new DateTime(2011, 1, 13),
            };

            Staff user7 = new Staff
            {
                Name = "Đinh Tiểu Gia",
                Sex = true,
                Phone = "0123456790",
                StaffType = usertype2,
                UserName = "user7",
                PasswordStored = CryptorEngine.Encrypt("user", true),
                LastLogin = new DateTime(2011, 1, 17),
            };

            Staff user8 = new Staff
            {
                Name = "Tiết Gia Cường",
                Sex = false,
                Phone = "0123456790",
                StaffType = usertype2,
                UserName = "user8",
                PasswordStored = CryptorEngine.Encrypt("user", true),
                LastLogin = new DateTime(2011, 1, 27),
            };

            Staff user9 = new Staff
            {
                Name = "Lý Bạch",
                Sex = false,
                Phone = "0123456790",
                StaffType = usertype2,
                UserName = "user9",
                PasswordStored = CryptorEngine.Encrypt("user", true),
                LastLogin = new DateTime(2011, 1, 6),
            };

            #endregion

            RoomCalendar roomcalendar1 = new RoomCalendar
            {
                Date = new DateTime(2011, 1, 5),
                Start = 4,
                Length = 2,
                RoomCalendarStatus = roomcalendarstatus1,
                Room = room2,
                Staff = user2
            };

            RoomCalendar roomcalendar2 = new RoomCalendar
            {
                Date = new DateTime(2011, 1, 5),
                Start = 10,
                Length = 2,
                RoomCalendarStatus = roomcalendarstatus1,
                Room = room2,
                Staff = user2
            };

            RoomCalendar roomcalendar3 = new RoomCalendar
            {
                Date = new DateTime(2011, 1, 7),
                Start = 1,
                Length = 3,
                RoomCalendarStatus = roomcalendarstatus2,
                Room = room1,
                Staff = user1
            };

            RoomCalendar roomcalendar4 = new RoomCalendar
            {
                Date = new DateTime(2011, 1, 8),
                Start = 8,
                Length = 4,
                RoomCalendarStatus = roomcalendarstatus1,
                Room = room6,
                Staff = user2
            };

            RoomCalendar roomcalendar5 = new RoomCalendar
            {
                Date = new DateTime(2011, 1, 8),
                Start = 4,
                Length = 2,
                RoomCalendarStatus = roomcalendarstatus3,
                Room = room4,
                Staff = user1
            };

            context.Entry(roomTH).State = EntityState.Added;
            context.Entry(roomHO).State = EntityState.Added;
            context.Entry(roomLI).State = EntityState.Added;
            context.Entry(roomSI).State = EntityState.Added;

            context.Entry(devicehistorytype1).State = EntityState.Added;
            context.Entry(devicehistorytype2).State = EntityState.Added;
            context.Entry(devicehistorytype3).State = EntityState.Added;
            context.Entry(devicehistorytype4).State = EntityState.Added;

            context.Entry(roomcalendarstatus1).State = EntityState.Added;
            context.Entry(roomcalendarstatus2).State = EntityState.Added;
            context.Entry(roomcalendarstatus3).State = EntityState.Added;

            #region add device
            context.Entry(device1).State = EntityState.Added;
            context.Entry(device2).State = EntityState.Added;
            context.Entry(device3).State = EntityState.Added;
            context.Entry(device4).State = EntityState.Added;
            context.Entry(device5).State = EntityState.Added;
            context.Entry(device6).State = EntityState.Added;
            context.Entry(device7).State = EntityState.Added;
            context.Entry(device8).State = EntityState.Added;
            context.Entry(device9).State = EntityState.Added;
            context.Entry(device10).State = EntityState.Added;
            context.Entry(device11).State = EntityState.Added;
            context.Entry(device12).State = EntityState.Added;
            context.Entry(device13).State = EntityState.Added;
            context.Entry(device14).State = EntityState.Added;
            context.Entry(device15).State = EntityState.Added;
            context.Entry(device16).State = EntityState.Added;
            context.Entry(device17).State = EntityState.Added;
            context.Entry(device18).State = EntityState.Added;
            context.Entry(device19).State = EntityState.Added;
            context.Entry(device20).State = EntityState.Added;

            #endregion

            #region addroom
            context.Entry(room0).State = EntityState.Added;
            context.Entry(room1).State = EntityState.Added;
            context.Entry(room2).State = EntityState.Added;
            context.Entry(room3).State = EntityState.Added;
            context.Entry(room4).State = EntityState.Added;
            context.Entry(room5).State = EntityState.Added;
            context.Entry(room6).State = EntityState.Added;
            context.Entry(room7).State = EntityState.Added;
            context.Entry(room8).State = EntityState.Added;
            context.Entry(room9).State = EntityState.Added;
            context.Entry(room10).State = EntityState.Added;
            context.Entry(room11).State = EntityState.Added;
            context.Entry(room12).State = EntityState.Added;
            context.Entry(room13).State = EntityState.Added;
            context.Entry(room14).State = EntityState.Added;
            context.Entry(room15).State = EntityState.Added;
            context.Entry(room16).State = EntityState.Added;
            context.Entry(room17).State = EntityState.Added;
            context.Entry(room18).State = EntityState.Added;
            context.Entry(room19).State = EntityState.Added;
            #endregion

            #region add room assets
            context.Entry(roomD1).State = EntityState.Added;
            context.Entry(roomD2).State = EntityState.Added;
            context.Entry(roomD3).State = EntityState.Added;
            context.Entry(roomD4).State = EntityState.Added;
            context.Entry(roomD5).State = EntityState.Added;
            context.Entry(roomD6).State = EntityState.Added;
            context.Entry(roomD7).State = EntityState.Added;
            #endregion

            context.Entry(devicehistory1).State = EntityState.Added;
            context.Entry(devicehistory2).State = EntityState.Added;
            context.Entry(devicehistory3).State = EntityState.Added;

            context.Entry(usertype0).State = EntityState.Added;
            context.Entry(usertype1).State = EntityState.Added;
            context.Entry(usertype2).State = EntityState.Added;

            #region add staff

            context.Entry(user0).State = EntityState.Added;
            context.Entry(user1).State = EntityState.Added;
            context.Entry(user2).State = EntityState.Added;
            context.Entry(user3).State = EntityState.Added;
            context.Entry(user4).State = EntityState.Added;
            context.Entry(user5).State = EntityState.Added;
            context.Entry(user6).State = EntityState.Added;
            context.Entry(user7).State = EntityState.Added;
            context.Entry(user8).State = EntityState.Added;
            context.Entry(user9).State = EntityState.Added;
            
            #endregion
            
            context.Entry(roomcalendar1).State = EntityState.Added;
            context.Entry(roomcalendar2).State = EntityState.Added;
            context.Entry(roomcalendar3).State = EntityState.Added;
            context.Entry(roomcalendar4).State = EntityState.Added;
            context.Entry(roomcalendar5).State = EntityState.Added;
            
            context.SaveChanges();
        }
       

        
    }
}
