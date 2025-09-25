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

namespace Stopwatch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
        DispatcherTimer clockTimer = new DispatcherTimer();
        DispatcherTimer stopwatchTimer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();

            // Initialize and start the clock timer to update current time display
            clockTimer.Interval = TimeSpan.FromMilliseconds(100);
            clockTimer.Tick += ClockTimer_Click;
            clockTimer.Start();

            // Initialize stopwatch timer to refresh elapsed time display
            stopwatchTimer.Interval = TimeSpan.FromMilliseconds(100);
            stopwatchTimer.Tick += Timer_Tick;

        }

        // Event handler for updating stopwatch display every 100ms
        private void  Timer_Tick(object? sender,EventArgs e)
        {
            TimeDisplay.Text = stopwatch.Elapsed.ToString(@"hh\:mm\:ss");
        }

        // Event handler for updating the clock display with current system time
        private void ClockTimer_Click(object sender, EventArgs e)
        {
            Sat.Text = DateTime.Now.ToString(@"HH\:mm\:ss");
        }

        // Start button click: begins stopwatch and starts UI refresh timer
        private void Start_Click(object sender,RoutedEventArgs e)
        {
            stopwatch.Start();
            stopwatchTimer.Start();
        }

        // Stop button click: pauses stopwatch but keeps elapsed time visible
        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            stopwatch.Stop();
        }

        // Reset button click: clears stopwatch and resets display to zero
        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            stopwatch.Restart();
            stopwatch.Stop();
            TimeDisplay.Text = "00:00:00";
                   }
               
        }
    }
