using NPOI.SS.UserModel;
using RoomM.Application.RoomM.Domain.RoomModule.Aggregates;
using System;
using System.Collections.Generic;

namespace RoomM.DeskApp
{
    public class RoomRegReportToExcel : ReportToExcel<RoomReg>
    {
        public RoomRegReportToExcel(String companyName, String subject, String template)
            : base(companyName, subject, template)
        { }

        public override void setupExport(List<RoomReg> roomRegList, Room room = null)
        {
            activeSheet = hssfworkbook.GetSheet("Sheet1");

            // set profile
            IRow r0 = activeSheet.GetRow(2);
            r0.GetCell(6).SetCellValue(DateTime.Now.ToShortDateString());

            IRow r1 = activeSheet.GetRow(3);
            r1.GetCell(6).SetCellValue("Nguyen Van A");

            IRow r2 = activeSheet.GetRow(4);
            r2.GetCell(6).SetCellValue("Quản lí phòng");

            IRow r3 = activeSheet.GetRow(5);
            r3.GetCell(6).SetCellValue(room.RoomType.Name);

            IRow r4 = activeSheet.GetRow(6);
            r4.GetCell(6).SetCellValue(room.Name);

            int startRow = 9;
            int index = 1;

            foreach (RoomReg r in roomRegList)
            {
                IRow row = activeSheet.CreateRow(startRow);
                row.CreateCell(1).SetCellValue(index);
                row.CreateCell(2).SetCellValue(r.Date.Value.DateTime.ToShortDateString());
                row.CreateCell(3).SetCellValue(r.Start.Value);
                row.CreateCell(4).SetCellValue(r.Length.Value);
                row.CreateCell(5).SetCellValue(r.User.FullName);
                row.CreateCell(6).SetCellValue(r.RoomRegType.Value);
                startRow++;
                index++;
            }

            //Force excel to recalculate all the formula while open
            activeSheet.ForceFormulaRecalculation = true;
        }
    }
}