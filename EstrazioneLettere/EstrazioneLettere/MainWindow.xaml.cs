using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.Generic;

namespace EstrazioneLettere
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        char[] _alfabeto = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        List<char> _listParola = new List<char>();
        string _parola;
        int index = 0;
        char lettera;

        private async void Button_ClickInizia(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                if (index == 25)
                {
                    index = -1;
                }
                index++;

                lettera = _alfabeto[index];
                lblLettera.Content = lettera;
                await Task.Delay(100);
            }
        }

        private async void Button_ClickEstrai(object sender, RoutedEventArgs e)
        {
            _listParola.Add(lettera);
            _parola = ""; //inizializzo la stringa parola a vuoto
            foreach (char c in _listParola) //per ogni carattere c nella lista parola, aggiungo alla stringa parola il carattere c
            {
                _parola += c;
            }

            if (_parola.Length == 5)
            {
                lstParole.Items.Add(_parola);
                _listParola.Clear();
                _parola = "";

            }
            
            txtParola.Clear();
            txtParola.Text = _parola.ToString();
            await Task.Delay(100);

        }

       
    }
}