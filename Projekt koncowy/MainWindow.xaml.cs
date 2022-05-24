using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Projekt_koncowy
{
    record Crypto (string symbol, string name, float current_price, long market_cap, int market_cap_rank, float high_24h, float low_24h, float price_change_24h);
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, Crypto> Rates = new Dictionary<string, Crypto>();

        private void DownloadData()
        {
            WebClient client = new WebClient();

            client.Headers.Add("Content-Type", "application/json");
            string jsonRates = client.DownloadString("https://api.coingecko.com/api/v3/coins/markets?vs_currency=pln&order=market_cap_desc&per_page=100&page=1&sparkline=false");
            XDocument doc = XDocument.Parse(jsonRates);

            //Zmienic pobranego XML na słownik rekordow Rate

         
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GetAll_Click(object sender, RoutedEventArgs e)
        {
           
            
        }
    }
}
