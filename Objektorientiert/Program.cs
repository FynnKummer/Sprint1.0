using System;
using System.Linq;
using System.Net.Mail;
using Excel = Microsoft.Office.Interop.Excel;

namespace Objektorientiert
{
    public class Program
    {
        public static void Main(string[] args)     //Hauptprogramm
        {
            Console.WriteLine("Wie viel verscheidene Schrauben möchten Sie konfigurieren");
            
             Schraube[] arr = new Schraube[Convert.ToInt32(Console.ReadLine())];


            for (int s = 0; s < arr.Length; s++)
            {
                Console.WriteLine("Gegen Sie den Namen der " + (s+1) + ". Schraube ein");
                 arr[s] = new Schraube(Console.ReadLine());


                //Abfrage der Werte                                                  
                arr[s].mat();    //Abfrage und Festlegung des Materials                                                                                                                                                         
                arr[s].fest();   //Abfrage und Festlegung des Festigkeitsklasse 
                arr[s].type();   //Abfrage und Festlegung des Schraubenkopfes
                arr[s].gew();    //Abfrage und Festlegung des Gewindes (z.B. M8)           
                arr[s].len();    //Abfrage und Festlegung des Schraubenlänge           
                arr[s].gewlen(); //Abfrage und Festlegung des Gewindelängen           
                arr[s].gewart(); //Abfrage und Festlegung des Gewindeart (FG/SG)           
                arr[s].amount(); //Abfrage und Festlegung des Schraubenanzahl          

                Console.Clear();    //Konsole bereinigen

                //Ausgabe der Eingabewerte
                arr[s].ausgabe_festigkeitsklasse();
                arr[s].ausgabe_material();
                Console.WriteLine("\nGewählte Schraube: " + arr[s].mataus + " Festigkeitsklasse: " + arr[s].festaus + " " + arr[s].ausgabe_schraubenkopf() + " " + arr[s].ausgabe_gewindeart() + " " + arr[s].gewinde + "x" + arr[s].laenge + "mm mit " + arr[s].gewindelaenge + "mm Gewinde\n");

                //Werte berechnen
                arr[s].density();
                arr[s].vol();
                arr[s].masse = arr[s].dichte / arr[s].volumen;

                arr[s].geometrie();

                //Ausgabe der Festigkeiten der Schraube
                arr[s].festigkeitausgabe();


                //Preis berechnen und ausgeben
                arr[s].Preis();

            }
            
            ExcelControll.Excel_erstellen(arr);

            Console.ReadKey();
        }   //Hauptprogramm Ende
    }

    class Schraube
    {
        public String name; // Vom Benutzer festgeleter Name für die Schraube
        public int menge;
        public int laenge;
        public double volumen;
        public int schluesselbreite;
        public String typ;      //Innensechskant/Ausßensechskant
        public String festigkeit;
        public String festaus;//Festigkeitsklasse ausgeschrieben

        public String gewindeart;
        public int gewindelaenge;
        public double gewindesteigung;
        public String gewinde;

        public String material;
        public String mataus;//Material ausgeschrieben
        public double dichte;
        public double masse;
        public double gesamtgewicht;

        public Schraube(String name) // Konstruktor
        {
            this.name = name;
        }


        //Abfrage von Werten

        public void mat()
        {
            bool loop = false;  //Variable für die Schleife

            do //Schleife bis ein richtiger Wert eigegeben wird
            {
                Console.WriteLine("Welches Material hat die Schraube?");
                Console.WriteLine("'1' = Verzinkter Stahl");
                Console.WriteLine("'2' = V2A");
                Console.WriteLine("'3' = V4A");
                this.material = Console.ReadLine(); //String einlesen

                if (this.material.Equals("1") || this.material.Equals("2") || this.material.Equals("3"))   //Richtige Eingabe
                {
                    loop = false;
                }
                else //Falsche Eingabe
                {
                    Console.WriteLine("Falsche Eingabe");
                    loop = true;
                }
            } while (loop == true);

        }    //Abfrage und Festlegung des Materials  

        public void fest()
        {
            bool loop = false;  //Variable für die Schleife
            String[] festigkeitsklassen = { "1", "2", "3", "5.8", "6.8", "8.8", "9.8", "10.9", "12.9" };

            do //Schleife bis ein richtiger Wert eigegeben wird
            {
                switch (this.material) //Abfrage der Festigkeitsklasse abhängig vom Material
                {
                    case "1":
                        Console.WriteLine("Welche Festigkeitsklasse hat die Schraube?");
                        Console.WriteLine("Mögliche Eingaben:");
                        Console.WriteLine("5.8 6.8 8.8 9.8 10.9 12.9");
                        this.festigkeit = Console.ReadLine(); //String einlesen 
                        break;

                    case "2":
                        Console.WriteLine("Welche Festigkeitsklasse hat die Schraube?");
                        Console.WriteLine("Mögliche Eingaben:");
                        Console.WriteLine("'1' = A2-50");
                        Console.WriteLine("'2' = A2-70");
                        this.festigkeit = Console.ReadLine(); //String einlesen 
                        break;

                    case "3":
                        this.festigkeit = "3"; //"3" = A4-50
                        break;
                }

                if (feld_legit(festigkeitsklassen, this.festigkeit))  //Richtige Eingaben
                {
                    loop = false;
                }
                else //Falsche Eingabe
                {
                    Console.WriteLine("Falsche Eingabe");
                    loop = true;
                }
            } while (loop == true);
        }   //Abfrage und Festlegung des Festigkeitsklasse 

        public void type()
        {
            bool loop = false;  //Variable für die Schleife

            do //Schleife bis ein richtiger Wert eigegeben wird
            {
                Console.WriteLine("Welchen Kopf hat die Schraube?");
                Console.WriteLine("'A' = Außenseckskant");
                Console.WriteLine("'I' = Innensechskant");
                this.typ = Console.ReadLine();      //String einlesen

                if (this.typ.Equals("A") || this.typ.Equals("I"))   //Richtige Eingabe
                {
                    loop = false;
                }
                else //Falsche Eingabe
                {
                    Console.WriteLine("Falsche Eingabe");
                    loop = true;
                }
            } while (loop == true);
        }   //Abfrage und Festlegung des Schraubenkopfes

        public void gew()
        {
            String[] feld = { "M4", "M5", "M6", "M8", "M10", "M12", "M16", "M20" };
            bool loop = false;  //Variable für die Schleife

            do //Schleife bis ein richtiger Wert eigegeben wird
            {
                Console.WriteLine("Welches Gewinde hat die Schraube?");
                Console.WriteLine("Mögliche Eingaben:");
                Console.WriteLine("M4 M5 M6 M8 M10 M12 M16 M20");
                this.gewinde = Console.ReadLine();      //String einlesen

                if (feld_legit(feld, this.gewinde))    //Richtige Eingabe
                {
                    loop = false;
                }
                else //falsche Eingabe
                {
                    Console.WriteLine("Falsche Eingabe");
                    loop = true;
                }
            } while (loop == true);  
        }    //Abfrage und Festlegung des Gewindes (z.B. M8) 

        public void len()
        {
            string wert = "";   //Variable für den String
            bool loop = false;  //Variable für die Schleife

            do //Schleife bis ein richtiger Wert bzw. eine Zahl eingelesen wird
            {
                Console.WriteLine("Welche Länge hat die Schraube? (in mm)");
                wert = Console.ReadLine(); //String einlesen

                if (wert.All(char.IsDigit)) //Der eingelesene String ist eine Zahl
                {
                    this.laenge = Convert.ToInt32(wert); //String zu einer Zahl konvertieren
                    loop = false;
                }
                else //Der eingelesene String ist keine Zahl
                {
                    Console.WriteLine("Falsche Eingabe");
                    loop = true;
                }

                if (this.laenge > 150) //Falscher Wert
                {
                    Console.WriteLine("Die Schraube kann nicht länger als 150mm sein!");
                    loop = true;
                }
                else if (this.laenge < 4) // Schraube zu kurz
                {
                    Console.WriteLine("Die Schraube kann nicht unter 4mm lang sein!");
                    loop = true;
                }
               
            } while (loop == true);
        }    //Abfrage und Festlegung des Schraubenlänge 

        public void gewlen()
        {
            string wert = "";   //Variable für den Eingabewert
            int gewindelaenge = 0;  //Variable für die Abfrage der Gewindelänge
            bool loop = false;  //Variable für die Schleife

            do //Schleife bis ein richtiger Wert bzw. eine Zahl eingelesen wird
            {
                Console.WriteLine("Welche Gewindelänge hat die Schraube? (in mm)");
                wert = Console.ReadLine(); //String einlesen

                if (wert.All(char.IsDigit)) //Der eingelesene String ist eine Zahl
                {
                    gewindelaenge = Convert.ToInt32(wert); //String zu einer Zahl konvertieren
                    loop = false;
                }
                else //Der eingelesene String ist keine Zahl
                {
                    Console.WriteLine("Falsche Eingabe");
                    loop = true;
                }

                if (gewindelaenge > this.laenge) //Falscher Wert
                {
                    Console.WriteLine("Das Gewinde kann nicht länger als die Schraube sein!");
                    loop = true;
                }
            } while (loop == true);

            this.gewindelaenge = gewindelaenge;
        } //Abfrage und Festlegung der Gewindelängen 

        public void gewart()
        {
            bool loop = false;  //Variable für die Schleife

            do //Schleife bis ein richtiger Wert eigegeben wird
            {
                Console.WriteLine("Welche Gewindeart hat die Schraube?");
                Console.WriteLine("'1' = Standardgewinde");
                Console.WriteLine("'2' = Feingewinde");
                this.gewindeart = Console.ReadLine(); //String einlesen

                if (this.gewindeart.Equals("1") || this.gewindeart.Equals("2")) //Richtige Eingabe
                {
                    loop = false;
                }
                else //Falsche Eingabe
                {
                    Console.WriteLine("Falsche Eingabe");
                    loop = true;
                }
            } while (loop == true);
        } //Abfrage und Festlegung des Gewindeart (FG/SG) 

        public void amount()
        {
            string wert = "";   //Variable für den Eingabewert
            int menge = 0;  //Variable für die Abfrage der Menge
            bool loop = false;  //Variable für die Schleife

            do //Schleife bis ein richtiger Wert bzw. eine Zahl eingelesen wird
            {
                Console.WriteLine("Welche Anzahl an Schrauben werden benötigt?");
                wert = Console.ReadLine(); //String einlesen

                if (wert.All(char.IsDigit)) //Der eingelesene String ist eine Zahl
                {
                    menge = Convert.ToInt32(wert); //String zu einer Zahl konvertieren
                    loop = false;
                }
                else //Der eingelesene String ist keine Zahl
                {
                    Console.WriteLine("Falsche Eingabe");
                    loop = true;
                }
            } while (loop == true);

            this.menge = menge;
        } //Abfrage und Festlegung des Schraubenanzahl 

        // Bestimmung von Werten & Ausgabe 

        public void ausgabe_festigkeitsklasse() //Der Variable den richtigen Ausgabestring zuweisen
        {
            if (this.festigkeit.Equals("1"))
            {
                this.festaus = "A2-50";
            }
            else if (this.festigkeit.Equals("2"))
            {
                this.festaus = "A2-70";
            }
            else if (this.festigkeit.Equals("3"))
            {
                this.festaus = "A4-50";
            }
            else
            {
                this.festaus = this.festigkeit;
            }
        }

        public void ausgabe_material()  //Der Variable den richtigen Ausgabestring zuweisen
        {
            switch (this.material)
            {
                case "1":
                    this.mataus = "Verzinkte Stahlschraube";
                    break;
                case "2":
                    this.mataus = "V2A Schraube";
                    break;
                case "3":
                    this.mataus = "V4A Schraube";
                    break;
            }
        }

        public String ausgabe_schraubenkopf() //Der Variable den richtigen Ausgabestring zuweisen
        {
            switch (this.typ)
            {
                case "A":
                    this.typ = "Außensechskant";
                    break;
                case "I":
                    this.typ = "Innensechskant";
                    break;
            }

            return typ;
        }

        public String ausgabe_gewindeart() //Der Variable den richtigen Ausgabestring zuweisen
        {
            if (this.gewindeart.Equals("1"))
            {
                return "Standardgewinde";
            }
            return "Feingewinde";
        }

        public void density()  //Zuweisung der Dichte
        {
            if (this.material.Equals("1"))
            {
                this.dichte = 0.0079; //Verzinkt
            }
            else if (this.material.Equals("2"))
            {
                this.dichte = 0.0079; //V2A
            }
            else
            {
                this.dichte = 0.008; //V4A
            }
        }

        public void vol() //Berechnung des Volumens
        {
            double volumen_schraubenkopf;
            double volumen_schaft;

            switch (this.gewinde)
            {
                case "M4":
                    if (this.typ.Equals("A")) //Für Außensechskant
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
                    if (this.typ.Equals("A")) //Für Außensechskant
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
                    if (this.typ.Equals("A")) //Für Außensechskant
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
                    if (this.typ.Equals("A")) //Für Außensechskant
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
                    if (this.typ.Equals("A")) //Für Außensechskant
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
                    if (this.typ.Equals("A")) //Für Außensechskant
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
                    if (this.typ.Equals("A")) //Für Außensechskant
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
                    if (this.typ.Equals("A")) //Für Außensechskant
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

        public void geometrie()
        {
            double h3, r, d2, d3, flankenwikel;

            String[] feld = this.gewinde.Split('M');
            int d = Int32.Parse(feld[1]);

            //Gewindesteigung + Schlüsselbreite
            if (gewindeart.Equals("1"))
            {
                switch (this.gewinde)
                {
                    case "M4":
                        this.gewindesteigung = 0.7;
                        this.schluesselbreite = 7;
                        break;

                    case "M5":
                        this.gewindesteigung = 0.8;
                        this.schluesselbreite = 8;
                        break;

                    case "M6":
                        this.gewindesteigung = 1;
                        this.schluesselbreite = 10;
                        break;

                    case "M8":
                        this.gewindesteigung = 1.25;
                        this.schluesselbreite = 13;
                        break;

                    case "M10":
                        this.gewindesteigung = 1.5;
                        this.schluesselbreite = 17;
                        break;

                    case "M12":
                        this.gewindesteigung = 1.75;
                        this.schluesselbreite = 19;
                        break;

                    case "M16":
                        this.gewindesteigung = 2;
                        this.schluesselbreite = 24;
                        break;

                    case "M20":
                        this.gewindesteigung = 2.5;
                        this.schluesselbreite = 30;
                        break;
                }
            }

            if (this.gewindeart.Equals("2"))//Die if Schleife wird zu spät beendet
            {
                switch (this.gewinde)
                {
                    case "M4":
                        this.gewindesteigung = 0.5;
                        break;

                    case "M5":
                        this.gewindesteigung = 0.5;
                        break;

                    case "M6":
                        this.gewindesteigung = 0.75;
                        break;

                    case "M8":
                        this.gewindesteigung = 0.75;

                        break;

                    case "M10":
                        this.gewindesteigung = 1;
                        break;

                    case "M12":
                        this.gewindesteigung = 1.25;
                        break;

                    case "M16":
                        this.gewindesteigung = 1.5;
                        break;

                    case "M20":
                        this.gewindesteigung = 1.5;
                        break;
                }
            }

            // Rechnungen   
            h3 = 0.6134 * this.gewindesteigung;    // Gewindetiefe 
            r = 0.1443 * this.gewindesteigung; // Rundung
            d2 = d - 0.64595 * this.gewindesteigung;   //Flankendurchmesser 
            d3 = d - 1.2269;    //Kerndurchmesser 
            flankenwikel = 60;  //Flankenwinkel 

            // Umwandlung der Strings 
            // Gewindetyp 
            if (this.gewindeart == "1")
            {
                this.gewindeart = "(Standardgewinde)";
            }
            else
            {
                this.gewindeart = "(Feingewinde)";
            }

            // Schraubenkopf
            if (this.typ == "a" || this.typ == "A")
            {
                this.typ = "Außensechskant";
            }
            else
            {
                this.typ = "Innensechskant";
            }

            //Gewicht
            this.masse = this.volumen * this.dichte;
            this.gesamtgewicht = this.masse * this.menge;

            // Ausgabe
            Console.WriteLine(" Technische Details:\n");
            Console.WriteLine(" Schraubenlänge:       " + this.laenge + " mm");
            Console.WriteLine(" Gewindelänge:         " + this.gewindelaenge + " mm");
            Console.WriteLine(" Schlüsselweite:       " + this.schluesselbreite + "mm");
            Console.WriteLine(" Gewindedurchmesser:   " + d + " mm");
            Console.WriteLine(" Masse pro Stück:      " + Math.Round(this.masse, 2) + " g");
            Console.WriteLine(" Gesamtgewicht:        " + Math.Round(this.gesamtgewicht, 2) + " g");
            Console.WriteLine(" Steigung:             " + this.gewindesteigung + " mm");
            Console.WriteLine(" Gewindetiefe:         " + Math.Round(h3, 2) + " mm");
            Console.WriteLine(" Rundung:              " + r + " mm");
            Console.WriteLine(" Flankendurchmesser:   " + Math.Round(d2, 2) + " mm");
            Console.WriteLine(" Kerndurchmesser:      " + Math.Round(d3, 2) + " mm");
            Console.WriteLine(" Flankenwinkel:        " + flankenwikel + "°\n");
        } //Berechnungen der Geometrie + Ausgabe davon
        
        public void Preis()
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
        }//Berechnung des Preises + Ausgabe davon

        public Boolean feld_legit(String[] feld, string a)
        {
            for (int i = 0; i < feld.Length; i++)
            {
                if (a.Equals(feld[i]))
                {
                    return true;
                }
            }
            return false;
        }// Methode zum Prüfen, ob die Eingabe in einer Methode aus der möglichen Auswahl ist

        public void festigkeitausgabe()
        {
            double Rm = 0;
            double Re = 0;

            switch (this.festigkeit)
            {
                case "5.8":
                    Rm = 500;
                    Re = 400;
                    break;
                case "6.8":
                    Rm = 600;
                    Re = 480;
                    break;
                case "8.8":
                    Rm = 800;
                    Re = 640;
                    break;
                case "9.8":
                    Rm = 900;
                    Re = 720;
                    break;
                case "10.9":
                    Rm = 1000;
                    Re = 900;
                    break;
                case "12.9":
                    Rm = 1200;
                    Re = 1080;
                    break;
                case "1":     //v4a 50er Festigkeitsklasse
                    Rm = 500;
                    Re = 210;
                    break;
                case "2":    //v2a 70er Festigkeitsklasse
                    Rm = 700;
                    Re = 450;
                    break;
                case "3":     //v4a 50er Festigkeitsklasse
                    Rm = 500;
                    Re = 210;
                    break;
            }
            Console.WriteLine(" Elastizitätsgrenze:   " + Re + " N/mm²");
            Console.WriteLine(" Zugfestigkeit:        " + Rm +  "N/mm²");
            Console.WriteLine();
        }// Berechnung der Festigkeit + Ausgabe
    }

    class ExcelControll
    {
        public int bestellnummer;
        // Konstuktor 

        public static void Excel_erstellen(Schraube[]arr)
        {
            new ExcelControll(arr);
        }

        ExcelControll(Schraube[]arr)
        {
            // Erstellen einer Neuen Exelmappe 
            int anzahl = 4;
            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = true;
            excelApp.Workbooks.Add();

            // Hinzufügen einer Seite? 
            Excel._Worksheet mySheet = (Excel.Worksheet)excelApp.ActiveSheet;



            // Kategorien festlegen

            mySheet.Cells[2, 1] = "Techniche Details";
            mySheet.Cells[3, 1] = "Schraubenlänge";
            mySheet.Cells[4, 1] = "Schlüsselweite";
            mySheet.Cells[5, 1] = "Gewindedurchmesser";
            mySheet.Cells[6, 1] = "Masse pro Stück";
            mySheet.Cells[7, 1] = "Gesamtgewicht";
            mySheet.Cells[8, 1] = "Steigung";
            mySheet.Cells[9, 1] = "Gewindetiefe";
            mySheet.Cells[10, 1] = "Rundung";
            mySheet.Cells[11, 1] = "Flankendurchmesser";
            mySheet.Cells[12, 1] = "Flankenwinkel";
            mySheet.Cells[13, 1] = "";
            mySheet.Cells[14, 1] = "Elastizitätzgrenze";
            mySheet.Cells[15, 1] = "Zugfestigkeit";
            mySheet.Cells[16, 1] = "";
            mySheet.Cells[17, 1] = "Preis (Netto)";
            mySheet.Cells[18, 1] = "Summe";
            mySheet.Cells[19, 1] = "Stückpreis";
            mySheet.Cells[20, 1] = "";
            mySheet.Cells[21, 1] = "Preis (Brutto)";
            mySheet.Cells[22, 1] = "Summe";
            mySheet.Cells[23, 1] = "Stückpreis";


            // Listenformat einführen 
            mySheet.Range["A1", "E25"].AutoFormat(Excel.XlRangeAutoFormat.xlRangeAutoFormatList2);

            // Werte der Schrauben in Tabelle eingeben 

            for (int i = 0; i < arr.Length; i++)
            {
                mySheet.Cells[2, i+2] = arr[i].name;
                mySheet.Cells[3, i+2] = arr[i].laenge;
                mySheet.Cells[4, i+2] = arr[i].schluesselbreite;
                mySheet.Cells[5, i+2] = arr[i].gewinde;
                mySheet.Cells[6, i+2] = arr[i].masse;
                mySheet.Cells[7, i+2] = arr[i].gesamtgewicht;
                mySheet.Cells[8, i+2] = arr[i].gewindesteigung;
                mySheet.Cells[9, i+2] = "Gewindetiefe";
                mySheet.Cells[10, i+2] = "Rundung S" + i;
                mySheet.Cells[11, i+2] = "Flankendurchmesser S" + i;
                mySheet.Cells[12, i+2] = "Flankenwinkel S" + i;
                mySheet.Cells[13, i+2] = "";
                mySheet.Cells[14, i+2] = "Elastizitätzgrenze S" + i;
                mySheet.Cells[15, i+2] = "Zugfestigkeit S" + i;
                mySheet.Cells[16, i+2] = "";
                mySheet.Cells[17, i+2] = "Preis (Netto) S" + i;
                mySheet.Cells[18, i+2] = "Summe S" + i;
                mySheet.Cells[19, i+2] = "Stückpreis S" + i;
                mySheet.Cells[20, i+2] = "";
                mySheet.Cells[21, i+2] = "Preis (Brutto) S" + i;
                mySheet.Cells[22, i+2] = "Summe S" + i;
                mySheet.Cells[23, i+2] = "Stückpreis S" + i;

                mySheet.Cells[25, i + 1].AddComment("Anmerkung S " + i);

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

                

            mySheet.SaveAs(@"C:\Windows\Temp\Bestellung " + Convert.ToString(bestellnummer)+".xlsx");


           //excelApp.Workbooks.Close();

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
            Mail.To.Add("jonathan.rietig@aol.de");

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