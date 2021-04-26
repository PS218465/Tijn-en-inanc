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
        bool i = false;
        DispatcherTimer timer = new DispatcherTimer();
        public time()
        {
            InitializeComponent();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1000); // geeft de timer in seconden aan
            timer.Tick += Timer_Tick; ; // linkt de time met de functie 

        }
        //lokale vars voor teller en min,sec en uren
        int teller = 0;
        int tijdS = 0;
        int tijdM = 0;
        int tijdU = 0;
        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                //haalt alle ingevulden dingen op
                tijdS = int.Parse(seconden.Text);
                tijdM = int.Parse(minuten.Text);
                tijdU = int.Parse(uren.Text);

                //begint met tellen
                teller = tijdS;
                teller++;

                seconden.Text = teller.ToString("00");
                if (tijdS > 58)//als seconden 60 hit word een minuut verhoogd 
                {
                    //seconden word gereset
                    teller = 0;
                    tijdS = 0;
                    seconden.Text = teller.ToString("00");


                    tijdM++;
                    minuten.Text = tijdM.ToString("00");
                }
                if (tijdM > 59)//als minuut 60 hit word uur 1 vehoogd
                {
                    //minuut wordt gereset
                    teller = 0;
                    tijdM = 0;
                    minuten.Text = teller.ToString("00");

                    tijdU++;
                    uren.Text = tijdU.ToString("00");
                }
                if (tijdU > 24)
                {
                    teller = 0;
                    tijdS = 0;
                    tijdU = 0;

                    seconden.Text = teller.ToString("00");

                    minuten.Text = tijdM.ToString("00");

                    uren.Text = tijdU.ToString("00");
                }
            }
            catch
            {
                MessageBox.Show("u mag geen letters invullen!");
                teller = 0;// zet de seconden weer op 0
                tijdS = 0; // zet de minuten weer op 0
                tijdU = 0;// zet de uren weer op 0

                seconden.Text = teller.ToString("00"); // zet de seconden in de textbox
                minuten.Text = teller.ToString("00"); // zet de minuten in de textbox
                uren.Text = tijdU.ToString("00"); // zet de uren in de textbox

                timer.Stop();// zet de timer op stop
                startstopbtn.Content = "start de timer"; // veranderd de button naam weer naar start

                seconden.IsEnabled = true; 
                minuten.IsEnabled = true;
                uren.IsEnabled = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (i == false)//verander de knop en bool zodat je niks meer kan invoeren
            {
                i = true;
                timer.Start(); // start de timer
                startstopbtn.Content = "(re)set timer"; 
                seconden.IsEnabled = false;
                minuten.IsEnabled = false;
                uren.IsEnabled = false;
            }
            else
            {
                //veranderd alles terug
                startstopbtn.Content = "start de timer";
                i = false;
                timer.Stop(); // zet de timer op stop
                
                tijdS = 0; 
                tijdM = 0;
                tijdU = 0;
                
                seconden.Text = tijdS.ToString("00");
                minuten.Text = tijdM.ToString("00");
                uren.Text = tijdU.ToString("00");
                
                seconden.IsEnabled = true;
                minuten.IsEnabled = true;
                uren.IsEnabled = true;
            }
            
        }
    }
}
