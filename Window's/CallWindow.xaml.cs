using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Моя_телефонная_книга.Window_s
{
    /// <summary>
    /// Логика взаимодействия для CallWindow.xaml
    /// </summary>
    public partial class CallWindow : Window
    {
        string idContact, typeDoCall;
        public CallWindow()
        {
            InitializeComponent();
        }

        public CallWindow(string Id, string Path, string TypeDoCall, string fio, string number)
        {
            InitializeComponent();
            idContact = Id;
            typeDoCall = TypeDoCall;
            fioTextBlock.Text = fio;
            numberTextBlock.Text = number;
            avatarCallImage.Source = new BitmapImage(new Uri(Path));
            timeNow = DateTime.Now;
            StartTimer();
        }

        //------------------ TIMER ------------------//

        //
        private void cancelCall_MouseDown(object sender, MouseButtonEventArgs e)
        {
            StartTimer();
            interm.db.Ask("insert into Log values(" + idContact + ",'" + timeNow.Hour + ":" + timeNow.Minute + ":" + timeNow.Second + "'" +
                ",sysdatetime(), sysdatetime(), '" + typeDoCall + "');");
            this.Close();
        }

        //
        public void StartTimer()
        {
            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }
        int p = 0, m = 0, h = 0;
        public DateTime timeNow;

        string min = "00", hour = "00";
        private void timer_Tick(object sender, EventArgs e)
        {
            if (p < 60)
            {
                if (p < 10)
                {
                    timerT.Text = "" + hour + ":" + min + ":" + "0" + Convert.ToString(p);
                }
                else
                {
                    timerT.Text = "" + hour + ":" + min + ":" + Convert.ToString(p);
                }
                p++;
            }
            else
            {
                if (m < 10)
                {
                    p = 0;
                    m++;
                    min = "0" + Convert.ToString(m);
                    if (m == 0)
                    {
                        min = "00";
                    }
                }
                else
                {
                    p = 0;
                    m++;
                    min = Convert.ToString(m);
                }
            }
            if (m > 59)
            {
                if (h < 10)
                {
                    m = 0;
                    h++;
                    hour = "0" + Convert.ToString(h);
                }
                else
                {
                    m = 0;
                    h++;
                    hour = Convert.ToString(h);
                }
                min = "00";
            }
        }
    }
}
