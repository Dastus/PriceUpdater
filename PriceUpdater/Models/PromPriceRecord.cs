namespace PriceUpdater.Models
{
    public class PromPriceRecord
    {
        public string Код_товара { get; set; }
        public string Название_позиции { get; set; }
        public string Название_позиции_укр { get; set; }
        public string Поисковые_запросы { get; set; }
        public string Поисковые_запросы_укр { get; set; }
        public string Описание { get; set; }
        public string Описание_укр { get; set; }
        public string Тип_товара { get; set; }
        public string Цена { get; set; }
        public string Валюта { get; set; }
        public string Единица_измерения { get; set; }
        public string Минимальный_объем_заказа { get; set; }
        public string Оптовая_цена { get; set; }
        public string Минимальный_заказ_опт { get; set; }
        public string Ссылка_изображения { get; set; }
        public string Наличие { get; set; }
        public string Количество { get; set; }
        public string Номер_группы { get; set; }
        public string Название_группы { get; set; }
        public string Адрес_подраздела { get; set; }
        public string Возможность_поставки { get; set; }
        public string Срок_поставки { get; set; }
        public string Способ_упаковки { get; set; }
        public string Способ_упаковки_укр { get; set; }
        public string Уникальный_идентификатор { get; set; }
        public string Идентификатор_товара { get; set; }
        public string Идентификатор_подраздела { get; set; }
        public string Идентификатор_группы { get; set; }
        public string Производитель { get; set; }
        public string Страна_производитель { get; set; }
        public string Скидка { get; set; }
        public string ID_группы_разновидностей { get; set; }
        public string Личные_заметки { get; set; }
        public string Продукт_на_сайте { get; set; }
        public string Cрок_действия_скидки_от { get; set; } //Cрок действия скидки от
        public string Cрок_действия_скидки_до { get; set; }//Cрок действия скидки до
        public string Цена_от { get; set; } //Цена от
        public string Ярлык { get; set; }
        public string HTML_заголовок { get; set; }
        public string HTML_заголовок_укр { get; set; }
        public string HTML_описание { get; set; }
        public string HTML_описание_укр { get; set; }
        public string HTML_ключевые_слова { get; set; }
        public string HTML_ключевые_слова_укр { get; set; }
        public string Вес_кг { get; set; } //Вес, кг
        public string Ширина_см { get; set; } //Ширина,см
        public string Высота_см { get; set; } //Высота, см
        public string Длина_см { get; set; }//Длина,см
        public string Где_находится_товар { get; set; }
        public string Код_маркировки_GTIN { get; set; } //Код_маркировки_(GTIN)
        public string Номер_устройства_MPN { get; set; } //Номер_устройства_(MPN)

        public string Название_Характеристики1 { get; set; } //Название_Характеристики
        public string Измерение_Характеристики1 { get; set; } //Измерение_Характеристики
        public string Значение_Характеристики1 { get; set; } //Значение_Характеристики

        public string Название_Характеристики2 { get; set; }
        public string Измерение_Характеристики2 { get; set; }
        public string Значение_Характеристики2 { get; set; }

        public string Название_Характеристики3 { get; set; }
        public string Измерение_Характеристики3 { get; set; }
        public string Значение_Характеристики3 { get; set; }

        public string Название_Характеристики4 { get; set; }
        public string Измерение_Характеристики4 { get; set; }
        public string Значение_Характеристики4 { get; set; }

        public string Название_Характеристики5 { get; set; }
        public string Измерение_Характеристики5 { get; set; }
        public string Значение_Характеристики5 { get; set; }

        public string Название_Характеристики6 { get; set; }
        public string Измерение_Характеристики6 { get; set; }
        public string Значение_Характеристики6 { get; set; }

        public string Название_Характеристики7 { get; set; }
        public string Измерение_Характеристики7 { get; set; }
        public string Значение_Характеристики7 { get; set; }

        public string Название_Характеристики8 { get; set; }
        public string Измерение_Характеристики8 { get; set; }
        public string Значение_Характеристики8 { get; set; }

        public string Название_Характеристики9 { get; set; }
        public string Измерение_Характеристики9 { get; set; }
        public string Значение_Характеристики9 { get; set; }

        public string Название_Характеристики10 { get; set; }
        public string Измерение_Характеристики10 { get; set; }
        public string Значение_Характеристики10 { get; set; }

        public static PromPriceRecord Deserialize(IEnumerable<string> csvRow)
        {
            if (csvRow is null)
            {
                return null;
            }

            var csvRowList = csvRow.ToList();

            var record = new PromPriceRecord
            {
                Код_товара = csvRowList[0],
                Название_позиции = csvRowList[1],
                Название_позиции_укр = csvRowList[2],
                Поисковые_запросы = csvRowList[3],
                Поисковые_запросы_укр = csvRowList[4],
                Описание = csvRowList[5],
                Описание_укр = csvRowList[6],
                Тип_товара = csvRowList[7],
                Цена = csvRowList[8],
                Валюта = csvRowList[9],
                Единица_измерения = csvRowList[10],
                Минимальный_объем_заказа = csvRowList[11],
                Оптовая_цена = csvRowList[12],
                Минимальный_заказ_опт = csvRowList[13],
                Ссылка_изображения = csvRowList[14],
                Наличие = csvRowList[15],
                Количество = csvRowList[16],
                Номер_группы = csvRowList[17],
                Название_группы = csvRowList[18],
                Адрес_подраздела = csvRowList[19],
                Возможность_поставки = csvRowList[20],
                Срок_поставки = csvRowList[21],
                Способ_упаковки = csvRowList[22],
                Способ_упаковки_укр = csvRowList[23],
                Уникальный_идентификатор = csvRowList[24],
                Идентификатор_товара = csvRowList[25],
                Идентификатор_подраздела = csvRowList[26],
                Идентификатор_группы = csvRowList[27],
                Производитель = csvRowList[28],
                Страна_производитель = csvRowList[29],
                Скидка = csvRowList[30],
                ID_группы_разновидностей = csvRowList[31],
                Личные_заметки = csvRowList[32],
                Продукт_на_сайте = csvRowList[33],
                Cрок_действия_скидки_от = csvRowList[34],
                Cрок_действия_скидки_до = csvRowList[35],
                Цена_от = csvRowList[36],
                Ярлык = csvRowList[37],
                HTML_заголовок = csvRowList[38],
                HTML_заголовок_укр = csvRowList[39],
                HTML_описание = csvRowList[40],
                HTML_описание_укр = csvRowList[41],
                HTML_ключевые_слова = csvRowList[42],
                HTML_ключевые_слова_укр = csvRowList[43],
                Вес_кг = csvRowList[44],
                Ширина_см = csvRowList[45],
                Высота_см = csvRowList[46],
                Длина_см = csvRowList[47],
                Где_находится_товар = csvRowList[48],
                Код_маркировки_GTIN = csvRowList[49],
                Номер_устройства_MPN = csvRowList[50],

                Название_Характеристики1 = GetByIndexOrDefault(51, csvRowList),
                Измерение_Характеристики1 = GetByIndexOrDefault(52, csvRowList),
                Значение_Характеристики1 = GetByIndexOrDefault(53, csvRowList),

                Название_Характеристики2 = GetByIndexOrDefault(54, csvRowList),
                Измерение_Характеристики2 = GetByIndexOrDefault(55, csvRowList),
                Значение_Характеристики2 = GetByIndexOrDefault(56, csvRowList),

                Название_Характеристики3 = GetByIndexOrDefault(57, csvRowList),
                Измерение_Характеристики3 = GetByIndexOrDefault(58, csvRowList),
                Значение_Характеристики3 = GetByIndexOrDefault(59, csvRowList),

                Название_Характеристики4 = GetByIndexOrDefault(60, csvRowList),
                Измерение_Характеристики4 = GetByIndexOrDefault(61, csvRowList),
                Значение_Характеристики4 = GetByIndexOrDefault(62, csvRowList),

                Название_Характеристики5 = GetByIndexOrDefault(63, csvRowList),
                Измерение_Характеристики5 = GetByIndexOrDefault(64, csvRowList),
                Значение_Характеристики5 = GetByIndexOrDefault(65, csvRowList),

                Название_Характеристики6 = GetByIndexOrDefault(66, csvRowList),
                Измерение_Характеристики6 = GetByIndexOrDefault(67, csvRowList),
                Значение_Характеристики6 = GetByIndexOrDefault(68, csvRowList),

                Название_Характеристики7 = GetByIndexOrDefault(69, csvRowList),
                Измерение_Характеристики7 = GetByIndexOrDefault(70, csvRowList),
                Значение_Характеристики7 = GetByIndexOrDefault(71, csvRowList),

                Название_Характеристики8 = GetByIndexOrDefault(72, csvRowList),
                Измерение_Характеристики8 = GetByIndexOrDefault(73, csvRowList),
                Значение_Характеристики8 = GetByIndexOrDefault(74, csvRowList),

                Название_Характеристики9 = GetByIndexOrDefault(75, csvRowList),
                Измерение_Характеристики9 = GetByIndexOrDefault(76, csvRowList),
                Значение_Характеристики9 = GetByIndexOrDefault(77, csvRowList),

                Название_Характеристики10 = GetByIndexOrDefault(78, csvRowList),
                Измерение_Характеристики10 = GetByIndexOrDefault(79, csvRowList),
                Значение_Характеристики10 = GetByIndexOrDefault(80, csvRowList),
            };

            return record;
        }

        private static string GetByIndexOrDefault(int index, List<string> list)
        {
            if (list.Count <= index)
            {
                return string.Empty;
            }

            return list[index];
        }
    }
}
