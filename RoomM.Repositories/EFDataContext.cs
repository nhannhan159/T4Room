using RoomM.Models.Rooms;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Repositories
{
    public class EFDataContext : DbContext
    {
        public static EFDataContext instance = new EFDataContext();

        // connection string:
        // private const string connectionString =
            // "Data Source=QUOCVU\\SQLEXPRESS;Initial Catalog=room_mgr;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
            // "Data Source=TIENTQ;Initial Catalog=room_mgr;Integrated Security=True";
            // "metadata=res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=TIENTQ;initial catalog=room_mgr;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;";
        public EFDataContext() : base("name=RoomDB") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
           .Where(type => !String.IsNullOrEmpty(type.Namespace))
           .Where(type => type.BaseType != null && type.BaseType.IsGenericType
                && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            
            // modelBuilder.Entity<Room>().Property(m => m.RoomTypeId).IsOptional();  

            base.OnModelCreating(modelBuilder);
        }
    }

    public static class StaticRoomContext
    {
        public static EFDataContext Context = new EFDataContext();
    }
}
