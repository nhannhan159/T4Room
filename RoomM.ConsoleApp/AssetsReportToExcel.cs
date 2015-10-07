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

namespace RoomM.ConsoleApp
{
    public class AssetsReportToExcel : ReportToExcel
    {

        IRoomAssetRepository roomAssetsRepo = RepositoryFactory.GetRepository<IRoomAssetRepository, RoomAsset>();

        public AssetsReportToExcel(String companyName, String subject, String template)
            : base(companyName, subject, template)
        {
            
        }


        public override void setupExport()
        {
            IList<RoomAsset> roomAssetsList = roomAssetsRepo.GetAll();

            activeSheet = hssfworkbook.GetSheet("Sheet1");

            int startRow = 8;
            int index = 1;

            foreach(RoomAsset rAsset in roomAssetsList) 
            {

                Row row = activeSheet.CreateRow(startRow);
                row.CreateCell(1).SetCellValue(index);
                row.CreateCell(2).SetCellValue(rAsset.ID);
                row.CreateCell(3).SetCellValue(rAsset.Asset.Name);
                row.CreateCell(4).SetCellValue(rAsset.Room.Name);

                startRow++;
                index++;
            }

            //Force excel to recalculate all the formula while open
            activeSheet.ForceFormulaRecalculation = true;
        }
    }
}
