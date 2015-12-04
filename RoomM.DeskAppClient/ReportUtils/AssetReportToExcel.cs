using NPOI.SS.UserModel;
using RoomM.Domain.AssetModule.Aggregates;
using RoomM.Domain.RoomModule.Aggregates;
using System;
using System.Collections.Generic;

namespace RoomM.DeskApp
{
    public class AssetReportToExcel : ReportToExcel<Asset>
    {
        public AssetReportToExcel(String companyName, String subject, String template)
            : base(companyName, subject, template)
        { }

        public override void setupExport(List<Asset> assetList, Room room = null)
        {
            activeSheet = hssfworkbook.GetSheet("Sheet1");

            // set profile
            IRow r0 = activeSheet.GetRow(2);
            r0.GetCell(4).SetCellValue(DateTime.Now.ToShortDateString());

            IRow r1 = activeSheet.GetRow(3);
            r1.GetCell(4).SetCellValue("Nguyễn Văn A");

            IRow r2 = activeSheet.GetRow(4);
            r2.GetCell(4).SetCellValue("Quản lí phòng");

            int startRow = 7;
            int index = 1;

            foreach (Asset rAsset in assetList)
            {
                IRow row = activeSheet.CreateRow(startRow);
                row.CreateCell(1).SetCellValue(index);
                row.CreateCell(2).SetCellValue(rAsset.Id);
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