using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;
using ViTrader.Model;
using EditCryptos;
using System.Threading.Tasks;
using System.Text;
using WebClient;
using System.Resources;

namespace ViTrader
{
    public partial class MainWindow : Form
    {
        string HTTPServerAddress;
        string HTTPServerPort;
        User user;
        ResourceManager manager;

        public MainWindow(int userId, string userName, string password, ResourceManager manager)
        {
            InitializeComponent();

            user = new User
            {
                Id = userId,
                UserName = userName,
                Password = password
            };

            this.manager = manager;
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        #region crypto_tab

        bool cryptosLoaded = false;
        Thread priceUpdateThread;

        private void UpdateSelectedCryptoPrice()
        {
            try
            {
                if (cryptosLoaded)
                {
                    string curCrypto = ReadCurrentCryptoSafe();

                    if (String.IsNullOrEmpty(curCrypto))
                        return;

                    RestClient priceUpdateClient = new RestClient(HTTP_VERB.GET,
                        "https://api.coingecko.com/api/v3/simple/price?ids=" +
                        curCrypto + "&vs_currencies=usd");

                    string response = priceUpdateClient.MakeRequest();

                    using (var obj = JsonDocument.Parse(response))
                    {
                        JsonElement root = obj.RootElement;
                        JsonElement coin = root.GetProperty(curCrypto);
                        var price = coin.GetProperty("usd").GetDecimal();
                        WriteCurrentPriceSafe(price.ToString() + " USD");
                    }
                }
            }
            catch (Exception)
            {
                WriteCurrentPriceSafe(manager.GetString("Error"));
                Thread.Sleep(2000);
            }
        }

        private void UpdateCurrentPrice()
        {
            while (true)
            {
                UpdateSelectedCryptoPrice();
                Thread.Sleep(2000);
            }
        }

        private void WriteCurrentPriceSafe(string text)
        {
            if (currentPriceLabel.InvokeRequired)
            {
                currentPriceLabel.Invoke(new Action(() => WriteCurrentPriceSafe(text)));
            }
            else
                currentPriceLabel.Text = text;
        }

        private string ReadCurrentCryptoSafe()
        {
            if (cryptoBox.InvokeRequired)
            {
                return (string)cryptoBox.Invoke(new Func<string>(() => ReadCurrentCryptoSafe()));
            }
            else
                return cryptoBox.Text;
        }

        private async Task LoadCryptos()
        {
            try
            {
                RestClient client = new RestClient(HTTP_VERB.GET,
                    "http://" + HTTPServerAddress + ":" + HTTPServerPort + "/cryptos");

                string response = await client.MakeRequestAsync();
                List<Crypto> cryptos;

                using (TextReader reader = new StringReader(response))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Crypto>));
                    cryptos = (List<Crypto>)serializer.Deserialize(reader);
                }

                var bindingSource = new BindingSource
                {
                    DataSource = cryptos
                };

                cryptoBox.DataSource = bindingSource.DataSource;
                cryptoBox.DisplayMember = "Name";
                cryptoBox.ValueMember = "Name";
                cryptosLoaded = true;

            }
            catch (Exception ex)
            {
                cryptosLoaded = false;

                MessageBox.Show(ex.Message, manager.GetString("LoadingCryptosError"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void LoadChart()
        {
            if (!cryptosLoaded)
                return;
            
            string timeString = timeBox.Text, cryptoName = cryptoBox.Text, periodString;

            if (timeString.Equals("1 d"))
                periodString = "minutely";

            else if (timeString.Equals("7 d") || timeString.Equals("14 d")|| timeString.Equals("20 d"))
                periodString = "hourly";

            else
                periodString = "daily";

            try
            {
                string uri 
                    = "https://api.coingecko.com/api/v3/coins/" + cryptoName + 
                    "/market_chart?vs_currency=usd&days=" + timeString.Split(' ')[0] 
                    + "&interval=" + periodString;

                RestClient client = new RestClient(HTTP_VERB.GET, uri);

                string response = await client.MakeRequestAsync();
                PriceData data = JsonSerializer.Deserialize<PriceData>(response);

                int selectedIndex = dataBox.SelectedIndex;
                double[] dataToChart;
                string[] times;

                if (selectedIndex == 0)
                    dataToChart = data.prices.Select(p => p[1]).ToArray();

                else if (selectedIndex == 1)
                    dataToChart = data.market_caps.Select(p => p[1]).ToArray();

                else
                    dataToChart = data.total_volumes.Select(p => p[1]).ToArray();

                times = data.prices.Select(p => DateTimeOffset
                    .FromUnixTimeMilliseconds((long)p[0]).ToString("yyyy-MM-dd HH")).ToArray();

                chart.AxisX.Clear();
                chart.AxisX.Add(new LiveCharts.Wpf.Axis { Labels = times });

                var series = new LiveCharts.Wpf.LineSeries()
                {
                    Title = cryptoName,
                    Values = new LiveCharts.ChartValues<double>(dataToChart),
                    Stroke = System.Windows.Media.Brushes.GreenYellow,
                    PointGeometrySize = 0.1
                };

                chart.Series.Clear();
                chart.Series.Add(series);

                chart.AxisX[0].Foreground = System.Windows.Media.Brushes.Black;
                chart.AxisY[0].Foreground = System.Windows.Media.Brushes.Black;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, manager.GetString("LoadingChartError"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buyBtn_Click(object sender, EventArgs e)
        {
            int x = this.Location.X + 200;
            int y = this.Location.Y + 100;

            BuyForm buyForm = new BuyForm(
                user, "http://" + HTTPServerAddress + ":" + HTTPServerPort, cryptoBox.Text, x, y);

            var result = buyForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                MessageBox.Show(manager.GetString("Bought") +
                    buyForm.returnString, manager.GetString("Success"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (result == DialogResult.Abort)
            {
                MessageBox.Show(buyForm.returnString, manager.GetString("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sellBtn_Click(object sender, EventArgs e)
        {
            int x = this.Location.X + 200;
            int y = this.Location.Y + 100;

            SellForm sellForm = new SellForm(
                user, "http://" + HTTPServerAddress + ":" + HTTPServerPort, cryptoBox.Text, x, y);

            var result = sellForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                MessageBox.Show(manager.GetString("Sold") +
                    sellForm.returnString, manager.GetString("Success"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (result == DialogResult.Abort)
            {
                MessageBox.Show(sellForm.returnString, manager.GetString("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void editBtn_Click(object sender, EventArgs e)
        {
            int x = this.Location.X + 300;
            int y = this.Location.Y + 200;

            EditCryptosForm editForm = new EditCryptosForm
                (user, "http://" + HTTPServerAddress + ":" + HTTPServerPort, x, y);

            editForm.ShowDialog();

            await LoadCryptos();
        }

        private void cryptoBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadChart();
        }

        private void timeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadChart();
        }

        private void dataBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadChart();
        }

        private void realoadBtn_Click(object sender, EventArgs e)
        {
            LoadChart();
        }

        private async void InitCryptoTab()
        {
            await LoadCryptos();

            timeBox.Items.Add("360 d");
            timeBox.Items.Add("180 d");
            timeBox.Items.Add("100 d");
            timeBox.Items.Add("20 d");
            timeBox.Items.Add("14 d");
            timeBox.Items.Add("7 d");
            timeBox.Items.Add("1 d");
            timeBox.SelectedIndex = 5;

            dataBox.Items.Add(manager.GetString("ComboBoxPrice"));
            dataBox.Items.Add(manager.GetString("ComboBoxCap"));
            dataBox.Items.Add(manager.GetString("ComboBoxVol"));
            dataBox.SelectedIndex = 0;

            priceUpdateThread = new Thread(UpdateCurrentPrice)
            {
                IsBackground = true
            };

            priceUpdateThread.Start();

            LoadChart();
        }

        #endregion

        #region wallet_tab

        private async Task<List<Position>> LoadPositions()
        {
            try
            {
                RestClient client = new RestClient(HTTP_VERB.GET,
                    "http://" + HTTPServerAddress + ":" + HTTPServerPort + "/positions/" + user.UserName);

                client.HeaderKey = user.UserName;
                client.HeaderValue = user.Password;
                client.ContentLength = 0;

                string response = await client.MakeRequestAsync();
                List<Position> positions;

                using (TextReader reader = new StringReader(response))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Position>));
                    positions = (List<Position>)serializer.Deserialize(reader);
                }

                return positions;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, manager
                    .GetString("LoadingPositionsError"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }
        }

        private async Task UpdatePositionsUSDValue(List<Position> positions)
        {
            StringBuilder cryptoNamesBuilder = new StringBuilder();

            foreach (var pos in positions)
            {
                cryptoNamesBuilder.Append(pos.CryptoName);
                if (pos != positions.Last())
                {
                    cryptoNamesBuilder.Append(",");
                }
            }

            string uri = "https://api.coingecko.com/api/v3/simple/price?ids=" +
                cryptoNamesBuilder.ToString() + "&vs_currencies=usd";

            RestClient client = new RestClient(HTTP_VERB.GET, uri);

            string response = await client.MakeRequestAsync();
            Dictionary<string, decimal> usdValues = new Dictionary<string, decimal>();

            using (var doc = JsonDocument.Parse(response))
            {
                foreach (var el in doc.RootElement.EnumerateObject())
                {
                    string cryptoName = el.Name;
                    var coin = JsonSerializer.Deserialize<Dictionary<string, decimal>>(el.Value);

                    usdValues[cryptoName] = coin.Values.First();
                }
            }

            foreach (var pos in positions)
            {
                pos.USDAmount = pos.Amount * usdValues[pos.CryptoName];
            }
        }

        private void UpdatePositionsList(List<Position> positions)
        {
            listView.Items.Clear();

            foreach (var pos in positions)
            {
                var row = new string[] { pos.CryptoName, pos.Amount.ToString(), pos.USDAmount.ToString() };
                var viewItem = new ListViewItem(row);

                viewItem.Tag = pos;
                listView.Items.Add(viewItem);
            }
        }

        private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            List<Position> positions = new List<Position>();

            foreach (ListViewItem item in listView.Items)
            {
                positions.Add((Position)item.Tag);
            }
            
            if (e.Column == 0)
            {
                positions.Sort((p1, p2) => p2.CryptoName.CompareTo(p1.CryptoName));
            }
            else if (e.Column == 1)
            {
                positions.Sort((p1, p2) => p2.Amount.CompareTo(p1.Amount));
            }
            else
            {
                positions.Sort((p1, p2) => p2.USDAmount.CompareTo(p1.USDAmount));
            }

            UpdatePositionsList(positions);
        }

        private async void InitWalletTab()
        {
            pieChart.Series.Clear();

            pieChart.LegendLocation = LiveCharts.LegendLocation.Bottom;
            LiveCharts.SeriesCollection series = new LiveCharts.SeriesCollection();

            List<Position> positions = await LoadPositions();

            if (positions == null)
                return;

            await UpdatePositionsUSDValue(positions);

            foreach (var pos in positions)
            {
                series.Add(new LiveCharts.Wpf.PieSeries()
                {
                    Title = pos.CryptoName,
                    Values = new LiveCharts.ChartValues<decimal> { pos.USDAmount }
                });
            }

            pieChart.Series = series;
            UpdatePositionsList(positions);
            totalValueLbl.Text = positions.Sum(p => p.USDAmount).ToString("F");
        }

        private async void confirmBtn_Click(object sender, EventArgs e)
        {
            try
            {
                decimal amount = decimal.Parse(textBox1.Text);

                if (amount > 10000)
                {
                    MessageBox.Show(
                        manager.GetString("USDTAmountError"),
                        manager.GetString("Error"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
                else if (amount < 100)
                {
                    MessageBox.Show(
                        manager.GetString("USDTAmountError"),
                        manager.GetString("Error"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                string uri =
                    "http://" + HTTPServerAddress + ":" + HTTPServerPort + "/positions/" +
                    user.UserName + "?amount=" + amount;

                RestClient client = new RestClient(HTTP_VERB.PUT, uri);

                client.HeaderKey = user.UserName;
                client.HeaderValue = user.Password;
                client.ContentLength = 0;

                string response = await client.MakeRequestAsync();

                if (response.Equals("USDT added"))
                {
                    MessageBox.Show(
                        manager.GetString("AddedUSDT") + amount,
                        manager.GetString("Success"),
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    InitWalletTab();
                }
                else
                {
                    MessageBox.Show(
                        manager.GetString("AddingUSDTError"),
                        manager.GetString("Error"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    manager.GetString("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region account_tab

        private async Task LoadUser()
        {
            try
            {
                RestClient client = new RestClient(HTTP_VERB.GET,
                    "http://" + HTTPServerAddress + ":" + HTTPServerPort + "/users/" + user.UserName);

                client.HeaderKey = user.UserName;
                client.HeaderValue = user.Password;
                client.ContentLength = 0;

                string response = await client.MakeRequestAsync();
                string password = user.Password;

                using (TextReader reader = new StringReader(response))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(User));
                    user = (User)serializer.Deserialize(reader);
                    user.Password = password;
                }

                userNameLbl.Text = user.UserName;
                emailAddressLbl.Text = user.EmailAddress;
                creationDateLbl.Text = user.TimeCreated.ToString();
                adminLbl.Text = user.isAdmin == 1 ?
                    manager.GetString("AdminPrivilegesYes") :
                    manager.GetString("AdminPrivilegesNo");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    manager.GetString("LoadingUserError"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadTrades()
        {
            try
            {
                RestClient client = new RestClient(HTTP_VERB.GET,
                    "http://" + HTTPServerAddress + ":" + HTTPServerPort + "/trades/" + user.UserName);

                client.HeaderKey = user.UserName;
                client.HeaderValue = user.Password;
                client.ContentLength = 0;

                string response = await client.MakeRequestAsync();
                List<Trade> trades;

                using (TextReader reader = new StringReader(response))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Trade>));
                    trades = (List<Trade>)serializer.Deserialize(reader);
                }

                listView1.Items.Clear();
                foreach (var trade in trades)
                {
                    var row = new string[] { trade.CryptoBought, trade.CryptoSold,
                        trade.AmountBought.ToString(), trade.AmountSold.ToString(),
                        trade.TradeTime.ToString("yyyy-MM-dd HH:mm") };

                    var listItem = new ListViewItem(row);
                    listItem.Tag = trade;
                    listView1.Items.Add(listItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    manager.GetString("LoadingTradesError"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editAccBtn_Click(object sender, EventArgs e)
        {
            int x = Location.X + 200;
            int y = Location.Y + 200;

            UpdateUserForm updateForm = new UpdateUserForm(user,
                "http://" + HTTPServerAddress + ":" + HTTPServerPort, x, y, manager);

            updateForm.ShowDialog();

            if (updateForm.DialogResult == DialogResult.OK)
            {
                MessageBox.Show(updateForm.returnString + "\n" +
                    manager.GetString("AppRestartMsg"),
                    manager.GetString("Success"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                Application.Restart();
            }
            else if (updateForm.DialogResult != DialogResult.Cancel)
            {
                MessageBox.Show(updateForm.returnString,
                    manager.GetString("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void deleteAccBtn_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show(
                manager.GetString("DeleteUserWarning"),
                "", MessageBoxButtons.YesNo);

            if (res == DialogResult.No)
                return;

            try
            {
                RestClient client = new RestClient(HTTP_VERB.DELETE,
                    "http://" + HTTPServerAddress + ":" + HTTPServerPort + "/users/" + user.UserName);

                client.HeaderKey = user.UserName;
                client.HeaderValue = user.Password;
                client.ContentLength = 0;

                string response = await client.MakeRequestAsync();

                if (response.Equals("Deleted"))
                {
                    MessageBox.Show(
                        manager.GetString("AppExitMsg"),
                        manager.GetString("Success"),
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Close();
                }
                else
                {
                    MessageBox.Show(
                        manager.GetString("DeletingUserError"),
                        manager.GetString("Error"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    manager.GetString("DeletingUserError"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void InitAccountTab()
        {
            await LoadUser();
            await LoadTrades();
        }

        #endregion

        private void MainWindow_Load(object sender, EventArgs e)
        {
            string fileName = "serverconfig.json";
            string jsonString = File.ReadAllText(fileName);

            using (JsonDocument doc = JsonDocument.Parse(jsonString))
            {
                JsonElement root = doc.RootElement;

                HTTPServerAddress = root.GetProperty("HTTPServerAddress").GetString();
                HTTPServerPort = root.GetProperty("HTTPPort").GetString();
            }

            InitCryptoTab();
            tabControl1.SelectedIndex = 2;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
                InitWalletTab();
            if (tabControl1.SelectedIndex == 2)
                InitAccountTab();
        }
    }

    class PriceData
    {
        public List<double[]> prices { get; set; }
        public List<double[]> market_caps { get; set; }
        public List<double[]> total_volumes { get; set; }
    }
}
