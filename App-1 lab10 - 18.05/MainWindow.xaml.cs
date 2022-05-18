using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace App_1_lab10___18._05
{
    record Rate (string Currency, string Code, double Bid, double Ask);
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, Rate> Rates = new Dictionary<string, Rate> ();
        private void DownloadData()
        {
            WebClient client = new WebClient();

            client.Headers.Add("Content-Type", "application/xml");
            string xmlRates = client.DownloadString("http://api.nbp.pl/api/exchangerates/tables/C");
            XDocument doc = XDocument.Parse(xmlRates);

            //Zmienic pobranego XML na słownik rekordow Rate
        }
        public MainWindow()
        {
            InitializeComponent();
            InputCurrencyCode.Items.Add("USD");
            InputCurrencyCode.Items.Add("EUR");
            InputCurrencyCode.Items.Add("PLN");
            ResultCurrencyCode.Items.Add("USD");
            ResultCurrencyCode.Items.Add("EUR");
            ResultCurrencyCode.Items.Add("PLN");

            InputCurrencyCode.SelectedIndex = 0;
            ResultCurrencyCode.SelectedIndex = 2;

        }

        private void CalBtn_Click(object sender, RoutedEventArgs e)
        {
            string inputCode = InputCurrencyCode.Text;
            string resultCode = ResultCurrencyCode.Text;
            decimal amount = decimal.Parse(InputValue.Text);

            //pobrać Rate dla inputCode i resultCode
            //obliczyć na podstawie pola Ask lub Bid kwotę po przeliczeniu 
            //Wyświetlić kwotę w polu ResultValue
        }

        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {
            string v = e.Text.Replace(",",".");
            e.Handled =! decimal.TryParse(e.Text, out decimal value);
        }
    }
}
