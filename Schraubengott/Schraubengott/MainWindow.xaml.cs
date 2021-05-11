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

        Random nummer = new Random();
        int bestellnummer;

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
            cbkopf.SelectedIndex = 0;
            cbmat.SelectedIndex = 0;
            cbkopf.SelectedIndex = 0;
            
            // Bestellnummer 
            bestellnummer = nummer.Next(10000000, 99999999);
        }

        private void btnexit_Click(object sender, RoutedEventArgs e)
        {
            //Wenn Exit-Button geklickt wird, wird gefragt, ob das Fenster geschlossen werden soll. Mit klick auf ja wird die App beendet
            if (MessageBox.Show("Das Fenster wirklich schließen?\nAlle Konfigurationene werden gelöscht!","Warnung", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();  
            }
            else
            {
                return;  
            }





        }

        private void cbmat_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            //Combobox für Festigkeitsklasse wir abhängig von dem Material befüllt
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
            else if (Convert.ToInt32(txt_len.Text) <= 5)
            {
                MessageBox.Show("Eingaben für Länge zu klein.", "Fehlerhafte Eingabe", MessageBoxButton.OK, MessageBoxImage.Error);
                return;//wenn len kleiner als 6 wird Methode beendet
            }
            else if (Convert.ToInt32(txt_gewlen.Text) <= 5)
            {
                MessageBox.Show("Eingaben für Gewindelänge zu klein.", "Fehlerhafte Eingabe", MessageBoxButton.OK, MessageBoxImage.Error);
                return;//wenn Gewlen kleiner als 6 wird Methode beendet
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
            feld[nr].bemerkung = text.Text.ToString();

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

        private void cmb_nr_SelectionChanged(object sender, SelectionChangedEventArgs e)//auswahl der Schraubennummer (Index vom Feld)
        {
            switch (cmb_nr.SelectedIndex)
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
            
            
            if(feld[nr].material=="Verzinkter Stahl")
            {
                cbmat.SelectedIndex = 1;
            }
            else if (feld[nr].material == "V2A")
            {
                cbmat.SelectedIndex = 2;
            }
            else if (feld[nr].material == "V4A")
            {
                cbmat.SelectedIndex = 3;
            }
            
            switch (feld[nr].gewinde)
            {
                case "M4":
                    cbgewinde.SelectedValue = 1;
                    break;

                case "M5":
                    cbgewinde.SelectedValue =2;
                    break;

                case "M6":
                    cbgewinde.SelectedValue =3;
                    break;

                case "M8":
                    cbgewinde.SelectedValue = 4;
                    break;

                case "M10":
                    cbgewinde.SelectedValue = 5;
                    break;
                    
                case "M12":
                    cbgewinde.SelectedValue = 6;
                    
                    break;
                    
                case "M16":
                    cbgewinde.SelectedValue = 7;
                  
                    break;
                
                case "M20":
                    cbgewinde.SelectedValue = 8;
                    
                    break;
            }

           




        }

        private void new_screw_Click(object sender, RoutedEventArgs e)
        {


            //neue Schraube wird erstellt und alle Auswhalen werden aus Default zurückgesetzt
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

        private void cbkopf_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Grafik der Schraube ändern, abhängig von dem Schraubenkopf
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
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
            
            if (check1.IsChecked == true)
            {
                menge1txt.Text = feld[0].menge.ToString();
                gew1txt.Text = Math.Round(feld[0].masse,2).ToString();
                preis1txt.Text = Math.Round(feld[0].stückpreis,2).ToString();
                gpreis1txt.Text = Math.Round(feld[0].preis_summe,2).ToString();
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
                 gew2txt.Text = Math.Round(feld[1].masse,2).ToString();
                 preis2txt.Text = Math.Round(feld[1].stückpreis,2).ToString();
                 gpreis2txt.Text = Math.Round(feld[1].preis_summe,2).ToString();
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
                gew3txt.Text = Math.Round(feld[2].masse,2).ToString();
                preis3txt.Text = Math.Round(feld[2].stückpreis,2).ToString();
                gpreis3txt.Text = Math.Round(feld[2].preis_summe,2).ToString();
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
                gew4txt.Text = Math.Round(feld[3].masse,2).ToString();
                preis4txt.Text = Math.Round(feld[3].stückpreis,2).ToString();
                gpreis4txt.Text = Math.Round(feld[3].preis_summe,2).ToString();
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
                gew5txt.Text = Math.Round(feld[4].masse,2).ToString();
                preis5txt.Text = Math.Round(feld[4].stückpreis,2).ToString();
                gpreis5txt.Text = Math.Round(feld[4].preis_summe,2).ToString();
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

            if (double.TryParse(gpreis1txt.Text, out w1) && double.TryParse(gpreis2txt.Text, out w2) && double.TryParse(gpreis3txt.Text, out w3) && double.TryParse(gpreis4txt.Text, out w4) && double.TryParse(gpreis5txt.Text, out w5))
                gesamtpreistxt.Text = (w1 + w2 + w3 + w4 + w5).ToString();

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
            bool senden = false; 
            ExcelControll.ExelContoll_aufrufen(feld, senden, bestellnummer);
        }

        private void btnangebot_Click(object sender, RoutedEventArgs e)
        {
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
            ExcelControll.ExelContoll_aufrufen(feld, senden, bestellnummer);
            MessageBox.Show("Angebot wurde erfolgreich abgesendet!", "Bestellt", MessageBoxButton.OK);
        }

    }

    class ExcelControll
    {
        public static void ExelContoll_aufrufen(Schraube[] arr, bool senden, int bestellnummer)
        {
            Excel_erstellen(arr, senden, bestellnummer);
        }
        public static void Excel_erstellen(Schraube[] arr, bool senden, int bestellnummer)
        {
            new ExcelControll(arr, senden, bestellnummer);
        }

        ExcelControll(Schraube[] arr, bool senden, int bestellnummer)
        {
            // Erstellen einer Neuen Exelmappe 
            Excel.Application excelApp = new Excel.Application();
           if (senden == true)
            {
                excelApp.Visible = false;
            }
           else
            {
                excelApp.Visible = true;               
            }

            excelApp.Workbooks.Add();

            // Hinzufügen einer Seite? 
            Excel._Worksheet mySheet = (Excel.Worksheet)excelApp.ActiveSheet;

            // Kategorien festlegen
            mySheet.Cells[2, 1] = "Menge";
            mySheet.Cells[3, 1] = "Techniche Details";
            mySheet.Cells[4, 1] = "Schraubenlänge";
            mySheet.Cells[5, 1] = "Gewindelänge";
            mySheet.Cells[6, 1] = "Schlüsselweite";
            mySheet.Cells[7, 1] = "Gewindedurchmesser";
            mySheet.Cells[8, 1] = "Masse pro Stück";
            mySheet.Cells[9, 1] = "Gesamtgewicht";
            mySheet.Cells[10, 1] = "Gewindesteigung";
            mySheet.Cells[11, 1] = "Gewindetiefe";
            mySheet.Cells[12, 1] = "Rundung";
            mySheet.Cells[13, 1] = "Flankendurchmesser";
            mySheet.Cells[14, 1] = "Kerndurchmesser";
            mySheet.Cells[15, 1] = "Flankenwinkel";
            mySheet.Cells[16, 1] = "";
            mySheet.Cells[17, 1] = "Elastizitätzgrenze";
            mySheet.Cells[18, 1] = "Zugfestigkeit";
            mySheet.Cells[19, 1] = "";
            mySheet.Cells[20, 1] = "Preis (Netto)";
            mySheet.Cells[21, 1] = "Summe";
            mySheet.Cells[22, 1] = "Stückpreis";
            mySheet.Cells[23, 1] = "";
            mySheet.Cells[24, 1] = "Preis (Brutto)";
            mySheet.Cells[25, 1] = "Summe";
            mySheet.Cells[26, 1] = "Stückpreis";          
            mySheet.Cells[28, 1] = "Bestellsumme"; 

            // Listenformat einführen 
            mySheet.Range["A1", "F29"].AutoFormat(Excel.XlRangeAutoFormat.xlRangeAutoFormatList2);

            // Werte der Schrauben in Tabelle eingeben 
            for (int i = 0; i < arr.Length; i++)
            {
                double summe = 0; 

                summe = summe + arr[i].nettopreis_Summe;

                mySheet.Cells[1, i + 2] = "Schraube" + i;
                mySheet.Cells[1, i + 2] = arr[i].name;
                mySheet.Cells[2, i + 2] = arr[i].menge;
                mySheet.Cells[4, i + 2] = arr[i].laenge + " mm";
                mySheet.Cells[5, i + 2] = arr[i].gewindelaenge + " mm";
                mySheet.Cells[6, i + 2] = arr[i].schluesselbreite + " mm";
                mySheet.Cells[7, i + 2] = arr[i].gewinde;
                mySheet.Cells[8, i + 2] = Math.Round(arr[i].masse, 2) + " g";
                mySheet.Cells[9, i + 2] = Math.Round(arr[i].gesamtgewicht, 2) + " g";
                mySheet.Cells[10, i + 2] = Math.Round(arr[i].gewindesteigung, 2) + " mm";
                mySheet.Cells[11, i + 2] = Math.Round(arr[i].gewindetiefe, 2) + " mm";
                mySheet.Cells[12, i + 2] = Math.Round(arr[i].gewinderundung, 2) + " mm";
                mySheet.Cells[13, i + 2] = Math.Round(arr[i].flankendurchmesser, 2) + " mm";
                mySheet.Cells[14, i + 2] = Math.Round(arr[i].kerndurchmesser, 2) + " mm";
                mySheet.Cells[15, i + 2] = Math.Round(arr[i].flankenwinkel, 2) + "°";
                mySheet.Cells[17, i + 2] = Math.Round(arr[i].elastizitätsgrenze, 2) + " N/mm²";
                mySheet.Cells[18, i + 2] = Math.Round(arr[i].Zugfestigkeit, 2) + " N/mm²";
                mySheet.Cells[21, i + 2] = Math.Round(arr[i].nettopreis_Summe, 2) + "€";
                mySheet.Cells[22, i + 2] = Math.Round(arr[i].nettoeinzelpreis, 2) + "€";
                mySheet.Cells[25, i + 2] = Math.Round(arr[i].preis_summe, 2) + "€";
                mySheet.Cells[26, i + 2] = Math.Round(arr[i].stückpreis, 2) + "€";
                
                mySheet.Cells[28, i + 2] = Math.Round(summe,2)+"€";

                mySheet.Cells[29, i + 2].AddComment("Test");               
            }

            // Zellenbreite an Text anpassen 
            for (int i = 1; i < 9; i++)
            {
                mySheet.Columns[i].AutoFit();
            }

            if (senden == true)
            {
                mySheet.SaveAs(@"C:\Windows\Temp\Bestellung " + Convert.ToString(bestellnummer) + ".xlsx");

                excelApp.Workbooks.Close();

                Emailsenden(bestellnummer);
            }       
       }

        public static void Emailsenden(int bestellnummer)
        {
            string text = "Anfrage";
            string betreff = "Anfrage";
            string server = "mail.gmx.net";
            int port = 587;
            string user = "456263856";
            string passwort = "1Q2w3e4r5t6z7u8_";

            MailMessage Mail = new MailMessage();

            //Absender
            Mail.From = new MailAddress("hsp.anfragen@gmx.net");

            //Empfänger 
            Mail.To.Add("hsp.anfragen@gmx.net");

            // Betreff
            Mail.Subject = betreff;

            Mail.Body = text;

            Attachment Tabelle = new Attachment(@"C:\Windows\Temp\Bestellung " + Convert.ToString(bestellnummer) + ".xlsx");

            Mail.Attachments.Add(Tabelle);

            // Abseneserver 
            SmtpClient mailClient = new SmtpClient(server);

            mailClient.UseDefaultCredentials = false;
            mailClient.EnableSsl = true;
            mailClient.Port = port;
            mailClient.Credentials = new System.Net.NetworkCredential(user, passwort);

            mailClient.Send(Mail);
        }
    }
}

