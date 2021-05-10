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
            Schraube a = new Schraube();
            
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


            if (gewartcheck.IsChecked== true)
            {
                feld[nr].gewindeart = "Feingewinde";
            }
            else if (gewartcheck.IsChecked == false)
            {
                feld[nr].gewindeart = "Standardgewinde";
            }

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


            //lbl_test2.Content = feld[nr].material;// nur zum Test, muss später weg
            


            Materialtxt.Text = ("Material" + "\n\n\n"  + feld[0].material + "\n\n\n" + feld[1].material + "\n\n\n" + feld[2].material + "\n\n\n" + feld[3].material + "\n\n\n" + feld[4].material);
            Festtxt.Text = ("Festigkeit" + "\n\n\n" + feld[0].festigkeit + "\n\n\n" + feld[1].festigkeit + "\n\n\n" + feld[2].festigkeit + "\n\n\n" + feld[3].festigkeit + "\n\n\n" + feld[4].festigkeit);
            Kopftxt.Text = ("Kopf" + "\n\n\n" + feld[0].typ + "\n\n\n" + feld[1].typ + "\n\n\n" + feld[2].typ + "\n\n\n" + feld[3].typ + "\n\n\n" + feld[4].typ);
            Gewindetxt.Text = ("Gewinde" + "\n\n" + feld[0].gewinde + "\n\n\n" + feld[1].gewinde + "\n\n\n" + feld[2].gewinde + "\n\n\n" + feld[3].gewinde + "\n\n\n" + feld[4].gewinde);
            Typtxt.Text = ("Typ" + "\n\n\n" + feld[0].gewindeart + "\n\n\n" + feld[1].gewindeart + "\n\n\n" + feld[2].gewindeart + "\n\n\n" + feld[3].gewindeart + "\n\n\n" + feld[4].gewindeart);
            Laengetxt.Text = ("Länge" + "\n\n\n" + feld[0].laenge + "\n\n\n" + feld[1].laenge + "\n\n\n" + feld[2].laenge + "\n\n\n" + feld[3].laenge + "\n\n\n" + feld[4].laenge);
            gewlentxt.Text = ("Gewindelänge" + "\n\n" + feld[0].gewindelaenge + "\n\n\n" + feld[1].gewindelaenge + "\n\n\n" + feld[2].gewindelaenge + "\n\n\n" + feld[3].gewindelaenge + "\n\n\n" + feld[4].gewindelaenge);
            mengetxt.Text = ("Menge" + "\n\n\n" + feld[0].menge + "\n\n\n" + feld[1].menge + "\n\n\n" + feld[2].menge + "\n\n\n" + feld[3].menge + "\n\n\n" + feld[4].menge);


            //Berechnungen für die ausgewählte Schraube
            
            feld[nr].berechnen();


            MessageBox.Show("Die aktuelle Konfiguration wurde in die Übersicht hinzugefügt.", "Konfiguration gespeichert", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void cbfk_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void cbkopf_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbkopf.SelectedValue.ToString() == "Außensechskant")
            {
                Image1.Visibility = Visibility.Visible;
                Image2.Visibility = Visibility.Hidden;

            }
            else
            {
                Image1.Visibility = Visibility.Hidden;
                Image2.Visibility = Visibility.Visible;
            }


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
                    //lbl_test.Content = nr;
                    break;

                case 1:
                    nr = 1;
                    tab_konfig.Header = "2. Konfiguration";
                    //lbl_test.Content = nr;
                    break;

                case 2:
                    nr = 2;
                    tab_konfig.Header = "3. Konfiguration";
                    //lbl_test.Content = nr;
                    break;

                case 3:
                    nr = 3;
                    tab_konfig.Header = "4. Konfiguration";
                   // lbl_test.Content = nr;
                    break;

                case 4:
                    nr = 4;
                    tab_konfig.Header = "5. Konfiguration";
                    //lbl_test.Content = nr;
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
                    new_screw.Content = "letzte Schraube erstellen";
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (check1.IsChecked == true)
            {
                menge1txt.Text = feld[0].menge.ToString();
                gew1txt.Text = feld[0].masse.ToString();
                preis1txt.Text = feld[0].preis_summe.ToString();

               /* TextBox txt = new TextBox();
                txt.TextWrapping = TextWrapping.Wrap;
                txt.Text = "fdsafdsa";
                txt.Margin = new Thickness(10, 64, 0, 0);
                grid2.Children.Add(txt);
               */
            }
            else if(check1.IsChecked == false)
            {
                menge1txt.Text = "0";
                gew1txt.Text = "0";
                preis1txt.Text = "0";
            }

            if (check2.IsChecked == true)
            {
                 menge2txt.Text = feld[1].menge.ToString();
                 gew2txt.Text = feld[1].masse.ToString();
                 preis2txt.Text = feld[1].preis_summe.ToString();
            }
            else if (check2.IsChecked == false)
            {
                menge2txt.Text = "0";
                gew2txt.Text = "0";
                preis2txt.Text = "0";
            }

            if (check3.IsChecked == true)
            {
                menge3txt.Text = feld[2].menge.ToString();
                gew3txt.Text = feld[2].masse.ToString();
                preis3txt.Text = feld[2].preis_summe.ToString();
            }
            else if (check3.IsChecked == false)
            {
                 menge3txt.Text = "0";
                 gew3txt.Text = "0";
                 preis3txt.Text = "0";
            }

            if (check4.IsChecked == true)
            {
                menge4txt.Text = feld[3].menge.ToString();
                gew4txt.Text = feld[3].masse.ToString();
                preis4txt.Text = feld[3].preis_summe.ToString();
            }
            else if (check4.IsChecked == false)
            {
                menge4txt.Text = "0";
                gew4txt.Text = "0";
                preis4txt.Text = "0";
            }

            if (check5.IsChecked == true)
            {
                menge5txt.Text = feld[4].menge.ToString();
                gew5txt.Text = feld[4].masse.ToString();
                preis5txt.Text = feld[4].preis_summe.ToString();
            }
            else if (check5.IsChecked == false)
            {
                menge5txt.Text = "0";
                gew5txt.Text = "0";
                preis5txt.Text = "0";
            }

            double x1 = Convert.ToDouble(menge1txt.Text);
            double x2 = Convert.ToDouble(menge2txt.Text);
            double x3 = Convert.ToDouble(menge3txt.Text);
            double x4 = Convert.ToDouble(menge4txt.Text);
            double x5 = Convert.ToDouble(menge5txt.Text);

            if (double.TryParse(menge1txt.Text, out x1) && double.TryParse(menge2txt.Text, out x2) && double.TryParse(menge3txt.Text, out x3) && double.TryParse(menge4txt.Text, out x4) && double.TryParse(menge5txt.Text, out x5))
                summemengetxt.Text = (x1 + x2 + x3 + x4 + x5).ToString();

            double y1 = Convert.ToDouble(gew1txt.Text);
            double y2 = Convert.ToDouble(gew2txt.Text);
            double y3 = Convert.ToDouble(gew3txt.Text);
            double y4 = Convert.ToDouble(gew4txt.Text);
            double y5 = Convert.ToDouble(gew5txt.Text);

            if (double.TryParse(gew1txt.Text, out y1) && double.TryParse(gew2txt.Text, out y2) && double.TryParse(gew3txt.Text, out y3) && double.TryParse(gew4txt.Text, out y4) && double.TryParse(gew5txt.Text, out y5))
                summegewtxt.Text = (y1 + y2 + y3 + y4 + y5).ToString();

            double z1 = Convert.ToDouble(preis1txt.Text);
            double z2 = Convert.ToDouble(preis2txt.Text);
            double z3 = Convert.ToDouble(preis3txt.Text);
            double z4 = Convert.ToDouble(preis4txt.Text);
            double z5 = Convert.ToDouble(preis5txt.Text);

            if (double.TryParse(preis1txt.Text, out z1) && double.TryParse(preis2txt.Text, out z2) && double.TryParse(preis3txt.Text, out z3) && double.TryParse(preis4txt.Text, out z4) && double.TryParse(preis5txt.Text, out z5))
                summepreistxt.Text = (z1 + z2 + z3 + z4 + z5).ToString();
      
        }

        private void btnexcel_Click(object sender, RoutedEventArgs e)
        {
            ExcelControll. Excel_erstellen(Schraube[] arr)
            {
                new ExcelControll(arr);
            }
        }
    }
    }

