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
        int pie = 0;
        int l = 0;
        int p = 0;
        bool first = false;

        public subwindow()
        {
            InitializeComponent();
            pijltjes.Content = "<<";
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
        string laatstesom = " ";
        string current = " ";
        string uitkomst = " ";
        int crash = 0;
        bool klaar = false;
        private void nummer_Click(object sender, RoutedEventArgs e)
        {
            /*if (pie == 1)
            {
                return;
            }*/
            if (l == 1)
            {
                if (pie == 1)
                {
                    pie--;
                }
                if (crash == 1)
                {
                    l--;
                    crash--;
                    current = " ";
                    current_som.Text = current;
                }
                else
                {
                    l--;
                    laatstesom = current + " = " + uitkomst;
                    laatste_som.Text = laatstesom;
                    current = " ";
                    current_som.Text = current;
                }
                
            }
            
                Button button = sender as Button;
                current += button.Content.ToString();
                current_som.Text = current;
                //MessageBox.Show(button.Content.ToString());
            
        }
        private void is_(object sender, RoutedEventArgs e)
        {
            string[] splt = current.Split(' ');
            try
            {

                l++;

                if (pie == 1)
                {
                    double i;
                    i = double.Parse(splt[1]) * Math.PI;
                    uitkomst = i.ToString();
                }
                else
                {
                    if (splt[2] == "+")
                    {
                        double i = double.Parse(splt[1]) + double.Parse(splt[3]);
                        uitkomst = i.ToString();
                    }
                    else if (splt[2] == "-")
                    {
                        double i = double.Parse(splt[1]) - double.Parse(splt[3]);
                        uitkomst = i.ToString();
                        
                    }
                    else if (splt[2] == "*")
                    {
                        double i = double.Parse(splt[1]) * double.Parse(splt[3]);
                        uitkomst = i.ToString();
                    }
                    else if (splt[2] == "/")
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
                MessageBox.Show("Maak een normale som!");
                current = " ";
                current_som.Text = current;
                uitkomst = " ";
                crash++;
            }
        }

        private void negative_numbers(object sender, RoutedEventArgs e)
        {
            try
            {
                if (klaar == true)
                {
                    return;
                }
                string[] splt = current.Split(' ');
                if (first == false)
                {
                    current = current.Replace(splt[1], "-" + splt[1]);
                    current_som.Text = current;
                    first = true;
                }
                else if (first == true)
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
                MessageBox.Show("er gaat iets mis");
                current = " ";
                current_som.Text = current;
            }
        }

        private void factors_Click(object sender, RoutedEventArgs e)
        {
            first = true;
            if (l == 1)
            {
                l--;
                laatstesom = current + " = " + uitkomst;
                laatste_som.Text = laatstesom;
                current = " ";
                current_som.Text = current;
            }
            Button button = sender as Button;
            current += " " + button.Content.ToString() + " ";
            current_som.Text = current;
            //MessageBox.Show(button.Content.ToString());
        }


        private void pi_Click(object sender, RoutedEventArgs e)
        {
            if (pie == 1)
            {
                MessageBox.Show("je hebt pie al gebruikt");
            }
            else
            {
                Button button = sender as Button;
                current += " " + button.Content.ToString() + " ";
                current_som.Text = current;
                pie++;
            }
        }

        private void clear(object sender, RoutedEventArgs e)
        {
            current = " ";
            current_som.Text = current;
        }

        private void removeLetter(object sender, RoutedEventArgs e)
        {
            if (pie == 1)
            {
                pie--;
            }
            if (l == 0)
            {
                try
                {
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
