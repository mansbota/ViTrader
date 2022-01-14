
namespace ViTrader
{
    partial class UpdateUserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateUserForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.newUserNameBox = new System.Windows.Forms.TextBox();
            this.updateUserConfirmBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.newUserNameBox);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // newUserNameBox
            // 
            resources.ApplyResources(this.newUserNameBox, "newUserNameBox");
            this.newUserNameBox.Name = "newUserNameBox";
            // 
            // updateUserConfirmBtn
            // 
            resources.ApplyResources(this.updateUserConfirmBtn, "updateUserConfirmBtn");
            this.updateUserConfirmBtn.Name = "updateUserConfirmBtn";
            this.updateUserConfirmBtn.UseVisualStyleBackColor = true;
            this.updateUserConfirmBtn.Click += new System.EventHandler(this.updateUserConfirmBtn_Click);
            // 
            // UpdateUserForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.updateUserConfirmBtn);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "UpdateUserForm";
            this.Load += new System.EventHandler(this.UpdateUserForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox newUserNameBox;
        private System.Windows.Forms.Button updateUserConfirmBtn;
    }
}