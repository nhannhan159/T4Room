using NPOI.HPSF;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using RoomM.DeskApp.ViewModels;
using RoomM.Models.Rooms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoomM.DeskApp
{
    public abstract class ReportToExcel<T>
    {

        SaveFileDialog saveFileDialog = new SaveFileDialog();
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

        public void save() {
            MainWindowViewModel.instance.ChangeStateToWait();

            saveFileDialog.InitialDirectory = Convert.ToString(Environment.SpecialFolder.MyDocuments);
            saveFileDialog.Filter = "Phần mở rộng (*.xls)|*.xls|Tất cả files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;


            if (saveFileDialog.ShowDialog().Equals(DialogResult.OK))
            {
                string filename = saveFileDialog.FileName;

                //Write the stream data of workbook to the root directory
                FileStream file = new FileStream(@filename, FileMode.Create);
                hssfworkbook.Write(file);
                file.Close();

                Process.Start(filename);
                MainWindowViewModel.instance.ChangeStateToComplete("Đã lưu tại " + filename);
            } 
        }

        public abstract void setupExport(List<T> data, Room room = null);

    }
}
