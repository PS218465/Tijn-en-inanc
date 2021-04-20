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
        DispatcherTimer laadbalk = new DispatcherTimer();
        
        public MainWindow()
        {
            InitializeComponent();
            //nieuw
            laadbalk.Interval = new TimeSpan(0, 0, 1);
            laadbalk.Tick += Progress_Tick;
            laadbalk.Start();

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
                string antl = aantal.Text.ToString(); // pakt de aantal dagen en zet hem in een string
                int getal = Convert.ToInt32(antl);  // pakt de aantal dagen en zet hem in een int

                string days = "dag"; 
                if (getal > 1) // als de aantal dagen die zijn ingevoerd hoger dan 1 zijn komt er dagen in plaats van dag te staan.
                {
                    days = "dagen"; // veranderd naar string days naar dagen
                }

                string pric = bedrag.Text.ToString();
                double plus = double.Parse(pric);

                if (selected1 != null)
                {
                    string fiets = selected1.Content.ToString();// zet de geslecteerde item in een string
                    string[] split = fiets.Split(' '); // split de string op spaties
                    double number = double.Parse(split[2]); // pakt de bedrag uit de string
                    double optel = number * getal; // doet de bedrag keer de aantal dagen

                    plus = optel + plus; // doet het bedrag + het totaal bedrag 
                    
                    string price = plus.ToString("0.00"); // doet variable plus in een string
                    bedrag.Text = price; // zet de bedrag in de textblock

                    // schakeld de comboboxen weer in
                    verzekeringen.IsEnabled = true; 
                    services.IsEnabled = true;

                    fietsen.SelectedIndex = -1; // maakt de combobox leeg
                    aantal.Text = "1"; // zet de aantal dagen weer op 1


                    StackPanel sp = new StackPanel() // maakt een nieuwe stackpannel
                    {
                        Background = Brushes.Black, // background colow word black
                        Orientation = Orientation.Horizontal,
                    };
                    TextBlock txtproduct = new TextBlock() // maakt een textblock aan
                    {
                        Foreground = Brushes.White,
                        Text = fiets + " ", 
                        Name = "product"
                    };
                    sp.Children.Add(txtproduct);  // zet de textblock in de stackpannel
                    TextBlock txtproduct2 = new TextBlock() // maakt een textblock aan
                    {
                        Foreground = Brushes.White,
                        Text = antl + " " + days + " ",
                        Name = "product2"
                    };
                    sp.Children.Add(txtproduct2);// zet de textblock in de stackpannel
                    TextBlock txtproduct3 = new TextBlock()// maakt een textblock aan
                    {
                        Foreground = Brushes.White,
                        Text = "€ " + Convert.ToString(optel),
                        Name = "product3",
                    };
                    sp.Children.Add(txtproduct3);// zet de textblock in de stackpannel
                    lijst.Items.Add(sp);


                }
                //alles is het zelfde als de bovenstaande if 
                else if (selected2 != null)
                {
                    string verzekering = selected2.Content.ToString();
                    string[] split2 = verzekering.Split(' ');
                    double number2 = double.Parse(split2[2]);
                    double optel2 = number2 * getal;
                    double uitkomst2 = optel2 + plus;
                    string price = uitkomst2.ToString("0.00");
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
                //alles is het zelfde als de bovenstaande if 
                else if (selected3 != null)
                {
                    string service = selected3.Content.ToString();
                    string[] split3 = service.Split(' ');
                    double number3 = double.Parse(split3[2]);
                    double optel3 = number3 * getal;
                    double uitkomst3 = optel3 + plus;
                    string price = uitkomst3.ToString("0.00");
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
            if (selected1 != null) // als combobox fietsen is geselecteerd dan word de andere comboboxen disabled
            {
                verzekeringen.IsEnabled = false;
                services.IsEnabled = false;
            }
        }

        private void verzekeringen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            teller = 0;
            ComboBoxItem selected2 = verzekeringen.SelectedItem as ComboBoxItem;
            if (selected2 != null) // als combobox verzekeringen is geselecteerd dan word de andere comboboxen disabled
            {
                fietsen.IsEnabled = false;
                services.IsEnabled = false;
            }
        }

        private void services_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            teller = 0;
            ComboBoxItem selected3 = services.SelectedItem as ComboBoxItem; // als combobox services is geselecteerd dan word de andere comboboxen disabled
            if (selected3 != null)
            {
                fietsen.IsEnabled = false;
                verzekeringen.IsEnabled = false;
            }
        }

        private void delete(object sender, MouseButtonEventArgs e)
        {

            teller = 0;
            StackPanel sp = lijst.SelectedItem as StackPanel;
            double optel = 0;
            var Result = MessageBox.Show("Weet je zeker dat je het wilt verwijderen", "", MessageBoxButton.YesNo, MessageBoxImage.Question); // message box die vraagt op je zeker wilt vw
            if (Result == MessageBoxResult.Yes) 
            {
                    foreach (TextBlock item in sp.Children.OfType<TextBlock>()) // hier pakt die heel de stackpannel
                    {

                        if (item.Name == "product3")
                        {
                            double ttl = Convert.ToDouble(bedrag.Text);

                            string prijs = item.Text;
                            string[] argumenten = prijs.Split('€'); // split de text vanaf de euro teken
                            optel = Double.Parse(argumenten[1]);// pakt de bedrag in de string
                            double uitkomst = ttl - optel; // doet het bedrag van het totaal prijs af
                            string bdrg = uitkomst.ToString("0.00"); // zet de uitkomst in een string
                            bedrag.Text = bdrg; // doet de nieuwe totaal bedrag in de textblock
                            lijst.Items.Remove(lijst.SelectedItem); // verwijderd de item 


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
                if (result == MessageBoxResult.Yes) // als als op yes is gedrukt
                {
                    lijst.Items.Clear(); // listbox word leeg gehaald
                    bedrag.Text = "0,00"; // bedrag word op 0 euro gezet
                    // comboboxen worden leeggehaald
                    fietsen.SelectedIndex = -1;
                    verzekeringen.SelectedIndex = -1;
                    services.SelectedIndex = -1;
                }
                else
                {
   
                }
            }
            else
            {
                MessageBox.Show("er zijn nog geen bestellingen toegevoegd");
            }

        }

        private void rek(object sender, RoutedEventArgs e)
        {
            subwindow win = new subwindow(); // maakt deen nieuwe window aan 
            win.Show(); // opend de nieuwe window
        }

        private void check(object sender, TextCompositionEventArgs e)
        {
            // zorgt er voor dat je niet meer dan 1 letter kan invullen zodat de gebruiker kan zien dat het niet kan
            Regex regex = new Regex("[^0-9]+"); 
            e.Handled = regex.IsMatch(aantal.Text);
        }

        private void time_Click(object sender, RoutedEventArgs e)
        {
            time time = new time(); // maakt een nieuwe window
            time.Show(); // opend een nieuwe window 
        }
    }
}
