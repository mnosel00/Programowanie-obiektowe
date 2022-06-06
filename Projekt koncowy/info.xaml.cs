using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace Projekt_koncowy
{
    /// <summary>
    /// Logika interakcji dla klasy info.xaml
    /// </summary>

    public partial class info : Window
    {
        private string value;

        public info(string value)
        {
            InitializeComponent();
            this.value = value;
            Crypto_Text.Text = value;
        }
      


    }
    
}
