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
    public class RoomHistoriesReportToExcel : ReportToExcel
    {

        IRoomAssetHistoryRepository roomsRepo = RepositoryFactory.GetRepository<IRoomAssetHistoryRepository, RoomAssetHistory>();
        IRoomRepository roomRepo = RepositoryFactory.GetRepository<IRoomRepository, Room>();

        private int roomId = 1;


        public RoomHistoriesReportToExcel(String companyName, String subject, String template)
            : base(companyName, subject, template)
        {
            
        }


        public override void setupExport()
        {
            Room mainR = roomRepo.GetSingle(roomId);
            IList<RoomAssetHistory> roomHisList = roomsRepo.GetAll();

            activeSheet = hssfworkbook.GetSheet("Sheet1");


            // set profile
            Row r0 = activeSheet.GetRow(2);
            r0.GetCell(6).SetCellValue(DateTime.Now.ToShortDateString());

            Row r1 = activeSheet.GetRow(3);
            r1.GetCell(6).SetCellValue("Nguyen Van A");

            Row r2 = activeSheet.GetRow(4);
            r2.GetCell(6).SetCellValue("Quản lí phòng");

            Row r3 = activeSheet.GetRow(5);
            r3.GetCell(6).SetCellValue(mainR.RoomType.Name);

            Row r4 = activeSheet.GetRow(6);
            r4.GetCell(6).SetCellValue(mainR.Name);

            int startRow = 9;
            int index = 1;

            foreach(RoomAssetHistory r in roomHisList) 
            {
                Row row = activeSheet.CreateRow(startRow);
                row.CreateCell(1).SetCellValue(index);
                row.CreateCell(2).SetCellValue(r.Date.ToShortDateString());
                row.CreateCell(3).SetCellValue(r.Asset.Name);
                row.CreateCell(4).SetCellValue(r.Amount);
                row.CreateCell(5).SetCellValue(r.Room.Name);
                startRow++;
                index++;
            }

            //Force excel to recalculate all the formula while open
            activeSheet.ForceFormulaRecalculation = true;
        }
    }
}
