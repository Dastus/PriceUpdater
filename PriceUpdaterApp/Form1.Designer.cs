namespace PriceUpdaterApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.selectPricePervijDomPriceButton = new System.Windows.Forms.Button();
            this.selectMainPriceButton1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.selectEskaroPriceButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.createImportFileButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.selectElectrotoolsPriceButton = new System.Windows.Forms.Button();
            this.dollarCourseTextBox = new System.Windows.Forms.TextBox();
            this.dollarCourseLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.binding = new System.Windows.Forms.BindingSource(this.components);
            this.VendorCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OldPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.marginPervijDomLabel = new System.Windows.Forms.Label();
            this.marginPervijDomTextBox = new System.Windows.Forms.TextBox();
            this.marginEskaroLabel = new System.Windows.Forms.Label();
            this.marginEskaroTextBox = new System.Windows.Forms.TextBox();
            this.marginElectrotoolsLabel = new System.Windows.Forms.Label();
            this.marginElectrotoolsTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.binding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // selectPricePervijDomPriceButton
            // 
            this.selectPricePervijDomPriceButton.Location = new System.Drawing.Point(25, 238);
            this.selectPricePervijDomPriceButton.Name = "selectPricePervijDomPriceButton";
            this.selectPricePervijDomPriceButton.Size = new System.Drawing.Size(277, 29);
            this.selectPricePervijDomPriceButton.TabIndex = 3;
            this.selectPricePervijDomPriceButton.Text = "Вибрати прайс \'Перший Дім\'";
            this.selectPricePervijDomPriceButton.UseVisualStyleBackColor = true;
            this.selectPricePervijDomPriceButton.Visible = false;
            this.selectPricePervijDomPriceButton.Click += new System.EventHandler(this.parsePervijDom_Click);
            // 
            // selectMainPriceButton1
            // 
            this.selectMainPriceButton1.Location = new System.Drawing.Point(25, 13);
            this.selectMainPriceButton1.Name = "selectMainPriceButton1";
            this.selectMainPriceButton1.Size = new System.Drawing.Size(280, 29);
            this.selectMainPriceButton1.TabIndex = 1;
            this.selectMainPriceButton1.Text = "Вибрати файл експорту PROM";
            this.selectMainPriceButton1.UseVisualStyleBackColor = true;
            this.selectMainPriceButton1.Click += new System.EventHandler(this.parsePromExportFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 2;
            // 
            // selectEskaroPriceButton
            // 
            this.selectEskaroPriceButton.Location = new System.Drawing.Point(25, 379);
            this.selectEskaroPriceButton.Name = "selectEskaroPriceButton";
            this.selectEskaroPriceButton.Size = new System.Drawing.Size(277, 29);
            this.selectEskaroPriceButton.TabIndex = 4;
            this.selectEskaroPriceButton.Text = "Вибрати прайс \'Eskaro\'";
            this.selectEskaroPriceButton.UseVisualStyleBackColor = true;
            this.selectEskaroPriceButton.Visible = false;
            this.selectEskaroPriceButton.Click += new System.EventHandler(this.parseEskaro_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 20);
            this.label2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 346);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 20);
            this.label3.TabIndex = 6;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // createImportFileButton
            // 
            this.createImportFileButton.Location = new System.Drawing.Point(271, 560);
            this.createImportFileButton.Name = "createImportFileButton";
            this.createImportFileButton.Size = new System.Drawing.Size(615, 29);
            this.createImportFileButton.TabIndex = 7;
            this.createImportFileButton.Text = "Зберегти XLS файл для імпорту";
            this.createImportFileButton.UseVisualStyleBackColor = true;
            this.createImportFileButton.Visible = false;
            this.createImportFileButton.Click += new System.EventHandler(this.createImportFile_Click);
            // 
            // selectElectrotoolsPriceButton
            // 
            this.selectElectrotoolsPriceButton.Location = new System.Drawing.Point(25, 513);
            this.selectElectrotoolsPriceButton.Name = "selectElectrotoolsPriceButton";
            this.selectElectrotoolsPriceButton.Size = new System.Drawing.Size(280, 29);
            this.selectElectrotoolsPriceButton.TabIndex = 8;
            this.selectElectrotoolsPriceButton.Text = "Вибрати прайс електроінструментів";
            this.selectElectrotoolsPriceButton.UseVisualStyleBackColor = true;
            this.selectElectrotoolsPriceButton.Visible = false;
            this.selectElectrotoolsPriceButton.Click += new System.EventHandler(this.parseElectrotools_Click);
            // 
            // dollarCourseTextBox
            // 
            this.dollarCourseTextBox.Location = new System.Drawing.Point(30, 111);
            this.dollarCourseTextBox.Name = "dollarCourseTextBox";
            this.dollarCourseTextBox.Size = new System.Drawing.Size(125, 27);
            this.dollarCourseTextBox.TabIndex = 9;
            this.dollarCourseTextBox.Visible = false;
            this.dollarCourseTextBox.LostFocus += new System.EventHandler(this.dollarCourseTextBox_OnMouseLeave);
            // 
            // dollarCourseLabel
            // 
            this.dollarCourseLabel.AutoSize = true;
            this.dollarCourseLabel.Location = new System.Drawing.Point(30, 88);
            this.dollarCourseLabel.Name = "dollarCourseLabel";
            this.dollarCourseLabel.Size = new System.Drawing.Size(238, 20);
            this.dollarCourseLabel.TabIndex = 10;
            this.dollarCourseLabel.Text = "Курс доллара (гривень за 1 USD)";
            this.dollarCourseLabel.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 481);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 20);
            this.label5.TabIndex = 11;
            // 
            // VendorCode
            // 
            this.VendorCode.MinimumWidth = 6;
            this.VendorCode.Name = "VendorCode";
            this.VendorCode.Width = 125;
            // 
            // Name
            // 
            this.ProductName.MinimumWidth = 6;
            this.ProductName.Name = "Name";
            this.ProductName.Width = 125;
            // 
            // OldPrice
            // 
            this.OldPrice.MinimumWidth = 6;
            this.OldPrice.Name = "OldPrice";
            this.OldPrice.Width = 125;
            // 
            // NewPrice
            // 
            this.NewPrice.MinimumWidth = 6;
            this.NewPrice.Name = "NewPrice";
            this.NewPrice.Width = 125;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(356, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(770, 526);
            this.dataGridView1.TabIndex = 12;
            // 
            // marginPervijDomLabel
            // 
            this.marginPervijDomLabel.AutoSize = true;
            this.marginPervijDomLabel.Location = new System.Drawing.Point(28, 152);
            this.marginPervijDomLabel.Name = "marginPervijDomLabel";
            this.marginPervijDomLabel.Size = new System.Drawing.Size(230, 20);
            this.marginPervijDomLabel.TabIndex = 13;
            this.marginPervijDomLabel.Text = "Коефіцієнт націнки перший дім";
            this.marginPervijDomLabel.Visible = false;
            // 
            // marginPervijDomTextBox
            // 
            this.marginPervijDomTextBox.Location = new System.Drawing.Point(29, 175);
            this.marginPervijDomTextBox.Name = "marginPervijDomTextBox";
            this.marginPervijDomTextBox.Size = new System.Drawing.Size(125, 27);
            this.marginPervijDomTextBox.TabIndex = 14;
            this.marginPervijDomTextBox.Visible = false;
            this.marginPervijDomTextBox.LostFocus += new System.EventHandler(this.marginPervijDomTextBox_OnMouseLeave);
            // 
            // marginEskaroLabel
            // 
            this.marginEskaroLabel.AutoSize = true;
            this.marginEskaroLabel.Location = new System.Drawing.Point(25, 290);
            this.marginEskaroLabel.Name = "marginEskaroLabel";
            this.marginEskaroLabel.Size = new System.Drawing.Size(190, 20);
            this.marginEskaroLabel.TabIndex = 15;
            this.marginEskaroLabel.Text = "Коефіцієнт націнки eskaro";
            this.marginEskaroLabel.Visible = false;
            // 
            // marginEskaroTextBox
            // 
            this.marginEskaroTextBox.Location = new System.Drawing.Point(28, 313);
            this.marginEskaroTextBox.Name = "marginEskaroTextBox";
            this.marginEskaroTextBox.Size = new System.Drawing.Size(125, 27);
            this.marginEskaroTextBox.TabIndex = 16;
            this.marginEskaroTextBox.Visible = false;
            this.marginEskaroTextBox.LostFocus += new System.EventHandler(this.marginEskaroTextBox_OnMouseLeave);
            // 
            // marginElectrotoolsLabel
            // 
            this.marginElectrotoolsLabel.AutoSize = true;
            this.marginElectrotoolsLabel.Location = new System.Drawing.Point(27, 418);
            this.marginElectrotoolsLabel.Name = "marginElectrotoolsLabel";
            this.marginElectrotoolsLabel.Size = new System.Drawing.Size(254, 20);
            this.marginElectrotoolsLabel.TabIndex = 17;
            this.marginElectrotoolsLabel.Text = "Коефіцієнт націнки ел.інструментів";
            this.marginElectrotoolsLabel.Visible = false;
            // 
            // marginElectrotoolsTextBox
            // 
            this.marginElectrotoolsTextBox.Location = new System.Drawing.Point(29, 442);
            this.marginElectrotoolsTextBox.Name = "marginElectrotoolsTextBox";
            this.marginElectrotoolsTextBox.Size = new System.Drawing.Size(125, 27);
            this.marginElectrotoolsTextBox.TabIndex = 18;
            this.marginElectrotoolsTextBox.Visible = false;
            this.marginElectrotoolsTextBox.LostFocus += new System.EventHandler(this.marginElectrotoolsTextBox_OnMouseLeave);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 601);
            this.Controls.Add(this.marginElectrotoolsTextBox);
            this.Controls.Add(this.marginElectrotoolsLabel);
            this.Controls.Add(this.marginEskaroTextBox);
            this.Controls.Add(this.marginEskaroLabel);
            this.Controls.Add(this.marginPervijDomTextBox);
            this.Controls.Add(this.marginPervijDomLabel);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dollarCourseLabel);
            this.Controls.Add(this.dollarCourseTextBox);
            this.Controls.Add(this.selectElectrotoolsPriceButton);
            this.Controls.Add(this.createImportFileButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.selectEskaroPriceButton);
            this.Controls.Add(this.selectPricePervijDomPriceButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectMainPriceButton1);
            this.Text = "PriceUpdateApp";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.binding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button selectMainPriceButton1;
        private OpenFileDialog openFileDialog1;
        private Label label1;
        private Button selectPricePervijDomPriceButton;
        private Button selectEskaroPriceButton;
        private Label label2;
        private Label label3;
        private FileSystemWatcher fileSystemWatcher1;
        private Button createImportFileButton;
        private SaveFileDialog saveFileDialog1;
        private Button selectElectrotoolsPriceButton;
        private Label dollarCourseLabel;
        private TextBox dollarCourseTextBox;
        private Label label5;
        private DataGridViewTextBoxColumn VendorCode;
        private DataGridViewTextBoxColumn ProductName;
        private DataGridViewTextBoxColumn OldPrice;
        private DataGridViewTextBoxColumn NewPrice;
        private BindingSource binding;
        private DataGridView dataGridView1;
        private TextBox marginPervijDomTextBox;
        private Label marginPervijDomLabel;
        private TextBox marginElectrotoolsTextBox;
        private Label marginElectrotoolsLabel;
        private TextBox marginEskaroTextBox;
        private Label marginEskaroLabel;
    }
}