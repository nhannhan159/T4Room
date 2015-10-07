using RoomM.Models.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.ConsoleApp
{
    // debug on console screen
    class Program
    {
        static void Main(string[] args)
        {
            RoomCalendarsReportToExcel reportDemo = new RoomCalendarsReportToExcel("sgu university", "roomM", "templates/roomcalendar_tmp.xls");
            reportDemo.setupExport();
            reportDemo.save("reports/roomcalendar_" + DateTime.Now.Ticks + ".xls");
        }
    }
}
