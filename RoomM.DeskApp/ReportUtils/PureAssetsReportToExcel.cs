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
    public class PureAssetsReportToExcel : ReportToExcel<Asset>
    {
        public PureAssetsReportToExcel(String companyName, String subject, String template)
            : base(companyName, subject, template)
        {
            
        }


        public override void setupExport(List<Asset> assetsList, Room room = null)
        {
            activeSheet = hssfworkbook.GetSheet("Sheet1");

            // set profile
            Row r0 = activeSheet.GetRow(2);
            r0.GetCell(4).SetCellValue(DateTime.Now.ToShortDateString());

            Row r1 = activeSheet.GetRow(3);
            r1.GetCell(4).SetCellValue("Nguyễn Văn A");

            Row r2 = activeSheet.GetRow(4);
            r2.GetCell(4).SetCellValue("Quản lí phòng");

            int startRow = 7;
            int index = 1;

            foreach(Asset rAsset in assetsList) 
            {

                Row row = activeSheet.CreateRow(startRow);
                row.CreateCell(1).SetCellValue(index);
                row.CreateCell(2).SetCellValue(rAsset.ID);
                row.CreateCell(3).SetCellValue(rAsset.Name);
                row.CreateCell(4).SetCellValue(rAsset.Amount);
                row.CreateCell(5).SetCellValue(rAsset.Description);

                startRow++;
                index++;
            }

            //Force excel to recalculate all the formula while open
            activeSheet.ForceFormulaRecalculation = true;
        }
    }
}
