//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Microsoft.Office.Interop.Excel;
//using System.IO;
//using System.Reflection;

//namespace Odesk
//{
//    public static class ExcelHelper
//    {
//        public static void CreateExcelFile()
//        {
//            object missing = Type.Missing;

//            Application oXL = new Application();
//            oXL.Visible = false;
//            Workbook oWB = oXL.Workbooks.Add(missing);
//            Worksheet oSheet = oWB.ActiveSheet as Worksheet;
//            oSheet.Name = "The first sheet";
//            oSheet.Cells[1, 1] = "Something";
//            Worksheet oSheet2 = oWB.Sheets.Add(missing, missing, 1, missing)
//                            as Worksheet;
//            oSheet2.Name = "The second sheet";
//            oSheet2.Cells[1, 1] = "Something completely different";
//            string fileName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
//                                    + "\\SoSample.xlsx";
//            oWB.SaveAs(fileName, XlFileFormat.xlOpenXMLWorkbook,
//                missing, missing, missing, missing,
//                XlSaveAsAccessMode.xlNoChange,
//                missing, missing, missing, missing, missing);
//            oWB.Close(missing, missing, missing);
//            oXL.UserControl = true;
//            oXL.Quit();
//        }
        

//    }
//}
