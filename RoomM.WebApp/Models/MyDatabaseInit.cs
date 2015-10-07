using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebMatrix.WebData;

namespace RoomM.WebApp.Models
{
    public class MyDatabaseInit : DropCreateDatabaseAlways<MyDatabaseContext>
    {
        protected override void Seed(MyDatabaseContext context)
        {
            // base.Seed(context);
            SeedMembership();
        }

        private void SeedMembership()
        {
            WebSecurity.InitializeDatabaseConnection("MyDatabaseContext",
            "UserProfile", "UserId", "UserName", autoCreateTables: true);
        }
    }
}