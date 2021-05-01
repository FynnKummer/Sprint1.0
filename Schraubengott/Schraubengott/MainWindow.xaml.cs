using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace Schraubengott
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

            private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void cbmat_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (cbmat.SelectedValue.ToString() == "V2A")
            {
                comboBox1.Items.Clear();
                comboBox1.Items.Add("V2A 50");
                comboBox1.Items.Add("V2A 70");
            }
            else if (cbmat.SelectedValue.ToString() == "V4A")
            {
                comboBox1.Items.Clear(); 
                comboBox1.Items.Add("V4A 70");
            }
            else if (cbmat.SelectedValue.ToString() == "Verzinkter Stahl")
            {
                comboBox1.Items.Clear(); 
                comboBox1.Items.Add("5.8");
                comboBox1.Items.Add("6.8");
                comboBox1.Items.Add("8.8");
                comboBox1.Items.Add("9.8");
                comboBox1.Items.Add("10.9");
                comboBox1.Items.Add("12.9");
            }
        }
    }

    class material : ObservableCollection<string>
    {
        public material()
        {

            Add("Verzinkter Stahl");
            Add("V2A");
            Add("V4A");
        }
    }
}
