namespace RoomM.WebApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using WebMatrix.WebData;

    internal sealed class Configuration : DbMigrationsConfiguration<RoomM.WebApp.Models.UsersContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RoomM.WebApp.Models.UsersContext context)
        {
            WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
            /*
            if (!Roles.RoleExists("Administrator"))
            {
                Roles.CreateRole("Administrator");
            }

            if (!WebSecurity.UserExists("john"))
            {
                WebSecurity.CreateUserAndAccount("john", "secret");
            }

            if (!Roles.GetRolesForUser("john").Contains("Administrator"))
            {
                Roles.AddUsersToRoles(new[] { "john" }, new[] { "Administrator" });
            }*/
        }
    }
}
