using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace ConsoleApp1
{

    class Programm
    {
        static void Main()
        {
            ExcelControll.Excel_erstellen();

            ExcelControll.emailsenden();
            
        }
    }

    class ExcelControll
    {
        // Konstuktor 

        public static void Excel_erstellen()
        {
            new ExcelControll();
        }

        ExcelControll()
        {
            // Erstellen einer Neuen Exelmappe 
            int anzahl = 4;
            string Anmerkung = "Test Anmerkung 123";
            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = true;
            excelApp.Workbooks.Add();

            // Hinzufügen einer Seite? 
            Excel._Worksheet mySheet = (Excel.Worksheet)excelApp.ActiveSheet;

            

            // Kategorien festlegen

            mySheet.Cells[2,1] = "Techniche Details";
            mySheet.Cells[3,1] = "Schraubenlänge";
            mySheet.Cells[4,1] = "Schlüsselweite";
            mySheet.Cells[5,1] = "Gewindedurchmesser";
            mySheet.Cells[6,1] = "Masse pro Stück";
            mySheet.Cells[7,1] = "Gesamtgewicht";
            mySheet.Cells[8,1] = "Steigung";
            mySheet.Cells[9,1] = "Gewindetiefe";
            mySheet.Cells[10,1] = "Rundung";
            mySheet.Cells[11,1] = "Flankendurchmesser";
            mySheet.Cells[12,1] = "Flankenwinkel";
            mySheet.Cells[13,1] = "";
            mySheet.Cells[14,1] = "Elastizitätzgrenze";
            mySheet.Cells[15,1] = "Zugfestigkeit";
            mySheet.Cells[16,1] = "";
            mySheet.Cells[17,1] = "Preis (Netto)";
            mySheet.Cells[18,1] = "Summe";
            mySheet.Cells[19,1] = "Stückpreis";
            mySheet.Cells[20,1] = "";
            mySheet.Cells[21,1] = "Preis (Brutto)";
            mySheet.Cells[22,1] = "Summe";
            mySheet.Cells[23,1] = "Stückpreis";
            mySheet.Cells[35,1] = "ANmerkung";

            // Werte der Schrauben arr in Tabelle eingeben 

            for (int i = 1; i>= anzahl; i++)
            {

                mySheet.Cells[3,i+1] = "";
                mySheet.Cells[4,1] = "Schlüsselweite";
                mySheet.Cells[5,1] = "Gewindedurchmesser";
                mySheet.Cells[6,1] = "Masse pro Stück";
                mySheet.Cells[7,1] = "Gesamtgewicht";
                mySheet.Cells[8,1] = "Steigung";
                mySheet.Cells[9,1] = "Gewindetiefe";
                mySheet.Cells[10,1] = "Rundung";
                mySheet.Cells[11,1] = "Flankendurchmesser";
                mySheet.Cells[12,1] = "Flankenwinkel";
                mySheet.Cells[13,1] = "";
                mySheet.Cells[14,1] = "Elastizitätzgrenze";
                mySheet.Cells[15,1] = "Zugfestigkeit";
                mySheet.Cells[16,1] = "";
                mySheet.Cells[17,1] = "Preis (Netto)";
                mySheet.Cells[18,1] = "Summe";
                mySheet.Cells[19,1] = "Stückpreis";
                mySheet.Cells[20,1] = "";
                mySheet.Cells[21,1] = "Preis (Brutto)";
                mySheet.Cells[22,1] = "Summe";
                mySheet.Cells[23,1] = "Stückpreis";

                
                

            }
            //ANmerkungen 
             mySheet.Cells[25,2].AddComment(Anmerkung);
            
           

           // Design  

            // Schrauben Durchnummerieren 
            mySheet.Range["A1","E25"].AutoFormat(Excel.XlRangeAutoFormat.xlRangeAutoFormatList2);

            for (int i=1; i<= anzahl; i++)
            {
                mySheet.Cells[1, 1+i] = "Schraube " +i+"    ";
            }
            

            // Zellenbreite an Text anpassen 
            for (int i = 1; i<9; i++)
            {
                mySheet.Columns[i].AutoFit();
            }
            
            // Excel abspeichern 
            mySheet.SaveAs(@"C:\Excel\Bestellung.xlsx");

            
            // Excel muss noch geschlossen werden 
           
           Console.ReadKey();
           Console.WriteLine("Email senden");
            
        }

         public static void emailsenden()

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
            Mail.To.Add("jonathan.rietig@aol.de");

            // Betreff

            Mail.Subject = betreff;

            Mail.Body = text;

           Attachment Tabelle = new Attachment(@"C:\Excel\Bestellung.xlsx");

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

