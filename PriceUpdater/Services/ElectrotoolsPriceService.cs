using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using PriceUpdater.Models;

namespace PriceUpdater.Services
{
    public class ElectrotoolsPriceService
    {
        public static List<ElectrotoolsPriceRecord> GetRecords(string filePath)
        {
            HSSFWorkbook workbook;
            using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                workbook = new HSSFWorkbook(fs);
            }
            var sheet = workbook.GetSheetAt(0);

            var electrotoolsRecords = new List<ElectrotoolsPriceRecord>();

            var headerRow = sheet.GetRow(0);
            var cellCount = headerRow.LastCellNum;

            for (int i = sheet.FirstRowNum; i <= sheet.LastRowNum; i++)
            {
                var row = sheet.GetRow(i);
                if (row == null)
                {
                    continue;
                }

                if (row.Cells.All(d => d.CellType == CellType.Blank))
                {
                    continue;
                }

                var model = TryConvertRowToPriceRecord(row);

                if (model is not null)
                {
                    electrotoolsRecords.Add(model);
                }
            }

            return electrotoolsRecords;
        }

        private static ElectrotoolsPriceRecord TryConvertRowToPriceRecord(IRow row)
        {
            var arr = new List<string>();

            for (int j = 0; j < row.Cells.Count() + 1; j++)
            {
                arr.Add(row.GetCell(j)?.ToString() ?? String.Empty);
            }

            var model = ElectrotoolsPriceRecord.Deserialize(arr);

            return model;
        }

        //public static List<ElectrotoolsPriceRecord> GetRecords(string filePath)
        //{
        //    WorkBook workbook = WorkBook.Load(filePath);
        //    WorkSheet sheet = workbook.GetWorkSheet("TDSheet");
        //    var tmp = sheet.ToDataTable();

        //    var electrotoolsRecords = new List<ElectrotoolsPriceRecord>();

        //    foreach (DataRow row in tmp.Rows)
        //    {
        //        var arr = new List<string>();

        //        foreach (var item in row.ItemArray)
        //        {
        //            arr.Add(item.ToString());
        //        }

        //        var model = ElectrotoolsPriceRecord.Deserialize(arr);

        //        if (model is not null)
        //        {
        //            electrotoolsRecords.Add(model);
        //        }
        //    }

        //    return electrotoolsRecords;
        //}
    }
}
