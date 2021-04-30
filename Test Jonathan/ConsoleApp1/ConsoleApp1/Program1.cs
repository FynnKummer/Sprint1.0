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
        }
    }

    class ExcelControll
    {
        public static void Excel_erstellen()
        {
            new ExcelControll();
        }

        ExcelControll()
        {
            int anzahl = 4;
            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = true;
            excelApp.Workbooks.Add();

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

           // Design festlegen 
            mySheet.Range["A1","E25"].AutoFormat(Excel.XlRangeAutoFormat.xlRangeAutoFormatList2);

            for (int i=1; i<= anzahl; i++)
            {
                mySheet.Cells[1, 1+i] = "Schraube " +i+"    ";
            }
            

            for (int i = 1; i<9; i++)
            {
                mySheet.Columns[i].AutoFit();
            }
            

        }

         public static void emailsenden( string text)

        {
            
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

