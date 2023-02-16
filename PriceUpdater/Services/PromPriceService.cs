using Microsoft.VisualBasic.FileIO;
using NPOI.HSSF.UserModel;
using PriceUpdater.Models;

namespace PriceUpdater.Services
{
    public static class PromPriceService
    {
        public static List<PromPriceRecord> GetRecords(string filePath)
        {
            var result = new List<PromPriceRecord>();

            using (var parser = new TextFieldParser(filePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    var fields = parser.ReadFields();
                    var record = PromPriceRecord.Deserialize(fields);

                    result.Add(record);
                }
            }

            return result;
        }

        public static void CreateImportFileNpoi(IReadOnlyCollection<PromPriceRecord> records, string path)
        {
            HSSFWorkbook workbook;
            using (var fs = new FileStream($"{AppDomain.CurrentDomain.BaseDirectory}/Import-Products.xls", FileMode.Open, FileAccess.Read))
            {
                workbook = new HSSFWorkbook(fs);
            }
            var sheet = workbook.GetSheetAt(0);

            var rowIndex = 0;

            foreach (var record in records)
            {
                rowIndex++;
                var row = sheet.CreateRow(rowIndex);

                row.CreateCell(0).SetCellValue(record.Код_товара);
                row.CreateCell(1).SetCellValue(record.Название_позиции);
                row.CreateCell(2).SetCellValue(record.Название_позиции_укр);
                row.CreateCell(3).SetCellValue(record.Поисковые_запросы);
                row.CreateCell(4).SetCellValue(record.Поисковые_запросы_укр);
                row.CreateCell(5).SetCellValue(record.Описание);
                row.CreateCell(6).SetCellValue(record.Описание_укр);
                row.CreateCell(7).SetCellValue(record.Тип_товара);
                row.CreateCell(8).SetCellValue(record.Цена);
                row.CreateCell(9).SetCellValue(record.Валюта);
                row.CreateCell(10).SetCellValue(record.Единица_измерения);
                row.CreateCell(11).SetCellValue(record.Минимальный_объем_заказа);
                row.CreateCell(12).SetCellValue(record.Оптовая_цена);
                row.CreateCell(13).SetCellValue(record.Минимальный_заказ_опт);
                row.CreateCell(14).SetCellValue(record.Ссылка_изображения);
                row.CreateCell(15).SetCellValue(record.Наличие);
                row.CreateCell(16).SetCellValue(record.Количество);
                row.CreateCell(17).SetCellValue(record.Скидка);
                row.CreateCell(18).SetCellValue(record.Производитель);
                row.CreateCell(19).SetCellValue(record.Страна_производитель);
                row.CreateCell(20).SetCellValue(record.Номер_группы);
                row.CreateCell(21).SetCellValue(record.Адрес_подраздела);
                row.CreateCell(22).SetCellValue(record.Способ_упаковки);
                row.CreateCell(23).SetCellValue(record.Способ_упаковки_укр);
                row.CreateCell(24).SetCellValue(record.Идентификатор_товара);
                row.CreateCell(25).SetCellValue(record.Уникальный_идентификатор);
                row.CreateCell(26).SetCellValue(record.Идентификатор_подраздела);
                row.CreateCell(27).SetCellValue(record.Идентификатор_группы);
                row.CreateCell(28).SetCellValue(record.ID_группы_разновидностей);
                row.CreateCell(29).SetCellValue(record.Личные_заметки);
                row.CreateCell(30).SetCellValue(record.Cрок_действия_скидки_от);
                row.CreateCell(31).SetCellValue(record.Cрок_действия_скидки_до);
                row.CreateCell(32).SetCellValue(record.Цена_от);
                row.CreateCell(33).SetCellValue(record.Ярлык);
                row.CreateCell(34).SetCellValue(record.HTML_заголовок);
                row.CreateCell(35).SetCellValue(record.HTML_заголовок_укр);
                row.CreateCell(36).SetCellValue(record.HTML_описание);
                row.CreateCell(37).SetCellValue(record.HTML_описание_укр);
                row.CreateCell(38).SetCellValue(record.HTML_ключевые_слова);
                row.CreateCell(39).SetCellValue(record.HTML_ключевые_слова_укр);
                row.CreateCell(40).SetCellValue(record.Вес_кг);
                row.CreateCell(41).SetCellValue(record.Ширина_см);
                row.CreateCell(42).SetCellValue(record.Высота_см);
                row.CreateCell(43).SetCellValue(record.Длина_см);
                row.CreateCell(44).SetCellValue(record.Где_находится_товар);
                row.CreateCell(45).SetCellValue(record.Код_маркировки_GTIN);
                row.CreateCell(46).SetCellValue(record.Номер_устройства_MPN);

                row.CreateCell(47).SetCellValue(record.Название_Характеристики1);
                row.CreateCell(48).SetCellValue(record.Измерение_Характеристики1);
                row.CreateCell(49).SetCellValue(record.Значение_Характеристики1);

                row.CreateCell(50).SetCellValue(record.Название_Характеристики2);
                row.CreateCell(51).SetCellValue(record.Измерение_Характеристики2);
                row.CreateCell(52).SetCellValue(record.Значение_Характеристики2);

                row.CreateCell(53).SetCellValue(record.Название_Характеристики3);
                row.CreateCell(54).SetCellValue(record.Измерение_Характеристики3);
                row.CreateCell(55).SetCellValue(record.Значение_Характеристики3);


                row.CreateCell(56).SetCellValue(record.Название_Характеристики4);
                row.CreateCell(57).SetCellValue(record.Измерение_Характеристики4);
                row.CreateCell(58).SetCellValue(record.Значение_Характеристики4);

                row.CreateCell(59).SetCellValue(record.Название_Характеристики5);
                row.CreateCell(60).SetCellValue(record.Измерение_Характеристики5);
                row.CreateCell(61).SetCellValue(record.Значение_Характеристики5);

                row.CreateCell(62).SetCellValue(record.Название_Характеристики6);
                row.CreateCell(63).SetCellValue(record.Измерение_Характеристики6);
                row.CreateCell(64).SetCellValue(record.Значение_Характеристики6);

                row.CreateCell(65).SetCellValue(record.Название_Характеристики7);
                row.CreateCell(66).SetCellValue(record.Измерение_Характеристики7);
                row.CreateCell(67).SetCellValue(record.Значение_Характеристики7);

                row.CreateCell(68).SetCellValue(record.Название_Характеристики8);
                row.CreateCell(69).SetCellValue(record.Измерение_Характеристики8);
                row.CreateCell(70).SetCellValue(record.Значение_Характеристики8);

                row.CreateCell(71).SetCellValue(record.Название_Характеристики9);
                row.CreateCell(72).SetCellValue(record.Измерение_Характеристики9);
                row.CreateCell(73).SetCellValue(record.Значение_Характеристики9);

                row.CreateCell(74).SetCellValue(record.Название_Характеристики10);
                row.CreateCell(75).SetCellValue(record.Измерение_Характеристики10);
                row.CreateCell(76).SetCellValue(record.Значение_Характеристики10);           
            }

            if (!path.EndsWith(".xls"))
            {
                path = path + ".xls";
            }

            using (var fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                workbook.Write(fs);
            }
        }

        //public static void CreateImportFile(IReadOnlyCollection<PromPriceRecord> records, string path)        
        //{
        //    WorkBook workbook = WorkBook.Load($"{AppDomain.CurrentDomain.BaseDirectory}/Import-Products.xls");
        //    WorkSheet sheet = workbook.GetWorkSheet("Export Products Sheet");
        //    int i = 1;

        //    foreach (var record in records)
        //    {
        //        i++;
        //        sheet["A" + i].Value = record.Код_товара;
        //        sheet["B" + i].Value = record.Название_позиции;
        //        sheet["C" + i].Value = record.Название_позиции_укр;
        //        sheet["D" + i].Value = record.Поисковые_запросы;
        //        sheet["E" + i].Value = record.Поисковые_запросы_укр;
        //        sheet["F" + i].Value = record.Описание;
        //        sheet["G" + i].Value = record.Описание_укр;
        //        sheet["H" + i].Value = record.Тип_товара;
        //        sheet["I" + i].Value = record.Цена;
        //        sheet["J" + i].Value = record.Валюта;
        //        sheet["K" + i].Value = record.Единица_измерения;
        //        sheet["L" + i].Value = record.Минимальный_объем_заказа;
        //        sheet["M" + i].Value = record.Оптовая_цена;
        //        sheet["N" + i].Value = record.Минимальный_заказ_опт;
        //        sheet["O" + i].Value = record.Ссылка_изображения;
        //        sheet["P" + i].Value = record.Наличие;
        //        sheet["Q" + i].Value = record.Количество;
        //        sheet["R" + i].Value = record.Скидка;
        //        sheet["S" + i].Value = record.Производитель;
        //        sheet["T" + i].Value = record.Страна_производитель;
        //        sheet["U" + i].Value = record.Номер_группы;
        //        sheet["V" + i].Value = record.Адрес_подраздела;
        //        sheet["W" + i].Value = record.Способ_упаковки;
        //        sheet["X" + i].Value = record.Способ_упаковки_укр;
        //        sheet["Y" + i].Value = record.Идентификатор_товара;
        //        sheet["Z" + i].Value = record.Уникальный_идентификатор;
        //        sheet["AA" + i].Value = record.Идентификатор_подраздела;
        //        sheet["AB" + i].Value = record.Идентификатор_группы;
        //        sheet["AC" + i].Value = record.ID_группы_разновидностей;
        //        sheet["AD" + i].Value = record.Личные_заметки;
        //        sheet["AE" + i].Value = record.Cрок_действия_скидки_от;
        //        sheet["AF" + i].Value = record.Cрок_действия_скидки_до;
        //        sheet["AG" + i].Value = record.Цена_от;
        //        sheet["AH" + i].Value = record.Ярлык;
        //        sheet["AI" + i].Value = record.HTML_заголовок;
        //        sheet["AJ" + i].Value = record.HTML_заголовок_укр;
        //        sheet["AK" + i].Value = record.HTML_описание;
        //        sheet["AL" + i].Value = record.HTML_описание_укр;
        //        sheet["AM" + i].Value = record.HTML_ключевые_слова;
        //        sheet["AN" + i].Value = record.HTML_ключевые_слова_укр;
        //        sheet["AO" + i].Value = record.Вес_кг;
        //        sheet["AP" + i].Value = record.Ширина_см;
        //        sheet["AQ" + i].Value = record.Высота_см;
        //        sheet["AR" + i].Value = record.Длина_см;
        //        sheet["AS" + i].Value = record.Где_находится_товар;
        //        sheet["AT" + i].Value = record.Код_маркировки_GTIN;
        //        sheet["AU" + i].Value = record.Номер_устройства_MPN;

        //        sheet["AV" + i].Value = record.Название_Характеристики1;
        //        sheet["AW" + i].Value = record.Измерение_Характеристики1;
        //        sheet["AX" + i].Value = record.Значение_Характеристики1;

        //        sheet["AY" + i].Value = record.Название_Характеристики2;
        //        sheet["AZ" + i].Value = record.Измерение_Характеристики2;
        //        sheet["BA" + i].Value = record.Значение_Характеристики2;

        //        sheet["BB" + i].Value = record.Название_Характеристики3;
        //        sheet["BC" + i].Value = record.Измерение_Характеристики3;
        //        sheet["BD" + i].Value = record.Значение_Характеристики3;

        //        sheet["BE" + i].Value = record.Название_Характеристики4;
        //        sheet["BF" + i].Value = record.Измерение_Характеристики4;
        //        sheet["BG" + i].Value = record.Значение_Характеристики4;

        //        sheet["BH" + i].Value = record.Название_Характеристики5;
        //        sheet["BI" + i].Value = record.Измерение_Характеристики5;
        //        sheet["BJ" + i].Value = record.Значение_Характеристики5;

        //        sheet["BK" + i].Value = record.Название_Характеристики6;
        //        sheet["BL" + i].Value = record.Измерение_Характеристики6;
        //        sheet["BM" + i].Value = record.Значение_Характеристики6;

        //        sheet["BN" + i].Value = record.Название_Характеристики7;
        //        sheet["BO" + i].Value = record.Измерение_Характеристики7;
        //        sheet["BP" + i].Value = record.Значение_Характеристики7;

        //        sheet["BQ" + i].Value = record.Название_Характеристики8;
        //        sheet["BR" + i].Value = record.Измерение_Характеристики8;
        //        sheet["BS" + i].Value = record.Значение_Характеристики8;

        //        sheet["BT" + i].Value = record.Название_Характеристики9;
        //        sheet["BU" + i].Value = record.Измерение_Характеристики9;
        //        sheet["BV" + i].Value = record.Значение_Характеристики9;

        //        sheet["BW" + i].Value = record.Название_Характеристики10;
        //        sheet["BX" + i].Value = record.Измерение_Характеристики10;
        //        sheet["BY" + i].Value = record.Значение_Характеристики10;
        //    }

        //    if (!path.EndsWith(".xls"))
        //    {
        //        path = path + ".xls";
        //    }
        //    workbook.SaveAs(path);
        //}

        //public static void SaveFile(
        //    IReadOnlyCollection<PromPriceRecord> records,
        //    string path)
        //{
        //    const string endline = "\r\n";
        //    var info = typeof(PromPriceRecord).GetProperties();
        //    Encoding utf8WithoutBom = new UTF8Encoding(false);
        //    TextWriter sw = new StreamWriter(File.Open(path, FileMode.Create), utf8WithoutBom);

        //    if (!File.Exists(path))
        //    {
        //        var file = File.Create(path);
        //        file.Close();
        //    }

        //    var sb = new StringBuilder();

        //    var firstLine = "";
        //    foreach (var property in typeof(PromPriceRecord).GetProperties())
        //    {
        //        firstLine += $"\"{property.Name}\",";
        //    }
        //    firstLine = firstLine.Substring(0, firstLine.Length-1);
        //    firstLine += endline;
        //    sb.Append(firstLine);

        //    foreach (var obj in records.Skip(0).Take(1))
        //    {
        //        var line = "";
        //        foreach (var prop in info)
        //        {
        //            line += $"\"{prop.GetValue(obj, null)}\",";
        //        }
        //        line = line.Substring(0, line.Length-1);
        //        line += endline;
        //        sb.Append(line);
        //    }

        //    var serialized = sb.ToString();
        //    sw.Write(serialized);
        //    sw.Close();
        //}
    }
}
