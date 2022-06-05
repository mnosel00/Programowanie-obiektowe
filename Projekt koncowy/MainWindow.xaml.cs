using System;
using System.Collections.Generic;
using System.Globalization;
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

            try
            {
              
                    DownloadJson();
                    
              

                foreach (var item in Rates)
                {
                    DropList.Items.Add(item.Value.name);
                    Coin.Items.Add(item.Value.name);
                }
                DropList.SelectedIndex = 0;
                Coin.SelectedIndex = 0;
            }
            catch (Exception ey )
            {

                MessageBox.Show("Nie można połączyć się z siecią. Sprawdz połączenie z internetem !");
            }
            


        }

        private void GetAll_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ListaApi.Text = "";
                DownloadJson();

                foreach (var item in Rates)
                {
                    ListaApi.Text += $"Nazwa coina: {item.Key}{"\n"}  Cena: {item.Value.name}  {item.Value.current_price}, Max Wartość: {item.Value.ath}, Data Max Wartość: {item.Value.ath_date} \n\n";

                }
            }
            catch (Exception yt)
            {

                MessageBox.Show(yt.Message);
            }
            

            

        }

        private void GetFromDropMenu_click(object sender, RoutedEventArgs e)
        {
            try
            {
                DownloadJson();
                string inputCoin = DropList.Text;
                /*ListFromDropMenu.Text = Rates.Select(x=>(x.Value.name,x.Value.current_price,x.Value.ath,x.Value.ath_date)).Where(x=>x.name==inputCoin).ToString();*/

                foreach (var item in Rates)
                {
                    if (item.Value.name == inputCoin)
                    {
                        //ListFromDropMenu.Text = $"Nazwa coina: {item.Key}{"\n"}  Cena: {item.Value.name}  {item.Value.current_price}, Max Wartość: {item.Value.ath}, Data Max Wartość: {item.Value.ath_date} \n\n";
                        ListFromDropMenu.Text = $"Nazwa pobranego coina: {item.Value.name}\n" +
                            $"Aktualna cena: {item.Value.current_price}{DropCurencyList.Text}\n" +
                            $"Pozycja na giełdzie: {item.Value.market_cap_rank}\n" +
                            $"W dniu {item.Value.ath_date} {item.Value.id} osiągnął maksymalną wartość, która wyniosła {item.Value.ath}{DropCurencyList.Text}\n" +
                            $"W ostatnich 24 godzinach cena pobranej waluty zmieniła się o {item.Value.price_change_24h}{DropCurencyList.Text}\n" +
                            $"W dniu dzisiejszym {item.Value.id} osiągnał cene maksymalną wynoszącą {item.Value.high_24h}{DropCurencyList.Text}\n" +
                            $"Z kolei cena najniższa zamknęła się na {item.Value.low_24h}{DropCurencyList.Text}";
                    }
                }
            }
            catch (Exception rt)
            {

               MessageBox.Show(rt.Message);
            }
           
        }

        private void GetCalc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DownloadJson();

                int kwota = int.Parse(MoneyAmount.Text);
                string curency = Curency.Text;
               
                string coin = Coin.Text;
                string symbol = Rates.Where(x => x.Value.name == coin).Select(x => x.Value.symbol).FirstOrDefault();
                float coinPrice = Rates.Where(x => x.Value.name == coin).Select(x => x.Value.current_price).FirstOrDefault();
                DownloadJsonExchange();

                if (DropCurencyList.Text == curency)
                {
                    DownloadJsonExchange();
                    CalcList.Text = $"Za kwotę {kwota}{curency} możesz kupić {kwota / coinPrice} {symbol}";
                }
                else if (DropCurencyList.Text == "PLN" && DropCurencyList.Text != curency)
                {

                    CalcList.Text = $"Waluta którą posiadasz, różni się od tej, która występuję na rynku.\nNastąpi " +
                        $"przeliczenie na {DropCurencyList.Text}. \n{kwota}{curency} po przekonwertowaniu wynosi {pieniadz}{DropCurencyList.Text}.\n" +
                        $"Za kwotę {pieniadz}{DropCurencyList.Text} czyli ({kwota}{Curency.Text}) możesz kupić {pieniadz / coinPrice} {symbol}";
                }
                else if (DropCurencyList.Text == "USD" && DropCurencyList.Text != curency)
                {

                    CalcList.Text = $"2Waluta którą posiadasz, różni się od tej, która występuję na rynku.\nNastąpi " +
                        $"przeliczenie na {DropCurencyList.Text}. \n{kwota}{curency} po przekonwertowaniu wynosi {pieniadz}{DropCurencyList.Text}.\n" +
                        $"Za kwotę {pieniadz}{DropCurencyList.Text} czyli ({kwota}{Curency.Text}) możesz kupić {pieniadz / coinPrice} {symbol}";
                }
                else if (DropCurencyList.Text == "EUR" && DropCurencyList.Text != curency)
                {

                    CalcList.Text = $"3Waluta którą posiadasz, różni się od tej, która występuję na rynku.\nNastąpi " +
                        $"przeliczenie na {DropCurencyList.Text}. \n{kwota}{curency} po przekonwertowaniu wynosi {pieniadz}{DropCurencyList.Text}.\n" +
                        $"Za kwotę {pieniadz}{Curency.Text} czyli ({kwota}{Curency.Text}) możesz kupić {pieniadz / coinPrice} {symbol}";
                }
                else if (DropCurencyList.Text == "GBP" && DropCurencyList.Text != curency)
                {

                    CalcList.Text = $"4Waluta którą posiadasz, różni się od tej, która występuję na rynku.\nNastąpi " +
                        $"przeliczenie na {DropCurencyList.Text}. \n{kwota}{curency} po przekonwertowaniu wynosi {pieniadz}{DropCurencyList.Text}.\n" +
                        $"Za kwotę {pieniadz}{DropCurencyList.Text} czyli ({kwota}{Curency.Text}) możesz kupić {pieniadz / coinPrice} {symbol}";
                }
            }
            catch (Exception ex )
            {

                MessageBox.Show("Błędnie wprowadzone dane. Proszę poprawić wartości i uruchomić funkcję jeszcze raz"); 
            }
            

            // API key: xkp4MKt6Cd8IJddRngLS3mQKZHmIIomd
            //fetch("https://api.apilayer.com/exchangerates_data/convert?to={to}&from={from}&amount={amount}", requestOptions)

        }

        private void DownloadJson()
        {
            try
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
            catch (Exception e )
            {

                MessageBox.Show("Nie można połączyć się z siecią. Sprawdz połączenie z internetem !");
            }
            


        }
        
        private void DownloadJsonExchange()
        {
            try
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
            catch (Exception ec)
            {

                MessageBox.Show("Proszę podać poprawne dane ");
            }
            
        }


    }
}
