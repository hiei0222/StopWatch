using System;
using System.Collections.Generic;
using System.Linq;
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
namespace StopWatch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitialTimer();
        }
        private DispatcherTimer _Timer;
        private int _TimeDelay = 0;
        private int count = 0;
        void InitialTimer()
        {
            _Timer = new DispatcherTimer();
            _TimeDelay = 1000;
            _Timer.Interval = TimeSpan.FromMilliseconds(_TimeDelay);
            _Timer.Tick += _Timer_Tick;
        }
        private void _Timer_Tick(object sender, object e)
        {
            //処理
            ShowTimeString(++count);
        }
        private string FormatTimeString(int value)
        {
            return value < 10 ? "0" + value.ToString() : value.ToString();
        }
        private void ShowTimeString(int count)
        {
            int hour = count / 3600;
            int minute = (count % 3600) / 60;
            int second = (count % 3600) % 60;
            txt_timeShow.Text = FormatTimeString(hour) + ":" + FormatTimeString(minute) + ":" + FormatTimeString(second);
        }
        private void btn_StartStop_Click_1(object sender, RoutedEventArgs e)
        {
            if (_Timer.IsEnabled)
            {
                btn_StartStop.Content = "Start";
                _Timer.Stop();
            }
            else 
            {
                btn_StartStop.Content = "Stop";
                _Timer.Start();
            }
        }

        private void btn_clear_Click(object sender, RoutedEventArgs e)
        {
            ShowTimeString(0);
        }
    }
}