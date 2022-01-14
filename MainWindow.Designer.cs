
namespace ViTrader
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.accountTab = new System.Windows.Forms.TabPage();
            this.reportBtn = new System.Windows.Forms.Button();
            this.deleteAccBtn = new System.Windows.Forms.Button();
            this.editAccBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.cryptoBoughtCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cryptoSoldCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.boughtAmntCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.soldAmtCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timeCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.adminLbl = new System.Windows.Forms.Label();
            this.creationDateLbl = new System.Windows.Forms.Label();
            this.emailAddressLbl = new System.Windows.Forms.Label();
            this.userNameLbl = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.walletTab = new System.Windows.Forms.TabPage();
            this.totalValueLbl = new System.Windows.Forms.Label();
            this.valueLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.confirmBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listView = new System.Windows.Forms.ListView();
            this.nameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.amountCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.usdCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pieChart = new LiveCharts.WinForms.PieChart();
            this.cryptoTab = new System.Windows.Forms.TabPage();
            this.realoadBtn = new System.Windows.Forms.Button();
            this.editBtn = new System.Windows.Forms.Button();
            this.dataBox = new System.Windows.Forms.ComboBox();
            this.timeBox = new System.Windows.Forms.ComboBox();
            this.currentPriceLabel = new System.Windows.Forms.Label();
            this.sellBtn = new System.Windows.Forms.Button();
            this.buyBtn = new System.Windows.Forms.Button();
            this.cryptoBox = new System.Windows.Forms.ComboBox();
            this.chart = new LiveCharts.WinForms.CartesianChart();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.accountTab.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.walletTab.SuspendLayout();
            this.groupBox.SuspendLayout();
            this.cryptoTab.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // accountTab
            // 
            resources.ApplyResources(this.accountTab, "accountTab");
            this.accountTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(191)))), ((int)(((byte)(227)))));
            this.accountTab.Controls.Add(this.reportBtn);
            this.accountTab.Controls.Add(this.deleteAccBtn);
            this.accountTab.Controls.Add(this.editAccBtn);
            this.accountTab.Controls.Add(this.groupBox2);
            this.accountTab.Controls.Add(this.groupBox1);
            this.accountTab.Name = "accountTab";
            // 
            // reportBtn
            // 
            resources.ApplyResources(this.reportBtn, "reportBtn");
            this.reportBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.reportBtn.Name = "reportBtn";
            this.reportBtn.UseVisualStyleBackColor = false;
            // 
            // deleteAccBtn
            // 
            resources.ApplyResources(this.deleteAccBtn, "deleteAccBtn");
            this.deleteAccBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.deleteAccBtn.Name = "deleteAccBtn";
            this.deleteAccBtn.UseVisualStyleBackColor = false;
            this.deleteAccBtn.Click += new System.EventHandler(this.deleteAccBtn_Click);
            // 
            // editAccBtn
            // 
            resources.ApplyResources(this.editAccBtn, "editAccBtn");
            this.editAccBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.editAccBtn.Name = "editAccBtn";
            this.editAccBtn.UseVisualStyleBackColor = false;
            this.editAccBtn.Click += new System.EventHandler(this.editAccBtn_Click);
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.listView1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // listView1
            // 
            resources.ApplyResources(this.listView1, "listView1");
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cryptoBoughtCol,
            this.cryptoSoldCol,
            this.boughtAmntCol,
            this.soldAmtCol,
            this.timeCol});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Name = "listView1";
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // cryptoBoughtCol
            // 
            resources.ApplyResources(this.cryptoBoughtCol, "cryptoBoughtCol");
            // 
            // cryptoSoldCol
            // 
            resources.ApplyResources(this.cryptoSoldCol, "cryptoSoldCol");
            // 
            // boughtAmntCol
            // 
            resources.ApplyResources(this.boughtAmntCol, "boughtAmntCol");
            // 
            // soldAmtCol
            // 
            resources.ApplyResources(this.soldAmtCol, "soldAmtCol");
            // 
            // timeCol
            // 
            resources.ApplyResources(this.timeCol, "timeCol");
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.adminLbl);
            this.groupBox1.Controls.Add(this.creationDateLbl);
            this.groupBox1.Controls.Add(this.emailAddressLbl);
            this.groupBox1.Controls.Add(this.userNameLbl);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // adminLbl
            // 
            resources.ApplyResources(this.adminLbl, "adminLbl");
            this.adminLbl.Name = "adminLbl";
            // 
            // creationDateLbl
            // 
            resources.ApplyResources(this.creationDateLbl, "creationDateLbl");
            this.creationDateLbl.Name = "creationDateLbl";
            // 
            // emailAddressLbl
            // 
            resources.ApplyResources(this.emailAddressLbl, "emailAddressLbl");
            this.emailAddressLbl.Name = "emailAddressLbl";
            // 
            // userNameLbl
            // 
            resources.ApplyResources(this.userNameLbl, "userNameLbl");
            this.userNameLbl.Name = "userNameLbl";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // walletTab
            // 
            resources.ApplyResources(this.walletTab, "walletTab");
            this.walletTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(191)))), ((int)(((byte)(227)))));
            this.walletTab.Controls.Add(this.totalValueLbl);
            this.walletTab.Controls.Add(this.valueLbl);
            this.walletTab.Controls.Add(this.label1);
            this.walletTab.Controls.Add(this.groupBox);
            this.walletTab.Controls.Add(this.listView);
            this.walletTab.Controls.Add(this.pieChart);
            this.walletTab.Name = "walletTab";
            // 
            // totalValueLbl
            // 
            resources.ApplyResources(this.totalValueLbl, "totalValueLbl");
            this.totalValueLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.totalValueLbl.Name = "totalValueLbl";
            // 
            // valueLbl
            // 
            resources.ApplyResources(this.valueLbl, "valueLbl");
            this.valueLbl.Name = "valueLbl";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // groupBox
            // 
            resources.ApplyResources(this.groupBox, "groupBox");
            this.groupBox.Controls.Add(this.confirmBtn);
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Controls.Add(this.textBox1);
            this.groupBox.Name = "groupBox";
            this.groupBox.TabStop = false;
            // 
            // confirmBtn
            // 
            resources.ApplyResources(this.confirmBtn, "confirmBtn");
            this.confirmBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.UseVisualStyleBackColor = false;
            this.confirmBtn.Click += new System.EventHandler(this.confirmBtn_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // listView
            // 
            resources.ApplyResources(this.listView, "listView");
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameCol,
            this.amountCol,
            this.usdCol});
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HideSelection = false;
            this.listView.Name = "listView";
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            // 
            // nameCol
            // 
            resources.ApplyResources(this.nameCol, "nameCol");
            // 
            // amountCol
            // 
            resources.ApplyResources(this.amountCol, "amountCol");
            // 
            // usdCol
            // 
            resources.ApplyResources(this.usdCol, "usdCol");
            // 
            // pieChart
            // 
            resources.ApplyResources(this.pieChart, "pieChart");
            this.pieChart.Name = "pieChart";
            // 
            // cryptoTab
            // 
            resources.ApplyResources(this.cryptoTab, "cryptoTab");
            this.cryptoTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(191)))), ((int)(((byte)(227)))));
            this.cryptoTab.Controls.Add(this.realoadBtn);
            this.cryptoTab.Controls.Add(this.editBtn);
            this.cryptoTab.Controls.Add(this.dataBox);
            this.cryptoTab.Controls.Add(this.timeBox);
            this.cryptoTab.Controls.Add(this.currentPriceLabel);
            this.cryptoTab.Controls.Add(this.sellBtn);
            this.cryptoTab.Controls.Add(this.buyBtn);
            this.cryptoTab.Controls.Add(this.cryptoBox);
            this.cryptoTab.Controls.Add(this.chart);
            this.cryptoTab.Name = "cryptoTab";
            // 
            // realoadBtn
            // 
            resources.ApplyResources(this.realoadBtn, "realoadBtn");
            this.realoadBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.realoadBtn.Name = "realoadBtn";
            this.realoadBtn.UseVisualStyleBackColor = false;
            this.realoadBtn.Click += new System.EventHandler(this.realoadBtn_Click);
            // 
            // editBtn
            // 
            resources.ApplyResources(this.editBtn, "editBtn");
            this.editBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.editBtn.Name = "editBtn";
            this.editBtn.UseVisualStyleBackColor = false;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // dataBox
            // 
            resources.ApplyResources(this.dataBox, "dataBox");
            this.dataBox.FormattingEnabled = true;
            this.dataBox.Name = "dataBox";
            this.dataBox.SelectedIndexChanged += new System.EventHandler(this.dataBox_SelectedIndexChanged);
            // 
            // timeBox
            // 
            resources.ApplyResources(this.timeBox, "timeBox");
            this.timeBox.FormattingEnabled = true;
            this.timeBox.Name = "timeBox";
            this.timeBox.SelectedIndexChanged += new System.EventHandler(this.timeBox_SelectedIndexChanged);
            // 
            // currentPriceLabel
            // 
            resources.ApplyResources(this.currentPriceLabel, "currentPriceLabel");
            this.currentPriceLabel.Name = "currentPriceLabel";
            // 
            // sellBtn
            // 
            resources.ApplyResources(this.sellBtn, "sellBtn");
            this.sellBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.sellBtn.Name = "sellBtn";
            this.sellBtn.UseVisualStyleBackColor = false;
            this.sellBtn.Click += new System.EventHandler(this.sellBtn_Click);
            // 
            // buyBtn
            // 
            resources.ApplyResources(this.buyBtn, "buyBtn");
            this.buyBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buyBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buyBtn.Name = "buyBtn";
            this.buyBtn.UseVisualStyleBackColor = false;
            this.buyBtn.Click += new System.EventHandler(this.buyBtn_Click);
            // 
            // cryptoBox
            // 
            resources.ApplyResources(this.cryptoBox, "cryptoBox");
            this.cryptoBox.FormattingEnabled = true;
            this.cryptoBox.Name = "cryptoBox";
            this.cryptoBox.SelectedIndexChanged += new System.EventHandler(this.cryptoBox_SelectedIndexChanged);
            // 
            // chart
            // 
            resources.ApplyResources(this.chart, "chart");
            this.chart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(191)))), ((int)(((byte)(227)))));
            this.chart.ForeColor = System.Drawing.Color.Black;
            this.chart.Name = "chart";
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.cryptoTab);
            this.tabControl1.Controls.Add(this.walletTab);
            this.tabControl1.Controls.Add(this.accountTab);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // MainWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.tabControl1);
            this.Name = "MainWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.accountTab.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.walletTab.ResumeLayout(false);
            this.walletTab.PerformLayout();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.cryptoTab.ResumeLayout(false);
            this.cryptoTab.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage accountTab;
        private System.Windows.Forms.TabPage walletTab;
        private System.Windows.Forms.TabPage cryptoTab;
        private System.Windows.Forms.Button realoadBtn;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.ComboBox dataBox;
        private System.Windows.Forms.ComboBox timeBox;
        private System.Windows.Forms.Label currentPriceLabel;
        private System.Windows.Forms.Button sellBtn;
        private System.Windows.Forms.Button buyBtn;
        private System.Windows.Forms.ComboBox cryptoBox;
        private LiveCharts.WinForms.CartesianChart chart;
        private System.Windows.Forms.TabControl tabControl1;
        private LiveCharts.WinForms.PieChart pieChart;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader nameCol;
        private System.Windows.Forms.ColumnHeader amountCol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button confirmBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ColumnHeader usdCol;
        private System.Windows.Forms.Button reportBtn;
        private System.Windows.Forms.Button deleteAccBtn;
        private System.Windows.Forms.Button editAccBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader cryptoBoughtCol;
        private System.Windows.Forms.ColumnHeader cryptoSoldCol;
        private System.Windows.Forms.ColumnHeader boughtAmntCol;
        private System.Windows.Forms.ColumnHeader soldAmtCol;
        private System.Windows.Forms.ColumnHeader timeCol;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label adminLbl;
        private System.Windows.Forms.Label creationDateLbl;
        private System.Windows.Forms.Label emailAddressLbl;
        private System.Windows.Forms.Label userNameLbl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label valueLbl;
        private System.Windows.Forms.Label totalValueLbl;
    }
}