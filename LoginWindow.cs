using System;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using ViTrader.Client;
using IniParser;
using IniParser.Model;
using System.Resources;
using System.Reflection;
using EditCryptos;
using System.Runtime.InteropServices;
using System.Drawing;

namespace ViTrader
{
    public partial class LoginWindow : Form
    {
        public class IconExtractor
        {
            public static Icon Extract(string file, int number, bool largeIcon)
            {
                IntPtr large;
                IntPtr small;
                ExtractIconEx(file, number, out large, out small, 1);
                try
                {
                    return Icon.FromHandle(largeIcon ? large : small);
                }
                catch
                {
                    return null;
                }

            }

            [DllImport("Shell32.dll", EntryPoint = "ExtractIconExW", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            private static extern int ExtractIconEx(string sFile, int iIndex, out IntPtr piLargeVersion, out IntPtr piSmallVersion, int amountIcons);
        }

        bool launchedMainWindow = false;
        ResourceManager manager;

        public LoginWindow()
        {
            InitializeComponent();
            this.Icon = IconExtractor.Extract("shell32.dll", 43, true);
        }

        private void userNameLog_Validating(object sender, CancelEventArgs e)
        {
            Regex regex = new Regex("^[a-zA-Z][a-zA-Z0-9]{3,9}$");

            if (!regex.IsMatch(userNameLog.Text))
            {
                e.Cancel = true;
                userNameLog.Select(0, userNameLog.Text.Length);
                logUserNameErr.SetError(label1,
                    manager.GetString("UserNameValidationError"));
            }
        }

        private void userNameLog_Validated(object sender, EventArgs e)
        {
            logUserNameErr.SetError(label1, "");
        }

        private void userNameReg_Validating(object sender, CancelEventArgs e)
        {
            Regex regex = new Regex("^[a-zA-Z][a-zA-Z0-9]{3,9}$");

            if (!regex.IsMatch(userNameReg.Text))
            {
                e.Cancel = true;
                userNameReg.Select(0, userNameReg.Text.Length);
                regUserNameErr.SetError(label3,
                    manager.GetString("UserNameValidationError"));
            }
        }

        private void userNameReg_Validated(object sender, EventArgs e)
        {
            regUserNameErr.SetError(label3, "");
        }

        private void passwordLog_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidatePassword(passwordLog.Text, out string error))
            {
                e.Cancel = true;
                passwordLog.Select(0, passwordLog.Text.Length);
                logPasswordErr.SetError(label2, error);
            }
        }

        private void passwordLog_Validated(object sender, EventArgs e)
        {
            logPasswordErr.SetError(label2, "");
        }

        private bool ValidatePassword(string password, out string err)
        {
            if (password.Length < 8 || !password.Any(char.IsDigit))
            {
                err = manager.GetString("PasswordValidationError");
                return false;
            }

            err = "";
            return true;
        }

        private void passwordReg_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidatePassword(passwordReg.Text, out string error))
            {
                e.Cancel = true;
                passwordReg.Select(0, passwordReg.Text.Length);
                regPasswordErr.SetError(label4, error);
            }
        }

        private void passwordReg_Validated(object sender, EventArgs e)
        {
            regPasswordErr.SetError(label4, "");
        }

        private void passwordReg2_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidatePassword(passwordReg2.Text, out string error))
            {
                e.Cancel = true;
                passwordReg2.Select(0, passwordReg2.Text.Length);
                regPasswordErr2.SetError(label6, error);
            }
        }

        private void passwordReg2_Validated(object sender, EventArgs e)
        {
            regPasswordErr2.SetError(label6, "");
        }

        private void emailAddress_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (emailAddress.Text.Length <= 0 || emailAddress.Text.Length > 50)
                {
                    e.Cancel = true;
                    emailAddress.Select(0, emailAddress.Text.Length);
                    emailAddressErr.SetError(label5, 
                        manager.GetString("EmailValidationError"));
                    return;
                }

                MailAddress mailAddress = new MailAddress(emailAddress.Text);

                if (mailAddress.Address != emailAddress.Text)
                {
                    e.Cancel = true;
                    emailAddress.Select(0, emailAddress.Text.Length);
                    emailAddressErr.SetError(label5,
                        manager.GetString("EmailValidationError"));
                }
            }
            catch (FormatException)
            {
                e.Cancel = true;
                emailAddress.Select(0, emailAddress.Text.Length);
                emailAddressErr.SetError(label5,
                    manager.GetString("EmailValidationError"));
            }
        }

        private void emailAddress_Validated(object sender, EventArgs e)
        {
            emailAddressErr.SetError(label5, "");
        }

        private void logButton_Click(object sender, EventArgs e)
        {
            userNameLog_Validating(label1, new CancelEventArgs());
            passwordLog_Validating(label2, new CancelEventArgs());

            if (!logUserNameErr.GetError(label1).Equals("") || !logPasswordErr.GetError(label2).Equals(""))
                return;

            try
            {   
                TCPClient client = new TCPClient();

                if (client.Login(userNameLog.Text, passwordLog.Text, out int id))
                {
                    MainWindow window = new MainWindow(id, userNameLog.Text, passwordLog.Text, manager);
                    window.Show();
                    launchedMainWindow = true;
                    this.Close();
                }
                else
                {
                    if (id == (int)Errors.WRONG_INFO)
                    {
                        MessageBox.Show(
                            manager.GetString("IncorrectCredentials"), 
                            manager.GetString("FailedToLoginError"),
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (id == (int)Errors.INACTIVE_ACCOUNT)
                    {
                        MessageBox.Show(
                            manager.GetString("InactiveAccount"),
                            manager.GetString("FailedToLoginError"),
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(
                            manager.GetString("UnknownError"),
                            manager.GetString("FailedToLoginError"),
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    manager.GetString("FailedToConnectError"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void regButton_Click(object sender, EventArgs e)
        {
            userNameReg_Validating(label3, new CancelEventArgs());
            passwordReg_Validating(label4, new CancelEventArgs());
            emailAddress_Validating(label5, new CancelEventArgs());
            passwordReg2_Validating(label6, new CancelEventArgs());

            if (!regUserNameErr.GetError(label3).Equals("")
                || !regPasswordErr.GetError(label4).Equals("")
                || !emailAddressErr.GetError(label5).Equals("")
                || !regPasswordErr.GetError(label6).Equals(""))
                return;

            if (!passwordReg.Text.Equals(passwordReg2.Text))
            {
                MessageBox.Show(
                    manager.GetString("MatchError"),
                    manager.GetString("Error"),
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            try
            {
                TCPClient client = new TCPClient();

                if (client.Register(userNameReg.Text, passwordReg.Text, emailAddress.Text, out int id))
                {
                    MessageBox.Show(
                        manager.GetString("CheckMail"),
                        manager.GetString("RegisteredSuccessfully"),
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (id == (int)Errors.USERNAME_EXISTS)
                    {
                        MessageBox.Show(
                            manager.GetString("UserNameExistsError"),
                            manager.GetString("FailedToRegisterError"),
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (id == (int)Errors.EMAIL_EXISTS)
                    {
                        MessageBox.Show(
                            manager.GetString("EmailExistsError"),
                            manager.GetString("FailedToRegisterError"),
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (id == (int)Errors.MAIL_NOT_SENT)
                    {
                        MessageBox.Show(
                            manager.GetString("ActivationError"),
                            manager.GetString("FailedToRegisterError"),
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(
                            manager.GetString("UnknownError"),
                            manager.GetString("FailedToRegisterError"),
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    manager.GetString("FailedToConnectError"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginWindow_Load(object sender, EventArgs e)
        {
            label1.Select();
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("settings.ini");

            if (bool.Parse(data["LoginWindow"]["firstTime"]))
            {
                data["LoginWindow"]["firstTime"] = "false";
                parser.WriteFile("settings.ini", data);
                return;
            }

            this.Width = int.Parse(data["LoginWindow"]["width"]);
            this.Height = int.Parse(data["LoginWindow"]["height"]);

            int x = int.Parse(data["LoginWindow"]["x"]);
            int y = int.Parse(data["LoginWindow"]["y"]);

            this.Location = new System.Drawing.Point(x, y);

            manager = new ResourceManager("ViTrader.Properties.GlobalStrings", 
                Assembly.GetExecutingAssembly());
        }

        private void LoginWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("settings.ini");

            data["LoginWindow"]["width"] = this.Width.ToString();
            data["LoginWindow"]["height"] = this.Height.ToString();
            data["LoginWindow"]["x"] = this.Location.X.ToString();
            data["LoginWindow"]["y"] = this.Location.Y.ToString();

            parser.WriteFile("settings.ini", data);

            if (!launchedMainWindow)
                Application.Exit();
        }

        private void engBtn_Click(object sender, EventArgs e)
        {
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("settings.ini");

            data["Localization"]["language"] = "en";
            parser.WriteFile("settings.ini", data);
            Application.Restart();
        }

        private void croBtn_Click(object sender, EventArgs e)
        {
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("settings.ini");

            data["Localization"]["language"] = "hr";
            parser.WriteFile("settings.ini", data);
            Application.Restart();
        }
    }
}