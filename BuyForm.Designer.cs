
namespace ViTrader
{
    partial class BuyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuyForm));
            this.buyGroupBox = new System.Windows.Forms.GroupBox();
            this.amountBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.confirmBuyBtn = new System.Windows.Forms.Button();
            this.cancelBuyBtn = new System.Windows.Forms.Button();
            this.buyGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // buyGroupBox
            // 
            resources.ApplyResources(this.buyGroupBox, "buyGroupBox");
            this.buyGroupBox.Controls.Add(this.amountBox);
            this.buyGroupBox.Controls.Add(this.label1);
            this.buyGroupBox.Name = "buyGroupBox";
            this.buyGroupBox.TabStop = false;
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
            // confirmBuyBtn
            // 
            resources.ApplyResources(this.confirmBuyBtn, "confirmBuyBtn");
            this.confirmBuyBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.confirmBuyBtn.Name = "confirmBuyBtn";
            this.confirmBuyBtn.UseVisualStyleBackColor = false;
            this.confirmBuyBtn.Click += new System.EventHandler(this.confirmBuyBtn_Click);
            // 
            // cancelBuyBtn
            // 
            resources.ApplyResources(this.cancelBuyBtn, "cancelBuyBtn");
            this.cancelBuyBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cancelBuyBtn.Name = "cancelBuyBtn";
            this.cancelBuyBtn.UseVisualStyleBackColor = false;
            this.cancelBuyBtn.Click += new System.EventHandler(this.cancelBuyBtn_Click);
            // 
            // BuyForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.cancelBuyBtn);
            this.Controls.Add(this.confirmBuyBtn);
            this.Controls.Add(this.buyGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BuyForm";
            this.Load += new System.EventHandler(this.BuyForm_Load);
            this.buyGroupBox.ResumeLayout(false);
            this.buyGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox buyGroupBox;
        private System.Windows.Forms.TextBox amountBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button confirmBuyBtn;
        private System.Windows.Forms.Button cancelBuyBtn;
    }
}