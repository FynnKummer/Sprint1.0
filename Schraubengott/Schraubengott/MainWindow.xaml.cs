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
        

        public MainWindow()
        {
            Schraube[] schrauben = new Schraube[1];
            schrauben[0] = new Schraube();
            Schraube s = new Schraube();
            InitializeComponent();
            

        }

        private void btnexit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void cbmat_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (cbmat.SelectedValue.ToString() == "V2A")
            {
                cbfk.Items.Clear();
                cbfk.Items.Add("V2A 50");
                cbfk.Items.Add("V2A 70");
            }
            else if (cbmat.SelectedValue.ToString() == "V4A")
            {
                cbfk.Items.Clear();
                cbfk.Items.Add("V4A 70");
            }
            else if (cbmat.SelectedValue.ToString() == "Verzinkter Stahl")
            {
                cbfk.Items.Clear();
                cbfk.Items.Add("5.8");
                cbfk.Items.Add("6.8");
                cbfk.Items.Add("8.8");
                cbfk.Items.Add("9.8");
                cbfk.Items.Add("10.9");
                cbfk.Items.Add("12.9");
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
           
            //s.gewindeart = "Feingewinde";
        }
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
           
            //s.gewindeart = "Standartgewinde";
        }

        private void btnauswahl_Click(object sender, RoutedEventArgs e)
        {
            if (tab_4.Visibility == Visibility.Visible)
            {
                tab_5.Visibility = Visibility.Visible;
            }
            if (tab_3.Visibility == Visibility.Visible)
            {
                tab_4.Visibility = Visibility.Visible;
            }
            if (tab_2.Visibility == Visibility.Visible)
            {
                tab_3.Visibility = Visibility.Visible;
            }
            if (tab_1.Visibility == Visibility.Visible)
            {
                tab_2.Visibility = Visibility.Visible;
            }
            if (tab_1.Visibility == Visibility.Collapsed)
            {
                tab_1.Visibility = Visibility.Visible;
            }
        }

        private void btndelete1_Click(object sender, RoutedEventArgs e)
        {
            tab_1.Visibility = Visibility.Collapsed;
        }
        private void btndelete2_Click(object sender, RoutedEventArgs e)
        {
            tab_2.Visibility = Visibility.Collapsed;
        }
        private void btndelete3_Click(object sender, RoutedEventArgs e)
        {
            tab_3.Visibility = Visibility.Collapsed;
        }
        private void btndelete4_Click(object sender, RoutedEventArgs e)
        {
            tab_4.Visibility = Visibility.Collapsed;
        }
        private void btndelete5_Click(object sender, RoutedEventArgs e)
        {
            tab_5.Visibility = Visibility.Collapsed;
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
