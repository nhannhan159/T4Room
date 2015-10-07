using NPOI.SS.UserModel;
using RoomM.Models.Assets;
using RoomM.Models.Rooms;
using RoomM.Repositories.Assets;
using RoomM.Repositories.RepositoryFramework;
using RoomM.Repositories.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.DeskApp
{
    public class RoomHistoriesReportToExcel : ReportToExcel<RoomAssetHistory>
    {
        public RoomHistoriesReportToExcel(String companyName, String subject, String template)
            : base(companyName, subject, template)
        {
            
        }

        public override void setupExport(List<RoomAssetHistory> roomHisList, Room room = null)
        {
            activeSheet = hssfworkbook.GetSheet("Sheet1");

            // set profile
            Row r0 = activeSheet.GetRow(2);
            // r0.GetCell(6).SetCellValue(DateTime.Now.ToShortDateString());

            Row r1 = activeSheet.GetRow(3);
            r1.GetCell(5).SetCellValue("Nguyen Van A");

            Row r2 = activeSheet.GetRow(4);
            r2.GetCell(5).SetCellValue("Quản lí phòng");

            Row r3 = activeSheet.GetRow(5);
            r3.GetCell(5).SetCellValue(room.RoomType.Name);

            Row r4 = activeSheet.GetRow(6);
            r4.GetCell(5).SetCellValue(room.Name);

            int startRow = 9;
            int index = 1;

            foreach(RoomAssetHistory r in roomHisList) 
            {
                Row row = activeSheet.CreateRow(startRow);
                row.CreateCell(1).SetCellValue(index);
                row.CreateCell(2).SetCellValue(r.Date.ToShortDateString());
                row.CreateCell(3).SetCellValue(r.HistoryType.Name);
                row.CreateCell(4).SetCellValue(r.Asset.Name);
                row.CreateCell(5).SetCellValue(r.Amount);
                row.CreateCell(6).SetCellValue(r.Room.Name);
                startRow++;
                index++;
            }

            //Force excel to recalculate all the formula while open
            activeSheet.ForceFormulaRecalculation = true;
        }
    }
}
