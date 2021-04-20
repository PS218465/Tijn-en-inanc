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

namespace Fietswinkel
{
    /// <summary>
    /// Interaction logic for subwindow.xaml
    /// </summary>
    public partial class subwindow : Window
    {
        int pie = 0;//als pi aan gebruikt word of niet
        int l = 0;//als de operator al gebruikt is
        bool first = false;//voor negatieve getallen

        public subwindow()
        {
            InitializeComponent();
            pijltjes.Content = "<<";//zet pijltjes omdat je die niet kan zetten in WPF
            //geef alle buttons hun events
            zero.Click += nummer_Click;
            een.Click += nummer_Click;
            twee.Click += nummer_Click;
            drie.Click += nummer_Click;
            vier.Click += nummer_Click;
            vijf.Click += nummer_Click;
            zes.Click += nummer_Click;
            zeven.Click += nummer_Click;
            acht.Click += nummer_Click;
            negen.Click += nummer_Click;

            komma.Click += nummer_Click;
            //pi.Click += pi_Click;

            plus.Click += factors_Click;
            min.Click += factors_Click;
            delen.Click += factors_Click;
            keer.Click += factors_Click;


        }
        //alle lokale variables
        string laatstesom = " ";
        string current = " ";
        string uitkomst = " ";
        int crash = 0;//is het gechrasht of niet
        bool klaar = false;//is de some klaar of niet?
        private void nummer_Click(object sender, RoutedEventArgs e)
        {
            if (l == 1)
            {
                if (pie == 1)//zet pi terug zodat je hem weer kunt gebruiken
                {
                    pie--;
                }
                if (crash == 1)//als het crash (dus geen normale som is) word de verkeerde som niet naar het bovenste textblock
                {
                    l--;
                    crash--;
                    current = " ";
                    current_som.Text = current;
                }
                else//zet de gemaakte som over naar het bovenste tekst vlak en zet = erachter + antwoord
                {
                    l--;
                    laatstesom = current + " = " + uitkomst;
                    laatste_som.Text = laatstesom;
                    current = " ";
                    current_som.Text = current;
                }

            }
            //plaatst de content van de button in de som
            Button button = sender as Button;
            current += button.Content.ToString();
            current_som.Text = current;
            //MessageBox.Show(button.Content.ToString());

        }
        private void is_(object sender, RoutedEventArgs e)
        {
            string[] splt = current.Split(' ');//split de som op een spatie
            try//voor als die crashed
            {

                l++;//zet l omhoog want hij is klaar

                if (pie == 1)//voor als pi is gebruikt
                {
                    double i;
                    i = double.Parse(splt[1]) * Math.PI;
                    uitkomst = i.ToString();
                }
                else
                {
                    if (splt[4] == "+" || splt[4] == "*" || splt[4] == "/" || splt[4] == "-")//voor als de gebruiker 2 operators heeft neergezet
                    {
                        if (splt[2] == "*")
                        {
                            double i = double.Parse(splt[1]) * double.Parse(splt[5]);
                            uitkomst = i.ToString();
                        }
                        else if (splt[2] == "/")
                        {
                            double i = double.Parse(splt[1]) / double.Parse(splt[5]);
                            uitkomst = i.ToString();
                        }
                        else if (splt[2] == "+")
                        {
                            double i = double.Parse(splt[1]) + double.Parse(splt[5]);
                            uitkomst = i.ToString();
                        }
                        else if (splt[2] == "-")
                        {
                            double i = double.Parse(splt[1]) - double.Parse(splt[5]);
                            uitkomst = i.ToString();

                        }
                    }
                    else if (splt[2] == "+")//als plus is
                    {
                        double i = double.Parse(splt[1]) + double.Parse(splt[3]);
                        uitkomst = i.ToString();
                    }
                    else if (splt[2] == "-")//als minus is
                    {
                        double i = double.Parse(splt[1]) - double.Parse(splt[3]);
                        uitkomst = i.ToString();

                    }
                    else if (splt[2] == "*")//als keer is
                    {
                        double i = double.Parse(splt[1]) * double.Parse(splt[3]);
                        uitkomst = i.ToString();
                    }
                    else if (splt[2] == "/")//als delen is
                    {
                        double i = double.Parse(splt[1]) / double.Parse(splt[3]);
                        uitkomst = i.ToString();
                    }
                }
                //update nummer en vars
                laatstesom = current + " = " + uitkomst;
                current_som.Text = laatstesom;
                klaar = true;
            }
            catch
            {
                //geeft message en reset alles als het crashed
                MessageBox.Show("Maak een normale som!");
                current = " ";
                current_som.Text = current;
                uitkomst = " ";
                crash++;
            }
        }

        private void negative_numbers(object sender, RoutedEventArgs e)
        {
            try//crash check
            {
                if (klaar == true)//als de som al klaar is kun je geen negatieve getallen meer invullen
                {
                    return;
                }
                string[] splt = current.Split(' ');//zelfe split op spatie
                if (first == false)//als de gebruiker het eerste getal negatief wil maken
                {
                    current = current.Replace(splt[1], "-" + splt[1]);
                    current_som.Text = current;
                    first = true;
                }
                else if (first == true)//als de gebruiker het tweede getal negatief wil maken
                {
                    string k = "-" + splt[3];
                    current = current.Replace(splt[3], k);
                    current_som.Text = current;
                    first = false;
                    //MessageBox.Show(p.ToString());
                }
            }
            catch
            {
                //voor als het crashed laat hij message zien en reset hij
                MessageBox.Show("er gaat iets mis");
                current = " ";
                current_som.Text = current;
            }
        }

        private void factors_Click(object sender, RoutedEventArgs e)
        {
            first = true;//eerste nummer is gezet
            if (l == 1)//voer alleen uit als de som helemaal klaar is 
            {
                l--;
                laatstesom = current + " = " + uitkomst;
                laatste_som.Text = laatstesom;
                current = " ";
                current_som.Text = current;
            }
            //zet de operator neer
            Button button = sender as Button;
            current += " " + button.Content.ToString() + " ";
            current_som.Text = current;
            //MessageBox.Show(button.Content.ToString());
        }


        private void pi_Click(object sender, RoutedEventArgs e)
        {
            if (pie == 1)//pie is al gebruikt
            {
                MessageBox.Show("je hebt pie al gebruikt");
            }
            else
            {
                //zet de pi neer
                Button button = sender as Button;
                current += " " + button.Content.ToString() + " ";
                current_som.Text = current;
                pie++;
            }
        }

        private void clear(object sender, RoutedEventArgs e)
        {
            //clear de som
            current = " ";
            current_som.Text = current;
        }

        private void removeLetter(object sender, RoutedEventArgs e)
        {
            if (pie == 1)//zet pi terug ander krijg je een bug
            {
                pie--;
            }
            if (l == 0)//als de som nog bezig is
            {
                try//crash test
                {
                    //remove de laatste char van de string
                    current = current.Remove(current.Length - 1);
                    current_som.Text = current;
                }
                catch
                {
                    MessageBox.Show("Je kunt niks meer verwijderen!");
                }
            }
        }
    }
}
