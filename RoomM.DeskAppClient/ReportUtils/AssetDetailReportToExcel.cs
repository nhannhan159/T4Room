﻿using NPOI.SS.UserModel;
using RoomM.Domain.AssetModule.Aggregates;
using RoomM.Domain.RoomModule.Aggregates;
using System;
using System.Collections.Generic;

namespace RoomM.DeskApp
{
    public class AssetDetailReportToExcel : ReportToExcel<AssetDetail>
    {
        public AssetDetailReportToExcel(String companyName, String subject, String template)
            : base(companyName, subject, template)
        { }

        public override void setupExport(List<AssetDetail> assetDetailList, Room room = null)
        {
            activeSheet = hssfworkbook.GetSheet("Sheet1");

            // set profile
            IRow r0 = activeSheet.GetRow(2);
            r0.GetCell(4).SetCellValue(DateTime.Now.ToShortDateString());

            IRow r1 = activeSheet.GetRow(3);
            r1.GetCell(4).SetCellValue("Nguyen Van A");

            IRow r2 = activeSheet.GetRow(4);
            r2.GetCell(4).SetCellValue("Quản lí phòng");

            IRow r3 = activeSheet.GetRow(5);
            r3.GetCell(4).SetCellValue(room.RoomType.Name);

            IRow r4 = activeSheet.GetRow(6);
            r4.GetCell(4).SetCellValue(room.Name);

            int startRow = 9;
            int index = 1;

            foreach (AssetDetail rAsset in assetDetailList)
            {
                IRow row = activeSheet.CreateRow(startRow);
                row.CreateCell(1).SetCellValue(index);
                row.CreateCell(2).SetCellValue(rAsset.Id);
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