using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schraubengott
{
    class Schraube
    {
        public string name; // Vom Benutzer festgeleter Name für die Schraube
        public int menge;
        public int laenge;
        public double volumen;
        public int schluesselbreite;
        public string typ; //Innensechskant/Ausßensechskant
        public string festigkeit;
        public string festaus;//Festigkeitsklasse ausgeschrieben

        public string gewindeart;
        public int gewindelaenge;
        public double gewindesteigung;
        public string gewinde;
        public double gewindetiefe;  //  belegt 
        public double gewinderundung; //  belegt 
        public double flankendurchmesser; //  belegt 
        public double kerndurchmesser; //  belegt 
        public double flankenwinkel;  //belegt

        public double elastizitätsgrenze; // belegt
        public double Zugfestigkeit; //belegt


        public string material;
        public string mataus;//Material ausgeschrieben
        public double dichte;
        public double masse;
        public double gesamtgewicht;

        public double preis_summe;  //
        public double stückpreis; //
        public double nettopreis_Summe;  // belegt
        public double nettoeinzelpreis;  //belegt
        
        //Auswahlen der Comboboxen den Variablen zuweisen
        public void gewinde_festlegen(string gew)
        {
            this.gewinde = gew;
        }
        public void kopf_festlegen(string kopf)
        {
            this.typ = kopf;

        }
        public void festigkeit_festlegen(string fest)
        {
            this.festigkeit = fest;
        }

        //Eingaben der Textboxen den Variablen zuweisen
        public void laenge_festlegen(int laenge)
        {

        }
        public void gewlen_festlegen(int gewlen)
        {
            
        }

        //Berechnungen 
        public void masse_berechnen()
        {
            if (this.material.Equals("Verzinkter Stahl"))
            {
                this.dichte = 0.0079; //Verzinkt
            }
            else if (this.material.Equals("V2A"))
            {
                this.dichte = 0.0079; //V2A
            }
            else
            {
                this.dichte = 0.008; //V4A
            }
        }
        public void vol_berechnen()
        {
            double volumen_schraubenkopf;
            double volumen_schaft;

            switch (this.gewinde)
            {
                case "M4":
                    if (this.typ.Equals("Außensechskant")) //Für Außensechskant
                    {
                        volumen_schraubenkopf = 108.9508;
                        volumen_schaft = Math.PI / 4 * (3.55 * 3.55) * gewindelaenge + (laenge - gewindelaenge) * Math.PI / 4 * (4 * 4);
                        this.volumen = volumen_schraubenkopf + volumen_schaft;
                    }
                    else //Für Innensechskant
                    {
                        volumen_schraubenkopf = 138.3500;
                        volumen_schaft = Math.PI / 4 * (3.55 * 3.55) * gewindelaenge + (laenge - gewindelaenge) * Math.PI / 4 * (4 * 4);
                        this.volumen = volumen_schraubenkopf + volumen_schaft;
                    }
                    break;

                case "M5":
                    if (this.typ.Equals("Außensechskant")) //Für Außensechskant
                    {
                        volumen_schraubenkopf = 178.8570;
                        volumen_schaft = Math.PI / 4 * (4.48 * 4.48) * gewindelaenge + (laenge - gewindelaenge) * Math.PI / 4 * (5 * 5);
                        this.volumen = volumen_schraubenkopf + volumen_schaft;
                    }
                    else //Für Innensechskant
                    {
                        volumen_schraubenkopf = 249.0851;
                        volumen_schaft = Math.PI / 4 * (4.48 * 4.48) * gewindelaenge + (laenge - gewindelaenge) * Math.PI / 4 * (5 * 5);
                        this.volumen = volumen_schraubenkopf + volumen_schaft;
                    }
                    break;

                case "M6":
                    if (this.typ.Equals("Außensechskant")) //Für Außensechskant
                    {
                        volumen_schraubenkopf = 317.2320;
                        volumen_schaft = Math.PI / 4 * (5.35 * 5.35) * gewindelaenge + (laenge - gewindelaenge) * Math.PI / 4 * (6 * 6);
                        this.volumen = volumen_schraubenkopf + volumen_schaft;
                    }
                    else //Für Innensechskant
                    {
                        volumen_schraubenkopf = 406.2859;
                        volumen_schaft = Math.PI / 4 * (5.35 * 5.35) * gewindelaenge + (laenge - gewindelaenge) * Math.PI / 4 * (6 * 6);
                        this.volumen = volumen_schraubenkopf + volumen_schaft;
                    }
                    break;

                case "M8":
                    if (this.typ.Equals("Außensechskant")) //Für Außensechskant
                    {
                        volumen_schraubenkopf = 738.7050;
                        volumen_schaft = Math.PI / 4 * (7.19 * 7.19) * gewindelaenge + (laenge - gewindelaenge) * Math.PI / 4 * (8 * 8);
                        this.volumen = volumen_schraubenkopf + volumen_schaft;
                    }
                    else //Für Innensechskant
                    {
                        volumen_schraubenkopf = 937.1503;
                        volumen_schaft = Math.PI / 4 * (7.19 * 7.19) * gewindelaenge + (laenge - gewindelaenge) * Math.PI / 4 * (8 * 8);
                        this.volumen = volumen_schraubenkopf + volumen_schaft;
                    }
                    break;

                case "M10":
                    if (this.typ.Equals("Außensechskant")) //Für Außensechskant
                    {
                        volumen_schraubenkopf = 1624.1050;
                        volumen_schaft = Math.PI / 4 * (9.03 * 9.03) * gewindelaenge + (laenge - gewindelaenge) * Math.PI / 4 * (10 * 10);
                        this.volumen = volumen_schraubenkopf + volumen_schaft;
                    }
                    else //Für Innensechskant
                    {
                        volumen_schraubenkopf = 1733.4893;
                        volumen_schaft = Math.PI / 4 * (9.03 * 9.03) * gewindelaenge + (laenge - gewindelaenge) * Math.PI / 4 * (10 * 10);
                        this.volumen = volumen_schraubenkopf + volumen_schaft;
                    }
                    break;

                case "M12":
                    if (this.typ.Equals("Außensechskant")) //Für Außensechskant
                    {
                        volumen_schraubenkopf = 2313.3760;
                        volumen_schaft = Math.PI / 4 * (10.86 * 10.86) * gewindelaenge + (laenge - gewindelaenge) * Math.PI / 4 * (12 * 12);
                        this.volumen = volumen_schraubenkopf + volumen_schaft;
                    }
                    else //Für Innensechskant
                    {
                        volumen_schraubenkopf = 2534.0101;
                        volumen_schaft = Math.PI / 4 * (10.86 * 10.86) * gewindelaenge + (laenge - gewindelaenge) * Math.PI / 4 * (12 * 12);
                        this.volumen = volumen_schraubenkopf + volumen_schaft;
                    }
                    break;

                case "M16":
                    if (this.typ.Equals("Außensechskant")) //Für Außensechskant
                    {
                        volumen_schraubenkopf = 4647.7100;
                        volumen_schaft = Math.PI / 4 * (14.7 * 14.7) * gewindelaenge + (laenge - gewindelaenge) * Math.PI / 4 * (16 * 16);
                        this.volumen = volumen_schraubenkopf + volumen_schaft;
                    }
                    else //Für Innensechskant
                    {
                        volumen_schraubenkopf = 5540.8195;
                        volumen_schaft = Math.PI / 4 * (14.7 * 14.7) * gewindelaenge + (laenge - gewindelaenge) * Math.PI / 4 * (16 * 16);
                        this.volumen = volumen_schraubenkopf + volumen_schaft;
                    }
                    break;

                case "M20":
                    if (this.typ.Equals("Außensechskant")) //Für Außensechskant
                    {
                        volumen_schraubenkopf = 9492.9770;
                        volumen_schaft = Math.PI / 4 * (18.38 * 18.38) * gewindelaenge + (laenge - gewindelaenge) * Math.PI / 4 * (20 * 20);
                        this.volumen = volumen_schraubenkopf + volumen_schaft;
                    }
                    else //Für Innensechskant
                    {
                        volumen_schraubenkopf = 11634.3569;
                        volumen_schaft = Math.PI / 4 * (18.38 * 18.38) * gewindelaenge + (laenge - gewindelaenge) * Math.PI / 4 * (20 * 20);
                        this.volumen = volumen_schraubenkopf + volumen_schaft;
                    }
                    break;
            }
        }

    }
    /*  public void preis_berechnen()//eventuell für jede Preisvariable eine eigene Methode
      {
      // Variablen festlegen
      double preis = 0;
      double kilopreis, nettoeinzelpreis, nettokilopreis, netto50, netto100, Nettobestellpreis, einzelpreis, preis50, preis100, Bestellpreis, massekilo;

      // Aufpreise festlegen
      const double aufpreis_Innensechskannt = 0.21;
      const double aufpreis_Teilgewinde = 0.16;
      const double aufpreis_Feingewinde = 0.27;
      const double kilopreis_verzinkt = 12.12;
      const double kilopreis_V2A = 26.78;
      const double kilopreis_V4A = 35.56;
      const double mws = 1.19;

      //Grundpreis nach Material
      if (this.material.Equals("1"))
      {                                           // Verzinkte Schraube 
          preis = kilopreis_verzinkt;
      }
      else if (this.material.Equals("2")) //hier fehlt die Bedingung
      {
          preis = kilopreis_V2A;                     // Edelstahlschraube 
      }
      else
      {
          preis = kilopreis_V4A;
      }

      // Aufpreise 
      // Teilgewindelänge 
      if (this.gewindelaenge != laenge)
      {
          preis = preis + aufpreis_Teilgewinde;
      }

      // Innensechskant
      if (this.typ.Equals("I", StringComparison.InvariantCultureIgnoreCase))
      {
          preis = preis + aufpreis_Innensechskannt;
      }

      // Feingewinde 
      if (this.gewindeart.Equals("F", StringComparison.InvariantCultureIgnoreCase))
      {
          preis = preis + aufpreis_Feingewinde;
      }

      // Preisvarianten berechnen            
      massekilo = 0.001 * masse;

      nettokilopreis = preis;
      nettoeinzelpreis = nettokilopreis * massekilo;
      netto50 = 50 * nettoeinzelpreis;
      netto100 = 100 * nettoeinzelpreis;
      Nettobestellpreis = menge * nettoeinzelpreis;

      einzelpreis = nettoeinzelpreis * mws;
      kilopreis = nettokilopreis * mws;
      preis50 = netto50 * mws;
      preis100 = netto100 * mws;
      Bestellpreis = einzelpreis * menge;

      // Objekt 

      this.preis_summe = Bestellpreis;
      this.stückpreis = einzelpreis;
      this.nettopreis_Summe = Nettobestellpreis;
      this.nettoeinzelpreis = nettoeinzelpreis;

      // Ausgabe der Preise            
      string summenenstring = "Summe (" + this.menge + "Stück):";

      Console.WriteLine(" Preise:");
      Console.WriteLine();
      Console.WriteLine("  Nettopreise                                  Preise inkl. Mehrwertsteuer");
      Console.WriteLine();
      Console.WriteLine("  {0,-18} {1,8:f} EUR {2} {0,-18} {3,8:f} EUR", summenenstring, Math.Round(Nettobestellpreis, 2), "            ", Math.Round(Bestellpreis));
      Console.WriteLine("  {0,-18} {1,8:f} EUR {2} {0,-18} {3,8:f} EUR", "Stückpreis:", Math.Round(nettoeinzelpreis, 2), "            ", Math.Round(einzelpreis, 2));
      Console.WriteLine("  {0,-18} {1,8:f} EUR {2} {0,-18} {3,8:f} EUR ", "Kilopreis:", Math.Round(nettokilopreis, 2), "            ", Math.Round(kilopreis, 2));
      Console.WriteLine("  {0,-18} {1,8:f} EUR {2} {0,-18} {3,8:f} EUR", "Preis 50 Stück:", Math.Round(netto50, 2), "            ", Math.Round(preis50, 2));
      Console.WriteLine("  {0,-18} {1,8:f} EUR {2} {0,-18} {3,8:f} EUR ", "Preis 100 Stück:", Math.Round(netto100, 2), "            ", Math.Round(preis100, 2));
  }


  }

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

    /*

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
*/
    }


