using PriceUpdater.Extensions;
using PriceUpdater.Models;
using PriceUpdater.Services;
using PriceUpdaterApp.Models;

namespace PriceUpdaterApp
{
    public partial class MainForm : Form
    {
        private List<PromPriceRecord> _promRecords = new List<PromPriceRecord>();
        private Dictionary<string, PromPriceRecord>  _promNamePricesMap = new Dictionary<string, PromPriceRecord>();
        private Dictionary<string, PromPriceRecord> _promArtPricesMap = new Dictionary<string, PromPriceRecord>();

        private List<PromPriceRecord> _promCommonEskaro = new List<PromPriceRecord>();
        private List<PromPriceRecord> _promCommonPervijDom = new List<PromPriceRecord>();
        private List<PromPriceRecord> _promCommonElectrotools = new List<PromPriceRecord>();
        private decimal _UahToUsdConvertationCourse = 0;
        private decimal _pervijDomMarginCoefficient = 0;
        private decimal _eskaroMarginCoefficient = 0;
        private decimal _electrotoolsMarginCoefficient = 0;

        private List<PriceChangeRecord> _changesPervijDom = new List<PriceChangeRecord>();
        private List<PriceChangeRecord> _changesEskaro = new List<PriceChangeRecord>();
        private List<PriceChangeRecord> _changesElectrotools = new List<PriceChangeRecord>();

        private List<PriceChangeRecord> _changes = new List<PriceChangeRecord> 
        {  
        };

        public MainForm()
        {
            InitializeComponent();
            SetPriceChangesDataGrid();
        }

        void parsePromExportFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filePath = openFileDialog1.FileName;

            if (!filePath.EndsWith(".csv"))
            {
                MessageBox.Show(
                    "Файл повинен бути CSV",
                    "Помилка обробки файла PROM", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                return;
            }

            try
            {
                label1.Text = filePath;
                _promRecords = PromPriceService.GetRecords(filePath);

                _promNamePricesMap = new Dictionary<string, PromPriceRecord>();
                _promArtPricesMap = new Dictionary<string, PromPriceRecord>();

                foreach (var promPrice in _promRecords)
                {
                    _promNamePricesMap.TryAdd(promPrice.Название_позиции, promPrice);
                    _promArtPricesMap.TryAdd(promPrice.Код_товара.NormalizeArticool(), promPrice);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message + " " + ex.StackTrace, 
                    "Помилка обробки файла PROM",
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show($"Записи з файлу PROM завантажено. Кількість: {_promRecords.Count}");
            this.selectPricePervijDomPriceButton.Visible = true;
            this.selectEskaroPriceButton.Visible = true;
            this.createImportFileButton.Visible = true;
            this.selectElectrotoolsPriceButton.Visible = true;
            this.dollarCourseLabel.Visible = true;
            this.dollarCourseTextBox.Visible = true;
            this.marginPervijDomLabel.Visible = true;
            this.marginPervijDomTextBox.Visible = true;
            this.marginEskaroLabel.Visible = true;
            this.marginEskaroTextBox.Visible = true;
            this.marginElectrotoolsLabel.Visible = true;
            this.marginElectrotoolsTextBox.Visible = true;
        }

        private void parsePervijDom_Click(object sender, EventArgs e)
        {
            if (_promRecords.Count == 0)
            {
                MessageBox.Show("Записи з файлу PROM не завантажені. Завантажте файл PROM");
                return;
            }

            if (_pervijDomMarginCoefficient <= 0)
            {
                MessageBox.Show("Встановіть коефіцієнт націнки", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            string filePath = openFileDialog1.FileName;

            if (!filePath.EndsWith(".pdf"))
            {
                MessageBox.Show(
                    "Файл повинен бути PDF",
                    "Помилка обробки файла 'Перший дім'",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            try 
            {
                _promCommonPervijDom = new List<PromPriceRecord>();
                _changesPervijDom = new List<PriceChangeRecord>();

                label2.Text = filePath;                
                var pervijDomRecords = PervijDomPriceService.GetRecords(filePath);
                var keys = _promNamePricesMap.Keys.ToList();
                var message = "";

                foreach (var pervijDomItem in pervijDomRecords)
                {
                    foreach (var key in keys)
                    {
                        if (key.Trim().Contains(pervijDomItem.Name.Trim()))
                        {
                            var promItem = _promNamePricesMap[key];
                            if (promItem.Цена.Trim() != pervijDomItem.PriceDiscount.Trim())
                            {
                                var newPrice = Decimal.Parse(pervijDomItem.PriceDiscount) * _pervijDomMarginCoefficient;
                                newPrice = Math.Round(newPrice);

                                _promCommonPervijDom.Add(_promNamePricesMap[key]);
                                message += $"{promItem.Название_позиции} | Стара ціна: {promItem.Цена} | Нова ціна {newPrice}\n";
                                _changesPervijDom.Add(
                                    new PriceChangeRecord
                                    {
                                        VendorCode = promItem.Код_товара,
                                        Name = promItem.Название_позиции,
                                        OldPrice = promItem.Цена,
                                        NewPrice = newPrice.ToString(),
                                    });
                                promItem.Цена = newPrice.ToString();
                            }
                        }
                    }
                }

                MessageBox.Show(
                    message, 
                    $"Прайс 'Перший дім' завантажено \n Оновлено записів: {_promCommonPervijDom.Count}");
                SetPriceChangesDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message + " " + ex.StackTrace,
                    "Помилка обробки файла прайса 'Перший дім'",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void parseEskaro_Click(object sender, EventArgs e)
        {
            if (_promRecords.Count == 0)
            {
                MessageBox.Show("Записи з файлу PROM не завантажені. Завантажте файл PROM");
                return;
            }

            if (_eskaroMarginCoefficient <= 0)
            {
                MessageBox.Show("Встановіть коефіцієнт націнки", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            string filePath = openFileDialog1.FileName;

            if (!filePath.EndsWith(".xls") && !filePath.EndsWith(".xlsx"))
            {
                MessageBox.Show(
                    "Файл повинен бути XLS або XLSX",
                    "Помилка обробки файла прайса 'Eskaro'",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            try
            {
                label3.Text = filePath;
                var eskaroPriceRecords = EskaroPriceService.GetRecords(filePath);

                _changesEskaro = new List<PriceChangeRecord>();
                _promCommonEskaro = new List<PromPriceRecord>();
                var eskaroItems = new List<EskaroPriceRecord>();

                foreach (var eskaroItem in eskaroPriceRecords)
                {
                    if (_promArtPricesMap.ContainsKey(eskaroItem.VendorCode))
                    {
                        var promItem = _promArtPricesMap[eskaroItem.VendorCode];

                        if (promItem.Цена.Trim() != eskaroItem.Price.Trim())
                        {
                            _promCommonEskaro.Add(promItem);
                            eskaroItems.Add(eskaroItem);
                        }
                    }
                }

                var message = "";

                foreach (var eskaroRecord in eskaroItems)
                {
                    var promRecord = _promArtPricesMap[eskaroRecord.VendorCode];

                    var newPrice = Decimal.Parse(eskaroRecord.Price) * _eskaroMarginCoefficient;
                    newPrice = Math.Round(newPrice);

                    message += $"{promRecord.Название_позиции} | Стара ціна: {promRecord.Цена} | Нова ціна {newPrice}\n";
                    _changesEskaro.Add(
                        new PriceChangeRecord 
                        { 
                            VendorCode = promRecord.Код_товара,
                            Name = promRecord.Название_позиции,
                            OldPrice = promRecord.Цена,
                            NewPrice = newPrice.ToString(),
                        });
                    promRecord.Цена = newPrice.ToString();
                }

                MessageBox.Show(message, $"Прайс 'Eskaro' завантажено \n Оновлено записів: {eskaroItems.Count} \n");
                SetPriceChangesDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message + " " + ex.StackTrace,
                    "Помилка обробки файла прайса 'Eskaro'",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void createImportFile_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            if (_promRecords.Count == 0)
            {
                MessageBox.Show("Записи з файлу PROM не завантажені. Завантажте файл PROM");
                return;
            }

            string filePath = saveFileDialog1.FileName;

            var outputCollection = _promCommonEskaro
                .Concat(_promCommonPervijDom)
                .Concat(_promCommonElectrotools)
                .ToList();

            if (outputCollection.Count == 0)
            {
                MessageBox.Show("Немає оновлених данних");
                return;
            }

            PromPriceService.CreateImportFileNpoi(outputCollection, filePath);
            MessageBox.Show("Файл збережено");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void parseElectrotools_Click(object sender, EventArgs e)
        {
            if (_UahToUsdConvertationCourse <= 0)
            {
                MessageBox.Show("Встановіть курс обміну UAH/USD", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_electrotoolsMarginCoefficient <= 0)
            {
                MessageBox.Show("Встановіть коефіцієнт націнки", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_promRecords.Count == 0)
            {
                MessageBox.Show("Записи з файлу PROM не завантажені. Завантажте файл PROM");
                return;
            }

            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            var filePath = openFileDialog1.FileName;
            if (!filePath.EndsWith(".xls"))
            {
                MessageBox.Show(
                    "Файл повинен бути XLS",
                    "Помилка обробки файла прайса електроінструментів",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            try
            {
                label5.Text = filePath;
                var electrotoolsPriceRecords = ElectrotoolsPriceService.GetRecords(filePath);

                _promCommonElectrotools = new List<PromPriceRecord>();
                _changesElectrotools = new List<PriceChangeRecord>();
                var electrotoolsItems = new List<ElectrotoolsPriceRecord>();

                foreach (var electrotoolsItem in electrotoolsPriceRecords)
                {
                    if (_promArtPricesMap.ContainsKey(electrotoolsItem.VendorCode))
                    {
                        var promItem = _promArtPricesMap[electrotoolsItem.VendorCode];

                        if (promItem.Цена.Trim() != electrotoolsItem.PriceUSD.Trim())
                        {
                            _promCommonElectrotools.Add(promItem);
                            electrotoolsItems.Add(electrotoolsItem);
                        }
                    }
                }

                var message = "";

                foreach (var electrotoolRecord in electrotoolsItems)
                {
                    var promRecord = _promArtPricesMap[electrotoolRecord.VendorCode];
                    var priceUAH = Decimal.Parse(electrotoolRecord.PriceUSD) * _UahToUsdConvertationCourse * _electrotoolsMarginCoefficient;
                    priceUAH = Math.Round(priceUAH);

                    _changesPervijDom.Add(
                        new PriceChangeRecord
                        {
                            VendorCode = promRecord.Код_товара,
                            Name = promRecord.Название_позиции,
                            OldPrice = promRecord.Цена,
                            NewPrice = priceUAH.ToString()
                        });
                    message += $"{promRecord.Название_позиции} | Стара ціна: {promRecord.Цена} | Нова ціна {priceUAH}\n";

                    promRecord.Цена = priceUAH.ToString();
                }

                MessageBox.Show(message, $"Прайс електроінструментів завантажено \n Оновлено записів: {electrotoolsItems.Count} \n");
                SetPriceChangesDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message + " " + ex.StackTrace,
                    "Помилка обробки файла прайса електроінструментів",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void dollarCourseTextBox_OnMouseLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(dollarCourseTextBox.Text))
            {
                return;
            }

            dollarCourseTextBox.Text = dollarCourseTextBox.Text.Replace(",", ".");

            var result = Decimal.TryParse(dollarCourseTextBox.Text, out var parsed);

            if (result == false)
            {
                MessageBox.Show("Введіть десяткове число", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dollarCourseTextBox.Text = "";
                return;
            }

            if (parsed <= 0)
            {
                MessageBox.Show("Число має бути більшим за нуль", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dollarCourseTextBox.Text = "";
                return;
            }

            _UahToUsdConvertationCourse = parsed;
        }

        private void SetPriceChangesDataGrid()
        {
            _changes = _changesEskaro
                .Concat(_changesPervijDom)
                .Concat(_changesElectrotools)
                .ToList();

            BindingSource binding = new BindingSource();
            binding.DataSource = _changes;

            dataGridView1.DataSource = binding;
        }

        private void marginPervijDomTextBox_OnMouseLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(marginPervijDomTextBox.Text))
            {
                return;
            }

            marginPervijDomTextBox.Text = marginPervijDomTextBox.Text.Replace(",", ".");

            var result = Decimal.TryParse(marginPervijDomTextBox.Text, out var parsed);

            if (result == false)
            {
                MessageBox.Show("Введіть десяткове число", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                marginPervijDomTextBox.Text = "";
                return;
            }

            if (parsed <= 0)
            {
                MessageBox.Show("Число має бути більшим за нуль", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                marginPervijDomTextBox.Text = "";
                return;
            }

            _pervijDomMarginCoefficient = parsed;
        }

        private void marginEskaroTextBox_OnMouseLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(marginEskaroTextBox.Text))
            {
                return;
            }

            marginEskaroTextBox.Text = marginEskaroTextBox.Text.Replace(",", ".");

            var result = Decimal.TryParse(marginEskaroTextBox.Text, out var parsed);

            if (result == false)
            {
                MessageBox.Show("Введіть десяткове число", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                marginEskaroTextBox.Text = "";
                return;
            }

            if (parsed <= 0)
            {
                MessageBox.Show("Число має бути більшим за нуль", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                marginEskaroTextBox.Text = "";
                return;
            }

            _eskaroMarginCoefficient = parsed;
        }

        private void marginElectrotoolsTextBox_OnMouseLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(marginElectrotoolsTextBox.Text))
            {
                return;
            }

            marginElectrotoolsTextBox.Text = marginElectrotoolsTextBox.Text.Replace(",", ".");

            var result = Decimal.TryParse(marginElectrotoolsTextBox.Text, out var parsed);

            if (result == false)
            {
                MessageBox.Show("Введіть десяткове число", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                marginElectrotoolsTextBox.Text = "";
                return;
            }

            if (parsed <= 0)
            {
                MessageBox.Show("Число має бути більшим за нуль", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                marginElectrotoolsTextBox.Text = "";
                return;
            }

            _electrotoolsMarginCoefficient = parsed;
        }
    }
}