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

            feld[nr].gewindeart = "Standardgewinde";
        }

        private void btnauswahl_Click(object sender, RoutedEventArgs e)
        {
            #region "Was ist das?"
                /*           
                            TextBox Konfigurator = new TextBox()
                            {
                                Text = "Material:\nFestigkeit:\n",
                                IsReadOnly = true,
                                Background = null,
                                BorderThickness = new Thickness(0),

                                HorizontalAlignment = HorizontalAlignment.Left,
                                VerticalAlignment = VerticalAlignment.Top,
                                Height = 350,
                                Width = 270,
                                Margin = new Thickness(43, 6, 0, 0),
                            };
                            if (nr == 0)
                            {
                                grid0.Children.Add(Konfigurator);
                            }
                            else if (nr == 1)
                            {
                                grid1.Children.Add(Konfigurator);
                            }

                            if (nr == 0 && tab_1.Visibility == Visibility.Visible)
                            {
                                nr++;
                            }
                            if (nr == 1 && tab_2.Visibility == Visibility.Visible)
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

                            }


                            matlabel.Content = feld[nr].material;
                            festlabel.Content = feld[nr].festigkeit;
                            kopflabel.Content = feld[nr].typ;
                            gewindelabel.Content = feld[nr].gewinde;
                            gewtyplabel.Content = feld[nr].gewindeart;
                            laengelabel.Content = feld[nr].laenge;
                            gewlenlabel.Content = feld[nr]. gewindelaenge;
                            mengelabel.Content = feld[nr].menge;
                            Bemerkung.Content = text.Text;
                            preis.Content = feld[nr].preis_summe;
                            einzelpreis.Content = feld[nr].stückpreis;
                            sweitelabel.Content = feld[nr].schluesselbreite;
                            masselabel.Content = feld[nr].masse;
                            gesamtlabel.Content = feld[nr].gesamtgewicht;  
                            Re.Content = feld[nr].elastizitätsgrenze;
                            Rm.Content = feld[nr].Zugfestigkeit;
                */
                #endregion

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
            feld[nr].gewindelaenge = Convert.ToInt32(txt_gewlen.Text);
            feld[nr].laenge = Convert.ToInt32(txt_len.Text);

            //hier dann alle Werte in die Schraube speichern

            
            feld[nr].festigkeit = cbfk.SelectedItem.ToString();
            if(txt_menge.Text.ToString()=="")
            {
                MessageBox.Show("Es wurde keine Eingabe für die Menge gemacht.", "Fehlerhafte Eingabe", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            feld[nr].menge = Convert.ToInt32(txt_menge.Text.ToString());
            feld[nr].kopf_festlegen(cbkopf.SelectedItem.ToString());
            feld[nr].gewinde_festlegen(cbgewinde.SelectedItem.ToString());

            lbl_test2.Content = feld[nr].gewinde;

            Schraube1konfig.Content = (feld[0].festigkeit + "" + feld[0].typ + "" + feld[0].gewinde + "" + feld[0].gewindeart + "" + feld[0].laenge + "" + feld[0].gewindelaenge + "" + feld[0].menge);
            Schraube2konfig.Content = (feld[1].festigkeit + "" + feld[1].typ + "" + feld[1].gewinde + "" + feld[1].gewindeart + "" + feld[1].laenge + "" + feld[1].gewindelaenge + "" + feld[1].menge);
            Schraube3konfig.Content = (feld[2].festigkeit + "" + feld[2].typ + "" + feld[2].gewinde + "" + feld[2].gewindeart + "" + feld[2].laenge + "" + feld[2].gewindelaenge + "" + feld[2].menge);
            Schraube4konfig.Content = (feld[3].festigkeit + "" + feld[3].typ + "" + feld[3].gewinde + "" + feld[3].gewindeart + "" + feld[3].laenge + "" + feld[3].gewindelaenge + "" + feld[3].menge);
            Schraube5konfig.Content = (feld[4].typ + "" + feld[4].gewinde );
        }

        private void cbfk_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //festigkeitsklasse
            feld[nr].festigkeit_festlegen(cbfk.SelectedItem.ToString());
        }

        private void cbkopf_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //kopf
           // feld[nr].kopf_festlegen(cbkopf.SelectedItem.ToString());
        }

        private void cbgewinde_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //gewinde

            //feld[nr].gewinde_festlegen(cbgewinde.SelectedItem.ToString());

            
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
                        
                        screw1.Visibility = Visibility.Visible;
                        cmb_nr.SelectedItem = screw1;
                        new_screw_int++;
                    new_screw.Content = "weitere Schrabue erstellen";

                    tab_konfig.Header = "1. Konfiguration";

                    //Keine Sorge, das kommt noch an die Richtige Stelle
                    
                        break;

                    case 2:
                        screw2.Visibility = Visibility.Visible;
                        cmb_nr.SelectedItem = screw2;
                        new_screw_int++;
                    new_screw.Content = "weitere Schrabue erstellen";
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
                    new_screw.Content = "letzte Schrabue erstelln";
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


        #endregion

        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void text_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
