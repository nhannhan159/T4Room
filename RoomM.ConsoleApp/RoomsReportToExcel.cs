using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NPOI.SS.UserModel;

using RoomM.Repositories.RepositoryFramework;
using RoomM.Repositories;
using RoomM.Models;

namespace RoomM.ConsoleApp
{
    public class RoomsReportToExcel : ReportToExcel
    {

        IRoomRepository roomsRepo = RepositoryFactory.GetRepository<IRoomRepository, Room>();

        public RoomsReportToExcel(String companyName, String subject, String template)
            : base(companyName, subject, template)
        {
            
        }


        public override void setupExport()
        {
            IList<Room> roomList = roomsRepo.GetAll();

            activeSheet = hssfworkbook.GetSheet("Sheet1");


            // set profile
            Row r0 = activeSheet.GetRow(2);
            r0.GetCell(5).SetCellValue(DateTime.Now.ToShortDateString());

            Row r1 = activeSheet.GetRow(3);
            r1.GetCell(5).SetCellValue("Nguyen Van A");

            Row r2 = activeSheet.GetRow(4);
            r2.GetCell(5).SetCellValue("Nhân sự");

            int startRow = 8;
            int index = 1;

            foreach(Room r in roomList) 
            {
                Row row = activeSheet.CreateRow(startRow);
                row.CreateCell(1).SetCellValue(index);
                row.CreateCell(2).SetCellValue(r.Name);
                row.CreateCell(3).SetCellValue(r.RoomType.Name);
                row.CreateCell(4).SetCellValue(r.DateCreate.ToShortDateString());
                startRow++;
                index++;
            }

            //Force excel to recalculate all the formula while open
            activeSheet.ForceFormulaRecalculation = true;
        }
    }
}
