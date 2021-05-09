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
            cmb_nr.SelectedIndex = 0;           //Combobox hat von Anfang an die erste Schraube ausgewählt

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
               // feld[nr].material = "V2A";
            }
            else if (cbmat.SelectedValue.ToString() == "V4A")
            {
                cbfk.Items.Clear();
                cbfk.Items.Add("V4A 70");
              //  feld[nr].material = "V4A";
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
              //  feld[nr].material = "Verzinkter Stahl";

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

            feld[nr].gewindeart = "Standardgewinde";
        }

        private void btnauswahl_Click(object sender, RoutedEventArgs e)
        {
            #region "Wenn was nicht passt Fehlermeldungen"

            //hier noch alle Eingabeelement mit den aktuellen Werten in der Schraube festlegen. Wenn noch nicht festgelegt, dann Default

            if (txt_len.Text == "" || txt_gewlen.Text == "")
            {
                MessageBox.Show("Für Gewindelänge und oder Länge liegt keine Eingabe vor.", "Fehlerhafte Eingabe", MessageBoxButton.OK, MessageBoxImage.Error);
                return;// wenn min eine Eingabe leer ist, wird die Methode beendet
            }

            else if (Convert.ToInt32(txt_len.Text) < Convert.ToInt32(txt_gewlen.Text))
            {
                MessageBox.Show("Eingaben für Länge und Gewindelänge sind nicht kompatibel.", "Fehlerhafte Eingabe", MessageBoxButton.OK, MessageBoxImage.Error);
                return;//wenn Gewlen größer als Len wird Methode beendet
            }

            if (cbfk.SelectedItem == null)
            {
                MessageBox.Show("Für die Festigkeitsklasse liegt keine Auswahl vor.", "Fehldend Auswahl", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            #endregion


            if(txt_menge.Text.ToString()=="")
            {
                MessageBox.Show("Es wurde keine Eingabe für die Menge gemacht.", "Fehlerhafte Eingabe", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            feld[nr].menge = Convert.ToInt32(txt_menge.Text.ToString());
            feld[nr].typ = cbkopf.SelectedValue.ToString();
            feld[nr].gewinde = cbgewinde.SelectedValue.ToString();
            feld[nr].festigkeit = cbfk.SelectedItem.ToString();
            feld[nr].material = cbmat.SelectedValue.ToString();
            feld[nr].gewindelaenge = Convert.ToInt32(txt_gewlen.Text);
            feld[nr].laenge = Convert.ToInt32(txt_len.Text);


            lbl_test2.Content = feld[nr].material;// nur zum Test, muss später weg
            


            Materialtxt.Text = ("Material" + Environment.NewLine + Environment.NewLine + Environment.NewLine + feld[0].material + Environment.NewLine + Environment.NewLine + Environment.NewLine + feld[1].material + Environment.NewLine + Environment.NewLine + Environment.NewLine + feld[2].material + Environment.NewLine + Environment.NewLine + Environment.NewLine + feld[3].material + Environment.NewLine + Environment.NewLine + Environment.NewLine + feld[4].material);
            Festtxt.Text = ("Festigkeit" + Environment.NewLine + Environment.NewLine + Environment.NewLine + feld[0].festigkeit + Environment.NewLine + Environment.NewLine + Environment.NewLine + feld[1].festigkeit + Environment.NewLine + Environment.NewLine + Environment.NewLine + feld[2].festigkeit + Environment.NewLine + Environment.NewLine + Environment.NewLine + feld[3].festigkeit + Environment.NewLine + Environment.NewLine + Environment.NewLine + feld[4].festigkeit);
            Kopftxt.Text = ("Kopf" + Environment.NewLine + Environment.NewLine + Environment.NewLine + feld[0].typ + Environment.NewLine + Environment.NewLine + Environment.NewLine + feld[1].typ + Environment.NewLine + Environment.NewLine + Environment.NewLine + feld[2].typ + Environment.NewLine + Environment.NewLine + Environment.NewLine + feld[3].typ + Environment.NewLine + Environment.NewLine + Environment.NewLine + feld[4].typ);
            Gewindetxt.Text = ("Gewinde" + Environment.NewLine + Environment.NewLine + feld[0].gewinde + Environment.NewLine + Environment.NewLine + Environment.NewLine + feld[1].gewinde + Environment.NewLine + Environment.NewLine + Environment.NewLine + feld[2].gewinde + Environment.NewLine + Environment.NewLine + Environment.NewLine + feld[3].gewinde + Environment.NewLine + Environment.NewLine + Environment.NewLine + feld[4].gewinde);
            Typtxt.Text = ("Typ" + Environment.NewLine + Environment.NewLine + Environment.NewLine + feld[0].gewindeart + Environment.NewLine + Environment.NewLine + Environment.NewLine + feld[1].gewindeart + Environment.NewLine + Environment.NewLine + Environment.NewLine + feld[2].gewindeart + Environment.NewLine + Environment.NewLine + Environment.NewLine + feld[3].gewindeart + Environment.NewLine + Environment.NewLine + Environment.NewLine + feld[4].gewindeart);
            Laengetxt.Text = ("Länge" + Environment.NewLine + Environment.NewLine + Environment.NewLine + feld[0].laenge + Environment.NewLine + Environment.NewLine + Environment.NewLine + feld[1].laenge + Environment.NewLine + Environment.NewLine + Environment.NewLine + feld[2].laenge + Environment.NewLine + Environment.NewLine + Environment.NewLine + feld[3].laenge + Environment.NewLine + Environment.NewLine + Environment.NewLine + feld[4].laenge);
            gewlentxt.Text = ("Gewindelänge" + Environment.NewLine + Environment.NewLine + feld[0].gewindelaenge + Environment.NewLine + Environment.NewLine + Environment.NewLine + feld[1].gewindelaenge + Environment.NewLine + Environment.NewLine + Environment.NewLine + feld[2].gewindelaenge + Environment.NewLine + Environment.NewLine + Environment.NewLine + feld[3].gewindelaenge + Environment.NewLine + Environment.NewLine + Environment.NewLine + feld[4].gewindelaenge);
            mengetxt.Text = ("Menge" + Environment.NewLine + Environment.NewLine + Environment.NewLine + feld[0].menge + Environment.NewLine + Environment.NewLine + Environment.NewLine + feld[1].menge + Environment.NewLine + Environment.NewLine + Environment.NewLine + feld[2].menge + Environment.NewLine + Environment.NewLine + Environment.NewLine + feld[3].menge + Environment.NewLine + Environment.NewLine + Environment.NewLine + feld[4].menge);

            MessageBox.Show("Die aktuelle Konfiguration wurde in die Übersicht hinzugefügt.", "Konfiguration gespeichert", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void cbfk_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void cbkopf_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void cbgewinde_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           

            
        }

        #region "hallo"



        private void cmb_nr_SelectionChanged(object sender, SelectionChangedEventArgs e)//auswahl der Schraubennummer (Index vom Feld)
        {

            switch (cmb_nr.SelectedIndex)
            {
                
                case 0:
                    nr = 0;
                    
                    tab_konfig.Header = "1. Konfiguration"; // Hier muss noch was geändert werden, dass sich der Tabheader immer der aktuellen Schraube anpasst
                    lbl_test.Content = nr;
                    break;

                case 1:
                    nr = 1;
                    tab_konfig.Header = "2. Konfiguration";
                    lbl_test.Content = nr;
                    break;

                case 2:
                    nr = 2;
                    tab_konfig.Header = "3. Konfiguration";
                    lbl_test.Content = nr;
                    break;

                case 3:
                    nr = 3;
                    tab_konfig.Header = "4. Konfiguration";
                    lbl_test.Content = nr;
                    break;

                case 4:
                    nr = 4;
                    tab_konfig.Header = "5. Konfiguration";
                    lbl_test.Content = nr;
                    break;

            }
                
        }

        private void new_screw_Click(object sender, RoutedEventArgs e)
        {
            
            


            //if (schraubenlenge < gewindelenge)
            //{
            //    gewindelengetextbox.Background = Brushes.Red;           wenn die Gewindelänge nicht zur Schraubenlänge passt, wird die Gewindelängetextbox rot
            //                                     Orangered geht auch
            //
            //
            //
            //}





            //new_screw.Content = (new_screw_int+1)+ ". Schraube erstellen";

            switch (new_screw_int)
                {
                    case 1:
                        
                        screw2.Visibility = Visibility.Visible;
                        cmb_nr.SelectedItem = screw2;
                        new_screw_int++;
                    tab_konfig.Header = "2. Konfiguration";



                    break;

                    case 2:
                        screw3.Visibility = Visibility.Visible;
                        cmb_nr.SelectedItem = screw3;
                        new_screw_int++;
                    
                    tab_konfig.Header = "3. Konfiguration";

                    break;

                    case 3:
                        screw4.Visibility = Visibility.Visible;
                        cmb_nr.SelectedItem = screw4;
                        new_screw_int++;
                    
                    tab_konfig.Header = "4. Konfiguration";
                    new_screw.Content = "letzte Schrabue erstelln";
                    break;

                    case 4:
                        screw5.Visibility = Visibility.Visible;
                        cmb_nr.SelectedItem = screw5;
                    
                    new_screw_int++;
                
                    tab_konfig.Header = "5. Konfiguration";
                    new_screw.Visibility = Visibility.Collapsed;
                    break;

                    
                
     

                }
         
        }


        #endregion

        #region bla

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }

        private void Materialtxt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Festtxt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Kopftxt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Gewindetxt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Typtxt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Laengetxt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void mengetxt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void check1_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void check2_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void check3_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void check4_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void check5_Checked(object sender, RoutedEventArgs e)
        {

        }

        #endregion

        private void TextBox_TextChanged_3(object sender, TextChangedEventArgs e)
        {

        }
    }
}
