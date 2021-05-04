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
             // Bestellnummer 

            Random nummer = new Random();
            Int32 bestellnummer = nummer.Next(10000000,99999999);
            Console.WriteLine("Bestellnummer: "+bestellnummer);
            Console.ReadKey();


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


             // Als Liste Formartieren  
            mySheet.Range["A1","F26"].AutoFormat(Excel.XlRangeAutoFormat.xlRangeAutoFormatList1);

            // Werte der Schrauben arr in Tabelle eingeben 
 
           for (int i = 1; i <= anzahl; i++)
            {
                mySheet.Cells[1, i + 1] = "Schraubennahme S" + i;
                mySheet.Cells[3, i+1] = "Schraubenlänge S" + i;
                mySheet.Cells[4, i+1] = "Schlüsselweite S" + i;
                mySheet.Cells[5, i+1] = "Gewindedurchmesser S" + i;
                mySheet.Cells[6, i+1] = "Masse pro Stück S" + i;
                mySheet.Cells[7, i+1] = "Gesamtgewicht S" + i;
                mySheet.Cells[8, i+1] = "Steigung S" + i;
                mySheet.Cells[9, i+1] = "Gewindetiefe S" + i;
                mySheet.Cells[10, i+1] = "Rundung S" + i;
                mySheet.Cells[11, i+1] = "Flankendurchmesser S" + i;
                mySheet.Cells[12, i+1] = "Flankenwinkel S" + i;
                mySheet.Cells[13, i+1] = "";
                mySheet.Cells[14, i+1] = "Elastizitätzgrenze S" + i;
                mySheet.Cells[15, i+1] = "Zugfestigkeit S" + i;
                mySheet.Cells[16, i+1] = "";
                mySheet.Cells[17, i+1] = "Preis (Netto) S" + i;
                mySheet.Cells[18, i+1] = "Summe S" + i;
                mySheet.Cells[19, i+1] = "Stückpreis S" + i;
                mySheet.Cells[20, i+1] = "";
                mySheet.Cells[21, i+1] = "Preis (Brutto) S" + i;
                mySheet.Cells[22, i+1] = "Summe S" + i;
                mySheet.Cells[23, i+1] = "Stückpreis S" + i;
            }


            //ANmerkungen 
             mySheet.Cells[23,2].AddComment(Anmerkung);
            
          

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
    class Walkthrough
    {
        static void Main(string[] args)
        {
            // Create a list of accounts.
            var bankAccounts = new List<Account>
            {
                new Account {
                              ID = 345678,
                              Balance = 541.27
                            },
                new Account {
                              ID = 1230221,
                              Balance = -127.44
                            }
            };

            // Display the list in an Excel spreadsheet.
            DisplayInExcel(bankAccounts);

            // Create a Word document that contains an icon that links to
            // the spreadsheet.
            CreateIconInWordDoc();
        }

        static void DisplayInExcel(IEnumerable<Account> accounts)
        {
            var excelApp = new Excel.Application();
            // Make the object visible.
            excelApp.Visible = true;

            // Create a new, empty workbook and add it to the collection returned
            // by property Workbooks. The new workbook becomes the active workbook.
            // Add has an optional parameter for specifying a praticular template.
            // Because no argument is sent in this example, Add creates a new workbook.
            excelApp.Workbooks.Add();

            // This example uses a single workSheet.
            Excel._Worksheet workSheet = excelApp.ActiveSheet;

            // Earlier versions of C# require explicit casting.
            //Excel._Worksheet workSheet = (Excel.Worksheet)excelApp.ActiveSheet;

            // Establish column headings in cells A1 and B1.
            workSheet.Cells[1, "A"] = "ID Number";
            workSheet.Cells[1, "B"] = "Current Balance";

            var row = 1;
            foreach (var acct in accounts)
            {
                row++;
                workSheet.Cells[row, "A"] = acct.ID;
                workSheet.Cells[row, "B"] = acct.Balance;
            }

            workSheet.Columns[1].AutoFit();
            workSheet.Columns[2].AutoFit();

            // Call to AutoFormat in Visual C#. This statement replaces the
            // two calls to AutoFit.
            workSheet.Range["A1", "B3"].AutoFormat(
                Excel.XlRangeAutoFormat.xlRangeAutoFormatClassic2);

            // Put the spreadsheet contents on the clipboard. The Copy method has one
            // optional parameter for specifying a destination. Because no argument
            // is sent, the destination is the Clipboard.
            workSheet.Range["A1:B3"].Copy();
        }

        static void CreateIconInWordDoc()
        {
            var wordApp = new Word.Application();
            wordApp.Visible = true;

            // The Add method has four reference parameters, all of which are
            // optional. Visual C# allows you to omit arguments for them if
            // the default values are what you want.
            wordApp.Documents.Add();

            // PasteSpecial has seven reference parameters, all of which are
            // optional. This example uses named arguments to specify values
            // for two of the parameters. Although these are reference
            // parameters, you do not need to use the ref keyword, or to create
            // variables to send in as arguments. You can send the values directly.
            wordApp.Selection.PasteSpecial(Link: true, DisplayAsIcon: true);
        }
    }
    class Walkthrough
    {
        static void Main(string[] args)
        {
            // Create a list of accounts.
            var bankAccounts = new List<Account>
            {
                new Account {
                              ID = 345678,
                              Balance = 541.27
                            },
                new Account {
                              ID = 1230221,
                              Balance = -127.44
                            }
            };

            // Display the list in an Excel spreadsheet.
            DisplayInExcel(bankAccounts);

            // Create a Word document that contains an icon that links to
            // the spreadsheet.
            CreateIconInWordDoc();
        }

        static void DisplayInExcel(IEnumerable<Account> accounts)
        {
            var excelApp = new Excel.Application();
            // Make the object visible.
            excelApp.Visible = true;

            // Create a new, empty workbook and add it to the collection returned
            // by property Workbooks. The new workbook becomes the active workbook.
            // Add has an optional parameter for specifying a praticular template.
            // Because no argument is sent in this example, Add creates a new workbook.
            excelApp.Workbooks.Add();

            // This example uses a single workSheet.
            Excel._Worksheet workSheet = excelApp.ActiveSheet;

            // Earlier versions of C# require explicit casting.
            //Excel._Worksheet workSheet = (Excel.Worksheet)excelApp.ActiveSheet;

            // Establish column headings in cells A1 and B1.
            workSheet.Cells[1, "A"] = "ID Number";
            workSheet.Cells[1, "B"] = "Current Balance";

            var row = 1;
            foreach (var acct in accounts)
            {
                row++;
                workSheet.Cells[row, "A"] = acct.ID;
                workSheet.Cells[row, "B"] = acct.Balance;
            }

            workSheet.Columns[1].AutoFit();
            workSheet.Columns[2].AutoFit();

            // Call to AutoFormat in Visual C#. This statement replaces the
            // two calls to AutoFit.
            workSheet.Range["A1", "B3"].AutoFormat(
                Excel.XlRangeAutoFormat.xlRangeAutoFormatClassic2);

            // Put the spreadsheet contents on the clipboard. The Copy method has one
            // optional parameter for specifying a destination. Because no argument
            // is sent, the destination is the Clipboard.
            workSheet.Range["A1:B3"].Copy();
        }

        static void CreateIconInWordDoc()
        {
            var wordApp = new Word.Application();
            wordApp.Visible = true;

            // The Add method has four reference parameters, all of which are
            // optional. Visual C# allows you to omit arguments for them if
            // the default values are what you want.
            wordApp.Documents.Add();

            // PasteSpecial has seven reference parameters, all of which are
            // optional. This example uses named arguments to specify values
            // for two of the parameters. Although these are reference
            // parameters, you do not need to use the ref keyword, or to create
            // variables to send in as arguments. You can send the values directly.
            wordApp.Selection.PasteSpecial(Link: true, DisplayAsIcon: true);
        }
    }
    class Walkthrough
    {
        static void Main(string[] args)
        {
            // Create a list of accounts.
            var bankAccounts = new List<Account>
            {
                new Account {
                              ID = 345678,
                              Balance = 541.27
                            },
                new Account {
                              ID = 1230221,
                              Balance = -127.44
                            }
            };

            // Display the list in an Excel spreadsheet.
            DisplayInExcel(bankAccounts);

            // Create a Word document that contains an icon that links to
            // the spreadsheet.
            CreateIconInWordDoc();
        }

        static void DisplayInExcel(IEnumerable<Account> accounts)
        {
            var excelApp = new Excel.Application();
            // Make the object visible.
            excelApp.Visible = true;

            // Create a new, empty workbook and add it to the collection returned
            // by property Workbooks. The new workbook becomes the active workbook.
            // Add has an optional parameter for specifying a praticular template.
            // Because no argument is sent in this example, Add creates a new workbook.
            excelApp.Workbooks.Add();

            // This example uses a single workSheet.
            Excel._Worksheet workSheet = excelApp.ActiveSheet;

            // Earlier versions of C# require explicit casting.
            //Excel._Worksheet workSheet = (Excel.Worksheet)excelApp.ActiveSheet;

            // Establish column headings in cells A1 and B1.
            workSheet.Cells[1, "A"] = "ID Number";
            workSheet.Cells[1, "B"] = "Current Balance";

            var row = 1;
            foreach (var acct in accounts)
            {
                row++;
                workSheet.Cells[row, "A"] = acct.ID;
                workSheet.Cells[row, "B"] = acct.Balance;
            }

            workSheet.Columns[1].AutoFit();
            workSheet.Columns[2].AutoFit();

            // Call to AutoFormat in Visual C#. This statement replaces the
            // two calls to AutoFit.
            workSheet.Range["A1", "B3"].AutoFormat(
                Excel.XlRangeAutoFormat.xlRangeAutoFormatClassic2);

            // Put the spreadsheet contents on the clipboard. The Copy method has one
            // optional parameter for specifying a destination. Because no argument
            // is sent, the destination is the Clipboard.
            workSheet.Range["A1:B3"].Copy();
        }

        static void CreateIconInWordDoc()
        {
            var wordApp = new Word.Application();
            wordApp.Visible = true;

            // The Add method has four reference parameters, all of which are
            // optional. Visual C# allows you to omit arguments for them if
            // the default values are what you want.
            wordApp.Documents.Add();

            // PasteSpecial has seven reference parameters, all of which are
            // optional. This example uses named arguments to specify values
            // for two of the parameters. Although these are reference
            // parameters, you do not need to use the ref keyword, or to create
            // variables to send in as arguments. You can send the values directly.
            wordApp.Selection.PasteSpecial(Link: true, DisplayAsIcon: true);
        }
    }

}


