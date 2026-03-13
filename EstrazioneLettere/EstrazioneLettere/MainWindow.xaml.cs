using System.Windows;
using System.Windows.Controls;

namespace EstrazioneLettere
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        char[] _alfabeto = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' }; //Alfabeto

        string _parola = ""; //Parola che si forma con le lettere estratte

        int index = 0; //Indice per estrarre lettere dall'alfabeto

        char _lettera; //Lettera estratta

        Random rnd = new Random(); //Random

        int _numeroCaratteri = 5; //Numero di caratteri da estrarre per parola

        bool _iniziataEstrazione = false; //Per capire se l'estrazione è iniziata

        public MainWindow()
        {
            InitializeComponent();
        }
        private async void Button_ClickInizia(object sender, RoutedEventArgs e)
        {
            _iniziataEstrazione = true;
            while (true)
            {
                index = rnd.Next(0, 26);
                _lettera = _alfabeto[index]; //Estraggo una lettera
                lblLettera.Content = _lettera; //Aggiorno la label con la lettera estratta
                await Task.Delay(100);
            }
        }

        private async void Button_ClickEstrai(object sender, RoutedEventArgs e)
        {
            if (_iniziataEstrazione == true)
            {
                _parola += _lettera; //Aggiorno la parola con ogni carattere estratto

                txtParola.Clear();

                txtParola.Text = _parola; //Aggiorno il textbox con la parola formata dalle lettere estratte

                if (_parola.Length >= _numeroCaratteri) //Capisco se la parola ha raggiunto il numero di caratteri da estrarre desiderato
                {
                    lstParole.Items.Add(_parola); //Aggiungo la parola alla listbox di parole
                    _parola = ""; //inizializzo la parola vuota
                }

                await Task.Delay(100);
            }
        }

        private void txtNumeroCaratteri_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtNumeroCaratteri.Text = _numeroCaratteri.ToString(); //Aggiorno il textbox con il numero di caratteri da estrarre
        }

        private void btnPiuCaratteri_Click(object sender, RoutedEventArgs e)
        {
            _numeroCaratteri++; //Aumento il numero di caratteri da estrarre
            txtNumeroCaratteri.Clear();
        }

        private void btnMenoCaratteri_Click(object sender, RoutedEventArgs e)
        {
            if (_numeroCaratteri > 1)
            {
                _numeroCaratteri--; //Diminuisco il numero di caratteri da estrarre
                txtNumeroCaratteri.Clear();
            }
        }
    }
}