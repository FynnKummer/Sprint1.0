using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schraubengott
{
    class ExcelControll
    {
        public int bestellnummer;
        // Konstuktor 

        public static void Excel_erstellen(Schraube[] arr)
        {
            new ExcelControll(arr);
        }

        ExcelControll(Schraube[] arr)
        {
            // Erstellen einer Neuen Exelmappe 
            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = true;
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


            // Excel abspeichern für Email  

            // Bestellnummer 

            Random nummer = new Random();
            bestellnummer = nummer.Next(10000000, 99999999);



            mySheet.SaveAs(@"C:\Windows\Temp\Bestellung " + Convert.ToString(bestellnummer) + ".xlsx");


            excelApp.Workbooks.Close();

            //Exel Speichern für Kunden 

            /* string Pfad = @"C:\Desktop\";

             mySheet.SaveAs(Pfad+@"\Bestellung " + Convert.ToString(bestellnummer) + ".xlsx");
            */

            // Excel muss noch geschlossen werden 

            

                    Console.ReadKey();
                    Console.ReadKey();
                    Console.WriteLine("Email senden");

                    Emailsenden(bestellnummer);

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



                    Console.WriteLine("Fertig");
                    Console.ReadKey();
        
        }

    }

}
