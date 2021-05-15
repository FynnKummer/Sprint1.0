using System;
using System.Net.Mail;
using Excel = Microsoft.Office.Interop.Excel;

class ExcelControll
{
    public static void ExelContoll_aufrufen(Schraube[] arr, bool senden, int bestellnummer, string kundennummer)
    {
        Excel_erstellen(arr, senden, bestellnummer, kundennummer);
    }
    public static void Excel_erstellen(Schraube[] arr, bool senden, int bestellnummer, string Kundennummer)
    {
        new ExcelControll(arr, senden, bestellnummer, Kundennummer);
    }

    ExcelControll(Schraube[] arr, bool senden, int bestellnummer, string kundennummer)
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

        mySheet.Cells[2, 1] = "Material";
        mySheet.Cells[3, 1] = "Festigkeitsklasse";
        mySheet.Cells[4, 1] = "Schraubenkopf";
        mySheet.Cells[5, 1] = "Gewinde";
        mySheet.Cells[6, 1] = "Gewindetyp";
        mySheet.Cells[7, 1] = "Schraubenlänge (mm)";
        mySheet.Cells[8, 1] = "Gewindelänge (mm)";
        mySheet.Cells[9, 1] = "Menge (St.)";
        mySheet.Cells[10, 1] = "";
        mySheet.Cells[11, 1] = "Preise (€)";
        mySheet.Cells[12, 1] = "Summe (netto)";
        mySheet.Cells[13, 1] = "Stückpreis (netto)";
        mySheet.Cells[14, 1] = "";
        mySheet.Cells[15, 1] = "Summe (brutto)";
        mySheet.Cells[16, 1] = "Stückpreis (brutto)";
        mySheet.Cells[17, 1] = "";
        mySheet.Cells[18, 1] = "Bestellsumme";
        mySheet.Cells[19, 1] = "";
        mySheet.Cells[20, 1] = "";
        mySheet.Cells[21, 1] = "";
        mySheet.Cells[22, 1] = "Technische Details";
        mySheet.Cells[23, 1] = "Schlüsselweite (mm)";
        mySheet.Cells[24, 1] = "Masse pro Stück (g)";
        mySheet.Cells[25, 1] = "Gesamtgewicht (g)";
        mySheet.Cells[26, 1] = "Gewindesteigung (mm)";
        mySheet.Cells[27, 1] = "Gewindetiefe (mm)";
        mySheet.Cells[28, 1] = "Rundung (mm)";
        mySheet.Cells[29, 1] = "Flankendurchmesser (mm)";
        mySheet.Cells[30, 1] = "Flankenwinkel (°)";
        mySheet.Cells[31, 1] = "";
        mySheet.Cells[32, 1] = "Elastizitätsgrenze (N/mm²)";
        mySheet.Cells[33, 1] = "Zugfestigkeit (N/mm²)";


        // Listenformat einführen 
        mySheet.Range["A1", "F19"].AutoFormat(Excel.XlRangeAutoFormat.xlRangeAutoFormatList2);
        mySheet.Range["A22", "F34"].AutoFormat(Excel.XlRangeAutoFormat.xlRangeAutoFormatList2);

        double summe = 0;

        // Werte der Schrauben in Tabelle eingeben 
        for (int i = 0; i < arr.Length; i++)
        {

            summe = summe + arr[i].nettopreis_Summe;
            mySheet.Cells[1, i + 2] = "Schraube " + (i + 1);
            mySheet.Cells[2, i + 2] = arr[i].material;
            mySheet.Cells[3, i + 2] = arr[i].festigkeit;
            mySheet.Cells[4, i + 2] = arr[i].typ;
            mySheet.Cells[5, i + 2] = arr[i].gewinde;
            mySheet.Cells[6, i + 2] = arr[i].gewindeart;
            mySheet.Cells[7, i + 2] = arr[i].laenge;
            mySheet.Cells[8, i + 2] = arr[i].gewindelaenge;
            mySheet.Cells[9, i + 2] = arr[i].menge;
            mySheet.Cells[10, i + 2] = "";
            mySheet.Cells[11, i + 2] = "";
            mySheet.Cells[12, i + 2] = Math.Round(arr[i].nettopreis_Summe, 2);
            mySheet.Cells[13, i + 2] = Math.Round(arr[i].nettoeinzelpreis, 2);
            mySheet.Cells[14, i + 2] = "";
            mySheet.Cells[15, i + 2] = Math.Round(arr[i].preis_summe, 2);
            mySheet.Cells[16, i + 2] = Math.Round(arr[i].stückpreis, 2);
            mySheet.Cells[17, i + 2] = "";
            // Summe 
            mySheet.Cells[19, i + 2].AddComment("Test");
            mySheet.Cells[20, i + 2] = "";
            mySheet.Cells[21, i + 2] = "";
            mySheet.Cells[22, i + 2] = "";
            mySheet.Cells[23, i + 2] = arr[i].schluesselbreite;
            mySheet.Cells[24, i + 2] = Math.Round(arr[i].masse, 2);
            mySheet.Cells[25, i + 2] = Math.Round(arr[i].gesamtgewicht, 2);
            mySheet.Cells[26, i + 2] = Math.Round(arr[i].gewindesteigung, 2);
            mySheet.Cells[27, i + 2] = Math.Round(arr[i].gewindetiefe, 2);
            mySheet.Cells[28, i + 2] = Math.Round(arr[i].gewinderundung, 2);
            mySheet.Cells[29, i + 2] = Math.Round(arr[i].flankendurchmesser, 2);
            mySheet.Cells[30, i + 2] = Math.Round(arr[i].flankenwinkel, 2);
            mySheet.Cells[31, i + 2] = "";
            mySheet.Cells[32, i + 2] = Math.Round(arr[i].elastizitätsgrenze, 2);
            mySheet.Cells[33, i + 2] = Math.Round(arr[i].Zugfestigkeit, 2);
        }

        mySheet.Cells[18, 6] = Math.Round(summe, 2);


        // Zellenbreite an Text anpassen 
        for (int i = 1; i < 9; i++)
        {
            mySheet.Columns[i].AutoFit();
        }

        if (senden == true)
        {
            mySheet.SaveAs(@"C:\Windows\Temp\Bestellung " + Convert.ToString(bestellnummer) + "(" + kundennummer + ").xlsx");

            excelApp.Workbooks.Close();

            Emailsenden(bestellnummer, kundennummer);
        }

    }

    public static void Emailsenden(int bestellnummer, string Kundennummer)
    {
        string text = "Anfrage";
        string betreff = "Anfrage (" + Kundennummer + ")";
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

        Attachment Tabelle = new Attachment(@"C:\Windows\Temp\Bestellung " + Convert.ToString(bestellnummer) + "(" + Kundennummer + ").xlsx");

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