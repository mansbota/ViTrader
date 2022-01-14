
namespace ViTrader
{
    partial class SellForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SellForm));
            this.sellGroupBox = new System.Windows.Forms.GroupBox();
            this.amountBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.confirmSellBtn = new System.Windows.Forms.Button();
            this.cancelSellBtn = new System.Windows.Forms.Button();
            this.sellGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // sellGroupBox
            // 
            resources.ApplyResources(this.sellGroupBox, "sellGroupBox");
            this.sellGroupBox.Controls.Add(this.amountBox);
            this.sellGroupBox.Controls.Add(this.label1);
            this.sellGroupBox.Name = "sellGroupBox";
            this.sellGroupBox.TabStop = false;
            // 
            // amountBox
            // 
            resources.ApplyResources(this.amountBox, "amountBox");
            this.amountBox.Name = "amountBox";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // confirmSellBtn
            // 
            resources.ApplyResources(this.confirmSellBtn, "confirmSellBtn");
            this.confirmSellBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.confirmSellBtn.Name = "confirmSellBtn";
            this.confirmSellBtn.UseVisualStyleBackColor = false;
            this.confirmSellBtn.Click += new System.EventHandler(this.confirmSellBtn_Click);
            // 
            // cancelSellBtn
            // 
            resources.ApplyResources(this.cancelSellBtn, "cancelSellBtn");
            this.cancelSellBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cancelSellBtn.Name = "cancelSellBtn";
            this.cancelSellBtn.UseVisualStyleBackColor = false;
            this.cancelSellBtn.Click += new System.EventHandler(this.cancelSellBtn_Click);
            // 
            // SellForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.cancelSellBtn);
            this.Controls.Add(this.confirmSellBtn);
            this.Controls.Add(this.sellGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SellForm";
            this.Load += new System.EventHandler(this.SellForm_Load);
            this.sellGroupBox.ResumeLayout(false);
            this.sellGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox sellGroupBox;
        private System.Windows.Forms.TextBox amountBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button confirmSellBtn;
        private System.Windows.Forms.Button cancelSellBtn;
    }
}