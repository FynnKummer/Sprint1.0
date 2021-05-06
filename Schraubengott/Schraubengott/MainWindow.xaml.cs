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
        Schraube[] feld = new Schraube[5];      //Array vom Typ Schraube erstellen
        int nr = 0;                             //Variable für den Index des Feldes Schraube
        int new_screw_int = 1;                  //Varibale für Neue Schraube Button und Combobox mit Schraubenauswahl
        // hier noch ne Random Nummer erzeugen lassen für ne Bestell und Kudnennummer


        public MainWindow()
        {
            for (int i = 0; i < feld.Length; i++)
            {
                feld[i] = new Schraube();         // Array wird mit Objekten gefüllt
            }

            InitializeComponent();


        }

        private void btnexit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();                    //Exitbutton schließt die App
        }

        private void cbmat_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (cbmat.SelectedValue.ToString() == "V2A")
            {
                cbfk.Items.Clear();
                cbfk.Items.Add("V2A 50");
                cbfk.Items.Add("V2A 70");
                feld[nr].material = "V2A";
            }
            else if (cbmat.SelectedValue.ToString() == "V4A")
            {
                cbfk.Items.Clear();
                cbfk.Items.Add("V4A 70");
                feld[nr].material = "V4A";
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
                feld[nr].material = "Verzinkter Stahl";
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


        public void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

            feld[nr].gewindeart = "Feingewinde";
        }
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {

            feld[nr].gewindeart = "Standartgewinde";
        }

        private void btnauswahl_Click(object sender, RoutedEventArgs e)
        {
            if (nr == 0 && tab_1.Visibility == Visibility.Visible)
            {
                nr++;
            }
            if (nr == 1 && tab_2.Visibility == Visibility.Visible)
            {
                nr++;
            }
            if (nr == 2 && tab_3.Visibility == Visibility.Visible)
            {
                nr++;
            }
            if (nr == 3 && tab_4.Visibility == Visibility.Visible)
            {
                nr++;
            }
            
            switch (nr)
            {
                case 0:
                    tab_1.Visibility = Visibility.Visible;
                    nr++;
                    break;
                case 1:
                    tab_2.Visibility = Visibility.Visible;
                    nr++;
                    break;
                case 2:
                    tab_3.Visibility = Visibility.Visible;
                    nr++;
                    break;
                case 3:
                    tab_4.Visibility = Visibility.Visible;
                    nr++;
                    break;
                case 4:
                    tab_5.Visibility = Visibility.Visible;
                    break;
            }         
        }

        private void btndelete1_Click(object sender, RoutedEventArgs e)
        {
            tab_1.Visibility = Visibility.Collapsed;
            nr = 0;
        }
        private void btndelete2_Click(object sender, RoutedEventArgs e)
        {
            tab_2.Visibility = Visibility.Collapsed;
            nr = 0;
        }
        private void btndelete3_Click(object sender, RoutedEventArgs e)
        {
            tab_3.Visibility = Visibility.Collapsed;
            nr = 0;
        }
        private void btndelete4_Click(object sender, RoutedEventArgs e)
        {
            tab_4.Visibility = Visibility.Collapsed;
            nr = 0;
        }
        private void btndelete5_Click(object sender, RoutedEventArgs e)
        {
            tab_5.Visibility = Visibility.Collapsed;
            nr = 0;
        }


        private void cbfk_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //festigkeitsklasse
            feld[nr].festigkeit_festlegen(cbfk.SelectedItem.ToString());
        }

        private void cbkopf_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //kopf
            feld[nr].kopf_festlegen(cbkopf.SelectedItem.ToString());
        }

        private void cbgewinde_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //gewinde

            feld[nr].gewinde_festlegen(cbgewinde.SelectedItem.ToString());

            
        }
        
            //lbl1.Content = txt_len.Text;

        

        private void cmb_nr_SelectionChanged(object sender, SelectionChangedEventArgs e)//auswahl der Schraubennummer (Index vom Feld)
        {
            switch (cmb_nr.SelectedItem.ToString())
            {
                case "Schraube 1":
                    //nr ist schon 0
                    tab_konfig.Header = "1. Konfiguration"; // Hier muss noch was geändert werden, dass sich der Tabheader immer der aktuellen Schraube anpasst

                    break;

                case "Schraube 2":
                    nr = 1;
                  
                    break;

                case "Schraube 3":
                    nr = 2;
                    
                    break;

                case "Schraube 4":
                    nr = 3;
                  
                    break;

                case "Schraube 5":
                    nr = 4;
                    
                    break;

            }
                
        }

        private void new_screw_Click(object sender, RoutedEventArgs e)
        {
            cmb_nr.Visibility = Visibility.Visible;

            //if (schraubenlenge < gewindelenge)
            //{
            //    gewindelengetextbox.Background = Brushes.Red;           wenn die Gewindelänge nicht zur Schraubenlänge passt, wird die Gewindelängetextbox rot
            //                                     Orangered geht auch
            //
            //
            //
            //}
            


            
            
                new_screw.Content = (new_screw_int+1)+ ". Schraube erstellen";
                
            switch (new_screw_int)
                {
                    case 1:
                        
                        screw1.Visibility = Visibility.Visible;
                        cmb_nr.SelectedItem = screw1;
                        new_screw_int++;
                    tab_konfig.Header = "1. Konfiguration";

                    //Keine Sorge, das kommt noch an die Richtige Stelle
                    MessageBox.Show("Eingaben für Länge und Gewindelänge sind nicht kompatibel.\nKeine Sorge, kommt noch an die richtige Stelle", "Fehlerhafte Eingabe", MessageBoxButton.OK,MessageBoxImage.Error);
                   
                        break;

                    case 2:
                        screw2.Visibility = Visibility.Visible;
                        cmb_nr.SelectedItem = screw2;
                        new_screw_int++;
                    tab_konfig.Header = "2. Konfiguration";

                    break;

                    case 3:
                        screw3.Visibility = Visibility.Visible;
                        cmb_nr.SelectedItem = screw3;
                        new_screw_int++;
                    tab_konfig.Header = "3. Konfiguration";
                    break;

                    case 4:
                        screw4.Visibility = Visibility.Visible;
                        cmb_nr.SelectedItem = screw4;
                        new_screw_int++;
                    tab_konfig.Header = "4. Konfiguration";
                    break;

                    case 5:
                        screw5.Visibility = Visibility.Visible;
                        cmb_nr.SelectedItem = screw5;
                        new_screw_int++;
                    tab_konfig.Header = "5. Konfiguration";
                    new_screw.Visibility = Visibility.Collapsed;


                    break;
                
     

                }
            





        }
    }
}
