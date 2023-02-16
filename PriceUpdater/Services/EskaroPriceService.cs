using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using PriceUpdater.Models;

namespace PriceUpdater.Services
{
    public static class EskaroPriceService
    {
        public static List<EskaroPriceRecord> GetRecords(string filePath)
        {
            ISheet sheet;

            if (filePath.ToLower().EndsWith(".xlsx"))
            {
                XSSFWorkbook xlsxWorkbook;
                using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    xlsxWorkbook = new XSSFWorkbook(fs);
                }
                sheet = xlsxWorkbook.GetSheetAt(0);
            }
            else 
            {
                HSSFWorkbook workbook;
                using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    workbook = new HSSFWorkbook(fs);
                }
                sheet = workbook.GetSheetAt(0);
            }

            var eskaroRecords = new List<EskaroPriceRecord>();

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
                    eskaroRecords.Add(model);
                }
            }

            return eskaroRecords;
        }

        private static EskaroPriceRecord TryConvertRowToPriceRecord(IRow row)
        {
            var arr = new List<string>();

            for (int j = 0; j < row.Cells.Count() + 1; j++)
            {
                arr.Add(row.GetCell(j)?.ToString() ?? String.Empty);
            }

            var model = EskaroPriceRecord.Deserialize(arr);

            return model;
        }

        //public static List<EskaroPriceRecord> GetRecords(string filePath)
        //{
        //    WorkBook workbook = WorkBook.Load(filePath);
        //    WorkSheet sheet = workbook.GetWorkSheet("TDSheet");
        //    var tmp = sheet.ToDataTable();

        //    var eskaroPrice = new List<EskaroPriceRecord>();

        //    foreach (DataRow row in tmp.Rows)
        //    {
        //        var arr = new List<string>();

        //        foreach (var item in row.ItemArray)
        //        {
        //            arr.Add(item.ToString());
        //        }

        //        var model = EskaroPriceRecord.Deserialize(arr);

        //        if (model is not null)
        //        {
        //            eskaroPrice.Add(model);
        //        }
        //    }

        //    return eskaroPrice;
        //}
    }
}
