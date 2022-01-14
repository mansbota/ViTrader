using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViTrader.Model;
using WebClient;

namespace ViTrader
{
    public partial class SellForm : Form
    {
        string endPoint, cryptoName;
        public string returnString;
        User user;
        int x, y;

        public SellForm(User user, string endPoint, string cryptoName, int x, int y)
        {
            InitializeComponent();

            this.user = user;
            this.endPoint = endPoint;
            this.cryptoName = cryptoName;
            this.x = x;
            this.y = y;
        }

        private void cancelSellBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            returnString = "Cancelled";
            this.Close();
        }

        private void SellForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(x, y);
        }

        private async void confirmSellBtn_Click(object sender, EventArgs e)
        {
            decimal amount;

            try
            {
                amount = decimal.Parse(amountBox.Text);

                string uri = endPoint + "/trades/" + user.UserName +
                    "?action=sell&name=" + cryptoName + "&amount=" + amount;

                RestClient client = new RestClient(HTTP_VERB.PUT, uri);

                client.HeaderKey = user.UserName;
                client.HeaderValue = user.Password;
                client.ContentLength = 0;

                string response = await client.MakeRequestAsync();

                if (response.Equals("Trade added"))
                {
                    this.DialogResult = DialogResult.OK;
                    returnString = amount.ToString();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                this.DialogResult = DialogResult.Abort;
                returnString = ex.Message;
                this.Close();
            }
        }
    }
}