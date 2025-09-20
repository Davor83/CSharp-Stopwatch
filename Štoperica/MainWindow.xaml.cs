using System.Diagnostics;
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
using System.Windows.Threading;
using System.Threading;

namespace Štoperica
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Stopwatch stopwatch = new Stopwatch();
        DispatcherTimer clockTimer = new DispatcherTimer();
        DispatcherTimer stopwatchTimer = new DispatcherTimer();
        



        public MainWindow()
        {
            InitializeComponent();

            
            // Timer za sat
            clockTimer.Interval = TimeSpan.FromMilliseconds(100);
            clockTimer.Tick += ClockTimer_Click;
            clockTimer.Start();

            // Timer za štopericu
            stopwatchTimer.Interval = TimeSpan.FromMilliseconds(100);
            stopwatchTimer.Tick += Timer_Tick;

        }

        private void  Timer_Tick(object? sender,EventArgs e)
        {
            TimeDisplay.Text = stopwatch.Elapsed.ToString(@"hh\:mm\:ss");
        }


        private void ClockTimer_Click(object? sender, EventArgs e)
        {
            Sat.Text = DateTime.Now.ToString(@"HH\:mm\:ss");
        }

       private void Start_Click(object sender,RoutedEventArgs e)
        {
            stopwatch.Start();
            stopwatchTimer.Start();
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            stopwatch.Stop();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            stopwatch.Restart();
            stopwatch.Stop();
            TimeDisplay.Text = "00:00:00";
                   }
               
        }
    }
