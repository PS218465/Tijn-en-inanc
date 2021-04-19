using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

using System.Windows.Threading;

namespace Fietswinkel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int teller = 0;
        public MainWindow()
        {
            InitializeComponent();
            //nieuw
            DispatcherTimer progress = new DispatcherTimer();
            progress.Interval = new TimeSpan(0,0,1);
            progress.Tick += Progress_Tick;
            progress.Start();

        }

        private void Progress_Tick(object sender, EventArgs e)
        {
            teller++;
            bar.Value = teller;
            if (teller > 59)
            {
                MessageBox.Show("je bent te lang afk!");
                this.Close();
            }
        }

        private void btnbestel_Click(object sender, RoutedEventArgs e)
        {
            teller = 0;
            // haalt de combobox fiets op
            ComboBoxItem selected1 = fietsen.SelectedItem as ComboBoxItem;
         
            // haalt de combobox verzekeringen op
            ComboBoxItem selected2 = verzekeringen.SelectedItem as ComboBoxItem;

            // haalt de combobox services op
            ComboBoxItem selected3 = services.SelectedItem as ComboBoxItem;

            //haalt de aantal van de dagen op
            try
            {
                string antl = aantal.Text.ToString();
                int getal = Convert.ToInt32(antl);

                string days = "dag";
                if (getal > 1)
                {
                    days = "dagen";
                }

                string pric = bedrag.Text.ToString();
                double plus = double.Parse(pric);

                if (selected1 != null)
                {
                    string fiets = selected1.Content.ToString();
                    string[] split = fiets.Split(' ');
                    double number = double.Parse(split[2]);
                    double optel = number * getal;

                    plus = optel + plus;
                    string price = Convert.ToString(plus);
                    bedrag.Text = price;


                    verzekeringen.IsEnabled = true;
                    services.IsEnabled = true;
                    fietsen.SelectedIndex = -1;
                    aantal.Text = "1";


                    StackPanel sp = new StackPanel()
                    {
                        Background = Brushes.Black,
                        Orientation = Orientation.Horizontal,
                    };
                    TextBlock txtproduct = new TextBlock()
                    {
                        Foreground = Brushes.White,
                        Text = fiets + " ",
                        Name = "product"
                    };
                    sp.Children.Add(txtproduct);
                    TextBlock txtproduct2 = new TextBlock()
                    {
                        Foreground = Brushes.White,
                        Text = antl + " " + days + " ",
                        Name = "product2"
                    };
                    sp.Children.Add(txtproduct2);
                    TextBlock txtproduct3 = new TextBlock()
                    {
                        Foreground = Brushes.White,
                        Text = "€ " + Convert.ToString(optel),
                        Name = "product3",
                    };
                    sp.Children.Add(txtproduct3);
                    lijst.Items.Add(sp);


                }
                else if (selected2 != null)
                {
                    string verzekering = selected2.Content.ToString();
                    string[] split2 = verzekering.Split(' ');
                    double number2 = double.Parse(split2[2]);
                    double optel2 = number2 * getal;
                    double uitkomst2 = optel2 + plus;
                    string price = Convert.ToString(uitkomst2);
                    bedrag.Text = price;

                    fietsen.IsEnabled = true;
                    services.IsEnabled = true;
                    verzekeringen.SelectedIndex = -1;
                    aantal.Text = "1";


                    StackPanel sp = new StackPanel()
                    {
                        Background = Brushes.Black,
                        Orientation = Orientation.Horizontal,
                    };
                    TextBlock txtproduct = new TextBlock()
                    {
                        Foreground = Brushes.White,
                        Text = verzekering + " ",
                        Name = "product"
                    };
                    sp.Children.Add(txtproduct);
                    TextBlock txtproduct2 = new TextBlock()
                    {
                        Foreground = Brushes.White,
                        Text = antl + days + " ",
                        Name = "product2"
                    };
                    sp.Children.Add(txtproduct2);
                    TextBlock txtproduct3 = new TextBlock()
                    {
                        Foreground = Brushes.White,
                        Text = "€" + Convert.ToString(optel2),
                        Name = "product3"
                    };
                    sp.Children.Add(txtproduct3);
                    lijst.Items.Add(sp);

                }
                else if (selected3 != null)
                {
                    string service = selected3.Content.ToString();
                    string[] split3 = service.Split(' ');
                    double number3 = double.Parse(split3[2]);
                    double optel3 = number3 * getal;
                    double uitkomst3 = optel3 + plus;
                    string price = Convert.ToString(uitkomst3);
                    bedrag.Text = price;

                    fietsen.IsEnabled = true;
                    verzekeringen.IsEnabled = true;
                    services.SelectedIndex = -1;
                    aantal.Text = "1";


                    StackPanel sp = new StackPanel()
                    {
                        Background = Brushes.Black,
                        Orientation = Orientation.Horizontal,
                    };
                    TextBlock txtproduct = new TextBlock()
                    {
                        Foreground = Brushes.White,
                        Text = service + " ",
                        Name = "product1"
                    };
                    sp.Children.Add(txtproduct);
                    TextBlock txtproduct2 = new TextBlock()
                    {
                        Foreground = Brushes.White,
                        Text = antl + days + " ",
                        Name = "product2"
                    };
                    sp.Children.Add(txtproduct2);
                    TextBlock txtproduct3 = new TextBlock()
                    {
                        Foreground = Brushes.White,
                        Text = "€" + Convert.ToString(optel3),
                        Name = "product3"
                    };
                    sp.Children.Add(txtproduct3);
                    lijst.Items.Add(sp);
                }
            }
            catch
            {
                MessageBox.Show("u moet de aantal dagen in cijfers aan geven! (er mag geen gebruik gemakt worden van letters)");
            }
         
        }

        private void fietsen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            teller = 0;
            //de geslecteerde item word opgelsagen en word omgezet naar een string
            ComboBoxItem selected1 = fietsen.SelectedItem as ComboBoxItem;
            string value= aantal.Text.ToString();
            if (selected1 != null)
            {
                verzekeringen.IsEnabled = false;
                services.IsEnabled = false;
            }
        }

        private void verzekeringen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            teller = 0;
            ComboBoxItem selected2 = verzekeringen.SelectedItem as ComboBoxItem;
            if (selected2 != null)
            {
                fietsen.IsEnabled = false;
                services.IsEnabled = false;
            }
        }

        private void services_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            teller = 0;
            ComboBoxItem selected3 = services.SelectedItem as ComboBoxItem;
            if (selected3 != null)
            {
                fietsen.IsEnabled = false;
                verzekeringen.IsEnabled = false;
            }
        }

        private void delete(object sender, MouseButtonEventArgs e)
        {
//HEAD
            teller = 0;
            StackPanel sp = lijst.SelectedItem as StackPanel;
            double optel = 0;
            var Result = MessageBox.Show("Weet je zeker dat je het wilt verwijderen", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (Result == MessageBoxResult.Yes)
            {
                foreach (TextBlock item in sp.Children.OfType<TextBlock>())
                {

                    if (item.Name == "product3")
                    {
                        double ttl = Convert.ToDouble(bedrag.Text);

                        string prijs = item.Text;
                        string[] argumenten = prijs.Split('€');
                        optel = Double.Parse(argumenten[1]);
                        double uitkomst = ttl - optel;
                        string bdrg = Convert.ToString(uitkomst);
                        bedrag.Text = bdrg;
                        lijst.Items.Remove(lijst.SelectedItem);


                    }

                }
            }
        }
        private void next_Click(object sender, RoutedEventArgs e)
        {
            teller = 0;
            int count = lijst.Items.Count;
            if (count >= 1)
            {
                var result = MessageBox.Show("is de bestelling al betaald?", "caption", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    lijst.Items.Clear();
                    bedrag.Text = "0,00";
                    fietsen.SelectedIndex = -1;
                    verzekeringen.SelectedIndex = -1;
                    services.SelectedIndex = -1;
                }
                else
                {
                    kassa kassa = new kassa();
                    kassa.Show();
                    this.Close();

                }
            }
            else
            {
                MessageBox.Show("er zijn nog geen bestellingen toegevoegd");
            }

        }

        private void rek(object sender, RoutedEventArgs e)
        {
            subwindow win = new subwindow();
            win.Show();
            this.Close();
        }

        private void check(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(aantal.Text);
        }

        private void time_Click(object sender, RoutedEventArgs e)
        {
            time time = new time();
            time.Show();
            this.Close();
        }
    }
}
