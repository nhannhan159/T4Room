using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NPOI.SS.UserModel;

using RoomM.Repositories.RepositoryFramework;
using RoomM.Models;

namespace RoomM.DeskApp
{
    public class AssetsReportToExcel : ReportToExcel<RoomAsset>
    {
        public AssetsReportToExcel(String companyName, String subject, String template)
            : base(companyName, subject, template)
        { }

        public override void setupExport(List<RoomAsset> roomAssetsList, Room room = null)
        {
            activeSheet = hssfworkbook.GetSheet("Sheet1");

            // set profile
            Row r0 = activeSheet.GetRow(2);
            r0.GetCell(4).SetCellValue(DateTime.Now.ToShortDateString());

            Row r1 = activeSheet.GetRow(3);
            r1.GetCell(4).SetCellValue("Nguyen Van A");

            Row r2 = activeSheet.GetRow(4);
            r2.GetCell(4).SetCellValue("Quản lí phòng");

            Row r3 = activeSheet.GetRow(5);
            r3.GetCell(4).SetCellValue(room.RoomType.Name);

            Row r4 = activeSheet.GetRow(6);
            r4.GetCell(4).SetCellValue(room.Name);

            int startRow = 9;
            int index = 1;

            foreach(RoomAsset rAsset in roomAssetsList) 
            {

                Row row = activeSheet.CreateRow(startRow);
                row.CreateCell(1).SetCellValue(index);
                row.CreateCell(2).SetCellValue(rAsset.ID);
                row.CreateCell(3).SetCellValue(rAsset.Asset.Name);
                row.CreateCell(4).SetCellValue(rAsset.Amount);

                startRow++;
                index++;
            }

            //Force excel to recalculate all the formula while open
            activeSheet.ForceFormulaRecalculation = true;
        }
    }
}
