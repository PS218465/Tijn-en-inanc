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
using System.Windows.Threading;

namespace Fietswinkel
{
    /// <summary>
    /// Interaction logic for time.xaml
    /// </summary>
    public partial class time : Window
    {

        DispatcherTimer timer = new DispatcherTimer();
        public time()
        {
            InitializeComponent();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1000); // geeft de timer in seconden aan
            timer.Tick += Timer_Tick; // linkt de time met de functie 

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

                if (startstopbtn.Content.ToString() == "start de tijd")
                {
                    timer.Start();
                    startstopbtn.Content = "(re)Set tijd";

                seconden.IsReadOnly = true;
                minuten.IsReadOnly = true;
                uren.IsReadOnly = true;
                }
                else if (startstopbtn.Content.ToString() == "(re)Set tijd")
                {
                    timer.Stop();
                    startstopbtn.Content = "start de tijd";

                seconden.IsReadOnly = false;
                minuten.IsReadOnly = false;
                uren.IsReadOnly = false;

                seconden.Text = "00";
                minuten.Text = "00";
                uren.Text = "00";
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {

            try
            {
                double sec = Convert.ToDouble(seconden.Text); // haalt de waarde op en zet hem in een double 
                double min = Convert.ToDouble(minuten.Text);// haalt de waarde op en zet hem in een double 
                double uur = Convert.ToDouble(uren.Text);// haalt de waarde op en zet hem in een double 



                string second = Convert.ToString(sec);// zet de seconden in een string
                string minutes = Convert.ToString(min);
                string hour = Convert.ToString(uur);
                seconden.Text = second; // doet de seconde in de textbox 


                sec += 1; // doet elke seconden plus 1

                if (sec > 59)
                {
                    sec = 0;

                    seconden.Text = second; // doet de seconde in de textbox 
                    min += 1;

                    minuten.Text = minutes;
                }
                else if (min > 59)
                {
                    minutes = "00";

                    uur ++;
                    uren.Text = hour;
                }
                else if (uur == 24)
                {
                    second = "00";
                    minutes = "00";
                    hour = "00";
                }
            }
            catch
            {
                MessageBox.Show("u mag geen letters gebruiken bij het invullen");
                seconden.Text = "00";
                minuten.Text ="00";
                uren.Text ="00";

                timer.Stop();
                startstopbtn.Content = "start de tijd";
            }
         }
     
    }
}
