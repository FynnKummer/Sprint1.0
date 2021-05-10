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

        // hier noch ne Random Nummer erzeugen lassen für ne Bestell und Kudnennummer

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

            // Bestellnummer 
            bestellnummer = nummer.Next(10000000, 99999999);


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
            feld[nr].dichte_festlegen();
            feld[nr].vol_berechnen();


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
                menge1txt.Text = "--";
                gew1txt.Text = "--";
                preis1txt.Text = "--";
            }

            if (check2.IsChecked == true)
            {
                 menge2txt.Text = feld[1].menge.ToString();
                 gew2txt.Text = feld[1].masse.ToString();
                 preis2txt.Text = feld[1].preis_summe.ToString();
            }
            else if (check2.IsChecked == false)
            {
                menge2txt.Text = "--";
                gew2txt.Text = "--";
                preis2txt.Text = "--";
            }

            if (check3.IsChecked == true)
            {
                menge3txt.Text = feld[2].menge.ToString();
                gew3txt.Text = feld[2].masse.ToString();
                preis3txt.Text = feld[2].preis_summe.ToString();
            }
            else if (check3.IsChecked == false)
            {
                 menge3txt.Text = "--";
                 gew3txt.Text = "--";
                 preis3txt.Text = "--";
            }

            if (check4.IsChecked == true)
            {
                menge4txt.Text = feld[3].menge.ToString();
                gew4txt.Text = feld[3].masse.ToString();
                preis4txt.Text = feld[3].preis_summe.ToString();
            }
            else if (check4.IsChecked == false)
            {
                menge4txt.Text = "--";
                gew4txt.Text = "--";
                preis4txt.Text = "--";
            }

            if (check5.IsChecked == true)
            {
                menge5txt.Text = feld[4].menge.ToString();
                gew5txt.Text = feld[4].masse.ToString();
                preis5txt.Text = feld[4].preis_summe.ToString();
            }
            else if (check5.IsChecked == false)
            {
                menge5txt.Text = "--";
                gew5txt.Text = "--";
                preis5txt.Text = "--";
            }

      /*    int x1 = int.TryParse(menge1txt.Text);
            int x2 = int.TryParse(menge2txt.Text);
            int x3 = int.TryParse(menge3txt.Text);
            int x4 = int.TryParse(menge4txt.Text);
            int x5 = int.TryParse(menge5txt.Text);

            if (Int32.TryParse(menge1txt.Text, out x1) && Int32.TryParse(menge2txt.Text, out x2) && Int32.TryParse(menge3txt.Text, out x3) && Int32.TryParse(menge4txt.Text, out x4) && Int32.TryParse(menge5txt.Text, out x5))
                summemengetxt.Text = (x1 + x2 + x3 + x4 + x5).ToString();

            int y1 = int.TryParse(gew1txt.Text);
            int y2 = int.TryParse(gew2txt.Text);
            int y3 = int.TryParse(gew3txt.Text);
            int y4 = int.TryParse(gew4txt.Text);
            int y5 = int.TryParse(gew5txt.Text);

            if (Int32.TryParse(gew1txt.Text, out y1) && Int32.TryParse(gew2txt.Text, out y2) && Int32.TryParse(gew3txt.Text, out y3) && Int32.TryParse(gew4txt.Text, out y4) && Int32.TryParse(gew5txt.Text, out y5))
                summegewtxt.Text = (y1 + y2 + y3 + y4 + y5).ToString();

            int z1 = int.TryParse(preis1txt.Text);
            int z2 = int.TryParse(preis2txt.Text);
            int z3 = int.TryParse(preis3txt.Text);
            int z4 = int.TryParse(preis4txt.Text);
            int z5 = int.TryParse(preis5txt.Text);

            if (Int32.TryParse(preis1txt.Text, out z1) && Int32.TryParse(preis2txt.Text, out z2) && Int32.TryParse(preis3txt.Text, out z3) && Int32.TryParse(preis4txt.Text, out z4) && Int32.TryParse(preis5txt.Text, out z5))
                summepreistxt.Text = (z1 + z2 + z3 + z4 + z5).ToString();
      */
        }

        private void btnexcel_Click(object sender, RoutedEventArgs e)
        {
            bool senden = false; 
            ExcelControll.ExelContoll_aufrufen(feld, senden, bestellnummer);
        }

        private void btnangebot_Click(object sender, RoutedEventArgs e)
        {
            bool senden = true;
            ExcelControll.ExelContoll_aufrufen(feld, senden, bestellnummer);
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

            mySheet.Cells[2, 1] = "Techniche Details";
            mySheet.Cells[3, 1] = "Schraubenlänge";
            mySheet.Cells[4, 1] = "Gewindelänge";
            mySheet.Cells[5, 1] = "Schlüsselweite";
            mySheet.Cells[6, 1] = "Gewindedurchmesser";
            mySheet.Cells[7, 1] = "Masse pro Stück";
            mySheet.Cells[8, 1] = "Gesamtgewicht";
            mySheet.Cells[9, 1] = "Gewindesteigung";
            mySheet.Cells[10, 1] = "Gewindetiefe";
            mySheet.Cells[11, 1] = "Rundung";
            mySheet.Cells[12, 1] = "Flankendurchmesser";
            mySheet.Cells[13, 1] = "Kerndurchmesser";
            mySheet.Cells[14, 1] = "Flankenwinkel";
            mySheet.Cells[15, 1] = "";
            mySheet.Cells[16, 1] = "Elastizitätzgrenze";
            mySheet.Cells[17, 1] = "Zugfestigkeit";
            mySheet.Cells[18, 1] = "";
            mySheet.Cells[19, 1] = "Preis (Netto)";
            mySheet.Cells[20, 1] = "Summe";
            mySheet.Cells[21, 1] = "Stückpreis";
            mySheet.Cells[22, 1] = "";
            mySheet.Cells[23, 1] = "Preis (Brutto)";
            mySheet.Cells[24, 1] = "Summe";
            mySheet.Cells[25, 1] = "Stückpreis";
            mySheet.Cells[27, 1] = "Menge";


            // Listenformat einführen 
            mySheet.Range["A1", "E29"].AutoFormat(Excel.XlRangeAutoFormat.xlRangeAutoFormatList2);

            // Werte der Schrauben in Tabelle eingeben 

            for (int i = 0; i < arr.Length; i++)
            {
                mySheet.Cells[1, i + 2] = arr[i].name;
                mySheet.Cells[3, i + 2] = arr[i].laenge + " mm";
                mySheet.Cells[4, i + 2] = arr[i].gewindelaenge + " mm";
                mySheet.Cells[5, i + 2] = arr[i].schluesselbreite + " mm";
                mySheet.Cells[6, i + 2] = arr[i].gewinde;
                mySheet.Cells[7, i + 2] = Math.Round(arr[i].masse, 2) + " g";
                mySheet.Cells[8, i + 2] = Math.Round(arr[i].gesamtgewicht, 2) + " g";
                mySheet.Cells[9, i + 2] = Math.Round(arr[i].gewindesteigung, 2) + " mm";
                mySheet.Cells[10, i + 2] = Math.Round(arr[i].gewindetiefe, 2) + " mm";
                mySheet.Cells[11, i + 2] = Math.Round(arr[i].gewinderundung, 2) + " mm";
                mySheet.Cells[12, i + 2] = Math.Round(arr[i].flankendurchmesser, 2) + " mm";
                mySheet.Cells[13, i + 2] = Math.Round(arr[i].kerndurchmesser, 2) + " mm";
                mySheet.Cells[14, i + 2] = Math.Round(arr[i].flankenwinkel, 2) + "°";

                mySheet.Cells[16, i + 2] = Math.Round(arr[i].elastizitätsgrenze, 2) + " N/mm²";
                mySheet.Cells[17, i + 2] = Math.Round(arr[i].Zugfestigkeit, 2) + " N/mm²";


                mySheet.Cells[20, i + 2] = Math.Round(arr[i].nettopreis_Summe, 2) + "€";
                mySheet.Cells[21, i + 2] = Math.Round(arr[i].nettoeinzelpreis, 2) + "€";


                mySheet.Cells[24, i + 2] = Math.Round(arr[i].preis_summe, 2) + "€";
                mySheet.Cells[25, i + 2] = Math.Round(arr[i].stückpreis, 2) + "€";

                mySheet.Cells[27, i + 2] = arr[i].menge;

                mySheet.Cells[28, i + 2].AddComment("Anmerkung S " + i);

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

        

            //Exel Speichern für Kunden 

            /* string Pfad = @"C:\Desktop\";

             mySheet.SaveAs(Pfad+@"\Bestellung " + Convert.ToString(bestellnummer) + ".xlsx");
            */

            // Excel muss noch geschlossen werden 

          

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

