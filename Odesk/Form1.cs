//using System;
//using System.IO;
//using System.Linq;
//using System.Windows.Forms;
//using CsvHelper;
//using MaasOne.Finance.YahooFinance;
//using System.Collections.Generic;
//using MaasOne.Base;
////using Excel = Microsoft.Office.Interop.Excel;
//using System.IO;
//using System.Reflection;
//using System.Drawing;

//namespace Odesk
//{
//    public partial class Form1 : Form
//    {
//        private List<DateStockError> _errorList = new List<DateStockError>();

//        public Form1()
//        {
//            InitializeComponent();
//        }

//        private void button1_Click(object sender, EventArgs e)
//        {
//            OpenFileDialog dialog = new OpenFileDialog();
//            dialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
//            dialog.FilterIndex = 2;
//            dialog.RestoreDirectory = true;

//            if (dialog.ShowDialog() == DialogResult.OK)
//            {
//                try
//                {
//                    MessageBox.Show(dialog.FileName);

//                    var csv = new CsvReader(new StreamReader(dialog.FileName));
//                    var dateStockList = csv.GetRecords<DateStock>().ToList();
//                    dateStockList.ForEach(date =>
//                        {
//                            date.Index = dateStockList.IndexOf(date);
//                            date.DownLoadStockData();
//                            //date.CreateHistCsv();
//                        });
//                    ComputeMaxHighDiff(dateStockList);
//                    CreateExcelFile(dateStockList, Path.GetFullPath(dialog.FileName));
//                }
//                catch (Exception ex)
//                {
//                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
//                }
//            }

            
//        }

//        private void ComputeMaxHighDiff(List<DateStock> dateStockList)
//        {
//            dateStockList.ForEach(date =>{
//                if (date.HistoricalData.Any())
//                {
//                    var resultList = new List<MaxResult>();
//                    resultList.Add(new MaxResult(){Result =  date.HistoricalData.Where(d => Convert.ToDateTime(d.EventDate) > date.Date).Max(x => x.Open)});
//                    resultList.Add(new MaxResult() { Result = date.HistoricalData.Where(d => Convert.ToDateTime(d.EventDate) > date.Date).Max(x => x.High) });
//                    resultList.Add(new MaxResult() { Result = date.HistoricalData.Where(d => Convert.ToDateTime(d.EventDate) > date.Date).Max(x => x.Low) });
//                    resultList.Add(new MaxResult() { Result = date.HistoricalData.Where(d => Convert.ToDateTime(d.EventDate) > date.Date).Max(x => x.Close) });
//                    double max = resultList.Max(x => x.Result);
//                    date.HistoricalData[0].Max = max.ToString();

//                    var currentStock = date.HistoricalData.FirstOrDefault(d => Convert.ToDateTime(d.EventDate).Year == date.Date.Year && Convert.ToDateTime(d.EventDate).Month == date.Date.Month && Convert.ToDateTime(d.EventDate).Day == date.Date.Day);
//                    if (currentStock == null) return;
//                    resultList = new List<MaxResult>();
//                    resultList.Add(new MaxResult() { Result = currentStock.Open });
//                    resultList.Add(new MaxResult() { Result = currentStock.High });
//                    resultList.Add(new MaxResult() { Result = currentStock.Low });
//                    resultList.Add(new MaxResult() { Result = currentStock.Close });
        
//                    double high2 = resultList.Max(x => x.Result);
//                    date.HistoricalData[0].High2 = high2.ToString();

//                    date.HistoricalData[0].Diff = (max - high2).ToString();

//                }
//            });
//        }

//        private void CreateExcelFile(List<DateStock> dateStockList, string filePath)
//        {
//            object missing = Type.Missing;

//            Excel.Application oXL = new Excel.Application();
//            oXL.Visible = false;
//            Excel.Workbook oWB = oXL.Workbooks.Add(missing);
//            Excel.Worksheet oSheet = oWB.ActiveSheet as Excel.Worksheet;
//            dateStockList.Reverse();
//            foreach (var dateStock in dateStockList)
//            {
//                try
//                {
//                    Excel.Worksheet newSheet = oWB.Sheets.Add(missing, missing, 1, missing) as Excel.Worksheet;
//                    newSheet.Name = string.Format("{0} {1}", dateStock.Stock, dateStock.Date.ToString("MM-dd-yyyy"));
//                    newSheet.Cells[1, 1] = "EventDate";
//                    newSheet.Cells[1, 2] = "PositiveStock";
//                    newSheet.Cells[1, 3] = "Open";
//                    newSheet.Cells[1, 4] = "High";
//                    newSheet.Cells[1, 5] = "Low";
//                    newSheet.Cells[1, 6] = "Close";
//                    newSheet.Cells[1, 7] = "Volume";
//                    newSheet.Cells[1, 8] = "Max";
//                    newSheet.Cells[1, 9] = "High2";
//                    newSheet.Cells[1, 10] = "Diff";

//                    int initialRow = 1;
//                    dateStock.HistoricalData.ForEach(histDate =>
//                    {
//                        initialRow += 1;
//                        newSheet.Cells[initialRow, 1] = histDate.Date.ToString("MM-dd-yyyy");
//                        newSheet.Cells[initialRow, 2] = histDate.PositiveStock;
//                        newSheet.Cells[initialRow, 3] = histDate.Open;
//                        newSheet.Cells[initialRow, 4] = histDate.High;
//                        newSheet.Cells[initialRow, 5] = histDate.Low;
//                        newSheet.Cells[initialRow, 6] = histDate.Close;
//                        newSheet.Cells[initialRow, 7] = histDate.Volume;
//                        newSheet.Cells[initialRow, 8] = histDate.Max;
//                        newSheet.Cells[initialRow, 9] = histDate.High2;
//                        newSheet.Cells[initialRow, 10] = histDate.Diff;

//                        if (histDate.Date.Year == dateStock.Date.Year && histDate.Date.Month == dateStock.Date.Month && histDate.Date.Day == dateStock.Date.Day)
//                        {
//                            Excel.Range cellRange = (Excel.Range)newSheet.Range[newSheet.Cells[initialRow, 1], newSheet.Cells[initialRow, 7]];
//                            cellRange.Interior.Color = ConvertColour(Color.Yellow);
//                        }

//                        ((Excel.Range)newSheet.Range["A1", "G100"]).Columns.AutoFit();

//                    });
//                }
//                catch (Exception ex)
//                {
//                    _errorList.Add(new DateStockError() { Stock = string.Format("{0} {1}", dateStock.Stock, dateStock.Date.ToString("MM-dd-yyyy")), Error = ex.Message });
//                    continue;
//                }
//            }

//            string fileName = Path.GetDirectoryName(filePath) + string.Format("\\Larica{0}.xlsx", Path.GetFileName(filePath));
//            oWB.SaveAs(fileName, Excel.XlFileFormat.xlOpenXMLWorkbook,
//            missing, missing, missing, missing,
//            Excel.XlSaveAsAccessMode.xlNoChange,
//            missing, missing, missing, missing, missing);
//            oWB.Close(missing, missing, missing);
//            oXL.UserControl = true;
//            oXL.Quit();

//            if (_errorList.Any())
//            {
//                using (var csv = new CsvWriter(new StreamWriter(string.Format(Path.GetDirectoryName(filePath)+ "\\error.csv"))))
//                {
//                    csv.WriteRecords(_errorList);
//                }
//            }

//        }

//        public static int ConvertColour(Color colour)
//        {
//            int r = colour.R;
//            int g = colour.G * 256;
//            int b = colour.B * 65536;

//            return r + g + b;
//        }
//    }
//}
