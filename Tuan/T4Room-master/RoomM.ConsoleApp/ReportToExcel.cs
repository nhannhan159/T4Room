using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NPOI.HPSF;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace RoomM.ConsoleApp
{
    public abstract class ReportToExcel
    {
        protected HSSFWorkbook hssfworkbook;
        protected Sheet activeSheet;

        public ReportToExcel(String comanyName, String subject, String templateFileName) {

            if (null != templateFileName)
            {
                FileStream file = new FileStream(@templateFileName, FileMode.Open, FileAccess.Read);
                hssfworkbook = new HSSFWorkbook(file);
            }
            else 
            {
                hssfworkbook = new HSSFWorkbook();
            }


            
            //Create a entry of DocumentSummaryInformation
            DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
            dsi.Company = comanyName;
            hssfworkbook.DocumentSummaryInformation = dsi;

            //Create a entry of SummaryInformation
            SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
            si.Subject = subject;
            hssfworkbook.SummaryInformation = si;
        }

        public void save(String filename) {
            //Write the stream data of workbook to the root directory
            FileStream file = new FileStream(@filename, FileMode.Create);
            hssfworkbook.Write(file);
            file.Close();
        }


        public abstract void setupExport();

        
             

    }
}
