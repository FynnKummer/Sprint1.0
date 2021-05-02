using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        Schraube s = new Schraube();
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
    

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox a_textBox = (TextBox)sender;
            string a_newText = string.Empty;

            for (int i = 0; i < a_textBox.Text.Length; i++)
            {
                if (Regex.IsMatch(a_textBox.Text[i].ToString(), "^[0-9]+$"))
                {
                    a_newText += a_textBox.Text[i];
                }
               
            }

            a_textBox.Text = a_newText;
            a_textBox.SelectionStart = a_textBox.Text.Length;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            label1.Content = "(Feingewinde)";
            s.gewindeart = "2";
        }
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            label1.Content = "(Standardgewinde)";
            s.gewindeart = "1";
        }

    }
    class Schraube
    {
        public String name; // Vom Benutzer festgeleter Name für die Schraube
        public int menge;
        public int laenge;
        public double volumen;
        public int schluesselbreite;
        public String typ;      //Innensechskant/Ausßensechskant
        public String festigkeit;
        public String festaus;//Festigkeitsklasse ausgeschrieben

        public String gewindeart;
        public int gewindelaenge;
        public double gewindesteigung;
        public String gewinde;

        public String material;
        public String mataus;//Material ausgeschrieben
        public double dichte;
        public double masse;
        public double gesamtgewicht;
    }

    }
