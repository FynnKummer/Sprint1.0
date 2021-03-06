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
using System.Net.Mail;
using Excel = Microsoft.Office.Interop.Excel;

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

        //Zufällige Bestellnummer erstellen
        Random nummer = new Random();           
        int bestellnummer;

        string kundennummer;

        public MainWindow()
        {
            for (int i = 0; i < feld.Length; i++) 
            {
                feld[i] = new Schraube();         // Array wird mit Objekten gefüllt
            }
            Schraube a = new Schraube();
            
            InitializeComponent();
            cmb_nr.SelectedIndex = 0;           //Combobox hat von Anfang an die erste Schraube ausgewählt

            //Comboboxen werden von Anfange an auf Default gesetzt
            cbfk.SelectedIndex = 0;
            cbgewinde.SelectedIndex = 0;
            cbmat.SelectedIndex = 0;
            cbkopf.SelectedIndex = 0;
            
            // Bestellnummer 
            bestellnummer = nummer.Next(10000000, 99999999);
            
        }

        private void Btnexit_Click(object sender, RoutedEventArgs e)
        {
            //Wenn Exit-Button geklickt wird, wird gefragt, ob das Fenster geschlossen werden soll. Mit klick auf ja wird die App beendet
            if (MessageBox.Show("Das Fenster wirklich schließen?\nAlle Konfigurationen werden gelöscht!","Warnung", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();  
            }
            else
            {
                return;  
            }
        }

        private void Cbmat_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            //ComboBoxItems für Festigkeitsklasse werden abhängig von dem Material erstellt
            if (cbmat.SelectedValue.ToString() == "V2A")
            {
                cbfk.Items.Clear();
                cbfk.Items.Add("--Bitte auswählen--");             
                cbfk.Items.Add("V2A 50");
                cbfk.Items.Add("V2A 70");
            }
            else if (cbmat.SelectedValue.ToString() == "V4A")
            {
                cbfk.Items.Clear();
                cbfk.Items.Add("--Bitte auswählen--");
                cbfk.Items.Add("V4A 70");
                cbfk.SelectedIndex = 1;
            }
            else if (cbmat.SelectedValue.ToString() == "Verzinkter Stahl")
            {
                cbfk.Items.Clear();
                cbfk.Items.Add("--Bitte auswählen--");
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

            //In den Textboxen für Menge, Schrauben- und Gewindelänge können nur Zahlen eingegeben werden
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
            feld[nr].gewindeart = "Feingewinde";    //Gewindeartauswahl der Checkbox wird em Objekt hinzugefügt
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            feld[nr].gewindeart = "Standardgewinde";    //Gewindeartauswahl der Checkbox wird em Objekt hinzugefügt
        }

        private void Cbkopf_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Grafik der Schraube ändern, abhängig von dem Schraubenkopf
            if (cbkopf.SelectedIndex == 1)
            {
                Image1.Visibility = Visibility.Visible;
                Image2.Visibility = Visibility.Collapsed;
            }
            else if (cbkopf.SelectedIndex == 2)
            {
                Image1.Visibility = Visibility.Collapsed;
                Image2.Visibility = Visibility.Visible;
            }
            else
            {
                Image1.Visibility = Visibility.Visible;
                Image2.Visibility = Visibility.Collapsed;
            }
        }

        private void Btnauswahl_Click(object sender, RoutedEventArgs e)
        {
            #region Fehlermeldung bei Falscheingaben"

            if (feld[nr].gewinde == "")
            {
                MessageBox.Show("Es fehlt eine Gewindeeingabe.\rBitte eine Auswahl treffen", "Fehlerhafte Eingabe", MessageBoxButton.OK, MessageBoxImage.Error);
                return;// wenn keine Gewindeeingabe, wird die Methode beendet
            }

            if (txt_len.Text == "" || txt_gewlen.Text == "")
            {
                MessageBox.Show("Für Gewindelänge und oder Länge liegt keine Eingabe vor.", "Fehlerhafte Eingabe", MessageBoxButton.OK, MessageBoxImage.Error);
                return;// wenn min eine Eingabe leer ist, wird die Methode beendet
            }
            else if (Convert.ToInt32(txt_len.Text) < 5 || Convert.ToInt32(txt_len.Text) > 150)
            {
                MessageBox.Show("Eingaben für Länge außerhalb des möglichen Wertebereichs.", "Fehlerhafte Eingabe", MessageBoxButton.OK, MessageBoxImage.Error);
                return;//wenn len kleiner als 5 wird Methode beendet
            }
            else if (Convert.ToInt32(txt_gewlen.Text) < 5 || Convert.ToInt32(txt_gewlen.Text) > 150)
            {
                MessageBox.Show("Eingaben für Gewindelänge außerhalb des möglichen Wertebereichs.", "Fehlerhafte Eingabe", MessageBoxButton.OK, MessageBoxImage.Error);
                return;//wenn Gewlen kleiner als 5 wird Methode beendet
            }
            else if (Convert.ToInt32(txt_len.Text) < Convert.ToInt32(txt_gewlen.Text))
            {
                MessageBox.Show("Eingaben für Länge und Gewindelänge sind nicht kompatibel.", "Fehlerhafte Eingabe", MessageBoxButton.OK, MessageBoxImage.Error);
                return;//wenn Gewlen größer als Len wird Methode beendet
            }

            if (cbfk.SelectedItem == null)
            {
                MessageBox.Show("Für die Festigkeitsklasse liegt keine Auswahl vor.", "Fehldend Auswahl", MessageBoxButton.OK, MessageBoxImage.Error);
                return;// wenn keine Festigkeitsklasse ausgewählt ist, wird die Methode beendet
            }

            if (txt_menge.Text.ToString() == "" || txt_menge.Text.ToString() == "0")
            {
                MessageBox.Show("Es wurde keine Eingabe für die Menge gemacht.", "Fehlerhafte Eingabe", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            #endregion

            #region "Ausgewählten Werte werden dem Objekt zugewiesen"
            if (gewartcheck.IsChecked== true)
            {
                feld[nr].gewindeart = "Feingewinde";
            }
            else if (gewartcheck.IsChecked == false)
            {
                feld[nr].gewindeart = "Standardgewinde";
            }

            feld[nr].menge = Convert.ToInt32(txt_menge.Text.ToString());
            feld[nr].typ = cbkopf.SelectedValue.ToString();
            feld[nr].gewinde = cbgewinde.SelectedValue.ToString();
            feld[nr].festigkeit = cbfk.SelectedItem.ToString();
            feld[nr].material = cbmat.SelectedValue.ToString();
            feld[nr].gewindelaenge = Convert.ToInt32(txt_gewlen.Text);
            feld[nr].laenge = Convert.ToInt32(txt_len.Text);
            feld[nr].bemerkung = text.Text.ToString();
            #endregion

            //Die Werte den Objekts Schraube werden in der Übersichtstabelle übernommen
            Materialtxt.Text = ("Material" + "\n\n\n"  + feld[0].material + "\n\n\n" + feld[1].material + "\n\n\n" + feld[2].material + "\n\n\n" + feld[3].material + "\n\n\n" + feld[4].material);
            Festtxt.Text = ("Festigkeit" + "\n\n\n" + feld[0].festigkeit + "\n\n\n" + feld[1].festigkeit + "\n\n\n" + feld[2].festigkeit + "\n\n\n" + feld[3].festigkeit + "\n\n\n" + feld[4].festigkeit);
            Kopftxt.Text = ("Kopf" + "\n\n\n" + feld[0].typ + "\n\n\n" + feld[1].typ + "\n\n\n" + feld[2].typ + "\n\n\n" + feld[3].typ + "\n\n\n" + feld[4].typ);
            Gewindetxt.Text = ("Gewinde" + "\n\n" + feld[0].gewinde + "\n\n\n" + feld[1].gewinde + "\n\n\n" + feld[2].gewinde + "\n\n\n" + feld[3].gewinde + "\n\n\n" + feld[4].gewinde);
            Typtxt.Text = ("Typ" + "\n\n\n" + feld[0].gewindeart + "\n\n\n" + feld[1].gewindeart + "\n\n\n" + feld[2].gewindeart + "\n\n\n" + feld[3].gewindeart + "\n\n\n" + feld[4].gewindeart);
            Laengetxt.Text = ("Länge" + "\n\n\n" + feld[0].laenge + "\n\n\n" + feld[1].laenge + "\n\n\n" + feld[2].laenge + "\n\n\n" + feld[3].laenge + "\n\n\n" + feld[4].laenge);
            gewlentxt.Text = ("Gewindelänge" + "\n\n" + feld[0].gewindelaenge + "\n\n\n" + feld[1].gewindelaenge + "\n\n\n" + feld[2].gewindelaenge + "\n\n\n" + feld[3].gewindelaenge + "\n\n\n" + feld[4].gewindelaenge);
            mengetxt.Text = ("Menge" + "\n\n\n" + feld[0].menge + "\n\n\n" + feld[1].menge + "\n\n\n" + feld[2].menge + "\n\n\n" + feld[3].menge + "\n\n\n" + feld[4].menge);

            //Berechnungen für die ausgewählte Schraube           
            feld[nr].Berechnen();

            MessageBox.Show("Die aktuelle Konfiguration wurde in die Übersicht hinzugefügt.", "Konfiguration gespeichert", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Cmb_nr_SelectionChanged(object sender, SelectionChangedEventArgs e)//auswahl der Schraubennummer (Index vom Feld)
        {
            switch (cmb_nr.SelectedIndex)//Auswahl der Schraube
            {
                case 0:
                    nr = 0;     
                    break;
            
                case 1:
                    nr = 1;
                    break;
                
                case 2:
                    nr = 2;
                    break;
                
                case 3:
                    nr = 3;
                    break;
                
                case 4:
                    nr = 4;
                    break;
            }

            #region "Die gespeicherten Werte des Objekts werden in den Comboboxen angezeigt"
            if (feld[nr].material=="Verzinkter Stahl")
            {
                cbmat.SelectedIndex = 1;

                switch (feld[nr].festigkeit)
                {
                    case "5.8":
                        cbfk.SelectedIndex =1 ;
                        break;
                    
                    case "6.8":
                        cbfk.SelectedIndex = 2;
                        break;

                    case "8.8":
                        cbfk.SelectedIndex = 3;
                        break;

                    case "9.8":
                        cbfk.SelectedIndex = 4;
                        break;

                    case "10.8":
                        cbfk.SelectedIndex = 5;
                        break;

                    case "12.8":
                        cbfk.SelectedIndex = 6;
                        break;
                }
            }
            else if (feld[nr].material == "V2A")
            {
                cbmat.SelectedIndex = 2;

                switch (feld[nr].festigkeit)
                {
                    case "V2A 50":
                        cbfk.SelectedIndex = 1;
                        break;

                    case "V2A 70":
                        cbfk.SelectedIndex = 2;
                        break;
                }
            }
            else if (feld[nr].material == "V4A")
            {
                cbmat.SelectedIndex = 3;
                cbfk.SelectedIndex = 1;
            }
            else
            {
                cbmat.SelectedIndex = 0;
                cbfk.SelectedIndex = 0;
            }

            switch (feld[nr].gewinde)
            {
                case null:
                    cbgewinde.SelectedIndex = 0;
                    break;

                case "M4":
                    cbgewinde.SelectedIndex = 1;
                    break;

                case "M5":
                    cbgewinde.SelectedIndex =2;
                    break;

                case "M6":
                    cbgewinde.SelectedIndex =3;
                    break;

                case "M8":
                    cbgewinde.SelectedIndex = 4;
                    break;

                case "M10":
                    cbgewinde.SelectedIndex = 5;
                    break;
                    
                case "M12":
                    cbgewinde.SelectedIndex = 6;                   
                    break;
                    
                case "M16":
                    cbgewinde.SelectedIndex = 7;                 
                    break;
                
                case "M20":
                    cbgewinde.SelectedIndex = 8;
                    
                    break;
            }

            if (feld[nr].gewindeart=="Feingewinde")
            {
                gewartcheck.IsChecked = true;
            }
            else
            {
                gewartcheck.IsChecked = false;
            }
            if (feld[nr].typ == "Außensechskant")
            {
                cbkopf.SelectedIndex = 1;
                Image1.Visibility = Visibility.Visible;
                Image2.Visibility = Visibility.Collapsed;
            }
            else if (feld[nr].typ == "Innensechskant")
            {
                cbkopf.SelectedIndex = 2;
                Image1.Visibility = Visibility.Collapsed;
                Image2.Visibility = Visibility.Visible;
            }
            else
            {
                cbkopf.SelectedIndex = 0;
            }

            txt_gewlen.Text = feld[nr].gewindelaenge.ToString();
            txt_len.Text = feld[nr].laenge.ToString();
            txt_menge.Text = feld[nr].menge.ToString();
            #endregion
        }

        private void New_screw_Click(object sender, RoutedEventArgs e)
        {
            //neue Schraube wird erstellt und alle Auswahlen werden aus Default zurückgesetzt
            cbfk.SelectedIndex = 0;
            cbgewinde.SelectedIndex = 0;
            cbkopf.SelectedIndex = 0;
            cbmat.SelectedIndex = 0;
            txt_gewlen.Text = "";
            txt_len.Text = "";
            txt_menge.Text = "";
            gewartcheck.IsChecked = false;
            
            switch (new_screw_int)
            {
                case 1:
                    screw2.Visibility = Visibility.Visible;
                    cmb_nr.SelectedItem = screw2;
                    new_screw_int++;                  
                    break;

                case 2:
                    screw3.Visibility = Visibility.Visible;
                    cmb_nr.SelectedItem = screw3;
                    new_screw_int++;                  
                    break;

                case 3:
                    screw4.Visibility = Visibility.Visible;
                    cmb_nr.SelectedItem = screw4;
                    new_screw_int++;                  
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

        private void btnwarenkorb_Click(object sender, RoutedEventArgs e)
        {
            #region "Fehlermeldung bei Falscheingabe"
            if (check1.IsChecked == true && feld[0].material == null || check2.IsChecked == true && feld[1].material == null || check3.IsChecked == true && feld[2].material == null || check4.IsChecked == true && feld[3].material == null || check5.IsChecked == true && feld[4].material == null)
            {
                MessageBox.Show("Die Auswahl ist leer.", "Fehlerhafte Eingabe", MessageBoxButton.OK, MessageBoxImage.Error);
                return;//wenn die ausgewählte schraube leer ist, wird die Methode beendet
            }          
            else if (check1.IsChecked == true || check2.IsChecked == true || check3.IsChecked == true || check4.IsChecked == true || check5.IsChecked == true)
            {
               MessageBox.Show("Auswahl wurde dem Warenkorb hinzugefügt.","", MessageBoxButton.OK, MessageBoxImage.Information);
               tab_2.Visibility = Visibility.Visible;
            }
            else 
            {
                MessageBox.Show("Es ist nichts ausgewählt.", "Fehlerhafte Eingabe", MessageBoxButton.OK, MessageBoxImage.Error);
                return;//wenn keine Checkbox ausgewählt, wird die Methode beendet
            }
            #endregion

            #region "Die Werte des ausgewälten Objekts werden im Warenkorb gespeichert"
            if (check1.IsChecked == true)
            {
                menge1txt.Text = feld[0].menge.ToString();
                gew1txt.Text = Math.Round(feld[0].gesamtgewicht, 2).ToString();
                preis1txt.Text = Math.Round(feld[0].stückpreis,2).ToString();
                gpreis1txt.Text = Math.Round(feld[0].nettopreis_Summe,2).ToString();
            }
            else if(check1.IsChecked == false)
            {
                menge1txt.Text = "0";
                gew1txt.Text = "0";
                preis1txt.Text = "0";
                gpreis1txt.Text = "0";
            }

            if (check2.IsChecked == true)
            {
                 menge2txt.Text = feld[1].menge.ToString();
                 gew2txt.Text = Math.Round(feld[1].gesamtgewicht, 2).ToString();
                 preis2txt.Text = Math.Round(feld[1].stückpreis,2).ToString();
                 gpreis2txt.Text = Math.Round(feld[1].nettopreis_Summe, 2).ToString();
            }
            else if (check2.IsChecked == false)
            {
                menge2txt.Text = "0";
                gew2txt.Text = "0";
                preis2txt.Text = "0";
                gpreis2txt.Text = "0";
            }

            if (check3.IsChecked == true)
            {
                menge3txt.Text = feld[2].menge.ToString();
                gew3txt.Text = Math.Round(feld[2].gesamtgewicht, 2).ToString();
                preis3txt.Text = Math.Round(feld[2].stückpreis,2).ToString();
                gpreis3txt.Text = Math.Round(feld[2].nettopreis_Summe, 2).ToString();
            }
            else if (check3.IsChecked == false)
            {
                 menge3txt.Text = "0";
                 gew3txt.Text = "0";
                 preis3txt.Text = "0";
                 gpreis3txt.Text = "0";
            }

            if (check4.IsChecked == true)
            {
                menge4txt.Text = feld[3].menge.ToString();
                gew4txt.Text = Math.Round(feld[3].gesamtgewicht, 2).ToString();
                preis4txt.Text = Math.Round(feld[3].stückpreis,2).ToString();
                gpreis4txt.Text = Math.Round(feld[3].nettopreis_Summe, 2).ToString();
            }
            else if (check4.IsChecked == false)
            {
                menge4txt.Text = "0";
                gew4txt.Text = "0";
                preis4txt.Text = "0";
                gpreis4txt.Text = "0";
            }

            if (check5.IsChecked == true)
            {
                menge5txt.Text = feld[4].menge.ToString();
                gew5txt.Text = Math.Round(feld[4].gesamtgewicht, 2).ToString();
                preis5txt.Text = Math.Round(feld[4].stückpreis,2).ToString();
                gpreis5txt.Text = Math.Round(feld[4].nettopreis_Summe, 2).ToString();
            }
            else if (check5.IsChecked == false)
            {
                menge5txt.Text = "0";
                gew5txt.Text = "0";
                preis5txt.Text = "0";
                gpreis5txt.Text = "0";
            }

            double w1 = Convert.ToDouble(gpreis1txt.Text);
            double w2 = Convert.ToDouble(gpreis2txt.Text);
            double w3 = Convert.ToDouble(gpreis3txt.Text);
            double w4 = Convert.ToDouble(gpreis4txt.Text);
            double w5 = Convert.ToDouble(gpreis5txt.Text);

            
                gesamtpreistxt.Text = (w1 + w2 + w3 + w4 + w5).ToString();

            double x1 = Convert.ToDouble(menge1txt.Text);
            double x2 = Convert.ToDouble(menge2txt.Text);
            double x3 = Convert.ToDouble(menge3txt.Text);
            double x4 = Convert.ToDouble(menge4txt.Text);
            double x5 = Convert.ToDouble(menge5txt.Text);

            
                summemengetxt.Text = (x1 + x2 + x3 + x4 + x5).ToString();

            double y1 = Convert.ToDouble(gew1txt.Text);
            double y2 = Convert.ToDouble(gew2txt.Text);
            double y3 = Convert.ToDouble(gew3txt.Text);
            double y4 = Convert.ToDouble(gew4txt.Text);
            double y5 = Convert.ToDouble(gew5txt.Text);

            
                summegewtxt.Text = (y1 + y2 + y3 + y4 + y5).ToString();

            double z1 = Convert.ToDouble(preis1txt.Text);
            double z2 = Convert.ToDouble(preis2txt.Text);
            double z3 = Convert.ToDouble(preis3txt.Text);
            double z4 = Convert.ToDouble(preis4txt.Text);
            double z5 = Convert.ToDouble(preis5txt.Text);

            
                summepreistxt.Text = (z1 + z2 + z3 + z4 + z5).ToString();
            #endregion
        }

        private void Btnexcel_Click(object sender, RoutedEventArgs e)
        {
            bool senden = false; 
            ExcelControll.ExelContoll_aufrufen(Feld_anpassen(feld), senden, bestellnummer,kundennummer);
        }

        public void Btnangebot_Click(object sender, RoutedEventArgs e)
        {
            kundennummer = txtkunde.Text; //Eingegebene Kundennr. wird in der Variablen gespeichert

            if (txtkunde.Text == "")
            {
                MessageBox.Show("Es wurde keine Kundennummer eingetragen", "", MessageBoxButton.OK, MessageBoxImage.Error);
                return; //Methode beenden, wenn keine Kundennummer eingetragen wird
            }
            else if (txtkunde.Text.Length != 10)
            {
                MessageBox.Show("Die Kundennummer muss aus 10 Zahlen bestehen.", "Falsche Eingabe", MessageBoxButton.OK, MessageBoxImage.Error);
                return; //Methode beenden, wenn eine Kundennummer mit weniger als 10 Zeichen eigegeben wird
            }
            
            bool senden = true;

            ExcelControll.ExelContoll_aufrufen(Feld_anpassen(feld), senden, bestellnummer,kundennummer);
            MessageBox.Show("Angebot wurde erfolgreich abgesendet!", "Bestellt", MessageBoxButton.OK);
        }

        private  Schraube[] Feld_anpassen(Schraube[] feld)
        {
            Schraube[] newfeld = new Schraube[5];
            for(int s=0; s < newfeld.Length; s++)
            {
                newfeld[s] = new Schraube();
            }        

            if (check1.IsChecked == true)
            {
                newfeld[0] = feld[0];              
            }

            if (check2.IsChecked == true)
            {
                newfeld[1] = feld[1];              
            }

            if (check3.IsChecked == true)
            {
                newfeld[2] = feld[2];              
            }

            if (check4.IsChecked == true)
            {
                newfeld[3] = feld[3];               
            }

            if (check5.IsChecked == true)
            {
                newfeld[4] = feld[4];             
            }

            return newfeld;
        }
    }

}

