﻿using System;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, Crypto> Rates = new Dictionary<string, Crypto>();

        private void DownloadData()
        {
            /*WebClient client = new WebClient();

            client.Headers.Add("Content-Type", "application/json");
            string jsonRates = client.DownloadString("https://api.coingecko.com/api/v3/coins/markets?vs_currency=pln&order=market_cap_desc&per_page=100&page=1&sparkline=false");
            XDocument doc = XDocument.Parse(jsonRates);

            //Zmienic pobranego XML na słownik rekordow Rate*/


        }
        public MainWindow()
        {
            InitializeComponent();
            DownloadJson();
            foreach (var item in Rates)
            {
                DropList.Items.Add(item.Value.name);
            }
            DropList.SelectedIndex = 0;

        }

        private void GetAll_Click(object sender, RoutedEventArgs e)
        {


            foreach (var item in Rates)
            {
                ListaApi.Text += $"Nazwa coina: {item.Key}{"\n"}  Cena: {item.Value.name}  {item.Value.current_price}, Max Wartość: {item.Value.ath}, Data Max Wartość: {item.Value.ath_date} \n\n";
            }
        }

        private void GetFromDropMenu_click(object sender, RoutedEventArgs e)
        {
            string inputCoin = DropList.Text;
            // ListFromDropMenu.Text = Rates.Select(x=>(x.Value.name,x.Value.current_price,x.Value.ath,x.Value.ath_date)).Where(x=>x.name==inputCoin).ToString();

            foreach (var item in Rates)
            {
                if (item.Value.name==inputCoin)
                {
                    ListFromDropMenu.Text = $"Nazwa coina: {item.Key}{"\n"}  Cena: {item.Value.name}  {item.Value.current_price}, Max Wartość: {item.Value.ath}, Data Max Wartość: {item.Value.ath_date} \n\n"; 
                }
            }
        }

        private void DownloadJson()
        {
            WebClient client = new WebClient();
            client.Headers.Add("Content-Type", "application/json");
            string json = client.DownloadString("https://api.coingecko.com/api/v3/coins/markets?vs_currency=pln&order=market_cap_desc&per_page=100&page=1&sparkline=false");
            List<CryptoModel> info = JsonSerializer.Deserialize<List<CryptoModel>>(json);



            foreach (var item in info)
            {
                Rates.Add(item.id, new Crypto(item.id, item.symbol, item.name,
                                                item.current_price, item.market_cap_rank,
                                                item.high_24h, item.low_24h, item.price_change_24h,
                                                item.ath, item.ath_date, item.last_updated
                    ));
            }


        }


    }
}