using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoomM.Models.Staffs;

namespace RoomM.Test
{
    [TestClass]
    public class StaffTest
    {
        [TestMethod]
        public void GetUserTest()
        {
            Staff u = StaffService.GetByID(1);
            Console.WriteLine(u.ToString());

            Console.WriteLine("Check pass1: " + StaffService.CheckPassword(u, "123"));
            Console.WriteLine("Check pass2: " + StaffService.CheckPassword(u, "admin"));

            Console.WriteLine("Check user exists1: " + StaffService.CheckUserExists("admin"));
            Console.WriteLine("Check user exists2: " + StaffService.CheckUserExists("adminaaaa"));

        }
    }
}
