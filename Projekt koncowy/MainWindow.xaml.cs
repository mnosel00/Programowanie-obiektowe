using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
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
//using Newtonsoft.Json;
//using static Projekt_koncowy.Data;

namespace Projekt_koncowy
{
    record Crypto(string id, string symbol, string name, float current_price, int market_cap_rank, float high_24h, float low_24h, float price_change_24h, float ath, DateTime ath_date, DateTime last_updated);
    record Exchange(float result);
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, Crypto> Rates = new Dictionary<string, Crypto>();
        Dictionary<int, Exchange> RatesEx = new Dictionary<int, Exchange>();
        float pieniadz;


        public MainWindow()
        {
            
            InitializeComponent();
            DropCurencyList.Items.Add("USD");
            DropCurencyList.Items.Add("PLN");
            DropCurencyList.Items.Add("EUR");
            DropCurencyList.Items.Add("GBP");

            Curency.Items.Add("USD");
            Curency.Items.Add("PLN");
            Curency.Items.Add("EUR");
            Curency.Items.Add("GBP");

            DropCurencyList.SelectedIndex = 1;

            DownloadJson();

            foreach (var item in Rates)
            {
                DropList.Items.Add(item.Value.name);
                Coin.Items.Add(item.Value.name);
            }
            DropList.SelectedIndex = 0;
            Coin.SelectedIndex = 0;


        }

        private void GetAll_Click(object sender, RoutedEventArgs e)
        {
            ListaApi.Text = "";
            DownloadJson();

            foreach (var item in Rates)
            {
                ListaApi.Text += $"Nazwa coina: {item.Key}{"\n"}  Cena: {item.Value.name}  {item.Value.current_price}, Max Wartość: {item.Value.ath}, Data Max Wartość: {item.Value.ath_date} \n\n";
            }
        }

        private void GetFromDropMenu_click(object sender, RoutedEventArgs e)
        {
            DownloadJson();
            string inputCoin = DropList.Text;
             /*ListFromDropMenu.Text = Rates.Select(x=>(x.Value.name,x.Value.current_price,x.Value.ath,x.Value.ath_date)).Where(x=>x.name==inputCoin).ToString();*/

            foreach (var item in Rates)
            {
                if (item.Value.name==inputCoin)
                {
                    //ListFromDropMenu.Text = $"Nazwa coina: {item.Key}{"\n"}  Cena: {item.Value.name}  {item.Value.current_price}, Max Wartość: {item.Value.ath}, Data Max Wartość: {item.Value.ath_date} \n\n";
                    ListFromDropMenu.Text = item.Value.ToString();
                }
            }
        }

        private void GetCalc_Click(object sender, RoutedEventArgs e)
        {
            DownloadJson();

            int kwota = int.Parse(MoneyAmount.Text);
            string curency = Curency.Text;
            string coin = Coin.Text;
            string symbol = Rates.Where(x => x.Value.name == coin).Select(x => x.Value.symbol).FirstOrDefault();
            float coinPrice = Rates.Where(x => x.Value.name == coin).Select(x => x.Value.current_price).FirstOrDefault();

            if (DropCurencyList.Text == curency)
            {
       
                CalcList.Text = $"Za kwotę {kwota}{curency} możesz kupić {kwota / coinPrice} {symbol}";
            }
            else if (DropCurencyList.Text == "PLN" && DropCurencyList.Text != curency)
            {
                DownloadJsonExchange();
                CalcList.Text = $"Za kwotę {pieniadz}{DropCurencyList.Text} możesz kupić {pieniadz / coinPrice} {symbol}";
            }

            // API key: xkp4MKt6Cd8IJddRngLS3mQKZHmIIomd
            //fetch("https://api.apilayer.com/exchangerates_data/convert?to={to}&from={from}&amount={amount}", requestOptions)

        }

        private void DownloadJson()
        { 
            string currency = DropCurencyList.Text;
            WebClient client = new WebClient();
            client.Headers.Add("Content-Type", "application/json");
            string json = client.DownloadString($"https://api.coingecko.com/api/v3/coins/markets?vs_currency={currency}&order=market_cap_desc&per_page=100&page=1&sparkline=false");
            List<CryptoModel> info = JsonSerializer.Deserialize<List<CryptoModel>>(json);

            //https://api.coingecko.com/api/v3/coins/markets?vs_currency=pln&order=market_cap_desc&per_page=100&page=1&sparkline=false



            foreach (var item in info)
            {
                if (!Rates.ContainsKey(item.id))
                {
                    Rates.Add(item.id, new Crypto(item.id, item.symbol, item.name,
                                                item.current_price, item.market_cap_rank,
                                                item.high_24h, item.low_24h, item.price_change_24h,
                                                item.ath, item.ath_date, item.last_updated
                    ));
                }
                else
                {
                    
                    Rates[item.id] = new Crypto(item.id, item.symbol, item.name,
                                                item.current_price, item.market_cap_rank,
                                                item.high_24h, item.low_24h, item.price_change_24h,
                                                item.ath, item.ath_date, item.last_updated);
                }
               
                
            }


        }
        
        private void DownloadJsonExchange()
        {
            string to = DropCurencyList.Text;
            string from = Curency.Text;
            string amount = MoneyAmount.Text;
            int id = 0;


            WebClient clientEx = new WebClient();
            clientEx.Headers.Add("Content-Type", "application/json");
            string jsn = clientEx.DownloadString($"https://api.apilayer.com/exchangerates_data/convert?to={to}&from={from}&amount={amount}&apikey=xkp4MKt6Cd8IJddRngLS3mQKZHmIIomd");
            //List<Rootobject> infoEx = JsonSerializer.Deserialize<List<Rootobject>>(jsn);

            Rootobject infoEx = JsonSerializer.Deserialize<Rootobject>(jsn);

            //https://api.apilayer.com/exchangerates_data/convert?to=pln&from=usd&amount=1000&apikey=xkp4MKt6Cd8IJddRngLS3mQKZHmIIomd

            pieniadz = infoEx.result;
        }


    }
}
