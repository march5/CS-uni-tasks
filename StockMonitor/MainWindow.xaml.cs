using System;
using System.Windows;
using System.Threading;
using System.Windows.Media;

namespace StockMonitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Random rand = new Random();

        public void simulateStock()
        {
            double[] changes = { 0f, 0f, 0f, 0f };
            int[] isNegative = { 0, 0, 0, 0};
            double[] values = { 100.05, 43.07, 98.07, 100.05};

            Color[] colors = new Color[4];

            while (true) {

                Thread.Sleep(TimeSpan.FromSeconds(5));//wait 5 sec

                for (int i = 0; i < 4; i++)
                {
                    changes[i] = Math.Round(rand.NextDouble(), 2);//here we take the random value from 0.0 to 1.0
                    isNegative[i] = rand.Next(100);//here we take random number wich will indicate wherher the change is positive or negative

                    if (isNegative[i] < 50)
                    {
                        colors[i] = Colors.Red;//if its negative the color will change to red
                        changes[i] = -changes[i];//we make it negative
                    }
                    else
                        colors[i] = Colors.ForestGreen;//if its positive the color will change to green
                }

                this.Dispatcher.BeginInvoke(new Action(() =>//here we change the panel's background colors
                {
                    KGHM_Panel.Background = new SolidColorBrush(colors[0]);
                    PKO_BP_Panel.Background = new SolidColorBrush(colors[1]);
                    LOTOS_Panel.Background = new SolidColorBrush(colors[2]);
                    ORLEN_Panel.Background = new SolidColorBrush(colors[3]);
                }));

                for (int i = 0; i < 4; i++)
                {
                    values[i] += changes[i];//we calculate new value
                    values[i] = Math.Round(values[i], 2);//and round it to two spaces
                }

                this.Dispatcher.BeginInvoke(new Action(() =>//here we change the value text and change text in panels
                {
                    kghmText3.Text = changes[0].ToString() + " PLN";
                    kghmText2.Text = values[0].ToString() + " PLN";
                    pkobpText3.Text = changes[1].ToString() + " PLN";
                    pkobpText2.Text = values[1].ToString() + " PLN";
                    lotosText3.Text = changes[2].ToString() + " PLN";
                    lotosText2.Text = values[2].ToString() + " PLN";
                    orlenText3.Text = changes[3].ToString() + " PLN";
                    orlenText2.Text = values[3].ToString() + " PLN";
                }));
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            Thread t1 = new Thread(simulateStock);
            t1.Start();

        }
    }

    

}
