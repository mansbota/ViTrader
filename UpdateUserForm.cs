using System;
using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ViTrader.Model;
using System.Resources;

namespace ViTrader
{
    public partial class UpdateUserForm : Form
    {
        string endPoint;
        public string returnString;
        User user;
        int x, y;
        ResourceManager manager;

        public UpdateUserForm(User user, string endPoint, int x, int y, ResourceManager manager)
        {
            InitializeComponent();

            this.user = user;
            this.endPoint = endPoint;
            this.x = x;
            this.y = y;

            this.manager = manager;
        }

        private void UpdateUserForm_Load(object sender, EventArgs e)
        {
            Location = new Point(x, y);
        }

        private void updateUserConfirmBtn_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex("^[a-zA-Z][a-zA-Z0-9]{3,9}$");

            if (!regex.IsMatch(newUserNameBox.Text))
            {
                MessageBox.Show(
                    manager.GetString("UserNameValidationError"),
                    manager.GetString("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            Process process = Process.Start(@"C:\Users\grgic\source\CSharp\UpdateUserViTrader\" +
                @"UpdateUserViTrader\bin\Release\net5.0\UpdateUserViTrader.exe",
                endPoint + " " + user.UserName + " " + newUserNameBox.Text + " " + user.Password);

            process.WaitForExit();
            int result = process.ExitCode;

            if (result == 0)
            {
                this.DialogResult = DialogResult.OK;
                returnString = manager.GetString("Success");
            }
            else if (result == -1)
            {
                this.DialogResult = DialogResult.Abort;
                returnString = manager.GetString("UserNameExistsError");
            }
            else
            {
                this.DialogResult = DialogResult.Abort;
                returnString = manager.GetString("UnknownError");
            }

            Close();
        }
    }
}
